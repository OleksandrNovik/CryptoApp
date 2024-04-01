using TestTrainee.Models;

namespace TestTrainee.Services.HttpRequests
{
    /// <summary>
    /// Interface, which describes all needed methods for service to implement
    /// </summary>
    public interface IHttpRequestService
    {
        /// <summary>
        /// Look for N first currents by some query
        /// </summary>
        /// <param name="searchQuery"> Query that is a template for names of currents </param>
        /// <param name="count"> Number of current items to provide </param>
        /// <returns> List of basic info current models </returns>
        public Task<List<CurrentModel>> SearchCurrent(string searchQuery, int count);

        /// <summary>
        /// Get detailed information about current
        /// </summary>
        /// <param name="id"> Id of current </param>
        /// <returns> Detailed information about current </returns>
        public Task<CurrentDetailsModel> GetDetails(string id);
    }
}
