using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
namespace AlgorithmsTest
{
    using Algorithms;
    public class KnapSackTest
    {

        [Fact]
        public void Calculate()
        {
            int maxWeight = 8;
            int[] volumes = new int[]  { 1, 3,  4,  5,  7 };
            int[] benefits = new int[] { 2, 5, 10, 14, 15 };
            int numberOfElelments = volumes.Length;
            int expectedBenefit = 19;
            List<int> expectedElements = new List<int>() { 5, 3 };

            KnapSack knapSack = new KnapSack();
            var knapSackResult = knapSack.GetMaxBenefit(maxWeight, volumes, benefits, numberOfElelments);

            Assert.Equal(expectedBenefit, knapSackResult.benefit);
            Assert.Equal(expectedElements, knapSackResult.elements);
            

            
        }
    }

   
}
