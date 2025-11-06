using System;

namespace VectorSystemApp
{
    // Базовий клас для системи з 2-х векторів
    class VectorSystem2
    {
        protected double[] A;
        protected double[] B;

        // ✅ Конструктор ініціалізує масиви довжиною 2
        public VectorSystem2()
        {
            A = new double[2];
            B = new double[2];
        }

        // ✅ Читання з перевіркою через TryParse
        public virtual void SetVectors()
        {
            Console.WriteLine("Введіть координати вектора A (2 елементи):");
            for (int i = 0; i < 2; i++)
                A[i] = ReadDouble($"A[{i}] = ");

            Console.WriteLine("Введіть координати вектора B (2 елементи):");
            for (int i = 0; i < 2; i++)
                B[i] = ReadDouble($"B[{i}] = ");
        }

        protected double ReadDouble(string prompt)
        {
            double value;
            Console.Write(prompt);
            while (!double.TryParse(Console.ReadLine(), out value))
                Console.Write("Некоректне число, повторіть: ");
            return value;
        }

        public virtual void DisplayVectors()
        {
            Console.WriteLine($"A = ({A[0]}, {A[1]})");
            Console.WriteLine($"B = ({B[0]}, {B[1]})");
        }

        public virtual bool IsLinearlyIndependent()
        {
            double determinant = A[0] * B[1] - A[1] * B[0];
            return determinant != 0;
        }
    }

    // Похідний клас для системи з 3-х векторів
    class VectorSystem3 : VectorSystem2
    {
        private double[] C;

        // ✅ Конструктор ініціалізує масиви довжиною 3 
        public VectorSystem3()
        {
            A = new double[3];
            B = new double[3]; //abcdacd
            C = new double[3];
        }

        public override void SetVectors()
        {
            Console.WriteLine("Введіть координати вектора A (3 елементи):"); //asdasddaadsad
            for (int i = 0; i < 3; i++)
                A[i] = ReadDouble($"A[{i}] = ");

            Console.WriteLine("Введіть координати вектора B (3 елементи):");
            for (int i = 0; i < 3; i++)
                B[i] = ReadDouble($"B[{i}] = ");

            Console.WriteLine("Введіть координати вектора C (3 елементи):");
            for (int i = 0; i < 3; i++)
                C[i] = ReadDouble($"C[{i}] = ");
        }

        public override void DisplayVectors()
        {
            Console.WriteLine($"A = ({A[0]}, {A[1]}, {A[2]})");
            Console.WriteLine($"B = ({B[0]}, {B[1]}, {B[2]})");
            Console.WriteLine($"C = ({C[0]}, {C[1]}, {C[2]})");
        }

        public override bool IsLinearlyIndependent()
        {
            double determinant =
                A[0] * (B[1] * C[2] - B[2] * C[1]) -
                A[1] * (B[0] * C[2] - B[2] * C[0]) +
                A[2] * (B[0] * C[1] - B[1] * C[0]);

            return determinant != 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Система 2-х vectors ===");
            VectorSystem2 system2 = new VectorSystem2();
            system2.SetVectors();
            system2.DisplayVectors();
            Console.WriteLine(system2.IsLinearlyIndependent()
                ? "Вектори лінійно незалежні."
                : "Вектори лінійно залежні.");

            Console.WriteLine("\n=== Система 3-х векторів ===");
            VectorSystem3 system3 = new VectorSystem3();
            system3.SetVectors();
            system3.DisplayVectors();
            Console.WriteLine(system3.IsLinearlyIndependent()
                ? "Вектори лінійно незалежні."
                : "Вектори лінійно залежні.");

            Console.WriteLine("\nНатисніть будь-яку клавішу для завершення...");
            Console.ReadKey();
        }
    }
}
