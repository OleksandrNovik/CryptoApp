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
