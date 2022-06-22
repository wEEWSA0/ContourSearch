using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContourSearch
{
    internal class RGB
    {
        private int _red, _green, _blue;

        public int Red { get { return _red; } }
        public int Green { get { return _green; } }
        public int Blue { get { return _blue; } }

        public RGB() { _red = 0; _green = 0; _blue = 0; }
        public RGB(int red, int green, int blue) { _red = red; _green = green; _blue = blue; }

        public void BytesToRGB(int bytes)
        {
            _red = (bytes >> 16) & 0xff;
            _green = (bytes >> 8) & 0xff;
            _blue = (bytes & 0xff);
        }

        public override string ToString()
        {
            return $"({_red}, {_green}, {_blue})";
        }

        public bool IsRoughlyEqual(RGB rgb, int uncertainty)
        {
            if (Red + uncertainty > rgb.Red && Red - uncertainty < rgb.Red)
            {
                if (Green + uncertainty > rgb.Green && Green - uncertainty < rgb.Green)
                {
                    if (Blue + uncertainty > rgb.Blue && Blue - uncertainty < rgb.Blue)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
