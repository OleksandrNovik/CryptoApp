﻿using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Windows.Input;
using TestTrainee.Services;

namespace TestTrainee.ViewModels
{
    public abstract class BaseWindowViewModel
    {
        private readonly Window _window;
        private readonly string windowName;
        public RelayCommand<string> Navigate => new RelayCommand<string>(NavigateTo);
        public ICommand CloseCommand => new RelayCommand<object?>(execute => { _window.Close(); });
        public ICommand ResizeCommand => new RelayCommand<object?>(execute => { ResizeWindow(); });
        public ICommand MinimizeCommand => new RelayCommand<object?>(execute => { _window.WindowState = WindowState.Minimized; });
        public BaseWindowViewModel(Window currentWindow, string windowName) 
        { 
            _window = currentWindow;
            this.windowName = windowName;
        }
        private void ResizeWindow()
        {
            if (_window.WindowState == WindowState.Maximized)
                _window.WindowState = WindowState.Normal;
            else
                _window.WindowState = WindowState.Maximized;
        }
        private void NavigateTo(string window)
        {
            if (window == windowName)
                return;
            StaticData.Navigation[window].Show();
            _window.Close();
        }
    }
}
