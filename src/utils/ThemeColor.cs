using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom8_QLTV.src.utils
{
    internal class ThemeColor
    {
        public static Color PrimaryColor { get; set; }

        public static Color SecondaryColor { get; set; }
        
        public static List <string> ColorList = new List <string> ()
        {
            "#46C2CB",
            "#453C67",
            "#F16767",
            "#A459D1",
            "#03C988",
            "#B3005E",
            "#EA5455",
            "#4E6E81",
            "#4AA96C",
            "#D47AE8",
            "#31C6D4",
            "#FF5151",
            "#867070",
            "#B46060",
            "#4D4D4D",
        };

        public static Color ChangeColorBrightness(Color color, double correctionFactor)
        {
            double red = color.R;
            double green = color.G;
            double blue = color.B;

            if (correctionFactor < 0)
            {
                correctionFactor = 1 + correctionFactor;
                red *= correctionFactor;
                green *= correctionFactor;
                blue *= correctionFactor;
            }
            else
            {
                red = (255 - red) * correctionFactor + red;
                green = (255 - green) * correctionFactor + green;
                blue = (255 - blue) * correctionFactor + blue;
            }

            return Color.FromArgb(color.A, (byte)red, (byte)green, (byte)blue);
        }
    }
}
