using System;

namespace ASCIIArt
{
    internal class PixelGenerator
    {
        public int resolution;

        public PixelGenerator(int res)
        {
            resolution = res;
        }

        internal string getPixel(int[,] package)
        {

            switch (resolution)
            {
                case 1:
                    if(package[0,0] == 0)
                    {
                        return "  ";
                    }
                    else
                    {
                        return " #";
                    }
                case 2:
                    //Console.WriteLine(package[0, 0] + " " + package[1, 0] + " " + package[0, 1] + " " + package[1, 1]);
                    int px = (package[0, 0]*8) + (package[1, 0]*4) + (package[0, 1]*2) + (package[1, 1]);
                    
                    switch (px)
                    {
                        case 0: return " "; //0000
                        case 1: return " "; //0001
                        case 2: return " "; //0010
                        case 3: return "-"; //0011
                        case 4: return " "; //0100
                        case 5: return "|"; //0101
                        case 6: return "/"; //0110
                        case 7: return "X"; //0111
                        case 8: return " "; //1000
                        case 9: return "\\"; //1001
                        case 10: return "|"; //1010
                        case 11: return "X"; //1011
                        case 12: return "-"; //1100
                        case 13: return "X"; //1101
                        case 14: return "X"; //1110
                        case 15: return "X"; //1111
                        default: return " ";

                    }
                    
                default:
                    throw new Exception("Resolution out of range");

            }
        }
    }
}