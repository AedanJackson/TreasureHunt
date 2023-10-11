using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureHunt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int YSize = 20;
            const int XSize = 20;
            Random RNG = new Random();
            char[,] TreasureMap = new char[YSize,XSize]; // initialise empty 2d array
            int[] XLocation = { RNG.Next(0, YSize), RNG.Next(0, XSize) }; // gen random coords
            PlotPoint(ref TreasureMap, 'X', XLocation); // Plots X on random coords
            PlayGame(ref TreasureMap, YSize, XSize);
            
        }

        // Subroutine to plot a character to a 2d array at a set point
        static void PlotPoint(ref char[,] Map, char Character, int[] point)
        {
            Map[point[0],point[1]] = Character;
        }

        // Subroutine to play the game
        static void PlayGame(ref char[,] TreasureMap, int YSize, int XSize)
        {
            bool LootFound = false;
            int Attempts = 0;
            while (!LootFound)
            {
                Attempts++;
                bool InputValid = false;
                int YDirection = 0;
                // Validation for Y direction
                do
                {
                    Console.WriteLine("Tell me matey, how lang be we Southerly? ");
                    try
                    {
                        YDirection = int.Parse(Console.ReadLine());
                        if (YDirection >= YSize)
                        {
                            Console.Write("Yarr! That be too far. Next tyme, note that we be less than 20 Southerly");
                        }
                        else if (YDirection < 0)
                        {
                            Console.WriteLine("Aye! We cannot be less than zeero you foole!");
                        }
                        else
                        {
                            InputValid = true;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("You landlubbing fool, That be nat a length!");
                    }
                } while (!InputValid);

                //Validation for X direction
                InputValid = false;
                int XDirection = 0;
                do
                {
                    Console.WriteLine("Tell me matey, how lang be we Eastwards? ");
                    try
                    {
                        XDirection = int.Parse(Console.ReadLine());
                        if (XDirection >= XSize)
                        {
                            Console.Write("Yarr! That be too far. Next tyme, note that we be less than 20 Eastwards");
                        }
                        else if (XDirection < 0)
                        {
                            Console.WriteLine("Aye! We cannot be less than zeero you foole!");
                        }
                        else
                        {
                            InputValid = true;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("You landlubbing fool, That be nat a length!");
                    }
                } while (!InputValid);

                // Output section. Message if found, if not found or if already selected
                if (TreasureMap[YDirection, XDirection] == 'X')
                {
                    Console.WriteLine($"Aharr! After {Attempts} bloomin' hours! I found the treasure! Now to nail ya to a tree ya scallywag!");
                    Console.WriteLine("You can have yer bleedin' map, ain't useful to me anymore!");
                    PrintMap(ref TreasureMap, YSize, XSize);
                    LootFound = true;
                }
                else if (TreasureMap[YDirection, XDirection] == '?')
                {
                    Console.WriteLine("Ye foole! There ye have been already");
                }
                else
                {
                    Console.WriteLine("No treasure to be found here! GARGH");
                    TreasureMap[YDirection, XDirection] = '?';
                }
            }
            Console.ReadLine();
        }

        // Prints out the map
        static void PrintMap(ref char[,] TreasureMap, int YSize, int XSize)
        {
            for (int y = 0; y < YSize; y++)
            {
                for (int x = 0; x < XSize; x++)
                {
                    Console.Write(TreasureMap[y, x]);
                }
                Console.WriteLine();
            }
        }
    }
}
