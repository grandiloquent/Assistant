using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using Helpers;
using Newtonsoft.Json;

namespace Assistant
{
    class MockLottery
    {
        private static readonly RNGCryptoServiceProvider _generator = new RNGCryptoServiceProvider();
        public static int Between(int minimumValue, int maximumValue)
        {
            byte[] randomNumber = new byte[1];

            _generator.GetBytes(randomNumber);

            double asciiValueOfRandomCharacter = Convert.ToDouble(randomNumber[0]);

            // We are using Math.Max, and substracting 0.00000000001, 
            // to ensure "multiplier" will always be between 0.0 and .99999999999
            // Otherwise, it's possible for it to be "1", which causes problems in our rounding.
            double multiplier = Math.Max(0, (asciiValueOfRandomCharacter / 255d) - 0.00000000001d);

            // We need to add one to the range, to allow for the rounding done with Math.Floor
            int range = maximumValue - minimumValue + 1;

            double randomValueInRange = Math.Floor(multiplier * range);

            return (int)(minimumValue + randomValueInRange);
        }
        public static (int[], int[]) Random1000()
        {
            //  var ls = new List<Dictionary<string, int>>();
            var array = new int[1000];
            var array1 = new int[1000];
            var j = "marksix.txt".ReadAllLines().Select(i => i.Split('\t').Last()).Select(i => int.Parse(i)).ToArray();
            var jr = Between(1, j.Length);
            while (jr + 1000 > j.Length)
            {
                jr = Between(1, j.Length);
            }
            var ls = new List<string>();

            for (int i = 0; i < 1000; i++)
            {
                var (a, b, c) = SimulateNormal(j.Skip(jr).Take(1000).ToArray());
                ls.Add($"{a}\t{b}\t{c}\n");
                //array[i] = a;
                //array1[i] = b;
                //var dic = new Dictionary<string, int>();
                //dic.Add("expense", a);
                //dic.Add("award", b);
                //dic.Add("hit", c);
                //ls.Add(dic);

            }
            "random1000.csv".GetDesktopPath().WriteAllText(string.Join("", ls));

            // "random1000.txt".GetDesktopPath().WriteAllText(JsonConvert.SerializeObject(ls));
            return (array, array1);
        }
        private static (int, int, int) SimulateNormal(int[] luckies)
        {
            var expense = 0;
            var award = 0;
            var hit = 0;
            var guess = new int[10];
            //var ls = new int[1000]; , int , guess
            for (int i = 0; i < 1000; i++)
            {

                //guess.Contains(lucky)

                var lucky = luckies[i];//Between(1, 49);
                                       // ls[i] = lucky;
                if (lucky % 2 == 0 && lucky <25)
                {
                    award += 5 * 40;
                    expense += (11 * 5);

                    hit++;
                }
                else
                    expense += (12 * 5);
            }
            return (expense, award, hit);
        }

        public static void AnalysisRandom1000()
        {
            var f = "random1000.csv".GetDesktopPath();

            var lines = f.ReadAllLines();
            var t = new char[] { '\t' };
            var e = lines.Select(i => int.Parse(i.Split(t, 2).First())).ToArray();
            var a = lines.Select(i => int.Parse(i.Split(t)[1])).ToArray();
            var h = lines.Select(i => int.Parse(i.Split(t)[2])).ToArray();

            var g = (a.Sum() - e.Sum()) / 1000;
            var j = a.Sum() / 1000;
            var k = e.Sum() / 1000;
            var hmi = h.Min();
            var hmx = h.Max();

            var s = $"{j} {k} {g} {hmx} {hmi}  ";

        }
    }
}
