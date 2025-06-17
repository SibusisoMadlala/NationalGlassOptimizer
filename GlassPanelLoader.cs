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
                new GlassPanel { Id = 1, Width = 700, Height = 484 },
                new GlassPanel { Id = 2, Width = 501, Height = 249 },
                new GlassPanel { Id = 3, Width = 1132, Height = 675 },
                new GlassPanel { Id = 4, Width = 485, Height = 433 },
                new GlassPanel { Id = 5, Width = 522, Height = 466 },
                      
                new GlassPanel { Id = 7, Width = 1726, Height = 926},
                new GlassPanel { Id = 6, Width = 700, Height = 484 },
                new GlassPanel { Id = 8, Width = 501, Height = 249 },
                new GlassPanel { Id = 9, Width = 1132, Height = 675 },
                
                
                new GlassPanel { Id = 10, Width = 1726, Height = 926},
                new GlassPanel { Id = 11, Width = 700, Height = 484 },
                new GlassPanel { Id = 12, Width = 501, Height = 249 },
                new GlassPanel { Id = 13, Width = 1132, Height = 675 }
            };
        }
    }
}
