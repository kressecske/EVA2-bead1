using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth.Model
{
    public class Field
    {
        Coordinate coords;
        private FieldType type;
        private Boolean visible;

        public Field(int x, int y, FieldType type)
        {
            this.coords = new Coordinate(x, y);
            this.type = type;
            visible = false;
        }
        public Field(Field f)
        {
            new Field(f.Coords.X, f.Coords.Y, f.Type);
        }

        public Boolean Visible
        {
            get { return visible; }
            set { visible = value; }
        }

        public Coordinate Coords
        {
            get { return coords; }
        }

        public int X
        {
            get { return coords.X; }
        }

        public int Y
        {
            get { return coords.Y; }
        }
        public FieldType Type
        {
            get { return type; }
        }

        public override string ToString()
        {
            return "Field: " + type.ToString() + " on X: " + X.ToString() + ", " + Y.ToString() + ". ";
        }
    }
}
