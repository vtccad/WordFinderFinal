using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordFinderFinal
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] input = {
                { "A", "B", "C", "E" },
                { "S", "F", "C", "S" },
                { "A", "D", "E", "E" }
            };


            bool[,] flag = {
                { false, false,false,false },
                { false, false,false,false },
                { false, false,false,false }
            };

            bool result = false;

            string[] testABCCED = { "A", "B", "C", "C", "E", "D" };
            ResetFlag(flag);
            result = false;
            result = IsWordInside(input, flag, testABCCED, result);
            Console.WriteLine(result + "\n");

            string[] testSee = { "S", "E", "E" };
            ResetFlag(flag);
            result = false;
            result = IsWordInside(input, flag, testSee, result);
            Console.WriteLine(result + "\n");

            string[] testABCB = { "A", "B", "C", "B" };
            ResetFlag(flag);
            result = false;
            result = IsWordInside(input, flag, testABCB, result);
            Console.WriteLine(result + "\n");


            Console.WriteLine("---Program Complete---");
            Console.ReadKey();
        }

        private static bool[,] ResetFlag(bool[,] flag)
        {
            for (int i = 0; i < flag.GetLength(0); i++)
            {
                for (int j = 0; j < flag.GetLength(1); j++)
                {
                    flag[i, j] = false;
                }
            }
            return flag;
        }

        private static bool IsWordInside(string[,] input, bool[,] flag, string[] input3, bool result)
        {
            for (int i = 0; i < input.GetLength(0); i++)
            {
                for (int j = 0; j < input.GetLength(1); j++)
                {
                    ResetFlag(flag);
                    if (compare(input, input3, flag, 0, i, j))
                    {
                        result = true;
                        break;
                    }
                }
            }

            return result;
        }

        private static bool compare(string[,] input, string[] input2, bool[,] flag, int index, int row, int col)
        {
            bool result = false;


            if (index < input2.Length)
            {

                if (input[row, col] == input2[index])
                {
                    flag[row, col] = true;
                    if (row - 1 >= 0 && !flag[row - 1, col])
                        if (result = compare(input, input2, flag, index + 1, row - 1, col))
                            return result;
                    if (row + 1 < input.GetLength(0) && !flag[row + 1, col])
                        if (result = compare(input, input2, flag, index + 1, row + 1, col))
                            return result;
                    if (col - 1 >= 0 && !flag[row, col - 1])
                        if (result = compare(input, input2, flag, index + 1, row, col - 1))
                            return result;
                    if (col + 1 < input.GetLength(1) && !flag[row, col + 1])
                        if (result = compare(input, input2, flag, index + 1, row, col + 1))
                            return result;
                }
                else
                {

                    return result = false;
                }
            }
            else
            {
                result = true;
            }


            return result;
        }
    }
}
