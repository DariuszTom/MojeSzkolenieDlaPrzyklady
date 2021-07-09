using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleApp1
{
    public static class AsyncMethods
    {
        private static object thread;

        /// <summary>
        /// Proba pracy z metodami asychronicznymi 
        /// </summary>
        /// <returns></returns>
        public static async Task Zad12And13()
        {
            await Zad12Async();
            await Zad13Async();
        }

        private static async Task Zad12Async()
        {
            
            var watchT = System.Diagnostics.Stopwatch.StartNew();
            WriteLine("Obliczanie wartośći funkcji y = 3x metodami asychronicznymi");
            int howManyL = 10;
            Task<string> res1= Task.Run(() => FunForLoop(howManyL));
            Task<string> res2= Task.Run(() => FunForWhile(howManyL));
            Task<string> res3 = Task.Run(() => FunForDoWhile(howManyL));

            Task.WaitAll(res1,res2,res3);
            watchT.Stop();
            var howLong = watchT.ElapsedMilliseconds;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Wszystkie taski zakończone w " + howLong + " milisekundy");
            WriteLine(sb.ToString());
        }
        private static string FunForLoop(int howLong)
        {
            long resultOfY;
            for (var LoopI = 0; LoopI <= howLong; LoopI++)
            {
                resultOfY = 3 * LoopI;// y = 3x
                WriteLine("Async ForLoop: Whene x={0} then y={1}", LoopI, resultOfY);
            }
            return "Done ForLoop";
        }
        private static string FunForWhile(int howLong)
        {
            long resultOfY;
            int LoopI = 0;
            while (LoopI <= howLong)
            {
                resultOfY = 3 * LoopI;// y = 3x
                WriteLine("Async While Loop: When x={0} then y={1}", LoopI, resultOfY);
                LoopI++;
            }
            return "Done While loop";
        }
        private static string FunForDoWhile(int howLong)
        {
            long resultOfY;
            int LoopI = 0;
            do
            {
                resultOfY = 3 * LoopI;// y = 3x
                WriteLine("Async DoWhile Loop: When x={0} then y={1}", LoopI, resultOfY);
                LoopI++;
            } while (LoopI <= howLong);
            return "Done DoWhile Loop";
        }
        private static async Task Zad13Async()
        {
            long increnment = 10000000;// Dalem wiecej powtorzen gdyz innaczej nie widać roznicy w perfomance miedzy roznymi rodzajami petli
            WriteLine("Metody asynchroniczne. Sumowanie liczb naturalny z przedziału 0-{0}", increnment);
            Task<string> resultSumQuick = Task.Run(() => QuickSum(increnment));
            Task<string> forSum = Task.Run(() => ForLoop(increnment));
            Task<string> forEachSum = Task.Run(() => ForEachLoop((int)increnment));
            Task<string> forWhileSum = Task.Run(() => WhileLoop(increnment));
            Task<string> forDoWhileSum = Task.Run(() => DoWhileLoop(increnment));

            Task.WaitAll(forSum, forEachSum, forWhileSum, forDoWhileSum);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Suma szybkiej kalkulacji=" + resultSumQuick.Result);
            sb.AppendLine("Suma z petli for=" + forSum.Result);
            sb.AppendLine("Suma z petli foreach=" + forEachSum.Result);
            sb.AppendLine("Suma z petli While=" + forWhileSum.Result);
            sb.AppendLine("Suma z petli DoWhile=" + forDoWhileSum.Result);
            WriteLine(sb.ToString());
        }
        private static string QuickSum(long howLong)
        {
            var watchT = System.Diagnostics.Stopwatch.StartNew();
            long resultSumQuick = howLong * (howLong + 1) / 2;
            watchT.Stop();
            string timeNeed = watchT.ElapsedMilliseconds.ToString();
            return (resultSumQuick + " czas kalkukacji ms "+ timeNeed + " Watek:" + Thread.CurrentThread.ManagedThreadId );
        }
        public static string ForLoop(long howLong)
        {
            var watchT = System.Diagnostics.Stopwatch.StartNew();
            long SumOfLoop = 0;
            for (var LoopI = 0; LoopI <= howLong; LoopI++)
            {
                SumOfLoop += LoopI;
            }
            string timeNeed = watchT.ElapsedMilliseconds.ToString();
            return (SumOfLoop + " czas kalkukacji ms " + timeNeed +" Watek:" + Thread.CurrentThread.ManagedThreadId);
        }
        public static string ForEachLoop(int howLong)
        {
            var watchT = System.Diagnostics.Stopwatch.StartNew();
            int[] numArr = Enumerable.Range(0, howLong+1).ToArray();
            long sum = 0;
            foreach (int number in numArr)
            {
                sum += number;
            }
            string timeNeed = watchT.ElapsedMilliseconds.ToString();
            return (sum + " czas kalkukacji ms " + timeNeed + " Watek:" + Thread.CurrentThread.ManagedThreadId);
        }
        public static string WhileLoop(long howLong)
        {
            var watchT = System.Diagnostics.Stopwatch.StartNew();
            long SumOfLoop = 0;
            long LoopI = 0;

            while (LoopI <= howLong)
            {
                SumOfLoop += LoopI;
                LoopI++;
            }
            string timeNeed = watchT.ElapsedMilliseconds.ToString();
            return (SumOfLoop + " czas kalkukacji ms " + timeNeed + " Watek:" + Thread.CurrentThread.ManagedThreadId);
        }
        public static string DoWhileLoop(long howLong)
        {
            var watchT = System.Diagnostics.Stopwatch.StartNew();
            long SumOfLoop = 0;
            long LoopI = 0;
            do
            {
                SumOfLoop += LoopI;
                LoopI++;
            } while (LoopI <= howLong);
            string timeNeed = watchT.ElapsedMilliseconds.ToString();
            return (SumOfLoop + " czas kalkukacji ms " + timeNeed + " Watek:" + Thread.CurrentThread.ManagedThreadId);
        }
       


    }
}
