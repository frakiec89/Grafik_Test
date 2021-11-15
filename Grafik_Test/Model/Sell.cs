using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafik_Test.Model
{

    public  class SellController
    {
        public List<Sell> Sells { get; set; } = new List<Sell>();
        public SellController()
        {
            Random random = new Random();
            

            for (int i = 0; i < 1000; i++)
            {
                Sells.Add(new Sell()
                {
                    Count = random.Next(1, 10),
                    DateSell = DateTime.Parse($"2021/{random.Next(1, 12)}/{random.Next(1,28)}") , Name ="Ivan" , NameProduct="test"+i
                });
            }
        }
    }



    public class Sell
    {
        public  string Name { get; set; }
        public DateTime DateSell { get; set; }

        public string NameProduct { get; set; }

        public int Count { get; set; }

    }
}
