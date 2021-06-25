using System.Globalization;

namespace Miodenus.Models.Math
{
    public class Angle : IMiodenusObject
    {
        public enum Type { Radians, Degrees }

        public const float PiInDegrees = 180.0f;
        public float Radians;

        public float Degrees
        {
            get
            {
                return ConvertRadiansToDegrees(Radians);
            }

            set
            {
                Radians = ConvertDegreesToRadians(value);
            }
        }
        
        public Angle(float value = 0.0f, Type angleType = Type.Radians)
        {
            Radians = (angleType == Type.Degrees) ? ConvertDegreesToRadians(value) : value;
        }
        
        public static Angle operator *(Angle angle, float scalar) => Multiply(angle, scalar);

        public static Angle operator *(float scalar, Angle angle) => Multiply(angle, scalar);
        
        public static Angle operator +(Angle angleA, Angle angleB) => Add(angleA, angleB);

        public static Angle operator -(Angle angleA, Angle angleB) => Subtract(angleA, angleB);
        
        public static float ConvertDegreesToRadians(float degrees) => (float)(degrees * System.Math.PI / PiInDegrees);

        public static float ConvertRadiansToDegrees(float radians) => (float)(radians * PiInDegrees / System.Math.PI);

        /* 
         * Нормализует (ограничивает) угол (градусы) в указанном диапазоне: [0 ; 360).
         * Если значение выходит за диапазон, угол пересчитывается так,
         * чтобы "визуально" он остался прежним, но его значение укладывалось бы в заданный диапазон.
         */
        public static float ConstrainAngle360Degrees(float degrees)
        {
            degrees = degrees % (2.0f * PiInDegrees);

            if (degrees < 0.0f)
            {
                degrees += 2.0f * PiInDegrees;
            }

            return degrees;
        }

        /* Нормализует (ограничивает) угол (градусы) в указанном диапазоне: [0 ; 180]. */
        public static float ConstrainAngle180Degrees(float degrees)
        {
            if (degrees < 0.0f || degrees > PiInDegrees)
            {
                degrees = degrees % PiInDegrees;

                if (degrees <= 0.0f)
                {
                    degrees += PiInDegrees;
                }
            }

            return degrees;
        }
        
        public static Angle Multiply(in Angle angle, float scalar)
        {
            return new Angle(angle.Radians * scalar);
        }

        public static Angle Add(in Angle angleA, in Angle angleB)
        {
            return new Angle(angleA.Radians + angleB.Radians);
        }
        
        public static Angle Subtract(in Angle angleA, in Angle angleB)
        {
            return new Angle(angleA.Radians - angleB.Radians);
        }
        
        public override bool Equals(object? obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            Angle temp = (Angle)obj;
            return temp.Radians.Equals(this.Radians);
        }

        public bool Equals(Angle? obj)
        {
            if (obj == null)
            {
                return false;
            }

            return obj.Radians.Equals(this.Radians);
        }

        public override int GetHashCode() => Radians.GetHashCode();

        public override string ToString() => string.Format(CultureInfo.InvariantCulture, "Angle: {0} rad", Radians);

        public object Clone() => new Angle(Radians);
    }
}