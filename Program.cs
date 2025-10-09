using System;

namespace VectorSystemApp
{
    // Базовий клас для системи з 2-х векторів
    class VectorSystem2
    {
        protected double[] A = new double[2];
        protected double[] B = new double[2];

        public virtual void SetVectors()
        {
            Console.WriteLine("Введіть координати вектора A (2 елементи):");
            A[0] = Convert.ToDouble(Console.ReadLine());
            A[1] = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введіть координати вектора B (2 елементи):");
            B[0] = Convert.ToDouble(Console.ReadLine());
            B[1] = Convert.ToDouble(Console.ReadLine());
        }

        public virtual void DisplayVectors()
        {
            Console.WriteLine($"A = ({A[0]}, {A[1]})");
            Console.WriteLine($"B = ({B[0]}, {B[1]})");
        }

        public virtual bool IsLinearlyIndependent()
        {
            // Визначник 2x2: |A B| = A1*B2 - A2*B1
            double determinant = A[0] * B[1] - A[1] * B[0];
            return determinant != 0;
        }
    }

    // Похідний клас для системи з 3-х векторів
    class VectorSystem3 : VectorSystem2
    {
        private double[] C = new double[3];

        public override void SetVectors()
        {
            A = new double[3];
            B = new double[3];

            Console.WriteLine("Введіть координати вектора A (3 елементи):");
            for (int i = 0; i < 3; i++) A[i] = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введіть координати вектора B (3 елементи):");
            for (int i = 0; i < 3; i++) B[i] = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введіть координати вектора C (3 елементи):");
            for (int i = 0; i < 3; i++) C[i] = Convert.ToDouble(Console.ReadLine());
        }

        public override void DisplayVectors()
        {
            Console.WriteLine($"A = ({A[0]}, {A[1]}, {A[2]})");
            Console.WriteLine($"B = ({B[0]}, {B[1]}, {B[2]})");
            Console.WriteLine($"C = ({C[0]}, {C[1]}, {C[2]})");
        }

        public override bool IsLinearlyIndependent()
        {
            // Визначник 3x3: |A B C|
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
            Console.WriteLine("=== Система 2-х векторів ===");
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
