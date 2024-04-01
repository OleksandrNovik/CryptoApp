namespace TestTrainee.Models.RequestModels
{
    /// <summary>
    /// Model that is returned by API when we get some number of current items
    /// </summary>
    public class CurrencyResponse
    {
        public List<CurrencyRequestModel> Data { get; set; }
    }

    /// <summary>
    /// Model that is reutrned by API when we get extended information about some current
    /// </summary>
    public class OneCurrencyResponce 
    { 
        public CurrencyRequestModel Data { get; set; }
    }
    /// <summary>
    /// Request model that holds all props API provides for a current
    /// </summary>
    public class CurrencyRequestModel
    {
        public string Id { get; set; }
        public string? Rank { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public decimal? Supply { get; set; }
        public decimal? MaxSupply { get; set; }
        public decimal? MarketCapUsd { get; set; }
        public decimal? VolumeUsd24Hr { get; set; }
        public decimal? PriceUsd { get; set; }
        public decimal? ChangePercent24Hr { get; set; }
        public decimal? Vwap24Hr { get; set; }
    }
}
