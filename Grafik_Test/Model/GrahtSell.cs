using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafik_Test.Model
{
    class GrahtSell
    {
      public static List<GrahtSellModel> SellModels ()
      {
            var sel = new Model.SellController();
            List<GrahtSellModel>  grahtSell = new ();
            var gr = from g in sel.Sells
                     group g by g.DateSell into sum
                     select new GrahtSellModel() { Date = sum.Key.Date, Count = sum.Sum(x => x.Count) };
            return gr.ToList().OrderBy(x=>x.Date).ToList();
      }
    }

    public class GrahtSellModel
    {
        public  DateTime Date { get; set; }
        public int Count { get; set; }
    }
}
