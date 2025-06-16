using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimizer
{
    public class CuttingHeadOptimizer
    {
        public static List<GlassPanel> Optimize(List<GlassPanel> panels)
        {
            var ordered = new List<GlassPanel>();
            var remaining = new List<GlassPanel>(panels);

            var current = remaining[0];
            ordered.Add(current);
            remaining.Remove(current);

            while (remaining.Any())
            {
                var nearest = remaining.OrderBy(p => Distance(current, p)).First();
                ordered.Add(nearest);
                remaining.Remove(nearest);
                current = nearest;
            }

            return ordered;
        }

        private static double Distance(GlassPanel a, GlassPanel b)
        {
            int dx = (a.X + a.Width / 2) - (b.X + b.Width / 2);
            int dy = (a.Y + a.Height / 2) - (b.Y + b.Height / 2);
            return Math.Sqrt(dx * dx + dy * dy);
        }
    }

}
