












using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
namespace AlgorithmsTest
{
    using Algorithms;
    using DataStructures;
    public class KnapSackTest
    {

        int maxWeight = 8;
        int expectedBenefit = 19;

        [Fact]
        public void SolveUsingDynamicProgramming()
        {
            int[] volumes = new int[] { 1, 3, 4, 5, 7 };
            int[] benefits = new int[] { 2, 5, 10, 14, 15 };
            List<int> expectedElements = new List<int>() { 5, 3 };

            int numberOfElelments = volumes.Length;
            var dynamicExample = new DynamcProgramming();
            
            var knapSackResult = dynamicExample.GetKnapSackMaxBenefit(maxWeight, volumes, benefits, numberOfElelments);

            Assert.Equal(expectedBenefit, knapSackResult.benefit);
            Assert.Equal(expectedElements, knapSackResult.elements);



        }

        [Fact]
        public void SolveUsingBranchAndBound() {

            List<Item> items = new List<Item>();
            
            Item item1 = new Item() { Weigth = 1, Value = 2 };
            Item item2 = new Item() { Weigth = 3, Value = 5 };
            Item item3 = new Item() { Weigth = 4, Value = 10 };
            Item item4 = new Item() { Weigth = 5, Value = 14 };
            Item item5 = new Item() { Weigth = 7, Value = 15 };
            items.Add(item1);
            items.Add(item2);
            items.Add(item3);
            items.Add(item4);
            items.Add(item5);

            BranchAndBound branchAndBound = new BranchAndBound();
            branchAndBound.SolveKnapSack(items, maxWeight);


                        
        }

        
    }

   
}
