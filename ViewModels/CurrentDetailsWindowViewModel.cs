using GalaSoft.MvvmLight.Command;
using System.Windows;
using TestTrainee.Models;
using TestTrainee.Services;
using TestTrainee.Services.HttpRequests;

namespace TestTrainee.ViewModels
{
    /// <summary>
    /// View model for a current details window
    /// </summary>
    public class CurrentDetailsWindowViewModel : BaseWindowViewModel
    {
        /// <summary>
        /// Service to execute http requests
        /// </summary>
        private readonly IHttpRequestService http;

        /// <summary>
        /// Get extended info about current
        /// </summary>
        public RelayCommand<string> FetchDataCommand => new RelayCommand<string>(async (id) =>
        {
            Model = await http.GetDetails(id);
        });

        /// <summary>
        /// Field to hold data about current
        /// </summary>
        private CurrentDetailsModel model = new CurrentDetailsModel 
        {
            Supply = "Loading...",
            Markets = "Loading...",
            MaxSupply = "Loading...",
            Name = "Loading...",
            PriceUsd = "Loading...",
            VolumeUsd24Hr = "Loading..."
        };

        /// <summary>
        /// Property to bind all fields for model <see cref="model"/>
        /// </summary>
        public CurrentDetailsModel Model
        {
            get => model;
            set {
                model = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Constructor of view model
        /// </summary>
        /// <param name="currentWindow"> Curernt window for all basic operations </param>
        /// <param name="windowName"> Window name for navigation </param>
        /// <param name="id"> Id of current that is shown </param>
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
