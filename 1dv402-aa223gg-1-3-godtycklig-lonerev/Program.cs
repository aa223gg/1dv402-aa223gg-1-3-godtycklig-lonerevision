using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1dv402_aa223gg_1_3_godtycklig_lonerev
{
    class Program
    {
        static void Main(string[] args)
        {
            //Main anropar ReadInt() och läser in antal löner.
            do
            {
                int numberOfSalaries = ReadInt("Ange antalet löner: ");
                if (numberOfSalaries < 2)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Värdet måste vara två eller högre.");
                    Console.ResetColor();

                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Tryck tangent för ny beräkning. Esc avslutar.");
                    Console.ResetColor();
                }
                else
                {
                    ProcessSalaries(numberOfSalaries);
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        static int ReadInt(string prompt)
        {
            string input = string.Empty;
            int result;
            while (true)
            {
                try
                {
                    Console.Write(prompt);
                    input = (Console.ReadLine());
                    result = int.Parse(input);
                    return result;
                }
                catch (FormatException)
                {
                    //Om något annat än heltal fylls i.
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("FEL! {0} kan inte kan inte tolkas som ett heltal", input);
                    Console.ResetColor();
                }
            }
        }
        static void ProcessSalaries(int count)
        {
            //skapar en array
            int[] salaries = new int[count];

            //användaren matar in löner
            for (int i = 0; i < salaries.Length; i++)
            {
                salaries[i] = ReadInt(String.Format("Ange lön nr {0}: ", i + 1));
            }
            Console.WriteLine("--------------------------------");

            //Skapa en kopia av arrayen
            int[] salariesCopy = (int[])salaries.Clone();

            //Sorterar lönerna i stigande ordning
            Array.Sort(salaries);

            //Deklarera variabler
            int medianSalary;
            int median1;
            int median2;
            double average;
            int salarySpread;

            //Räkna ut medianlönen
            if (salaries.Length % 2 == 0)
            {
                median1 = salaries[salaries.Length / 2];
                median2 = salaries[salaries.Length / 2 - 1];
                medianSalary = (median1 + median2) / 2;
            }
            else
            {
                medianSalary = salaries[salaries.Length / 2];
            }

            //Räkna ut medellön
            average = salaries.Average();

            //Räkna ut lönespridningen
            salarySpread = salaries.Max() - salaries.Min();

            //Skriv ut medianlön, medellön och lönespridning
            Console.WriteLine("{0, -15} {1, 15:c0}", "Medianlön:", medianSalary);
            Console.WriteLine("{0, -15} {1, 15:c0}", "Medellön:", average);
            Console.WriteLine("{0, -15} {1, 15:c0}", "Lönespridning:", salarySpread);

            Console.WriteLine("--------------------------------");

            //Skriv ut lönerna.
            for (int i = 0; i < salariesCopy.Length; ++i)
            {
                Console.Write("{0, 8}", salariesCopy[i]);
                if ((i + 1) % 3 == 0)
                {
                    Console.WriteLine();
                }
            }
            Console.WriteLine();

            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Tryck valfri tangent för ny beräkning, Escape avslutar");
            Console.ResetColor();
        }
    }
}


