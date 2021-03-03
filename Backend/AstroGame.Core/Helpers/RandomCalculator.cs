using System;
using System.Collections.Generic;
using System.Linq;

namespace AstroGame.Core.Helpers
{
    public static class RandomCalculator
    {
        public static readonly Random Random = new Random();

        /*public static T SelectByWeight<T>(List<KeyValuePair<T, double>> weights)
        {
            var diceRoll = Random.NextDouble();

            var cumulative = 0.0d;
            for (var i = 0; i < weights.Count; i++)
            {
                cumulative += weights[i].Value;

                if (!(diceRoll < cumulative)) continue;

                var selectedElement = weights[i].Key;
                return selectedElement;
            }

            return default(T);
        } */

        public static T SelectByWeight<T>(List<KeyValuePair<T, uint>> weights)
        {
            var size = weights.Sum(w => w.Value);
            var arr = new T[size];

            var position = 0;

            foreach (var w in weights)
            {
                for (var j = 0; j < w.Value; j++)
                {
                    arr[position] = w.Key;
                    position++;
                }
            }

            var selectedItem = Random.Next(0, (int) size);

            return arr[selectedItem];
        }
    }
}