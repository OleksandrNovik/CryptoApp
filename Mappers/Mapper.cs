using TestTrainee.Models;
using TestTrainee.Models.RequestModels;

namespace TestTrainee.Mappers
{
    /// <summary>
    /// Mapper, which takes request model and maps values for a UI models
    /// </summary>
    public class Mapper
    {
        /// <summary>
        /// Method to return string interpretation of decimal from API
        /// </summary>
        /// <param name="value"> Some decimal value, that can be null </param>
        /// <returns>  If items is null returns "Unknown", otherwise value of this decimal as string </returns>
        private string NullOrValue(decimal? value) => value.HasValue ? value.Value.ToString("0.#####") : "Unknown";
        
        /// <summary>
        /// Turns request model into detailed model of current
        /// </summary>
        /// <param name="rm"> Request model </param>
        /// <returns> Mapped values of request model into UI model </returns>
        public CurrentDetailsModel DetailedModel(CurrencyRequestModel rm)
        {
            return new CurrentDetailsModel
            {
                Name = $"{rm.Name} ({rm.Symbol})",
                MaxSupply = NullOrValue(rm.MaxSupply),
                PriceUsd = NullOrValue(rm.PriceUsd),
                Supply = NullOrValue(rm.Supply),
                VolumeUsd24Hr = NullOrValue(rm.VolumeUsd24Hr),
            };
        }
        /// <summary>
        /// Turns request model into basic info model
        /// </summary>
        /// <param name="rm"> Request model </param>
        /// <returns> Basic info UI model </returns>
        public CurrentModel FromRequest(CurrencyRequestModel rm)
        {
            return new CurrentModel
            {
                Id = rm.Id,
                Name = $"{rm.Name} ({rm.Symbol})",
                Volume = rm.VolumeUsd24Hr ?? 0,
                PriceChange = rm.ChangePercent24Hr ?? 0
            };
        }

        /// <summary>
        /// Takes range request items and turns them all into basic info models 
        /// </summary>
        /// <param name="rmList"> List of request models </param>
        /// <returns> List of resulted UI models </returns>
        public List<CurrentModel> FromRequestRange(List<CurrencyRequestModel> rmList)
        {
            var list = new List<CurrentModel>();
            foreach (var rm in rmList)
            {
                list.Add(FromRequest(rm));
            }
            return list;
        }
    }
}
