namespace Optimizer
{
    public class Program
    {
        static void Main(string[] args)
        {
            var stockSheets = StockSheetLoader.Load();
            var panelsToCut = GlassPanelLoader.Load();

            var optimizer = new LayoutOptimizer();
            var layouts = new List<(GlassPanel, int, int, int, int)>();

            foreach (var sheet in stockSheets)
            {
                for (int i = 0; i < sheet.Quantity; i++)
                {
                    var layoutsForSheet = optimizer.Layout(sheet.Width, sheet.Height, 0, 0, panelsToCut);
                    if (layoutsForSheet.Count > 0)
                    {
                        sheet.PlacedPanels.AddRange(layoutsForSheet.Select(x => x.panel));
                        layouts.AddRange(layoutsForSheet);
                    }
                }
            }

            Console.WriteLine("Optimization completed. Result:");
            foreach (var layout in layouts)
            {
                Console.WriteLine($"Panel {layout.Item1.Id}: ({layout.Item2}, {layout.Item3}) WxH: {layout.Item4}x{layout.Item5}");
            }

            Visualization.DrawLayouts(stockSheets);
        }
    }
}
