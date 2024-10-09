using System;
using CalculatorLib;

namespace CalculatorProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();

            Console.WriteLine("Seleccionar tipo de expression:");
            Console.WriteLine("1. Infija (ej: (1 + 2) * 3)");
            Console.WriteLine("2. Prefija (ej: + * 3 2 1)");
            Console.Write("option: ");
            string option = Console.ReadLine();

            if (option == "1")
            {
                Console.Write("Ingrese la expresion infija: ");
                string expression = Console.ReadLine();
                double result = calc.EvaluarInfija(expression);
                Console.WriteLine($"resultado: {result}");
            }
            else if (option == "2")
            {
                Console.Write("Ingrese la expresion prefija: ");
                string expression = Console.ReadLine();
                double result = calc.EvaluarPrefija(expression);
                Console.WriteLine($"resultado: {result}");
            }
            else
            {
                Console.WriteLine("Opcion no existe.");
            }
        }
    }
}
