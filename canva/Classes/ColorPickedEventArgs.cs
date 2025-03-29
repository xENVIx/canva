using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace canva.Classes
{
    public class ColorPickedEventArgs : EventArgs
    {
        public Color PickedColor { get; }
        public Point ImageCoordinates { get; }

        public ColorPickedEventArgs(Color color, Point coords)
        {
            PickedColor = color;
            ImageCoordinates = coords;
        }
    }
}
