using System;

namespace ClassLibrary1
{
    public static class Input
    {
        public static int IntInput()          //Метод для ввода целого числа
        {
            try
            {
                return int.Parse(Console.ReadLine());
            }
            catch
            {
                return 0;
            }
        }
        public static double DoubleInput()    //Метод для ввода дробного числа
        {
            try
            {
                return double.Parse(Console.ReadLine());
            }
            catch
            {
                return 0;
            }
        }
    }
}
