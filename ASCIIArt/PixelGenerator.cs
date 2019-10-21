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
            int px;
            int sum;
            switch (resolution)
            {
                case 1:
                    if (package[0, 0] == 0)
                    {
                        return "  ";
                    }
                    else
                    {
                        return " #";
                    }
                case 2:
                    //Console.WriteLine(package[0, 0] + " " + package[1, 0] + " " + package[0, 1] + " " + package[1, 1]);
                    px = (package[0, 0] * 8) + (package[1, 0] * 4) + (package[0, 1] * 2) + (package[1, 1]);

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
                case 3:
                    px = (package[0, 0] * 256) + (package[1, 0] * 128) + (package[2, 0] * 64) + (package[0, 1] * 32) + (package[1, 1] * 16) + (package[2, 1] * 8) + (package[0, 2] * 4) + (package[1, 2] * 2) + (package[2, 2] * 1);
                    sum = package[0, 0] + package[1, 0] + package[2, 0] + package[0, 1] + package[1, 1] + package[2, 1] + package[0, 2] + package[1, 2] + package[2, 2];

                    // 256 128  64
                    //  32  16   8
                    //   4   2   1

                    switch (sum)
                    {
                        case 0: return " ";
                        case 1: return " ";
                        case 2: return " ";
                        case 3: switch (px)
                            {
                                case 276: return ">";
                                case 138: return ">";
                                case 81: return "<";
                                case 162: return "<";
                                case 273: return "\\";
                                case 146: return "|";
                                case 84: return "/";
                                case 56: return "-";
                                case 7: return "_";
                                case 458: return "-";
                                default: return " ";
                            }
                           
                        case 4: switch (px)
                            {
                                case 273+128: return "\\";
                                case 273+64: return "\\";
                                case 273+32: return "\\";
                                case 273+8: return "\\";
                                case 273+4: return "\\";
                                case 273+2: return "\\";
                                case 146+256: return "|";
                                case 146+64: return "|";
                                case 146+32: return "|";
                                case 146+8: return "|";
                                case 146+4: return "|";
                                case 146+1: return "|";
                                case 84+256: return "/";
                                case 84+128: return "/";
                                case 84+32: return "/";
                                case 84+8: return "/";
                                case 84+2: return "/";
                                case 84+1: return "/";
                                case 56+256: return "-";
                                case 56+128: return "-";
                                case 56+64: return "-";
                                case 56+4: return "-";
                                case 56+2: return "-";
                                case 56+1: return "-";
                                default: return " ";
                            }
                        case 5: return "X";
                        case 6: return "O";
                        case 7: return "E";
                        case 8: return "M";
                        case 9: return "#";
                        default: return "!";
                    }

                default:
                    throw new Exception("Resolution out of range");

            }
        }
    }
}