using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewCake
{
    public static class PrintDataStructures
    {

        public static void PrintDictionary(Dictionary<int,int> inputDictionary)
        {
            foreach (var item in inputDictionary)
            {
                System.Console.WriteLine("Key= {0} Value = {1} ", item.Key, item.Value);
            }            
        }

        public static void PrintIntArrays(int[] input)
        {
            System.Console.Write("Printing Array : [");
            foreach (var item in input)
            {
                System.Console.Write("{0} ", item);
            }
            System.Console.Write("]");
        }

    }
}
