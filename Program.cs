using System;
using System.Numerics;

namespace Binomial_Calculator
{
    class Program
    {
        //prior method of n choose k clac
        static public BigInteger FacCalc(int n)
        {
            BigInteger fac;

            if (n == 0)
            {
                return 1;
            }
            else
            {
                fac = 1;
                for (int i = 1; i < n; i++)
                {
                    fac += fac * i;
                }

                //Console.WriteLine("FAC n is: "+n+" fac: "+fac);
                return fac;
            }
        }

        static BigInteger NchooseKcalc(int k, int n)
        {
            BigInteger product = 1;
            //Console.WriteLine("n: " + n + "k: " + k);
            for (BigInteger i = 1; i <= k; i++)
            {
                product = product * ((n + i - k) / i);
            }
            return product;
        }

        static void PrintArray(BigInteger[,] array)
        {
            Console.WriteLine("C X Y");
            for (int i = 0; i < 10000; i++)
            {
                if (array[2, i] != 0)
                {
                    Console.WriteLine(array[2, i] + " " + array[0, i] + " " + array[1, i]);//print [c x y]
                }

            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Jake's Binomial solver");

            int n = 0;
            int k = 0;
            bool userCheck = false;
            

            Console.WriteLine("Solving for (x+y)^n");
            Console.WriteLine("Up to 9999");
            while (userCheck != true)
            { 
                try
                {
                    Console.WriteLine("What is your n value: ");
                    n = Convert.ToInt32(Console.ReadLine());
                    if(n >=0 && n < 10000)
                    {
                        Console.WriteLine("You Chose: " + n + " Is this correct (Y/N): ");
                        char ans = Console.ReadLine()[0];
                        if (ans == 'y' || ans == 'Y')
                        {
                            userCheck = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input, try again");
                    }
                    
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input, try again");
                }
                
                
            }


            BigInteger[,] exponentArray = new BigInteger[3, 10000];//making A multi dim array to hold exponent values
            //ex x^2+xy+y^2
            // x 2 1 0
            // y 0 1 2
            //nk 1 1 1

            //the idea is to then convert the array to a string and outprint it

            //sum from k to n of (n choose k)*(x^n-k)*(y^k)
            while (k <= n)
            {
                exponentArray[0, k] = n - k;
                exponentArray[1, k] = k;
                exponentArray[2, k] = NchooseKcalc(k, n);
                k++;
            }

            PrintArray(exponentArray);
            Console.WriteLine();
            //printing
            for (int i = 0; i <= n; i++)
            {
                //write choose first then x the y
                if (exponentArray[2, i] != 1)
                {
                    //Console.Write(Math.Round(exponentArray[2, i]) + "*");if using decimals
                    Console.Write(exponentArray[2, i] + "*");
                }

                if (exponentArray[0, i] != 0)
                {
                    if (exponentArray[0, i] == 1)
                    {
                        Console.Write("x");
                    }
                    else
                    {
                        Console.Write("x^" + exponentArray[0, i]);
                    }
                }

                if (exponentArray[0, i] != 0 && exponentArray[1, i] != 0)
                {
                    Console.Write("*");
                }

                if (exponentArray[1, i] != 0)
                {
                    if (exponentArray[1, i] == 1)
                    {
                        Console.Write("y");
                    }
                    else
                    {
                        Console.Write("y^" + exponentArray[1, i]);
                    }
                }
                if ((i + 1) != 10000)
                {
                    if (exponentArray[2, i + 1] != 0)
                    {
                        Console.Write(" + ");
                    }
                }

            }

        }
    }
}