using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AlgorithmsTest
{
    using Algorithms;

    public class BacktrackingTest
    {

        [Fact]
        public void GivenOneQueenWhenSolveThenReturnEmptyList() {

            int queens = 1;
            
            NQueensBacktraking nqueens = new NQueensBacktraking();
            List<List<int>> result = nqueens.SolveNqueensProblem(queens);

            Assert.True(result.Count == 0);

        }

        [Fact]
        public void GivenTwoQueenWhenSolveThenReturnEmptyList()
        {

            int queens = 2;

            NQueensBacktraking nqueens = new NQueensBacktraking();
            List<List<int>> result = nqueens.SolveNqueensProblem(queens);

            Assert.True(result.Count == 0);

        }

        [Fact]
        public void GivenThreeQueenWhenSolveThenSolveProblem()
        {

            int queens = 3;

            NQueensBacktraking nqueens = new NQueensBacktraking();
            List<List<int>> result = nqueens.SolveNqueensProblem(queens);

            Assert.True(result.Count == 0);

        }
    }
}
