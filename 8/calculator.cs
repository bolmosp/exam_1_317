using System;
using System.Collections.Generic;

namespace CalculatorWebService.Models
{
    public class Calculator
    {
        public double EvaluarInfija(string expresion)
        {
            Stack<double> valores = new Stack<double>();
            Stack<char> operadores = new Stack<char>();

            for (int i = 0; i < expresion.Length; i++)
            {
                char c = expresion[i];

                if (c == ' ') continue;

                if (char.IsDigit(c))
                {
                    StringBuilder numero = new StringBuilder();
                    while (i < expresion.Length && (char.IsDigit(expresion[i]) || expresion[i] == '.'))
                    {
                        numero.Append(expresion[i++]);
                    }
                    valores.Push(double.Parse(numero.ToString()));
                    i--;
                }
                else if (c == '(')
                {
                    operadores.Push(c);
                }
                else if (c == ')')
                {
                    while (operadores.Peek() != '(')
                    {
                        valores.Push(AplicarOperador(operadores.Pop(), valores.Pop(), valores.Pop()));
                    }
                    operadores.Pop();
                }
                else if (EsOperador(c))
                {
                    while (operadores.Count > 0 && Precedencia(c) <= Precedencia(operadores.Peek()))
                    {
                        valores.Push(AplicarOperador(operadores.Pop(), valores.Pop(), valores.Pop()));
                    }
                    operadores.Push(c);
                }
            }

            while (operadores.Count > 0)
            {
                valores.Push(AplicarOperador(operadores.Pop(), valores.Pop(), valores.Pop()));
            }

            return valores.Pop();
        }

        public double EvaluarPrefija(string expresion)
        {
            Stack<double> valores = new Stack<double>();

            for (int i = expresion.Length - 1; i >= 0; i--)
            {
                char c = expresion[i];

                if (c == ' ') continue;

                if (char.IsDigit(c))
                {
                    StringBuilder numero = new StringBuilder();
                    while (i >= 0 && (char.IsDigit(expresion[i]) || expresion[i] == '.'))
                    {
                        numero.Insert(0, expresion[i--]);
                    }
                    valores.Push(double.Parse(numero.ToString()));
                    i++;
                }
                else if (EsOperador(c))
                {
                    double operando1 = valores.Pop();
                    double operando2 = valores.Pop();
                    valores.Push(AplicarOperador(c, operando1, operando2));
                }
            }

            return valores.Pop();
        }

        private bool EsOperador(char c)
        {
            return c == '+' || c == '-' || c == '*' || c == '/';
        }

        private int Precedencia(char operador)
        {
            return (operador == '+' || operador == '-') ? 1 : 2;
        }

        private double AplicarOperador(char operador, double b, double a)
        {
            return operador switch
            {
                '+' => a + b,
                '-' => a - b,
                '*' => a * b,
                '/' => a / b,
                _ => throw new ArgumentException("Operador inválido"),
            };
        }
    }
}
