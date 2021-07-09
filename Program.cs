using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace ConsoleApp1
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            /// Wyodrebnilem niektorze funkcje które uznałem ze mogą mi się przydać w przyszłości  i dodałem do clasy Static Function
            /// Zadanie z loopami uzyłem metod asynchornicznych dlatego ze wcześniej nie miałem z tym kontaku i chchiałem sprawdzić jak takie coś działa
            //Program.Zad1();
            //Program.MoveToNext();
            //Program.Zad2();
            //Program.MoveToNext();
            //Program.Zad3();
            //Program.MoveToNext();
            //Program.Zad4();
            //Program.MoveToNext();
            //Program.Zad5();
            //Program.MoveToNext();
            //Program.Zad6();
            //Program.MoveToNext();
            //Program.Zad7();
            //Program.MoveToNext();
            //Program.Zad8();
            //Program.MoveToNext();
            //Program.Zad9();
            //Program.MoveToNext();
            //Program.Zad10();
            //Program.MoveToNext();
            //Program.Zad11();
            //Program.MoveToNext();
            await AsyncMethods.Zad12And13();
            Program.MoveToNext();
            WriteLine("Koniec");
            Program.TryDelegate();
            Program.MoveToNext();
        }

        public static void MoveToNext()
        {
            string txt = "Nacisnij dowolny klawisz by przejść do nastepnego zadania";
            WriteLine(txt);
            ReadKey();
            WriteLine(Environment.NewLine);
        }

        public static void Zad1()
        {
            double decimalRes;
            WriteLine("Sprawdz czy liczba jest całkowita. Wpisz liczbe: Max {0} lub Min -{0}", long.MaxValue);
            var result = ReadLine().Replace(".", ",");
            if (Double.TryParse(result, out decimalRes) == true)
                if (decimalRes - (Int64)decimalRes == 0)
                    WriteLine("{0} jest liczba calkowita", result);
                else
                    WriteLine("{0} nie jest liczba calkowita", result);
            else
                WriteLine(@"Podana wartość {0}, nie jest liczba", result);
        }

        public static void Zad2()
        {
            WriteLine("Przypisanie kategorie wzrost. Podaj swoj wzrost, wartość jako liczba naturalna");
            var result = ReadLine().Replace(".", ",");
            if (Double.TryParse(result, out double decimalRes) == true)
            {
                decimalRes = Math.Abs(decimalRes);
                switch (decimalRes)
                {
                    case object _ when decimalRes < 150d :
                        result = "Niski";
                        break;

                    case object _ when decimalRes >= 150d & decimalRes < 170d:
                        result = "Sredni";
                        break;
                    case object _ when decimalRes >= 170d:
                        result = "Wysoki";
                        break;
                }
                WriteLine("Wzrost {0}cm, kategoria {1} ",decimalRes, result);
            }
            else
                WriteLine(@"Podana wartość {0}, nie jest liczba", result);
        }
        public static void Zad3()
        {
            WriteLine("Obliczania pierwstka kwadratowego,. Wpisz liczbe: Max {0} lub Min 0", long.MaxValue);
            var result = ReadLine().Replace(".", ",");
            if (Double.TryParse(result, out double decimalRes) == true)
            {
                if (decimalRes <= 0)
                {
                    WriteLine("PIERWIASTEK KWADRATOWY Z LICZBY UJEMNEJ NIE ISTNIEJE");
                    return;
                }
                WriteLine("Wynik to: {0}", Math.Sqrt(decimalRes));
            }
            else
               WriteLine(@"Podana wartość {0}, nie jest liczba", result);

        }
        public static void Zad4()
        {
            WriteLine("Sortowanie bąbelkowe zbioru liczb. Liczby podaj prosze odzielające jedną od drugiej przecinkiem ',' ");
            var numberAll = StaticFunction.RemLetters(ReadLine());
            long[] vektorOfNum = Array.ConvertAll(numberAll.Split(new char[] { ' ', ',', '.', '?' },
                                                StringSplitOptions.RemoveEmptyEntries),long.Parse);
            vektorOfNum= StaticFunction.BubbleSortObje(false, vektorOfNum);
            WriteLine("Wynik sortowania: {0}", string.Join(",",vektorOfNum));
        }
        public static void Zad5()
        {
            (double heightC, double baseRadius) descCyllinder =(0,0);
            WriteLine("Obliczanie pola  powierzchni  walca  i  jego  objętość"+ Environment.NewLine);
            WriteLine("Podaj prosze wysokość walca (musi być wieksza niż 0)" + Environment.NewLine);
            do
            {
                if (Double.TryParse(StaticFunction.RemLetters(ReadLine()), out descCyllinder.heightC) != true)
                    WriteLine(@"Podana wartość nie jest liczba");
            } while (descCyllinder.heightC <= 0);

            WriteLine("Podaj prosze podać powierzchni walca (musi być wieksza niż 0)");
            do
            {
                if (Double.TryParse(StaticFunction.RemLetters(ReadLine()), out descCyllinder.baseRadius) != true)
                    WriteLine(@"Podana wartość nie jest liczba");
            } while (descCyllinder.baseRadius <= 0);

            double fieldC= 2 * Math.PI * descCyllinder.baseRadius * (descCyllinder.baseRadius + descCyllinder.heightC);
            double volume = Math.PI * Math.Pow(descCyllinder.baseRadius,2) * descCyllinder.heightC;
            WriteLine("Pole powierzchni całkowitej: {0:f4}  Objętość: {1:f4}", fieldC, volume);
        }
        public static void Zad6()
        {
            ValueTuple<string, int>[] parForFun = { ("a", 0), ("b", 0), ("c", 0) };
            WriteLine("Obliczanie równania kwadratowego standardowego ax2+bx+c=0" + Environment.NewLine);

            for (byte loopB = 0; loopB < 3; loopB++)
            {
                WriteLine("Podaj parametr: " + parForFun[loopB].Item1 );
                if (int.TryParse(StaticFunction.RemLetters(ReadLine()), out parForFun[loopB].Item2) != true)
                {
                    WriteLine(@"Podana wartość nie jest liczba. Kończe zadanie"); return;
                }
            }

            if (parForFun[0].Item2 == 0) { Console.WriteLine(@"\n To nie równanie kwadratowe {0} wynosi {1}", parForFun[0].Item1, parForFun[0].Item2); return; }

            double delta = Math.Pow(parForFun[1].Item2,2) - 4 * parForFun[0].Item2 * parForFun[2].Item2;//∆=b2−4ac

            Console.WriteLine("Wynik równania: {0}x2+{1}x+{2}=0", parForFun[0].Item2, parForFun[1].Item2, parForFun[2].Item2);
            switch (delta)
            {
                case double _ when (delta == 0):
                    {
                        double x1 = -parForFun[1].Item2 / (2 * parForFun[0].Item2);//-b / (2 * a)
                        Console.WriteLine("Równanie ma jeden pierwiastek (podwójny):{0}", x1);
                        break;
                    }
                case double _ when (delta > 0):
                    {
                        double x1 = (-parForFun[1].Item2 + Math.Sqrt(delta)) / (2 * parForFun[0].Item2);
                        double x2 = (-parForFun[1].Item2 - Math.Sqrt(delta)) / (2 * parForFun[0].Item2);
                        Console.WriteLine("Równanie ma dwa pierwiastki. x1={0} i x2={1}", x1, x2);
                        break;
                    }
                case double _ when (delta < 0):
                    {
                        Console.WriteLine("Równanie ma zero pierwiastków, nie ma rozwiązania");
                        break;
                    }
            }
        }
        enum CalculatorOpt
        {
            Dodawanie,
            Odejmowanie,
            Mnozenie,
            Dzielenie,
        }
        public static void EndZad()
        {
            WriteLine(@"Podana wartość nie jest liczba. Kończe zadanie"); return;
        }
        public static void Zad7()
        {
            WriteLine("Calculator konsolowy" + Environment.NewLine);
            WriteLine("Wybierze dzialanie z listy, wpisujac odpowiedni FundNumber");

            for (byte loopB=0; loopB < 4; loopB++)
            {
                dynamic wd = (CalculatorOpt)loopB;
                WriteLine("\t {0} FundNumber: {1}",wd, loopB);
            }
            if (int.TryParse(StaticFunction.RemLetters(ReadLine()), out int met) != true && ( met>=0 & met <= 3))
            {
                WriteLine(@"Podana wartość nie jest liczba. Kończe zadanie"); return;
            }

            double? parA = 0; double? parB = 0;

            for (byte loopB = 1; loopB <= 2; loopB++)
            {
                WriteLine("Podaj parametr {0}",loopB);
                if (Double.TryParse(StaticFunction.RemLetters(ReadLine()), out double val) != true)
                {
                    WriteLine(@"Podana wartość nie jest liczba. Kończe zadanie"); return;
                }
                if (loopB == 1) parA = val;
                    else parB = val;
            }
            switch (met)
            {
                case 0:
                    WriteLine($"Twój wynik: {parA} + {parB} = " + (parA + parB)); break;
                case 1:
                    WriteLine($"Twój wynik: {parA} - {parB} = " + (parA - parB)); break;
                case 2:
                    WriteLine($"Twój wynik: {parA} * {parB} = " + (parA * parB)); break;
                case 3:
                    WriteLine($"Twój wynik: {parA} / {parB} = " + (parA / parB)); break;
                default:
                    WriteLine($"Wybrana niepoprawna funkcja: {0}", met); break;
            }
        }
        public static void Zad8()
        {
            WriteLine("Podaj rok by dowiedziec czy to był rok przestępny");
            if (int.TryParse(StaticFunction.RemLetters(ReadLine()), out int year) != true )
            {
                WriteLine(@"Podana wartość nie jest rokiem. Kończe zadanie"); return;
            }
            if (DateTime.IsLeapYear(year)) WriteLine(@"Rok {0} jest rokiem przestepnym",year);
                else WriteLine(@"Rok {0} jest rokiem nieprzestępny", year);
        }
        public static void Zad9()
        {
            WriteLine("Sprawdzanie czy 3 liczby stanowią trójkę pitagorejską. Liczby podaj prosze odzielające jedną od drugiej przecinkiem ',' ");
            var numberAll = StaticFunction.RemLetters(ReadLine());
            long[] vektorOfNum = Array.ConvertAll(numberAll.Split(new char[] { ' ', ',', '.', '?' },
                                                StringSplitOptions.RemoveEmptyEntries), long.Parse);
            if(vektorOfNum.Length!= 3)
            {
                {
                    WriteLine(@"Nie podano trzech liczb a {0}. Kończe zadanie", vektorOfNum.Length); return;
                }
            }
            vektorOfNum = StaticFunction.BubbleSortObje(true, vektorOfNum);
            string txtFromNum = string.Join(",", vektorOfNum);
            if (Math.Pow(vektorOfNum[0], 2) == (Math.Pow(vektorOfNum[1], 2) + Math.Pow(vektorOfNum[2], 2)))
                    WriteLine(@"Liczby: {0} stanowią trójke pitagorejską", txtFromNum);
               else WriteLine(@"Liczby: {0} nie stanowią trójke pitagorejską", txtFromNum);
        }
        public static void Zad10()
        {
            WriteLine("Obliczanie silni. Podaj prosze liczbę całkowitą");
            if (uint.TryParse(StaticFunction.RemLetters(ReadLine()), out uint natNum) != true)
            {
                WriteLine(@"Nie jest liczbą naturalną"); return;
            }
            var ss = new Program();
            long factor = ss.Silnia(natNum);
            WriteLine("Wynik silni to: " + factor);
        }
        public long Silnia(long fnum)
        {// rekurencja trzeba zapytac jak spradzic ile razy mogę wylołac ta sama funkcje z siebie za nim zabraknie miejsca na staku
            if (fnum == 0)
                return 1;
            else
                return (fnum * Silnia(fnum - 1));
        }
        public static void Zad11()
        {
            uint natNum;
            WriteLine("Sprawdzanie czy liczba jest pierwsza? Podaj jakomś liczbę naturalną by sprawdzić czy jest pierwsza");
            if (uint.TryParse(StaticFunction.RemLetters(ReadLine()), out natNum) != true)
            {
                WriteLine(@"Nie jest liczbą, bądź nie jest całkowita lub jest mniejsza niz 0"); return;
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("Liczba: " + natNum);

            if (StaticFunction.IsNumPrime((int)natNum) != true)
                sb.Append(" nie");
            //int[] numArr = Enumerable.Range(0, 9).ToArray();
            //Array.Reverse(numArr);
            sb.Append(" jest liczbą pierwszą");
            WriteLine(sb.ToString());
        }
         public static void Main2()
        {
            int liczba;
            liczba = Int32.Parse(Console.ReadLine());

            int wynik = (liczba % 2 == 0) ? 0 : 1;
            Console.WriteLine("Wynik {0}", wynik);
            
        }
        public static void Zad2New()
        {
            int[] dane = Enumerable.Range(0, 10).ToArray();
            Array.Reverse(dane);
            StringBuilder sb = new StringBuilder(); 
            foreach (int number in dane) 
            {
                sb.AppendLine($"dane[{number}] = {dane[number]}");
            }
            WriteLine(sb.ToString());

        }
        public static void zad3New()
        {
            int[] uczestnicyWycieczki = { 26, 34, 23, 54, 31 };
                int sum = uczestnicyWycieczki.Sum();
                double srednia= uczestnicyWycieczki.Average();
                int wieknajstarszy = uczestnicyWycieczki.Max();
                int najmlodszy= uczestnicyWycieczki.Min();
            string[] imiona = new string[10];
        }
        public static void zad6New()
        {
            int len = 10;
            int[,] macierz = new int[len, len];
            for (int y = 0; y < len; y++)
            {
                WriteLine();
                for (int x = 0; x < len; x++)
                {
                    int min = y == x ? 1 : 0;
                    macierz[y, x] = min;
                    Write(min);

                }
            } 
        }
        public static void zad7New()
        {

            double[,] tabela_2w = new double[10, 10];
            string wynik = "";
            int i, j;
            double suma1 = 0, suma2 = 0;
            for (i = 0; i < 10; i++)
            {
                for (j = 0; j < 10; j++)
                {
                    tabela_2w[i, j] = i > 0 && j == 0 ? tabela_2w[i - 1, j] + 1 : i > 0 && j == 1 ? tabela_2w[i, j - 1] *
                        tabela_2w[i, j - 1] : 0;
                    wynik += tabela_2w[i, j] + " ";
                    suma1 = j == 0 ? suma1 + tabela_2w[i, j] : suma1 + 0;
                    suma2 = j == 1 ? suma2 + tabela_2w[i, j] : suma2 + 0;
                }
                wynik += "\n";
            }
            Console.WriteLine(wynik);
            Console.WriteLine("Suma liczb znajdujących się w pierwszej kolumnie = " + suma1);
            Console.WriteLine("Suma liczb znajdujących się w drugiej kolumnie = " + suma2);

        }
        public static void zad8New()
        {
            string[] imiona = { "Ala", "Agata", "Ela", "Gienia", "Ola", "Ela", "Tola", "Ela"};
            string[] imiona2 = { "Ala", "Ela" };
            int index=Array.IndexOf(imiona, "Ala");
          

            foreach (string imie in imiona2)
            {
                Write(index.ToString());
            }

            ReadLine();
        }
        public static void zad9new()
        {
            int len = 1000;
            long suma=0;
            long bettersum = 0;
            int[] dane = Enumerable.Range(1, len).ToArray();

            foreach(int numer in dane)
            {
                suma += numer;
            }
            bettersum=dane.Sum();

            WriteLine("Pierwszy sum {0}. Drugi sum: {0}", suma.ToString(), bettersum.ToString());
           

        }
        public delegate string OperacjanaStringInt(string txt, int num);

        public static string AddIntToString(string txt, int num)
        {
            return txt + num.ToString();
        }
        public static string AddStringToInt(string txt, int num)
        {
            return num.ToString() + txt;
        }
        private static void TryDelegate()
        {
            OperacjanaStringInt OpSI = new OperacjanaStringInt(AddIntToString);
            var result = OpSI("hej", 2);
            WriteLine(result);
            OpSI = AddStringToInt;
            result = OpSI("hej", 2);
            WriteLine(result);
            ReadKey();
        }
    }

}   

 