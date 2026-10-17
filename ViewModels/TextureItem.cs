using mystical.Grafix.Data;
using System;

namespace comixpaint.ViewModels
{
    public class TextureItem
    {
        public string Name { get; }

        public Func<int, int, ArrayBitmap> Create { get; }

        public TextureItem(string name, Func<int, int, ArrayBitmap> create)
        {
            Name = name;
            Create = create;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
