using SkuApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkuApp.Repositories
{
    public interface ISkuRepository
    {
        IEnumerable<SkuModel> All();
        SkuModel GetById(string id);
    }
}
