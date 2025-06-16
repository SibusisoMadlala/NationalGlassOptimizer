using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimizer
{
    public class LayoutOptimizer
    {
        private const int MARGIN = 20;

        public List<(GlassPanel panel, int x, int y, int width, int height)> Layout(int stockW, int stockH, int x, int y, List<GlassPanel> parts)
        {
            if (!parts.Any(p => !p.Placed))
                return new List<(GlassPanel, int, int, int, int)>();

            var validPlacements = new List<(GlassPanel part, int wasteArea, int shortSideLeft)>();

            foreach (var part in parts.Where(p => !p.Placed))
            {
                if (part.Width + MARGIN <= stockW && part.Height + MARGIN <= stockH)
                {
                    int waste = (stockW * stockH) - (part.Width * part.Height);
                    int shortSide = Math.Min(stockW - part.Width, stockH - part.Height);
                    validPlacements.Add((part, waste, shortSide));
                }
            }

            if (!validPlacements.Any()) return new List<(GlassPanel, int, int, int, int)>();

            var bestPiece = validPlacements.OrderBy(v => v.wasteArea).ThenBy(v => v.shortSideLeft).First().part;
            bestPiece.X = x;
            bestPiece.Y = y;
            bestPiece.Placed = true;

            var layout = (bestPiece, x, y, bestPiece.Width, bestPiece.Height);

            int rightX = x + bestPiece.Width + MARGIN;
            int rightW = stockW - bestPiece.Width - MARGIN;

            int bottomY = y + bestPiece.Height + MARGIN;
            int bottomH = stockH - bestPiece.Height - MARGIN;

            var rightLayout = Layout(rightW, bestPiece.Height, rightX, y, parts);
            var bottomLayout = Layout(stockW, bottomH, x, bottomY, parts);

            return new List<(GlassPanel, int, int, int, int)> { layout }
                .Concat(rightLayout)
                .Concat(bottomLayout)
                .ToList();
        }
    }
}
