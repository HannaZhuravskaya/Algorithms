using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Custom
{
    public class GenerateCountriesGroupTask
    {
        // By memory
        public List<string> GenerateCountriesGroup(List<string> countries, int numberOfCountriesToPick = 5)
        {
            if (numberOfCountriesToPick > countries.Count)
                throw new ArgumentOutOfRangeException(nameof(numberOfCountriesToPick));

            if (numberOfCountriesToPick == countries.Count)
                return countries;

            var pickedCountries = new Dictionary<int, string>();
            var rand = new Random();

            while (pickedCountries.Count < numberOfCountriesToPick)
            {
                int index = rand.Next(0, countries.Count - 1);

                if (!pickedCountries.ContainsKey(index))
                    pickedCountries.Add(index, countries[index]);
            }

            return pickedCountries.Select(c => c.Value).ToList();
        }

        /*
         n = 4
            [1] USA, China -> 1
            [2] Germany, France, Italy, Spain -> 2
            [3] Andorra, Malta -> 1

        n = 5
            [1] USA, China -> 1 or 2
            [2] Germany, France, Italy, Spain -> 2 or 3
            [3] Andorra, Malta -> 1 or 2
        */
        public List<string> GenerateGoodCountriesGroup(List<List<string>> countriesBuckets, int numberOfCountriesToPick = 5)
        {
            var numOfCountries = 0;
            foreach (var bucket in countriesBuckets)
            {
                numOfCountries += bucket.Count;
            }

            if (numberOfCountriesToPick > numOfCountries)
                throw new ArgumentOutOfRangeException(nameof(numberOfCountriesToPick));

            // Cast int to double
            // Error: var coeff = numberOfCountriesToPick / numOfCountries;
            var coeff = (double)numberOfCountriesToPick / numOfCountries;

            var pickedCountries = new List<string>();
            var bucketsToUse = new Stack<List<string>>();

            foreach (var bucket in countriesBuckets)
            {
                var bucketCoeff = coeff * bucket.Count;

                // Different method name, cast to decimal and then to int.
                // Error: var min = Math.Floor(bucketCoeff);
                // Error: var max = Math.Ceil(bucketCoeff);

                var min = (int)Math.Floor((decimal)bucketCoeff);
                var max = (int)Math.Ceiling((decimal)bucketCoeff);

                if (min != max)
                {
                    bucketsToUse.Push(bucket);
                }

                pickedCountries.AddRange(GenerateCountriesGroup(bucket, min));
            }

            while (pickedCountries.Count < numberOfCountriesToPick)
            {
                var bucket = bucketsToUse.Pop();

                while (true)
                {
                    //Error: var newCountry = GenerateCountriesGroup(bucketsToUse.Pop(), 1)[0];
                    var newCountry = GenerateCountriesGroup(bucket, 1)[0];

                    if (!pickedCountries.Contains(newCountry))
                    {
                        pickedCountries.Add(newCountry);
                        break;
                    }
                }
            }

            return pickedCountries;
        }

        public static void Test()
        {
            var data = new List<List<string>>(){
                new List<string>(){"USA", "China"},
                new List<string>(){"Germany", "France", "Italy", "Spain"},
                new List<string>(){"Andorra", "Malta"}
            };

            var obj = new GenerateCountriesGroupTask();
            var result = obj.GenerateGoodCountriesGroup(data, 4);
            result = obj.GenerateGoodCountriesGroup(data, 5);
        }
    }
}