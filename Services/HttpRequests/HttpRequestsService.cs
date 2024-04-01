using Newtonsoft.Json;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Windows;
using TestTrainee.Mappers;
using TestTrainee.Models;
using TestTrainee.Models.RequestModels;
using TestTrainee.Services.HttpRequests;

namespace TestTrainee.Services
{
    /// <summary>
    /// Service to make http requests of current
    /// </summary>
    public class HttpRequestsService : IHttpRequestService
    {
        /// <summary>
        /// Http client to execute requests
        /// </summary>
        private readonly HttpClient client;

        /// <summary>
        /// Mapper for mapping result of get requests to models
        /// </summary>
        private readonly Mapper mapper;

        /// <summary>
        /// Constructor of service, which initialize needed fields
        /// and sets up base address
        /// </summary>
        public HttpRequestsService()
        {
            client = new HttpClient();
            mapper = new Mapper();
            client.BaseAddress = new Uri("https://api.coincap.io/v2/");
        }

        /// <summary>
        /// Get detailed information for a current
        /// </summary>
        /// <param name="id"> Id of current </param>
        /// <returns> Current detailed model </returns>
        /// <exception cref="ArgumentNullException"> If data is not provided from API endpoint </exception>
        public async Task<CurrentDetailsModel> GetDetails(string id)
        {
            var data = await GetResource<OneCurrencyResponce>($"assets/{id}");
            if (data == null) 
                throw new ArgumentNullException($"Null responce data is occured at {nameof(GetDetails)}");
            var model = mapper.DetailedModel(data.Data);

            var marketData = await GetResource<MarketRequestModel>($"assets/{id}/markets?limit=4");
            if (marketData == null)
                throw new ArgumentNullException($"Null responce data is occured at {nameof(GetDetails)}");

            var markets = new StringBuilder(string.Join(", ", marketData.Data.Take(3)
                .Select(m => $"{m.ExchangeId} (Price: {m.PriceUsd:0.000})")));
            
            if (marketData.Data.Count > 3)
                markets.Append("...");

            model.Markets = markets.ToString();
            return model;
        }

        /// <summary>
        /// Searches for a current by some query
        /// </summary>
        /// <param name="searchQuery"> Query request to get some currents </param>
        /// <param name="count"> Number of currents </param>
        /// <returns> List of found items </returns>
        public async Task<List<CurrentModel>> SearchCurrent(string searchQuery, int count)
        {
            StringBuilder query = new StringBuilder("assets?");

            bool isEmpty = string.IsNullOrEmpty(searchQuery),
                isIncorrect = count < 1;

            // Number of current items and search query are not provided
            if (isEmpty && isIncorrect)
                query.Append("limit=10");
            // One of parameters is provided
            else if (isEmpty || isIncorrect)
            {
                string queryPart = isEmpty ? $"limit={count}" : $"search={searchQuery}";
                query.Append(queryPart);
            } 
            // All parameters are provided
            else 
                query.Append($"limit={count}&search={searchQuery}");

            return GetModels(await GetResource<CurrencyResponse>(query.ToString()));
        
        }

        /// <summary>
        /// Gets current info by some query
        /// </summary>
        /// <typeparam name="T"> Type of model we need to return </typeparam>
        /// <param name="query"> Query to get items  </param>
        /// <returns> List of current items with all info needed </returns>
        /// <exception cref="Exception"> Throws exception if request was not successfull </exception>
        private async Task<T?> GetResource<T>(string query)
        {
            var responce = await client.GetAsync(query);

            if (!responce.IsSuccessStatusCode)
                throw new Exception("GET request was not successfull!");

            var data = JsonConvert.DeserializeObject<T>(await responce.Content.ReadAsStringAsync());

            return data;
        }
        /// <summary>
        /// Coverts response to a list of models
        /// </summary>
        /// <param name="response"> Response with its data </param>
        /// <returns> List of models </returns>
        private List<CurrentModel> GetModels(CurrencyResponse? response)
        {
            if (response == null)
                return new List<CurrentModel>();

            return mapper.FromRequestRange(response.Data);
        }
    }
}