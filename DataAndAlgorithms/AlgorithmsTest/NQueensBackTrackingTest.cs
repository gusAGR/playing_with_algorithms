using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AlgorithmsTest
{
    using Algorithms;

    public class NQueensBackTrackingTest 
    {

        [Fact]
        public void GivenOneQueenWhenSolveNQueensThenReturnEmptyList() {

            int queens = 1;
            
            Backtraking nqueens = new Backtraking();
            List<List<int>> result = nqueens.SolveNqueensProblem(queens);

            Assert.True(result.Count==0);

        }

        [Fact]
        public void GivenThreeQueenWhenSolveTNQueensThenEmptyList()
        {

            int queens = 3;

            Backtraking nqueens = new Backtraking();
            List<List<int>> result = nqueens.SolveNqueensProblem(queens);

            Assert.True(result.Count == 0);

        }

        [Fact]
        public void GivenFourQueenWhenSolveNQueensThenReturnOk()
        {

            int queens = 4;
            List<List<int>> expected = new List<List<int>>(2);
            List<int> solution1 = new List<int>() { 1, 3, 0, 2 };
            List<int> solution2 = new List<int>() { 2, 0, 3, 1 };
            expected.Add(solution1);
            expected.Add(solution2);

            Backtraking nqueens = new Backtraking();
            List<List<int>> result = nqueens.SolveNqueensProblem(queens);

            Assert.Equal<List<int>>(expected, result);
        }
    }
}
