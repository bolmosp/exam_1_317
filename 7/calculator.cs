using System;
using System.Collections.Generic;

namespace CalculatorLib
{
    public class Calculator
    {
        public double notFixedEval(string expression)
        {
            Stack<double> values = new Stack<double>();
            Stack<char> operators = new Stack<char>();

            for (int i = 0; i < expression.Length; i++)
            {
                char c = expression[i];
                
                if (c == ' ')
                    continue;
                
                if (char.IsDigit(c))
                {
                    StringBuilder number = new StringBuilder();
                    while (i < expression.Length && (char.IsDigit(expression[i]) || expression[i] == '.'))
                    {
                        number.Append(expression[i++]);
                    }
                    values.Push(double.Parse(number.ToString()));
                    i--;
                }
                else if (c == '(')
                {
                    operators.Push(c);
                }
                else if (c == ')')
                {
                    while (operators.Peek() != '(')
                    {
                        values.Push(ApplyOperator(operators.Pop(), values.Pop(), values.Pop()));
                    }
                    operators.Pop();
                }
                else if (IsOperator(c))
                {
                    while (operators.Count > 0 && Precedence(c) <= Precedence(operators.Peek()))
                    {
                        values.Push(ApplyOperator(operators.Pop(), values.Pop(), values.Pop()));
                    }
                    operators.Push(c);
                }
            }
            
            while (operators.Count > 0)
            {
                values.Push(ApplyOperator(operators.Pop(), values.Pop(), values.Pop()));
            }
            
            return values.Pop();
        }
        
        public double PrefixEval(string expression)
        {
            Stack<double> values = new Stack<double>();

            for (int i = expression.Length - 1; i >= 0; i--)
            {
                char c = expression[i];
                
                if (c == ' ')
                    continue;
                
                if (char.IsDigit(c))
                {
                    StringBuilder number = new StringBuilder();
                    while (i >= 0 && (char.IsDigit(expression[i]) || expression[i] == '.'))
                    {
                        number.Insert(0, expression[i--]);
                    }
                    values.Push(double.Parse(number.ToString()));
                    i++;
                }
                else if (IsOperator(c))
                {
                    double operand1 = values.Pop();
                    double operand2 = values.Pop();
                    values.Push(ApplyOperator(c, operand1, operand2));
                }
            }
            
            return values.Pop();
        }
        
        private bool IsOperator(char c)
        {
            return c == '+' || c == '-' || c == '*' || c == '/';
        }
        
        private int Precedence(char operator1)
        {
            switch (operator1)
            {
                case '+':
                case '-':
                    return 1;
                case '*':
                case '/':
                    return 2;
                default:
                    return 0;
            }
        }
        
        private double ApplyOperator(char operator1, double b, double a)
        {
            switch (operator1)
            {
                case '+': return a + b;
                case '-': return a - b;
                case '*': return a * b;
                case '/': return a / b;
                default: throw new ArgumentException("Operador inválido");
            }
        }
    }
}
