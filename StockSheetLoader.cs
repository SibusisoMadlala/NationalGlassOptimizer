using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimizer
{
    public class StockSheetLoader
    {
        public static List<StockSheet> Load()
        {
            return new List<StockSheet>
            {
                new StockSheet { SourceNumber = 1, Width = 3210, Height = 2440, Quantity = 1, Cost = 7890 }
            };
        }
    }
}
