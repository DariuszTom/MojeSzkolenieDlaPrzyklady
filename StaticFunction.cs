using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    internal static class StaticFunction
    {
        /// <summary>
        /// Zbiór funkcji  które mogą mi się jeszcze przydać
        /// </summary>
        
        public static long[] BubbleSortObje(bool ASC, long[] Vecktor)
        {
            bool Swap;
            var VecktorCount = default(long);
            long loopC;
            long firstVal;
            long secondVal;

                do
                {
                    Swap = false;
                    var loopTo = (Vecktor.Length - 1) - VecktorCount;
                    loopC = 0;
                    for (loopC = 0; loopC < loopTo; loopC++)
                    {
                        firstVal = (Vecktor[(long)loopC]);
                        secondVal = (Vecktor[(long)loopC+1]);
                        if ((firstVal > secondVal & ASC == false) || (firstVal < secondVal & ASC == true))
                        {
                            Vecktor[(long)loopC] = secondVal;
                            Vecktor[(long)(loopC + 1)] = firstVal;
                            Swap = true;
                        }
                    }
                    VecktorCount = VecktorCount + 1L;
                }
                while (Swap != false);
                      
            return Vecktor;
        }

        public static int WordCount(this string str)
        {
            var WordCount = str.Split(new char[] { ' ', ',', '.', '?' },
                                StringSplitOptions.RemoveEmptyEntries).Length;
            return WordCount;
        }

        public static string EvenOrOdd(int iNumb)
        {
            string EvenOrOdd;
            if (iNumb % 2 != 0)
                EvenOrOdd = "Odd";
            else
                EvenOrOdd = "Even";
            return EvenOrOdd;
        }

        public static string RemLetters(string myString)
        {
            string remLettersRet = default;
            string regPattern = "[a-zA-Z]+";

            var regx = new Regex(regPattern);
            remLettersRet = regx.Replace(myString, "");
            remLettersRet = Regex.Replace(remLettersRet, @"\,$", "");
            return remLettersRet;
        }

        public static int СenturyFromYear(int year) => (int)Math.Ceiling(year * 0.01);
        public static bool IsNumPrime(int num)
        {
            if (num > 1)
            {
                return Enumerable.Range(1, num).Where(x => num % x == 0)
                                 .SequenceEqual(new[] { 1, num });
            }
            return false;
        }

    }
}