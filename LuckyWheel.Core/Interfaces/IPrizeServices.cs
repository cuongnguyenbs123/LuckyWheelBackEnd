using LuckyWheel.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyWheel.Core.Interfaces
{
    public interface IPrizeServices
    {
        List<Prize> GetPrizes();
        Prize YourPrize();
    }
}
