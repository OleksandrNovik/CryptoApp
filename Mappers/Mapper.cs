using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTrainee.Models;
using TestTrainee.Models.RequestModels;

namespace TestTrainee.Mappers
{
    public class Mapper
    {
        private string NullOrValue(decimal? value) => value.HasValue ? value.Value.ToString("0.#####") : "Unknown";
        public CurrentDetailsModel DetailedModel(CurrencyRequestModel rm)
        {
            return new CurrentDetailsModel
            {
                Name = $"{rm.Name} ({rm.Symbol})",
                ChangePercent24Hr = NullOrValue(rm.ChangePercent24Hr),
                MarketCapUsd = NullOrValue(rm.MarketCapUsd),
                MaxSupply = NullOrValue(rm.MaxSupply),
                PriceUsd = NullOrValue(rm.PriceUsd),
                Supply = NullOrValue(rm.Supply),
                VolumeUsd24Hr = NullOrValue(rm.VolumeUsd24Hr),
            };
        }
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
