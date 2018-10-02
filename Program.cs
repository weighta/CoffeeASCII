using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CoffeeManASCII
{
    class Skeleton
    {

    }
    class Coffee
    {
        Random ran = new Random();
        public void buildCoffee()
        {
            while (true)
            {
                float percent = 0;
                float steam = 0;
                float interval = ran.Next(3, 10) / 10f;
                int rows = ran.Next(10, 30);
                int columns = ran.Next(5, 30);
                while (percent <= 100)
                {
                Console.Clear();
                string coffee = "";
                for (int i = 0; i < Math.Round(rows / 2f); i++) //Steam
                {
                    for (int j = 0; j < (int)((Math.Sin(steam) * ((columns / 2f) - 1)) + (columns / 2f) + 1); j++)
                    {
                        Console.Write(" ");
                    }
                    steam += (float)(Math.PI / 4f);
                    Console.WriteLine("█");
                }
                for (int i = 0; i < rows; i++)
                {
                    
                    coffee += Environment.NewLine;
                    coffee += "▓-";
                    for (int j = 0; j < columns; j++)
                    {
                        int ratio = (int)((((float)i + 1f) / rows) * 100f);
                        if ((int)((((float)i + 1f) / rows) * 100f) > percent)
                        {
                            coffee += "▓";
                        }
                        else
                        {
                            coffee += " ";
                        }
                    }
                    coffee += "-▓";
                    //Console.WriteLine(Math.Sin(((((float)i + 1f) / (float)rows) * 180f) * (Math.PI / 180f)).ToString());
                    //Console.ReadKey();
                    for (int j = 0; j < (int)Math.Round(Math.Sin((((i + 1f) / rows) * 180f) * (Math.PI / 180f)) * (float)columns * 0.75f) - 1; j++)
                    {
                        if (j == 0 && i == 0)
                        {
                            coffee += "▓";
                        }
                        else
                        {
                            coffee += " ";
                        }

                    }
                    for (int j = 0; j < (int)Math.Round(Math.Log(Math.Pow(columns, 1), Math.E)); j++)
                    {
                        coffee += "▓";
                    }
                }
                coffee += Environment.NewLine;
                for (int i = 0; i < columns + 4; i++)
                {
                    coffee += "▓";
                }
                percent += interval;
                Console.WriteLine(coffee);
                Thread.Sleep(200);
            }
            Console.WriteLine("");
            Console.WriteLine("Please Refill Coffee");
            Console.WriteLine("Thank You");
            }
        }

        public void sineWave()
        {
            int i = 0;
            Console.ForegroundColor = ConsoleColor.Red;
            while (true)
            {
                float rad = (float)(i * (Math.PI / 180f));
                for (int j = 0; j < (32 * Math.Sin(Math.Pow(rad, 1.7))) + 64; j++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine("█");
                Thread.Sleep(25);
                i += 3;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Random ran = new Random();
            Coffee coffee = new Coffee();
            Console.WriteLine("C or S?");
            string input = Console.ReadLine();
            if (input.ToLower() == "c")
            {
                Thread buildACoffee = new Thread(new ThreadStart(coffee.buildCoffee));
                buildACoffee.Start();
            }
            else
            {
                Thread sinewave = new Thread(new ThreadStart(coffee.sineWave));
                sinewave.Start();
            }

        }
    }
}
