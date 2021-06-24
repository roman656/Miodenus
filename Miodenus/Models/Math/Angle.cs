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
        
        public override string ToString() => string.Format(CultureInfo.InvariantCulture, "Angle: {0} rad", Radians);

        public object Clone() => new Angle(Radians);
    }
}