using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    public class MaximumUnitsOfTruck
    {
        public int MaximumUnits(int[][] boxTypes, int truckSize)
        {
            Array.Sort<int[]>(boxTypes, new Comparison<int[]>((a1, a2) => a1[1].CompareTo(a2[1])));

            var stack = new Stack<(int boxes, int itemsPerBox)>();
            for (int i = 0; i < boxTypes.Length; ++i)
            {
                stack.Push((boxTypes[i][0], boxTypes[i][1]));
            }

            var usedItems = 0;
            var usedBoxes = 0;

            while (usedBoxes < truckSize && stack.Count > 0)
            {
                var (boxes, itemsPerBox) = stack.Pop();
                var availableBoxes = truckSize - usedBoxes;

                if (boxes < availableBoxes)
                {
                    usedBoxes += boxes;
                    usedItems += boxes * itemsPerBox;
                }
                else
                {
                    usedBoxes += availableBoxes;
                    usedItems += availableBoxes * itemsPerBox;
                }
            }

            return usedItems;
        }
    }
}