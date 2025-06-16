using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimizer
{
    public class GlassPanelLoader
    {
        public static List<GlassPanel> Load()
        {
            return new List<GlassPanel>
            {
                new GlassPanel { Id = 1, Width = 1000, Height = 500 },
                new GlassPanel { Id = 2, Width = 800, Height = 800 },
                new GlassPanel { Id = 3, Width = 600, Height = 1200 },
                new GlassPanel { Id = 4, Width = 500, Height = 500 },
                new GlassPanel { Id = 5, Width = 1500, Height = 900 }
            };
        }
    }
}
