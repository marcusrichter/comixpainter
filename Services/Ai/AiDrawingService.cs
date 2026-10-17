using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using mystical.Grafix.Data;
using mystical.Grafix.ShaderShapes;

namespace comixpaint.Services.Ai
{
    /// <summary>
    /// Erzeugt aus einer Textbeschreibung ein ShaderShapeImage über die DeepSeek-API.
    /// </summary>
    public class AiDrawingService
    {
        private const string DEEPSEEK_API_KEY = "";
        private const string DEEPSEEK_ENDPOINT = "https://api.deepseek.com/chat/completions";
        private const string DEEPSEEK_MODEL = "deepseek-chat";

        private static readonly HttpClient HttpClient = new HttpClient();

        public async Task<ShaderShapeImage> CreateImageAsync(string prompt, int width = 200, int height = 200, ShaderShapeImage? template = null)
        {
            if (string.IsNullOrWhiteSpace(prompt))
            {
                throw new ArgumentException("Es wurde keine Beschreibung angegeben.", nameof(prompt));
            }

            var templateJson = template == null ? null : BuildTemplateJson(template);
            var shapeJson = await RequestShapeJsonAsync(prompt, width, height, templateJson);
            return BuildImage(shapeJson, width, height);
        }

        private async Task<string> RequestShapeJsonAsync(string prompt, int width, int height, string? templateJson)
        {
            var userContent = templateJson == null
                ? $"Zeichne: {prompt}"
                : $"Zeichne: {prompt}\n\nDas aktuelle Bild hat folgende Formen (JSON). Erstelle ein ähnliches Bild anhand dieser Vorlage:\n{templateJson}";

            var requestBody = new
            {
                model = DEEPSEEK_MODEL,
                messages = new object[]
                {
                    new { role = "system", content = BuildSystemPrompt() },
                    new { role = "user", content = userContent }
                },
                response_format = new { type = "json_object" },
                max_tokens = 8192,
                temperature = 0.4
            };

            using var request = new HttpRequestMessage(HttpMethod.Post, DEEPSEEK_ENDPOINT);
            request.Headers.Add("Authorization", $"Bearer {DEEPSEEK_API_KEY}");
            request.Content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

            using var response = await HttpClient.SendAsync(request);
            var responseText = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidOperationException($"DeepSeek-API-Fehler ({response.StatusCode}): {responseText}");
            }

            using var document = JsonDocument.Parse(responseText);
            var root = document.RootElement;

            if (!root.TryGetProperty("choices", out var choices) || choices.GetArrayLength() == 0)
            {
                throw new InvalidOperationException("DeepSeek-API hat keine Antwort geliefert.");
            }

            var message = choices[0];
            var content = message.TryGetProperty("message", out var messageElement) &&
                          messageElement.TryGetProperty("content", out var contentElement)
                ? contentElement.GetString()
                : null;

            if (string.IsNullOrWhiteSpace(content))
            {
                throw new InvalidOperationException("DeepSeek-API hat keinen Inhalt geliefert.");
            }

            return content;
        }

        private ShaderShapeImage BuildImage(string shapeJson, int fallbackWidth, int fallbackHeight)
        {
            using var document = ParseShapeJson(shapeJson);
            var root = document.RootElement;

            var width = ReadInt(root, "width", fallbackWidth);
            var height = ReadInt(root, "height", fallbackHeight);
            if (width <= 0) width = fallbackWidth;
            if (height <= 0) height = fallbackHeight;

            var image = new ShaderShapeImage(width, height);

            if (root.TryGetProperty("shapes", out var shapes) && shapes.ValueKind == JsonValueKind.Array)
            {
                foreach (var shapeElement in shapes.EnumerateArray())
                {
                    AddShape(image, shapeElement);
                }
            }

            image.Paint(true);
            return image;
        }

        private void AddShape(ShaderShapeImage image, JsonElement element)
        {
            var type = ReadString(element, "type", "rect")?.ToLowerInvariant() ?? "rect";
            var paintcolor = ParseFillColor(element, Color.Blue);
            var bordercolor = ParseColor(element, "stroke", Color.Black);
            var linewidth = ReadInt(element, "linewidth", 2);
            var shadedir = ParseShadeDir(element, "shadedir");
            var shadesteps = ReadInt(element, "shadesteps", 3);

            var shapetype = type switch
            {
                "oval" => ShaderShape.SHAPETYPE_OVAL,
                "polygon" or "free" => ShaderShape.SHAPETYPE_FREE,
                "freepix" or "line" => ShaderShape.SHAPETYPE_FREEPIX,
                _ => ShaderShape.SHAPETYPE_RECT
            };

            var shape = image.CreateShape(shapetype, linewidth, shadedir, shadesteps, paintcolor, bordercolor);

            if (shapetype == ShaderShape.SHAPETYPE_OVAL)
            {
                var x = ReadInt(element, "x", 0);
                var y = ReadInt(element, "y", 0);
                var shapeWidth = Math.Max(1, ReadInt(element, "width", 20));
                var shapeHeight = Math.Max(1, ReadInt(element, "height", 20));

                // Die Oval-Form erwartet Mittelpunkt und Halbachsen-Punkt.
                shape.AddOrUpdatePoint(x + shapeWidth / 2, y + shapeHeight / 2, 2);
                shape.AddOrUpdatePoint(x + shapeWidth, y + shapeHeight, 2);
            }
            else if (shapetype == ShaderShape.SHAPETYPE_RECT)
            {
                var x = ReadInt(element, "x", 0);
                var y = ReadInt(element, "y", 0);
                var shapeWidth = Math.Max(1, ReadInt(element, "width", 20));
                var shapeHeight = Math.Max(1, ReadInt(element, "height", 20));

                shape.AddOrUpdatePoint(x, y, 2);
                shape.AddOrUpdatePoint(x + shapeWidth, y + shapeHeight, 2);
            }
            else
            {
                var points = ReadPoints(element);

                if (shapetype == ShaderShape.SHAPETYPE_FREEPIX)
                {
                    if (points.Count >= 2)
                    {
                        foreach (var point in points)
                        {
                            shape.AddPoint(point.X, point.Y);
                        }

                        if (points.Count >= 3)
                        {
                            shape.AddPoint(points[0].X, points[0].Y);
                        }
                    }
                    else
                    {
                        shape.Shapetype = ShaderShape.SHAPETYPE_RECT;
                        var x = image.Width / 4;
                        var y = image.Height / 4;
                        var shapeWidth = Math.Max(20, image.Width / 2);
                        var shapeHeight = Math.Max(20, image.Height / 2);

                        shape.AddOrUpdatePoint(x, y, 2);
                        shape.AddOrUpdatePoint(x + shapeWidth, y + shapeHeight, 2);
                    }
                }
                else if (points.Count >= 3)
                {
                    foreach (var point in points)
                    {
                        shape.AddPoint(point.X, point.Y);
                    }

                    shape.AddPoint(points[0].X, points[0].Y);
                }
                else
                {
                    shape.Shapetype = ShaderShape.SHAPETYPE_RECT;
                    var x = points.Count == 2 ? Math.Min(points[0].X, points[1].X) : image.Width / 4;
                    var y = points.Count == 2 ? Math.Min(points[0].Y, points[1].Y) : image.Height / 4;
                    var shapeWidth = points.Count == 2 ? Math.Abs(points[0].X - points[1].X) : image.Width / 2;
                    var shapeHeight = points.Count == 2 ? Math.Abs(points[0].Y - points[1].Y) : image.Height / 2;

                    if (shapeWidth == 0) shapeWidth = 20;
                    if (shapeHeight == 0) shapeHeight = 20;

                    shape.AddOrUpdatePoint(x, y, 2);
                    shape.AddOrUpdatePoint(x + shapeWidth, y + shapeHeight, 2);
                }
            }
        }

        private List<Point> ReadPoints(JsonElement element)
        {
            var points = new List<Point>();

            if (!element.TryGetProperty("points", out var pointsElement) || pointsElement.ValueKind != JsonValueKind.Array)
            {
                return points;
            }

            foreach (var pointElement in pointsElement.EnumerateArray())
            {
                if (pointElement.ValueKind != JsonValueKind.Array || pointElement.GetArrayLength() < 2)
                {
                    continue;
                }

                if (pointElement[0].TryGetInt32(out var x) && pointElement[1].TryGetInt32(out var y))
                {
                    points.Add(new Point(x, y));
                }
            }

            return points;
        }

        private static int ParseShadeDir(JsonElement element, string name)
        {
            var dir = ReadString(element, name, "center")?.ToLowerInvariant() ?? "center";

            return dir switch
            {
                "top" => ShaderShape.SHADEDIR_TOP,
                "topright" or "top-right" => ShaderShape.SHADEDIR_TOPRIGHT,
                "right" => ShaderShape.SHADEDIR_RIGHT,
                "bottomright" or "bottom-right" => ShaderShape.SHADEDIR_BOTTOMRIGHT,
                "bottom" => ShaderShape.SHADEDIR_BOTTOM,
                "bottomleft" or "bottom-left" => ShaderShape.SHADEDIR_BOTTOMLEFT,
                "left" => ShaderShape.SHADEDIR_LEFT,
                "topleft" or "top-left" => ShaderShape.SHADEDIR_TOPLEFT,
                _ => ShaderShape.SHADEDIR_CENTER
            };
        }

        private static Color ParseFillColor(JsonElement element, Color fallback)
        {
            var names = new[] { "fill", "fillcolor", "fillColor", "paintcolor", "paintColor" };

            foreach (var name in names)
            {
                if (element.TryGetProperty(name, out var property) && property.ValueKind == JsonValueKind.String)
                {
                    var colorString = property.GetString();
                    if (string.IsNullOrWhiteSpace(colorString))
                    {
                        continue;
                    }

                    try
                    {
                        return ColorFX.ParseColor(colorString);
                    }
                    catch
                    {
                        // Fallback bei ungültiger Farbangabe.
                    }
                }
            }

            return fallback;
        }

        private static Color ParseColor(JsonElement element, string name, Color fallback)
        {
            if (element.TryGetProperty(name, out var property) && property.ValueKind == JsonValueKind.String)
            {
                var colorString = property.GetString();
                if (!string.IsNullOrWhiteSpace(colorString))
                {
                    try
                    {
                        return ColorFX.ParseColor(colorString);
                    }
                    catch
                    {
                        // Fallback bei ungültiger Farbangabe.
                    }
                }
            }

            return fallback;
        }

        private static int ReadInt(JsonElement element, string name, int fallback)
        {
            if (element.TryGetProperty(name, out var property) &&
                property.ValueKind == JsonValueKind.Number &&
                property.TryGetInt32(out var value))
            {
                return value;
            }

            return fallback;
        }

        private static string? ReadString(JsonElement element, string name, string? fallback)
        {
            if (element.TryGetProperty(name, out var property) && property.ValueKind == JsonValueKind.String)
            {
                return property.GetString();
            }

            return fallback;
        }

        private static string ExtractJsonObject(string content)
        {
            var trimmed = content.Trim();

            if (trimmed.StartsWith("```"))
            {
                var firstNewline = trimmed.IndexOf('\n');
                if (firstNewline >= 0)
                {
                    trimmed = trimmed.Substring(firstNewline + 1);
                }

                var closingFence = trimmed.LastIndexOf("```", StringComparison.Ordinal);
                if (closingFence >= 0)
                {
                    trimmed = trimmed.Substring(0, closingFence);
                }
            }

            var start = trimmed.IndexOf('{');
            var end = trimmed.LastIndexOf('}');
            if (start >= 0 && end > start)
            {
                return trimmed.Substring(start, end - start + 1);
            }

            return trimmed;
        }

        private static JsonDocument ParseShapeJson(string shapeJson)
        {
            shapeJson = ExtractJsonObject(shapeJson);

            try
            {
                return JsonDocument.Parse(shapeJson);
            }
            catch (JsonException)
            {
                var repairedJson = RepairTruncatedJson(shapeJson);
                if (repairedJson != null)
                {
                    try
                    {
                        return JsonDocument.Parse(repairedJson);
                    }
                    catch (JsonException)
                    {
                        // Reparaturversuch war nicht erfolgreich.
                    }
                }

                throw new InvalidOperationException("Die KI-Antwort enthielt kein vollständiges JSON. Bitte versuchen Sie es erneut oder beschreiben Sie das Motiv kürzer.");
            }
        }

        private static string? RepairTruncatedJson(string json)
        {
            var openBrackets = new List<char>();
            var inString = false;
            var escaped = false;

            foreach (var character in json)
            {
                if (inString)
                {
                    if (escaped)
                    {
                        escaped = false;
                    }
                    else if (character == '\\')
                    {
                        escaped = true;
                    }
                    else if (character == '"')
                    {
                        inString = false;
                    }

                    continue;
                }

                if (character == '"')
                {
                    inString = true;
                }
                else if (character == '{' || character == '[')
                {
                    openBrackets.Add(character);
                }
                else if (character == '}' || character == ']')
                {
                    if (openBrackets.Count > 0 && IsMatchingBracket(openBrackets[openBrackets.Count - 1], character))
                    {
                        openBrackets.RemoveAt(openBrackets.Count - 1);
                    }
                }
            }

            if (inString || openBrackets.Count == 0)
            {
                return null;
            }

            var closing = new StringBuilder();
            for (var i = openBrackets.Count - 1; i >= 0; i--)
            {
                closing.Append(openBrackets[i] == '{' ? '}' : ']');
            }

            return json + closing;
        }

        private static bool IsMatchingBracket(char open, char close)
        {
            return (open == '{' && close == '}') || (open == '[' && close == ']');
        }

        private string BuildTemplateJson(ShaderShapeImage image)
        {
            var shapeObjects = new List<object>();

            foreach (var shape in image.Shapes ?? new List<ShaderShape>())
            {
                shapeObjects.Add(BuildShapeTemplateJson(shape));
            }

            return JsonSerializer.Serialize(new
            {
                width = image.Width,
                height = image.Height,
                shapes = shapeObjects
            });
        }

        private object BuildShapeTemplateJson(ShaderShape shape)
        {
            var fill = ToHex(shape.Paintcolor);
            var stroke = ToHex(shape.Bordercolor);

            if (shape.Shapetype == ShaderShape.SHAPETYPE_OVAL || shape.Shapetype == ShaderShape.SHAPETYPE_RECT)
            {
                return new
                {
                    type = shape.Shapetype == ShaderShape.SHAPETYPE_OVAL ? "oval" : "rect",
                    x = shape.TranslateX,
                    y = shape.TranslateY,
                    width = shape.Width,
                    height = shape.Height,
                    fill,
                    stroke,
                    linewidth = shape.Linewidth,
                    shadedir = ShadeDirToString(shape.Shadedir),
                    shadesteps = shape.Shadesteps
                };
            }

            var points = new List<int[]>();
            var sourcePoints = shape.Points ?? new List<ShaderShapePoint>();
            for (var i = 0; i < sourcePoints.Count; i++)
            {
                if (i == sourcePoints.Count - 1 && sourcePoints.Count > 1)
                {
                    var first = sourcePoints[0].Point;
                    var last = sourcePoints[i].Point;
                    if (first != null && last != null && first.X == last.X && first.Y == last.Y)
                    {
                        break;
                    }
                }

                var point = sourcePoints[i].Point;
                if (point != null)
                {
                    points.Add(new[] { point.X + shape.TranslateX, point.Y + shape.TranslateY });
                }
            }

            return new
            {
                type = shape.Shapetype == ShaderShape.SHAPETYPE_FREEPIX ? "freepix" : "polygon",
                points,
                fill,
                stroke,
                linewidth = shape.Linewidth,
                shadedir = ShadeDirToString(shape.Shadedir),
                shadesteps = shape.Shadesteps
            };
        }

        private static string ToHex(Color color)
        {
            return $"#{color.R:X2}{color.G:X2}{color.B:X2}";
        }

        private static string ShadeDirToString(int shadedir)
        {
            return shadedir switch
            {
                ShaderShape.SHADEDIR_TOP => "top",
                ShaderShape.SHADEDIR_TOPRIGHT => "topright",
                ShaderShape.SHADEDIR_RIGHT => "right",
                ShaderShape.SHADEDIR_BOTTOMRIGHT => "bottomright",
                ShaderShape.SHADEDIR_BOTTOM => "bottom",
                ShaderShape.SHADEDIR_BOTTOMLEFT => "bottomleft",
                ShaderShape.SHADEDIR_LEFT => "left",
                ShaderShape.SHADEDIR_TOPLEFT => "topleft",
                _ => "center"
            };
        }

        private static string BuildSystemPrompt()
        {
            return "Du bist ein Zeichenassistent für eine Comic-Zeichen-App. "
                   + "Erzeuge ausschließlich gültiges JSON ohne Markdown. "
                   + "Das JSON-Objekt hat die Felder width, height und shapes. "
                   + "Jede Form hat type (\"rect\", \"oval\", \"polygon\" oder \"freepix\"), x, y, width, height "
                   + "(bei polygon und freepix stattdessen points als [[x,y],...]), fill und stroke als Hex-Farben (#RRGGBB), "
                   + "linewidth (0-5), shadedir (top|topright|right|bottomright|bottom|bottomleft|left|topleft|center) "
                   + "und shadesteps (1-5). Bestimme für jede Form eine eigene, passende fill-Farbe. "
                   + "polygon ist eine gefüllte geschlossene Punktlinie, freepix eine ungefüllte geschlossene Punktlinie. "
                   + "Verwende maximal 12 Formen, für polygon und freepix höchstens 24 Punkte. "
                   + "Antworte kompakt und erzeuge einfache, klar erkennbare Comic-Formen.";
        }
    }
}
