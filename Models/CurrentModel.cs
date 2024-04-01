namespace TestTrainee.Models
{
    /// <summary>
    /// Basic information about current to show it as item of list
    /// </summary>
    public class CurrentModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Volume { get; set; }
        public decimal PriceChange { get; set; }
    }
}
