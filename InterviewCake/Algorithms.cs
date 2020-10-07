using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewCake
{
    public static class Algorithms
    {
        // BinarySearch Run Time : O(lg n) Space : O(1)
        public static bool BinarySearch(int target,int[] nums)
        {

            // Example : nums[] (first Pass only or one looping only)
            //        [ 1 , 2 , 3 , 4 , 5 , 6 , 7 , 8 , 9 , 10 ]
            // index =  0   1   2   3   4   5   6   7   8    9
            // target = 3

            // Step 1: Define walls for the array
            // EX : floorIndex = -1 , ceilingIndex = 10
            int floorIndex = -1;
            int ceilingIndex = nums.Length;

            while(floorIndex + 1 < ceilingIndex)
            {
                

                // EX: distance = 11
                int distance = ceilingIndex - floorIndex;

                // EX: halfDistance = 5 (since its int division the fraction part would be ignored)
                int halfDistance = distance / 2;
                // EX guessIndex = -1 + 5 = 4
                int guessIndex = floorIndex + halfDistance;

                // EX : guessValue = nums[4] = 5
                int guessValue = nums[guessIndex];

                // EX : 5 == 3 ?? NO
                if(guessValue == target)
                {
                    return true;
                }


                // EX: 5 > 3 ?? YES
                if (guessValue>target)
                {
                    //EX: Target to the left lower the ceiling
                    // ceilingIndex = 4
                    ceilingIndex = guessIndex;
                }
                else
                {
                    // Else skipped
                    floorIndex = guessIndex;
                }
                
            }

            // return false target not found
            return false;
        }


        // MergeRanges Run Time : O(n lg n); Space : O(n)
        public static List<Meeting> MergeRanges(List<Meeting> meetings)
        {
            // Ex: Input = [Meeting(0, 1), Meeting(3, 5), Meeting(4, 8), Meeting(10, 12), Meeting(9, 10)]

            // Make a copy of input so we don't destroy the actual input.
            // so for given example
            // sortedMeetings = [Meeting(0, 1), Meeting(3, 5), Meeting(4, 8), Meeting(9, 10), Meeting(10, 12)]

            var sortedMeetings = meetings.Select(x => new Meeting(x.StartTime,x.EndTime)).OrderBy(x =>x.StartTime).ToList();

            // Assign the first element of sorted meetings to Merged Meetings
            // So after this declaration
            // mergedMeetings = [Meeting(0,1)]
            var mergedMeetings = new List<Meeting> { sortedMeetings[0] };

            // We will go over sortedMeetings = [Meeting(0, 1), Meeting(3, 5), Meeting(4, 8), Meeting(9, 10), Meeting(10, 12)]
            foreach (Meeting m in sortedMeetings)
            {
                // Pass 1: mergedMeetings = [Meeting(0,1)]
                // lastMergedMeeting = [Meeting(0,1)]
                // Pass 2: mergedMeetings = [Meeting(0,1)]
                // lastMergedMeeting = [Meeting(0,1)]
                // Pass 3: mergedMeetings = [Meeting(0,1),Meeting(3,5)]
                // lastMergedMeeting = [Meeting(3,5)]

                // IMPORTANT :
                // NOTE: This is an inplace change(Change my reference), as in this variable points to the last member of mergedMeetings List
                var lastMergedMeeting = mergedMeetings.Last();

                // Pass 1: 
                // Here m.StartTime will be pointing to 1st Meeting object of sortedMeetings
                // so m.StartTime = 0
                // lastMergedMeeting.EndTime = 1
                // 0<=1 ? Yes

                // Pass 2:
                // Here m.StartTime will be pointing to 2nd Meeting object of sortedMeetings
                // so m.StartTime = 3
                // lastMergedMeeting.EndTime = 1
                // 3<= 1 ? NO


                if (m.StartTime <= lastMergedMeeting.EndTime)
                {
                    // Pass 1: 
                    // So we will find lastMergedMeeting.EndTime = 1, m.EndTime = 1
                    // MAX(1,1) = 1
                    // So lastMergedMeeting will be (stay the same) = [Meeting(0,1)]
                    lastMergedMeeting.EndTime = Math.Max(lastMergedMeeting.EndTime, m.EndTime);
                }
                else
                {
                    // Pass 1: skip the else

                    // Pass 2: Add the meeting to mergedMeetings
                    // else add that meeting to the list
                    mergedMeetings.Add(m);
                }
            }

            return mergedMeetings;
        }

        // Reverse String in place Run Time : O(n) Space : O(1)
        public static char[] Reverse(char[] arrayOfChars)
        {
            // Point reference to the firs and last index of the array of chars
            int leftIndex = 0;
            int rightIndex = arrayOfChars.Length - 1;

            // Scroll the pointers towards the middle till they cross each other
            while (leftIndex < rightIndex)
            {
                char tempChar = arrayOfChars[rightIndex];
                arrayOfChars[rightIndex] = arrayOfChars[leftIndex];
                arrayOfChars[leftIndex] = tempChar;

                // Move the pointers towards the middle
                leftIndex++;
                rightIndex--;
            }

            return arrayOfChars;
        }

        // Reverse Words in place Run Time :   Space: O(n)
        public static char[] ReverseWords(char[] message)
        {
            //Ex : message = { 'c', 'a', 'k', 'e', ' ',
            //                 'p', 'o', 'u', 'n', 'd', ' ',
            //                 's', 't', 'e', 'a', 'l'};

            Reverse(message,0,message.Length-1);

            int messageLength = message.Length;
            int currentWordStartIndex = 0;
            for (int i = 0; i <= messageLength; i++)
            {
                if(i==messageLength || message[i]==' ')
                {
                    Reverse(message, currentWordStartIndex, i-1);
                    currentWordStartIndex = i + 1;
                }
            }

            return message;
        }

        // Reverse String in place mentioning left and right index Run Time : O(n) Space : O(1)
        public static char[] Reverse(char[] arrayOfChars,int leftIndex,int rightIndex)
        {
            // Scroll the pointers towards the middle till they cross each other
            while (leftIndex < rightIndex)
            {
                char tempChar = arrayOfChars[rightIndex];
                if (tempChar == '"')
                {
                    Console.WriteLine();
                }
                arrayOfChars[rightIndex] = arrayOfChars[leftIndex];
                arrayOfChars[leftIndex] = tempChar;

                // Move the pointers towards the middle
                leftIndex++;
                rightIndex--;
            }

            return arrayOfChars;
        }

        // Merge arrays Run TIme: O(n) Space: O(1)
        public static int[] MergeArrays(int[] arrayOne,int[] arrayTwo)
        {
            int[] mergedArray = new int[arrayOne.Length+arrayTwo.Length];
            int a1i = 0;
            int a2i = 0;
            int totalCount = arrayOne.Length + arrayTwo.Length;

            for (int i = 0; i < totalCount; i++)
            {
                if (a1i > arrayOne.Length - 1)
                {
                    mergedArray[i] = arrayTwo[a2i];
                    a2i++;
                    continue;
                }

                if(a2i > arrayTwo.Length - 1)
                {
                    mergedArray[i] = arrayOne[a1i];
                    a1i++;
                    continue;
                }

                if ((arrayOne[a1i] < arrayTwo[a2i]))
                {
                    mergedArray[i] = arrayOne[a1i];
                    a1i++;
                }
                else
                {
                    mergedArray[i] = arrayTwo[a2i];
                    a2i++;
                }                
            }

            return mergedArray;
        }

        // Verify if order are served in First-Come-First-Serve basis Run Time : O(n) and Space : O(1)
        public static bool VerifyFCFSOrder(int[] servedOrders,int[] takeOutOrders,int[] dineInOrders)
        {
            bool output = true;
            
            //Takeout Order Served index
            int iTS = 0;
            // Dine-in Order served index
            int iDS = 0;

            int totalOrdersServed = servedOrders.Length-1;

           
            foreach(var order in servedOrders)
            {
                if (iTS<takeOutOrders.Length && order == takeOutOrders[iTS])
                {
                    iTS++;
                }
                else if (iDS<dineInOrders.Length && order == dineInOrders[iDS])
                {
                    iDS++;
                }
                //else
                //{
                //    return false;
                //}
            }

            if(servedOrders.Length < 0)
            {
                throw new Exception("No orders have been served yet.");
            }

            if((takeOutOrders.Length >0) && (takeOutOrders.Length > (servedOrders.Length - iDS)))
            {
                throw new Exception("Not all Take out orders have been served.");
            }

            if ((takeOutOrders.Length > 0) && (takeOutOrders.Length < (servedOrders.Length - iDS)))
            {
                throw new Exception("Some Take out orders have not been paid.");
            }

            if ((dineInOrders.Length > 0) && (dineInOrders.Length > (servedOrders.Length - iTS)))
            {
                throw new Exception("Not all Dine-In orders have been served.");
            }

            if ((dineInOrders.Length > 0) && (dineInOrders.Length < (servedOrders.Length - iTS)))
            {
                throw new Exception("Some Dine-In orders have not been paid.");
            }

            if (takeOutOrders.Length !=iTS || dineInOrders.Length != iDS)
            {
                return false;
            }

            /*
             Bonus
             Q1) This assumes each customer order in servedOrders is unique. 
                 How can we adapt this to handle arrays of customer orders with potential repeats?
                 A:  This code already handles repeat orders

             Q2) Our implementation returns true when all the items in dineInOrders and takeOutOrders are first-come first-served
                 in servedOrders and false otherwise. That said, it'd be reasonable to throw an exception if some orders that went 
                 into the kitchen were never served, or orders were served but not paid for at either register. 
                 How could we check for those cases?
                 A: Already handled in the code

             Q3) Our solution iterates through the customer orders from front to back. Would our algorithm work if we 
                 iterated from the back towards the front? Which approach is cleaner? 
             */

            return output;
        }

        // My solution run Time O(2n) or O(n)
        // Interview Cake solution run time O(n)

        public static bool TwoMoviesInFlightDuration(int flightLength,int[] movieLengths)
        {
            //Assumption : users going to watch exactly two movies
            // Sorting the array run time(lg n)
            Array.Sort<int>(movieLengths);
            int movieCount = 0;

            #region MySolution
            /* -- My Solution 
            Dictionary<int, int> movieLengthsLookup = new Dictionary<int, int>();

            foreach(int length in movieLengths)
            {
                if (!movieLengthsLookup.ContainsKey(length))
                {
                    movieLengthsLookup.Add(length, length);
                }
            }

            foreach (int length in movieLengths)
            {
                int firstMovieLength = length;
                movieLengthsLookup.Remove(length);

                int secondMovieLength = 0;

                try
                {
                    secondMovieLength = movieLengthsLookup.First(x => x.Value <= flightLength - firstMovieLength).Value;
                }catch(Exception e)
                {
                    secondMovieLength = 0;
                    continue;
                }

                if (secondMovieLength <= (flightLength- firstMovieLength))
                {
                    return true;
                }
                else
                {
                    // restoring the key
                    movieLengthsLookup.Add(firstMovieLength, firstMovieLength);
                }
            }
            */
            #endregion


            #region InterviewCakeS Solution
            var movieLengthsSeen = new HashSet<int>();

            foreach (var firstMovieLength in movieLengths)
            {
                int matchingSecondMovieLength = flightLength - firstMovieLength;
                if (movieLengthsSeen.Contains(matchingSecondMovieLength))
                {
                    return true;
                }

                movieLengthsSeen.Add(firstMovieLength);
            }

            #endregion

            return false;
        }

        #region IsPalindrome MySolution Run Time O(n)
        public static bool IsPalindrome(string input)
        {
            Dictionary<char, int> charLookup = new Dictionary<char, int>();

            foreach (char item in input.ToCharArray())
            {
                if (!charLookup.ContainsKey(item))
                {
                    charLookup.Add(item, 1);
                }
                else
                {
                    charLookup[item] = charLookup[item] + 1;
                }
            }

            int countOfOddElements = 0;

            foreach (char item in charLookup.Keys)
            {
                if (charLookup[item] % 2 == 1)
                {
                    countOfOddElements += 1;
                }

                if(countOfOddElements > 1)
                {
                    return false;
                }
            }
                       
            return true;
        }
        #endregion

        #region HasPalinDromePermutation InterviewCake Solution Run Time O(n)
        public static bool HasPalindromePermutation(string theString)
        {
            // Track characters we've seen an odd number of times
            var unpairedCharacters = new HashSet<char>();

            foreach (char c in theString)
            {
                if (unpairedCharacters.Contains(c))
                {
                    unpairedCharacters.Remove(c);
                }
                else
                {
                    unpairedCharacters.Add(c);
                }
            }

            // The string has a palindrome permutation if it
            // has one or zero characters without a pair
            return unpairedCharacters.Count <= 1;
        }
        #endregion  


        public static Dictionary<string,int> WordCloud(string longString)
        {
            Dictionary<string, int> wordCloud = new Dictionary<string, int>();

            System.Console.WriteLine(longString);


            char[] charArray = longString.ToCharArray();

            int wordLength = 0;
            int wordStart = 0;

            for (int i = 0; i < charArray.Length; i++)
            {
                string word = "";

                // Example : This is an  example 


                if (!Char.IsPunctuation(charArray[i]) && Char.IsLetter(charArray[i]))
                {
                    //System.Console.WriteLine("Incrementing word length for '{0}'", charArray[i]);
                    wordLength++;

                }

                switch (charArray[i])
                {
                    case '\'':
                    case '-':
                        wordLength++;
                        break;
                    default:
                        break;
                }
                
                  
                if (charArray[i]==' ' || charArray[i] == '.' || charArray[i]=='(' || charArray[i]==',' || charArray[i]=='@' || i==longString.Length-1)
                {
                    if (wordLength > 0)
                    {
                        
                        word = longString.Substring(wordStart, wordLength);

                        wordStart = i + 1;

                        wordLength = 0;

                        if (wordCloud.ContainsKey(word))
                        {
                            wordCloud[word] += 1;
                        }
                        else
                        {
                            wordCloud.Add(word, 1);
                        }
                    }
                    else
                    {
                        wordStart = i+1;
                    }
                }else if (Char.IsSymbol(charArray[i]))
                {
                    string symbol = charArray[i].ToString();
                    if (wordCloud.ContainsKey(symbol))
                    {
                        wordCloud[symbol] += 1;
                    }
                    else
                    {
                        wordCloud.Add(symbol, 1);
                    }
                    wordStart = i + 1;
                }
                
            }

            //foreach (string word in longString.Split(' '))
            //{
            //    string formattedWord = word;

            //    if (!wordCloud.ContainsKey(formattedWord) && formattedWord != "")
            //    {
            //        wordCloud.Add(formattedWord, 1);
            //    }
            //    else
            //    {
            //        if (formattedWord != "")
            //        {
            //            wordCloud[formattedWord] += 1;
            //        }                    
            //    }
            //}

            return wordCloud;
        }

    }
}
