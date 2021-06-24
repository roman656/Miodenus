using System;
using System.Globalization;

namespace Miodenus.Models.Math
{
    public class Vector : IMiodenusObject
    {
        public float X;
        public float Y;
        public float Z;
        
        public float Length => (float)System.Math.Sqrt(X * X + Y * Y + Z * Z);

        public Vector(float x = 0.0f, float y = 0.0f, float z = 0.0f)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
        
        public static Vector operator *(Vector vectorA, float scalar) => Multiply(vectorA, scalar);

        public static Vector operator *(float scalar, Vector vectorA) => Multiply(vectorA, scalar);

        public static Vector operator +(Vector vectorA, Vector vectorB) => Add(vectorA, vectorB);

        public static Vector operator -(Vector vectorA, Vector vectorB) => Subtract(vectorA, vectorB);

        public static Vector operator -(Vector vector) => Negate(vector);

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
        
        /* Скалярное произведение. */
        public static float DotProduct(in Vector vectorA, in Vector vectorB)
        {
            return (vectorA.X * vectorB.X + vectorA.Y * vectorB.Y + vectorA.Z * vectorB.Z);
        }
        
        /* Векторное произведение. */
        public static Vector CrossProduct(in Vector vectorA, in Vector vectorB)
        {
            return new Vector(vectorA.Y * vectorB.Z - vectorA.Z * vectorB.Y,
                              vectorA.Z * vectorB.X - vectorA.X * vectorB.Z,
                              vectorA.X * vectorB.Y - vectorA.Y * vectorB.X);
        }
        
        /* Смешанное произведение. */
        public static float TripleProduct(in Vector vectorA, in Vector vectorB, in Vector vectorC)
        {
            return (vectorA.X * vectorB.Y * vectorC.Z
                    + vectorA.Y * vectorB.Z * vectorC.X
                    + vectorA.Z * vectorB.X * vectorC.Y
                    - vectorA.Z * vectorB.Y * vectorC.X
                    - vectorA.X * vectorB.Z * vectorC.Y
                    - vectorA.Y * vectorB.X * vectorC.Z);
        }

        public static Vector Negate(in Vector vector) => new Vector(-vector.X, -vector.Y, -vector.Z);

        public static Vector Multiply(in Vector vector, float scalar)
        {
            return new Vector(vector.X * scalar, vector.Y * scalar, vector.Z * scalar);
        }

        public static Vector Add(in Vector vectorA, in Vector vectorB)
        {
            return new Vector(vectorA.X + vectorB.X, vectorA.Y + vectorB.Y, vectorA.Z + vectorB.Z);
        }
        
        public static Vector Subtract(in Vector vectorA, in Vector vectorB)
        {
            return new Vector(vectorA.X - vectorB.X, vectorA.Y - vectorB.Y, vectorA.Z - vectorB.Z);
        }
        
        /*
         * Проверка компланарности 3х векторов.
         * 3 вектора называются компланарными, если они, будучи приведенными к общему началу, лежат в одной плоскости.
         * Смешанное произведение компланарных векторов равно 0.
         * Возвращает: true - вектора компланарны; false - в противном случае.
         */
        public static bool CheckCoplanarity(in Vector vectorA, in Vector vectorB, in Vector vectorC)
        {
            return (TripleProduct(vectorA, vectorB, vectorC) == 0.0f);
        }
        
        /*
         * Проверка коллинеарности векторов.
         * Два вектора коллинеарны, если их векторное произведение равно нулевому вектору.
         * Возвращает: true - вектора коллинеарны; false - в противном случае.
         */
        public static bool CheckCollinearity(in Vector vectorA, in Vector vectorB)
        {
            return CrossProduct(vectorA, vectorB).Equals(new Vector());
        }

        public static Vector Abs(in Vector vector)
        {
            return new Vector(System.Math.Abs(vector.X), System.Math.Abs(vector.Y), System.Math.Abs(vector.Z));
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

        public override int GetHashCode() => HashCode.Combine(X, Y, Z);

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "Vector: ({0}, {1}, {2})", X, Y, Z);
        }

        public object Clone() => new Vector(X, Y, Z);
    }
}