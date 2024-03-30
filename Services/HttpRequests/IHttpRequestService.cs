using TestTrainee.Models;

namespace TestTrainee.Services.HttpRequests
{
    public interface IHttpRequestService
    {
        public Task<List<CurrentModel>> SearchCurrent(string searchQuery, int count);
        public Task<CurrentDetailsModel> GetDetails(string id);
    }
}
