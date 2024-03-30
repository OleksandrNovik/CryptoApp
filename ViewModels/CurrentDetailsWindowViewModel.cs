using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Windows.Input;
using TestTrainee.Models;
using TestTrainee.Services;
using TestTrainee.Services.HttpRequests;

namespace TestTrainee.ViewModels
{
    public class CurrentDetailsWindowViewModel : BaseWindowViewModel
    {
        /// <summary>
        /// Service to execute http requests
        /// </summary>
        private readonly IHttpRequestService http;

        public RelayCommand<string> FetchDataCommand => new RelayCommand<string>(async (id) =>
        {
            Model = await http.GetDetails(id);
        });

        private CurrentDetailsModel model;
        public CurrentDetailsModel Model
        {
            get => model;
            set {
                model = value;
                OnPropertyChanged();
            }
        }
        public CurrentDetailsWindowViewModel(
            Window currentWindow, 
            string windowName,
            string id
            ) : base(currentWindow, windowName)
        {
            http = new HttpRequestsService();
            FetchDataCommand.Execute(id);
        }
    }
}
