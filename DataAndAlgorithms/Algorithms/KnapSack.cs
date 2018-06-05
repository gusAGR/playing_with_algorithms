using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace Algorithms
{
    /// <summary>
    /// Implementation of KnapSack integer problem using dynamic programming to solve it.
    /// </summary>
    public class KnapSack
    {
        /// <summary>
        /// Gets de maximun benefit and the volumes of the elements included in the knapsack which solve the problem.
        /// </summary>
        /// <param name="maxWeight">Maximun weight allowed in the knapsack</param>
        /// <param name="volumes">Array with the element volumes.</param>
        /// <param name="benefits">Array with the benefit of each element. The n benefit elements corresponds with the n volumes element</param>
        /// <param name="numberOfElements">Number of elements</param>
        /// <returns> Tuple </returns>
        public (int benefit, List<int> elements) GetMaxBenefit(int maxWeight, int[] volumes, int[] benefits, int numberOfElements)
        {
            List<int> elements = new List<int>();

            int[,] benefitsMatrix = GenerateMatrix(maxWeight, volumes, benefits, numberOfElements);

            int maxBenefit = benefitsMatrix[numberOfElements, maxWeight];

            for (int row = numberOfElements; row >= 0 && maxWeight > 0; row--)
            {
                if (benefitsMatrix[row, maxWeight] != benefitsMatrix[row - 1, maxWeight])
                {
                    int volume = volumes[row-1];
                    elements.Add(volume);
                    maxWeight -= volume;
                }
            }

            return (maxBenefit, elements);
        }

        /// <summary>
        /// Generate a matrix with all the possible solutions.
        /// </summary>
        /// <returns>Two dimension array of ints</returns>
        public int[,] GenerateMatrix(int maxWeight, int[] volumes, int[] benefits, int numberOfElements) {

            int[,] benefitsMatrix = new int[numberOfElements +1, maxWeight +1];

            for (int volume = 1; volume <= numberOfElements; volume++) {
                int originalIndex = volume - 1;
                for (int weight = 1; weight <= maxWeight; weight++)
                {
                    if (volumes[originalIndex]> weight)
                    {
                        benefitsMatrix[volume, weight] = benefitsMatrix[volume - 1, weight];
                    }
                    else
                    {
                        benefitsMatrix[volume, weight] = Math.Max(benefitsMatrix[volume - 1, weight], benefitsMatrix[volume - 1, weight - volumes[originalIndex]] + benefits[originalIndex]);
                    }
                }
            }

            return benefitsMatrix;
        }

    }
}
