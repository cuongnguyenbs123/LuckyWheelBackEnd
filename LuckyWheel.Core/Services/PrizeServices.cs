using LuckyWheel.Core.Entities;
using LuckyWheel.Core.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyWheel.Core.Services
{
    public class PrizeServices : IPrizeServices
    {
        private readonly IMongoCollection<Prize> _prizes;
        public PrizeServices(IDBConfig dbconfig)
        {
            _prizes = dbconfig.GetPrizes();
        }
        public List<Prize> GetPrizes() => _prizes.Find(prize => true).ToList();
    }
}
