using System;

namespace Miodenus.Models.Math
{
    public class Vector : IMiodenusObject
    {
        public float X = 0.0f;
        public float Y = 0.0f;
        public float Z = 0.0f;
        
        public float Length => (float)System.Math.Sqrt(X * X + Y * Y + Z * Z);
        
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

        public static Vector Normalize(in Vector vector)
        {
            float length = vector.Length;
            return new Vector(vector.X / length, vector.Y / length, vector.Z / length);
        }

        public static float Distance(in Vector vectorA, in Vector vectorB)
        {
            return (float)System.Math.Sqrt(System.Math.Pow(vectorB.X - vectorA.X, 2) 
                                           + System.Math.Pow(vectorB.Y - vectorA.Y, 2)
                                           + System.Math.Pow(vectorB.Z - vectorA.Z, 2));
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