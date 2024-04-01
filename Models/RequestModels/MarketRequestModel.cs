namespace TestTrainee.Models.RequestModels
{
    /// <summary>
    /// Model to get list of markets, on which we can buy some current
    /// </summary>
    public class MarketRequestModel
    {
        public List<MarketModel> Data { get; set; }
    }
}
