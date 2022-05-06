using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuckyWheel.Core.Entities;
using MongoDB.Driver;

namespace LuckyWheel.Core.Interfaces
{
    public interface IDBConfig
    {
        IMongoCollection<Prize> GetPrizes();
    }
}
