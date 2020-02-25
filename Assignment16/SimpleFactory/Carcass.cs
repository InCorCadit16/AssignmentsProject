using SimpleFactory;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleFactory
{
    public class Carcass
    {
        public CarcassType CarcassType { get; set; }

        public float Width { get; set; }
        public float Height { get; set; }
        public float Length { get; set; }

        internal void SetDimensions(float width, float length, float height) { Width = width; Length = length; Height = height; }
    }
}
