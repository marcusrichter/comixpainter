using comixpaint.Services.Drawing;
using comixpaint.Services.State;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;

namespace comixpaint.ViewModels
{
    public partial class ToolsViewModel : ViewModelBase
    {
        private readonly ToolsService _toolsService;
        private readonly StateService _state;

        [ObservableProperty]
        private int _selectedTool;

        public ToolsViewModel(ToolsService toolsService, StateService state)
        {
            _toolsService = toolsService;
            _state = state;

            SelectedTool = _state.SelectedTool;
        }

        [RelayCommand]
        private void DrawOval() => SelectTool(_toolsService.DrawOvalClick);

        [RelayCommand]
        private void DrawRect() => SelectTool(_toolsService.DrawRectClick);

        [RelayCommand]
        private void DrawFree() => SelectTool(_toolsService.DrawFreeClick);

        [RelayCommand]
        private void DrawLines() => SelectTool(_toolsService.DrawLinesClick);

        [RelayCommand]
        private void DrawFreeLines() => SelectTool(_toolsService.DrawFreeLinesClick);

        [RelayCommand]
        private void Move() => SelectTool(_toolsService.MoveClick);

        [RelayCommand]
        private void Delete() => SelectTool(_toolsService.DeleteClick);

        [RelayCommand]
        private void MoveInFront() => SelectTool(_toolsService.MoveInFrontClick);

        [RelayCommand]
        private void MoveInBack() => SelectTool(_toolsService.MoveInBackClick);

        [RelayCommand]
        private void Copy() => SelectTool(_toolsService.CopyClick);

        [RelayCommand]
        private void Recolor() => SelectTool(_toolsService.RecolorClick);

        [RelayCommand]
        private void SelectShape() => SelectTool(_toolsService.SelectShape);

        [RelayCommand]
        private void PickColor() => SelectTool(_toolsService.PickColor);

        private void SelectTool(Action action)
        {
            action();
            SelectedTool = _state.SelectedTool;
        }
    }
}

