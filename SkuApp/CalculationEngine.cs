using SkuApp.Models;
using SkuApp.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkuApp
{
    public class CalculationEngine
    {
        private readonly ISkuRepository _skuRepository;
        public CalculationEngine(ISkuRepository skuRepository)
        {
            _skuRepository = skuRepository;
        }
        public decimal GetTotalPrice(IEnumerable<string> products)
        {
            Dictionary<string, int> dicProducts = new Dictionary<string, int>();
            foreach (string pr in products)
            {
                if (dicProducts.ContainsKey(pr))
                {
                    int count = dicProducts[pr];
                    dicProducts[pr] = ++count;
                }
                else
                {
                    dicProducts[pr] = 1;
                }
            }

            decimal total = 0.0M;
            foreach(KeyValuePair<string,int> keyValuePair in dicProducts)
            {
                switch(keyValuePair.Key)
                {
                    case "A":
                        {
                            SkuModel model = _skuRepository.GetById("A");
                            total += (dicProducts["A"] / 3) * 130 + (dicProducts["A"] % 3 * model.UnitPrice);
                        }
                        break;
                    case "B":
                        {
                            SkuModel model = _skuRepository.GetById("B");
                            total += (dicProducts["B"] / 2) * 45 + (dicProducts["B"] % 2 * model.UnitPrice);
                        }
                        break;
                    default:
                        {
                            SkuModel model = _skuRepository.GetById(keyValuePair.Key);
                            if (model != null)
                            {
                                total += (dicProducts[keyValuePair.Key] * model.UnitPrice);
                            }
                            
                        }
                        break;
                }
            }

            return total;
        }
    }
}
