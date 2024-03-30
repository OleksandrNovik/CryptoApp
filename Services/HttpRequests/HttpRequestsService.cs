using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using TestTrainee.Mappers;
using TestTrainee.Models;
using TestTrainee.Models.RequestModels;
using TestTrainee.Services.HttpRequests;

namespace TestTrainee.Services
{
    public class HttpRequestsService : IHttpRequestService
    {
        private readonly HttpClient client;
        private readonly Mapper mapper;

        public HttpRequestsService()
        {
            client = new HttpClient();
            mapper = new Mapper();
            client.BaseAddress = new Uri("https://api.coincap.io/v2/");
        }
        /// <summary>

        /// <summary>
        /// Searches for a current by some query
        /// </summary>
        /// <param name="searchQuery"> Query request to get some currents </param>
        /// <param name="number"> Number of currents </param>
        /// <returns> List of found items </returns>
        public async Task<List<CurrentModel>> SearchCurrent(string searchQuery, int count)
        {
            StringBuilder query = new StringBuilder("assets?");

            bool isEmpty = string.IsNullOrEmpty(searchQuery),
                isIncorrect = count < 1;

            // Два параметра не є заданими одночасно
            if (isEmpty && isIncorrect)
                query.Append("limit=10");
            // Один з параметрів задано
            else if (isEmpty || isIncorrect)
            {
                string queryPart = isEmpty ? $"limit={count}" : $"search={searchQuery}";
                query.Append(queryPart);
            } 
            // Усі параметри задані
            else 
                query.Append($"limit={count}&search={searchQuery}");

            return await GetCurrents(query.ToString());
        }
        /// <summary>
        /// Gets current info by some query
        /// </summary>
        /// <param name="query"> Query to get items </param>
        /// <returns> List of current items with all info needed </returns>
        private async Task<List<CurrentModel>> GetCurrents(string query)
        {
            var responce = await client.GetAsync(query);

            if (!responce.IsSuccessStatusCode)
                throw new Exception("GET request was not successfull!");

            var data = JsonConvert.DeserializeObject<CurrencyResponse>(await responce.Content.ReadAsStringAsync());

            return GetModels(data);
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
