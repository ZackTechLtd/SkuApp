using Newtonsoft.Json;
using SkuApp.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SkuApp.Repositories
{
    public class SkuRepository : ISkuRepository
    {
        private List<SkuModel> _skuModels = null;
        private List<SkuModel> LoadSkus(bool forceReload = false)
        {
            if (_skuModels == null || forceReload)
            {
                using (StreamReader r = new StreamReader("Content\\SkuPrices.txt"))
                {
                    string json = r.ReadToEnd();
                    _skuModels = JsonConvert.DeserializeObject<List<SkuModel>>(json);
                }
            }

            return _skuModels;
        }

        public IEnumerable<SkuModel> All()
        {
            return LoadSkus();
        }

        public SkuModel GetById(string id)
        {
            LoadSkus();
            return _skuModels.FirstOrDefault(x => x.Id == id);
        }
    }
}
