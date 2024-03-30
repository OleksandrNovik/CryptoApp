﻿using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using TestTrainee.Models;
using TestTrainee.Services;
using TestTrainee.Services.HttpRequests;
using TestTrainee.Views;

namespace TestTrainee.ViewModels
{
    public class MainWindowViewModel : BaseWindowViewModel
    {
        /// <summary>
        /// Service to execute http requests
        /// </summary>
        private readonly IHttpRequestService http;

        /// <summary>
        /// Contsructor of ViewModel
        /// </summary>
        /// <param name="currentWindow"> To manipulate the window we need to pass it as parameter </param>
        /// <param name="windowName"> This is current window's name for navigation </param>
        public MainWindowViewModel(Window currentWindow, string windowName)
            : base(currentWindow, windowName)
        {
            http = new HttpRequestsService();
            SearchCommad.Execute(null);
        }

        /// <summary>
        /// Command to execute search
        /// </summary>
        public ICommand SearchCommad => new RelayCommand(async () =>
        {
            await GetCurrents();
        });

        /// <summary>
        /// Command to access Id of current, when user clicks More Info button this command runs
        /// </summary>
        public RelayCommand<string> MoreInfoCommand => new RelayCommand<string>(ShowInfo);

        /// <summary>
        /// Full prop for currents list
        /// </summary>
        private ObservableCollection<CurrentModel> currents = new ObservableCollection<CurrentModel>();
        public ObservableCollection<CurrentModel> CurrentList
        {
            get => currents;
            set
            {
                currents = value;
                OnPropertyChanged();
            }
        }
        private string searchQuery = "";
        public string SearchQuery
        {
            get => searchQuery;
            set
            {
                searchQuery = value;
            }
        }
        private string numberInputValue = "";
        public string NumberInputValue
        {
            get => numberInputValue;
            set
            {
                numberInputValue = value;
            }
        }
        private async Task GetCurrents()
        {
            List<CurrentModel> currentList;
            int.TryParse(NumberInputValue, out int number);
            currentList = await http.SearchCurrent(SearchQuery, number);
            CurrentList = new ObservableCollection<CurrentModel>(currentList);
        }
        private void ShowInfo(string currentId)
        {
            var currentWindow = new CurrentDetailsWindow(currentId);
            currentWindow.Show();
            _window.Close();
        }
    }
}

