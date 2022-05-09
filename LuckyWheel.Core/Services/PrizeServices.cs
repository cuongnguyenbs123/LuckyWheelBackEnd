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

        public Prize YourPrize()
        {
            List<Prize> SortedOriginLList = _prizes.Find(Prize => true)
                .SortBy(prize => prize.percent)
                .ToList();
            double result = GetRandomNumber(0, 100);
            double currentPercent = 0;
            int i = 0;
            while (true)
            {
                if (result < SortedOriginLList[i].percent + currentPercent)
                {
                  return SortedOriginLList[i];
                    break;
                }
                else
                {
                    currentPercent += SortedOriginLList[i].percent;
                    i++;
                }
            }
        }
        public double GetRandomNumber(double minimum, double maximum)
        {
            Random random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }
    }
}
