using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimizer
{
    public class StockSheet
    {
        public int SourceNumber { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Quantity { get; set; }
        public int Cost { get; set; }
        public List<GlassPanel> PlacedPanels = new List<GlassPanel>();
        public List<GlassPanel> OptimizedPath = new List<GlassPanel>();
    }
}
