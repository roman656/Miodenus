using System;
using Miodenus.Models.Math;

namespace Miodenus.Models
{
    public class MainController
    {
        public MainController()
        {
            VectorTests();
        }

        // Temporary solution.
        private static void VectorTests()
        {
            var vectorA = new Vector(5, 1, 0);
            
            Console.WriteLine("Текущий вектор: {0}", vectorA);
            Console.WriteLine("Длина: {0}", vectorA.Length);
            Console.WriteLine("Хеш-код: {0}", vectorA.GetHashCode());
            Console.WriteLine("Вектор в абсолютных значениях: {0}", Vector.Abs(vectorA));
            Console.WriteLine("Обратный вектор: {0}", Vector.Negate(vectorA));
            Console.WriteLine("Нормализованный вектор: {0}", Vector.Normalize(vectorA));
            Console.WriteLine("Вектор, умноженный на 2: {0}", Vector.Multiply(vectorA, 2));
            Console.WriteLine("Вектор, умноженный на 0.1: {0}", Vector.Multiply(vectorA, 0.1f));
            
            var vectorB = new Vector(-2, 1, 0);
            
            Console.WriteLine("Текущий вектор: {0}", vectorB);
            Console.WriteLine("Длина: {0}", vectorB.Length);
            Console.WriteLine("Хеш-код: {0}", vectorB.GetHashCode());
            Console.WriteLine("Вектор в абсолютных значениях: {0}", Vector.Abs(vectorB));
            Console.WriteLine("Обратный вектор: {0}", Vector.Negate(vectorB));
            Console.WriteLine("Нормализованный вектор: {0}", Vector.Normalize(vectorB));
            Console.WriteLine("Вектор, умноженный на 2: {0}", Vector.Multiply(vectorB, 2));
            Console.WriteLine("Вектор, умноженный на 0.1: {0}", Vector.Multiply(vectorB, 0.1f));
            
            Console.WriteLine("Операции над несколькими векторами:");
            Console.WriteLine("Object: {0} equals {1}: {2}", vectorA, vectorB, vectorA.Equals((object)vectorB));
            Console.WriteLine("{0} equals {1}: {2}", vectorA, vectorB, vectorA.Equals(vectorB));
            Console.WriteLine("{0} equals {1}: {2}", vectorA, vectorA, vectorA.Equals(vectorA));
            Console.WriteLine("{0} + {1}: {2}", vectorA, vectorB, Vector.Add(vectorA, vectorB));
            Console.WriteLine("{0} distance {1}: {2}", vectorA, vectorB, Vector.Distance(vectorA, vectorB));
            Console.WriteLine("{0} - {1}: {2}", vectorA, vectorB, Vector.Subtract(vectorA, vectorB));
            Console.WriteLine("{0} collinearity {1}: {2}", vectorA, vectorB, Vector.CheckCollinearity(vectorA, vectorB));
            
            var vectorC = new Vector(-2, 1, 0);
            
            Console.WriteLine("{0} coplanarity {1} and {2}: {3}", vectorA, vectorB, vectorC, Vector.CheckCoplanarity(vectorA, vectorB, vectorC));
            Console.WriteLine("{0} cross {1}: {2}", vectorA, vectorB, Vector.CrossProduct(vectorA, vectorB));
            Console.WriteLine("{0} dot {1}: {2}", vectorA, vectorB, Vector.DotProduct(vectorA, vectorB));
            Console.WriteLine("{0} triple {1} and {2}: {3}", vectorA, vectorB, vectorC, Vector.TripleProduct(vectorA, vectorB, vectorC));
            
            Console.WriteLine("{0} + {1}: {2}", vectorA, vectorB, vectorA + vectorB);
            Console.WriteLine("{0} - {1}: {2}", vectorA, vectorB, vectorA - vectorB);
            Console.WriteLine("-{0}: {1}", vectorA, -vectorA);
            Console.WriteLine("{0} * 20: {1}", vectorA, vectorA * 20);
            Console.WriteLine("0 * {0}: {1}", vectorA, 0 * vectorA);
            Console.WriteLine("0.5 * {0}: {1}", vectorA, 0.5f * vectorA);
            Console.WriteLine("0 * {0} + {1}: {2}", vectorA, new Vector(1, 1, 1), 0 * vectorA + new Vector(1, 1, 1));
        }
    }
}