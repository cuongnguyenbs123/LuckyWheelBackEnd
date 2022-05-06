using LuckyWheel.Core.Entities;
using LuckyWheel.Core.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyWheel.Core.Services
{
    public class DBConfigServices:IDBConfig
    {
        private readonly IMongoCollection<Prize> _prizes;
        public DBConfigServices(IOptions<DBConfig> dbconfig)
        {
            var client = new MongoClient(dbconfig.Value.Connection_String);
            var database = client.GetDatabase(dbconfig.Value.Database_Name);
            _prizes = database.GetCollection<Prize>(dbconfig.Value.Prize_Collection_Name);
        }

        public IMongoCollection<Prize> GetPrizes() => _prizes;
    }
}
