using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewCake
{
    class Program
    {
        static void Main(string[] args)
        {

            #region   Example for Binary Search 
            /*int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            System.Console.Write("Enter a target to search : ");
            int target = Convert.ToInt32(System.Console.ReadLine());

            if (Algorithms.BinarySearch(target, nums))
            {
                System.Console.WriteLine($"Target : {target} exists in the given array nums.");
            }
            else
            {
                System.Console.WriteLine($"Target : {target} not found in the array!!");
            }
            
            System.Console.ReadKey();
            */
            #endregion

            #region Example for Merging Meeting Times
            /*List<Meeting> inputMeetingList = new List<Meeting>();
            inputMeetingList.Add(new Meeting(0, 3));
            inputMeetingList.Add(new Meeting(1, 2));
            //input.Add(new Meeting(4, 8));
            //input.Add(new Meeting(10, 12));
            //input.Add(new Meeting(9, 10));

            System.Console.Write("Input Meeting Ranges are : [");
            foreach (Meeting m in inputMeetingList)
            {
                System.Console.Write(m.ToString());
            }
            System.Console.Write("]");
            System.Console.WriteLine("");

            var output = Algorithms.MergeRanges(inputMeetingList);

            System.Console.Write("Merged Meeting Ranges are : [");
            foreach (Meeting m in output)
            {
                System.Console.Write(m.ToString());
            }
            System.Console.Write("]");
            System.Console.ReadKey();
            */
            #endregion

            #region Example for Reverse string (using array of chars since string is immutable)
            /*System.Console.WriteLine();
            System.Console.Write("Enter a string : ");
            string userInput = System.Console.ReadLine();
            char[] inputArray = userInput.ToCharArray();

            System.Console.Write("Input is ");
            System.Console.Write("{0}",new string(inputArray));

            System.Console.WriteLine();

            System.Console.Write("Reverse of input = ");
            System.Console.Write("{0}",new string(Algorithms.Reverse(inputArray)));

            System.Console.WriteLine();
            System.Console.Write("Enter a Sentence : ");
            userInput = System.Console.ReadLine();
            inputArray = userInput.ToCharArray();

            System.Console.Write("Sentence is ");
            System.Console.Write("{0}", new string(inputArray));

            System.Console.WriteLine();

            System.Console.Write("Reverse of sentence is = ");
            System.Console.Write("{0}", new string(Algorithms.ReverseWords(inputArray)));

            System.Console.WriteLine();
            System.Console.ReadKey();
            */
            #endregion

            #region Merge Sorted Arrays
            /*System.Console.WriteLine();
            int[] myArray = { 1, 5, 8, 12, 14, 19 };
            int[] alicesArray = { 3, 4, 6 };

            System.Console.Write("[");
            foreach (var item in Algorithms.MergeArrays(myArray, alicesArray))
            {
                System.Console.Write("{0} ", item);
            }
            System.Console.Write("]");

            System.Console.ReadKey();
            */
            #endregion

            #region Cafe Order Checker
            /*
            System.Console.WriteLine();
            int[] takeOutOrders = { 1};
            int[] dineInOrders = { 4, 5, 6,7,4 };
            int[] servedOrders = { 4, 5,6,7,4 };

            try
            {
                if (Algorithms.VerifyFCFSOrder(servedOrders, takeOutOrders, dineInOrders))
                {
                    System.Console.WriteLine("The orders are in First-Come-First-Served order.");
                }
                else
                {
                    System.Console.WriteLine("ERROR! Orders are not in FCFS order.");
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("We have a problem: \"{0}\"", e.Message);
            } 
            
            System.Console.ReadKey();
            */
            #endregion

            #region In-flight entertainment system
            /*
            System.Console.WriteLine();
            
            int[] movieLengths = { 180, 195, 186, 170, 220 };
            int flightLength = 360;

            //Dictionary<int, int> movieLengthsLookup = new Dictionary<int, int>();
            //movieLengthsLookup.Add(1, 1);
            
            if (Algorithms.TwoMoviesInFlightDuration(flightLength, movieLengths))
            {
                System.Console.WriteLine("There are 2 movies that can be watched during this flight.");
            }
            else
            {
                System.Console.WriteLine("Sorry!! No 2 movies that can be watched during this flight.");
            }
            
            System.Console.ReadKey();
            
            */
            #endregion

            #region Permutation Palindrome
            /*
            System.Console.WriteLine();

            System.Console.WriteLine("Enter a word : ");
            string input = System.Console.ReadLine();

            if (Algorithms.IsPalindrome(input))
            {
                System.Console.WriteLine("Entered Word is a Permutation-Palindrome");
            }
            else
            {
                System.Console.WriteLine("Not a permutation-palindrome");
            }

            System.Console.ReadKey();
            */
            #endregion

            #region Word-Cloud 
            System.Console.WriteLine();
            string input = //"Cliff finished his cake and paid the bill.";
                           //"We came, we saw, we conquered...then we ate Bill's (Mille-Feuille) cake.";
                           //   "We came, we saw, we ate cake.Friends, Romans, countrymen! Let us eat cake.New tourists in New York often wait in long lines for cronuts.";
                           "☹ + ☕ = ☺";
            //"mankar.saurabh@gmail.com epjmorgan@gmail.com ndsheetal@gmail.com";
            foreach (var item in Algorithms.WordCloud(input))
            {
                System.Console.WriteLine("Word = {0}  Frequency = {1}", item.Key, item.Value);
            }

            System.Console.ReadKey();

            #endregion
        }
    }
}
