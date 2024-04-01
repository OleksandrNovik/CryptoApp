namespace TestTrainee.Models
{
    /// <summary>
    /// Information about market 
    /// (planed to be used in Market Window or to show some charts for market) 
    /// </summary>
    public class MarketModel
    {
        public string ExchangeId { get; set; }
        public string BaseId { get; set; }
        public string QuoteId { get; set; }
        public decimal PriceUsd { get; set; }
    }
}