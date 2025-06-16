using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Font = System.Drawing.Font;

namespace Optimizer
{
    public class Visualization
    {
        public static void DrawLayouts(List<StockSheet> sheets)
        {
            Directory.CreateDirectory("output_images");

            foreach (var sheet in sheets)
            {
                using (Bitmap bmp = new Bitmap(1000, 1000))
                using (Graphics g = Graphics.FromImage(bmp))
                using (Pen pen = new Pen(Color.Black, 2))
                using (Font font = new Font("Arial", 10))
                {
                    g.Clear(Color.White);

                    float scaleX = 1000f / sheet.Width;
                    float scaleY = 1000f / sheet.Height;

                    foreach (var panel in sheet.PlacedPanels)
                    {
                        // Defensive check (optional, avoids drawing if panel has invalid size)
                        if (panel.Width <= 0 || panel.Height <= 0) continue;

                        var rect = new Rectangle(
                            (int)(panel.X * scaleX),
                            (int)(panel.Y * scaleY),
                            (int)(panel.Width * scaleX),
                            (int)(panel.Height * scaleY)
                        );

                        g.FillRectangle(Brushes.LightBlue, rect);
                        g.DrawRectangle(pen, rect);

                        
                        PointF textLocation = new PointF(rect.Left + 2, rect.Top + 2);
                        g.DrawString($"ID {panel.Id}", font, Brushes.Black, textLocation);
                    }

                   

                    // Save image
                    string outputPath = Path.Combine("output_images", $"sheet_{sheet.SourceNumber}.png");
                    bmp.Save(outputPath, System.Drawing.Imaging.ImageFormat.Png);
                }
            }


        }

    }
}
