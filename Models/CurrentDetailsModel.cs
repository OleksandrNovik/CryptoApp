namespace TestTrainee.Models
{
    /// <summary>
    /// Detailed information about current, which is used in UI
    /// </summary>
    public class CurrentDetailsModel
    {
        public string Name { get; set; }
        public string Supply { get; set; }
        public string MaxSupply { get; set; }
        public string VolumeUsd24Hr { get; set; }
        public string PriceUsd { get; set; }
        public string Markets { get; set; }
    }
}
