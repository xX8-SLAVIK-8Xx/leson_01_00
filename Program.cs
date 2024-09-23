using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace leson_01_00
{
    internal class Program
    {
        public class Ccalculator
        {
            static public double Add(double one_namber, double two_namber)
            {
                return one_namber + two_namber;
            }
            static public double Minus(double one_namber, double two_namber)
            {
                return one_namber - two_namber;
            }
            static public double Multiply(double one_namber, double two_namber)
            {
                return one_namber * two_namber;
            }
            static public double Divide (double one_namber, double two_namber)
            {                
                if (two_namber == 0) 
                { 
                    throw new DivideByZeroException("Деление на ноль невозможно.");
                }
                return (one_namber / two_namber);
                                 
            }   
        }
        static public void ShowCcalculator(double namber_one, double number_two,char operator_ )
        {

            switch ((Operator)operator_)
            {
                case Operator.Plus:
                    Console.WriteLine($"{namber_one}+{number_two}={Ccalculator.Add(namber_one, number_two)}");
                    break;
                case Operator.Мinus:
                    Console.WriteLine($"{namber_one}-{number_two}={Ccalculator.Minus(namber_one, number_two)}");
                    break;
                case Operator.Multiply:
                    Console.WriteLine($"{namber_one}*{number_two}={Ccalculator.Multiply(namber_one, number_two)}");
                    break;
                case Operator.Divide:
                    if (number_two == 0) { Console.WriteLine("На ноль не делится "); }
                    else { Console.WriteLine($"{namber_one}/{number_two}={Ccalculator.Divide(namber_one, number_two)}"); }
                    break;
                default:
                    Console.WriteLine($"Ошибка не известный оперант :'{(char)operator_}'");
                    break;
            }
        }
        static public(double,double, char) RequestForData()
        {
            double namber_one =0, number_two=0;
            char operator_=' ';
            while (true)
            {
                Console.Clear();
                try
                {
                    Console.Write("Калькулятор\n" +
                                  "Укажете первое число:");
                    namber_one = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Укажете второе число:");
                    number_two = Convert.ToInt32(Console.ReadLine());
                   
                }
                catch (Exception)
                {
                    Console.WriteLine("Ошибка !: Укажите число");
                    Console.ReadKey();
                    continue;
                }
                try
                {
                    Console.WriteLine("Выберете действие :+ - * /");

                    operator_ = Convert.ToChar(Console.ReadLine());
                    return (namber_one, number_two, operator_);

                }
                catch (Exception)
                {
                    Console.WriteLine("Ошибка !: Укажите:+ - * / ");                    
                    Console.ReadKey();
                    continue;

                }
            }
           
        }
        enum Operator
        {
            Plus     = '+',
            Мinus    = '-',
            Multiply = '*',
            Divide   = '/'
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                //не знаю зачем я так всё усложнил,но всё же :) 
                var value = RequestForData();
                var number_one = value.Item1;
                var number_two = value.Item2;
                var operator_ = value.Item3;
                ShowCcalculator(number_one, number_two, operator_);
                Console.ReadKey();
            }
        }
    }

    
}




