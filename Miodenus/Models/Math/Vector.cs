using System;

namespace Miodenus.Models.Math
{
    public class Vector : IMiodenusObject
    {
        public float X = 0.0f;
        public float Y = 0.0f;
        public float Z = 0.0f;
        
        public Vector() {}

        public Vector(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }
        
        public Vector(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public double Length
        {
            get
            {
                return System.Math.Sqrt(X * X + Y * Y + Z * Z);
            }
        }
        
        public override bool Equals(object? obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            Vector temp = (Vector)obj;
            return (temp.X.Equals(this.X) && temp.Y.Equals(this.Y) && temp.Z.Equals(this.Z));
        }

        public bool Equals(Vector? obj)
        {
            if (obj == null)
            {
                return false;
            }
            
            return (obj.X.Equals(this.X) && obj.Y.Equals(this.Y) && obj.Z.Equals(this.Z));
        }
        
        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, Z);
        }
        
        public override string ToString()
        {
            return ($"Vector: ({X}, {Y}, {Z})");
        }

        public object Clone()
        {
            return new Vector(X, Y, Z);
        }
    }
}