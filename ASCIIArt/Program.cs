using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIArt
{
    class Program
    {
        static int[,] Canvas;
        static int resolution;
        static int dimX;
        static int dimY;
        static PixelGenerator pxgen;

        static string GetPixel(int x, int y)
        {
            int[,] package = new int[resolution, resolution];
            for(int i = 0; i < resolution; i++)
            {
                for(int j = 0; j < resolution; j++)
                {
                    package[j, i] = Canvas[resolution * x + j, resolution * y + i];
                    
                }
            }
            return pxgen.getPixel(package);
        } 

        static void DrawLine()
        {
            Console.WriteLine("Set 2 end points: 'x1 y1 x2 y2' \r\n with types: '<int> <int> <int> <int>' (values in range of picture) ");
            string input = Console.ReadLine();
            int x1;
            int y1;
            int x2;
            int y2;
            try
            {
                x1 = resolution*Convert.ToInt32(input.Split(' ')[0]);
                y1 = resolution*Convert.ToInt32(input.Split(' ')[1]);
                x2 = resolution*Convert.ToInt32(input.Split(' ')[2]);
                y2 = resolution*Convert.ToInt32(input.Split(' ')[3]);
                if(x1 > dimX*resolution || x1 < 0 || x2 > dimX*resolution || x2 < 0 || y1 > dimY*resolution || y1 < 0 || y2 > dimY*resolution ||y2 < 0)
                {
                    throw new Exception("Value out of range of the picture");
                }

                double dx = x2 - x1;
                double dy = y2 - y1;

                double kroku = Math.Max(Math.Abs(dx), Math.Abs(dy));

                double x = (double) x1 + resolution/2;
                double y = (double) y1 + resolution/2;

                for(int i = 0; i < kroku; i++)
                {
                    Canvas[(int) Math.Round(x), (int) Math.Round(y)] = 1;
                    x += dx / kroku;
                    y += dy / kroku;
                }
             
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        static void DrawCanvas()
        {
            string line;
            for (int y = 0; y < dimY; y += 1)
            {
                line = "";
                for(int x = 0; x < dimX; x += 1)
                {
                    line += GetPixel(x,y);
                }
                Console.WriteLine(line);
            }
        }

        static void DataPrint()
        {
            string line;
            for (int y = 0; y < dimY*resolution; y += 1)
            {
                line = "";
                for (int x = 0; x < dimX*resolution; x += 1)
                {
                    line += Canvas[x,y];
                }
                Console.WriteLine(line);
            }
        }

        static bool SetRes()
        {
            string input = Console.ReadLine();
            try
            {
                resolution = Convert.ToInt32(input);
                pxgen = new PixelGenerator(resolution);
                if(resolution <= 0 || resolution >= 4)
                {
                    throw new Exception("Resolution out of range (1 - 3)");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }

        static bool SetDims()
        {
            string input = Console.ReadLine();
           
            try
            {
                dimX = Convert.ToInt32(input.Split(' ')[0]);
                dimY = Convert.ToInt32(input.Split(' ')[1]);
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
                return false;
            }
            Canvas = new int[resolution*dimX,resolution*dimY];
            for(int i = 0; i < dimX*resolution; i++)
            {
                for(int j = 0; j < dimY*resolution; j++)
                {
                    Canvas[i, j] = 0;
                }
            }
            return true;
        }

        static void Main(string[] args)
        {
            string input;
            bool cont = true;

            Console.WriteLine("Set resolution 'r' \r\n with type: '<int>'");

            while (!SetRes()) { };

            Console.WriteLine("Set dimensions 'x y' \r\n with types: '<int> <int>'");

            while (!SetDims()) { };

            while (cont)
            {
                input = Console.ReadLine().ToLower();
                switch (input)
                {
                    case "exit": cont = false;
                        break;
                    case "line": DrawLine();
                        break;
                    case "show": DrawCanvas();
                        break;
                    case "canvas": DataPrint();
                        break;
                    case "bruh": Console.WriteLine("You don't have permissions to use this command");
                        break;
                    case "help": Console.WriteLine("Commands: \r\n 'line' \r\n 'show' \r\n 'exit' \r\n 'canvas'");
                        break;
                    default: Console.WriteLine("Unexpected command, type 'help' for help");
                        break;
                }
            }
        }
    }
}
