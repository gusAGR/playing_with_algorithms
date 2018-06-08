using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    using System.Linq;
    public class NQueensBacktraking
    {

        /// <summary>
        /// Solve the N Queens problem.
        /// </summary>
        /// <param name="queens">Number of queens to locate</param>
        /// <param name="solutions">List with all the possible solutions</param>
        public List<List<int>> SolveNqueensProblem(int queens ) {

            List<List<int>> solutions = new List<List<int>>();

            if (queens < 1)
            {
                return solutions;
            }
            else
            {
                List<int> partialComputation = new List<int>(queens);
                SolveNQueensProblem(0, partialComputation, solutions);
            }

            return solutions;
        }

        /// <summary>
        /// Recursive function to solve N Queens problem.
        /// </summary>
        /// <param name="nextColumn">Next column that we have to populate</param>
        /// <param name="partialComputation"> Current partial computation</param>
        /// <param name="solutions">List with all the possible solutions</param>
        protected void SolveNQueensProblem(int nextColumn, List<int> partialComputation, List<List<int>> solutions) {

            int queens = partialComputation.Count;
            if (queens == nextColumn)
            {
                List<int> aux = new List<int>(partialComputation);
                solutions.Add(aux);
            }else {
                for(int row = 0; row < queens; row++)
                {
                    partialComputation.Insert(nextColumn, row);
                    if (IsSuitable(partialComputation)) {
                        SolveNQueensProblem(nextColumn + 1, partialComputation, solutions);
                    }
                }
            }

        }

        /// <summary>
        /// Checks if a partialComputation is suitable for reach a valid solution.
        /// </summary>
        /// <param name="partialComputation">Contains an on going partial computation that could be a solution of the problem.</param>
        /// <returns>False if the last row-flag in the partialComputation it's in the same row or diagonal that a previuos one. True when other. </returns>
        protected bool IsSuitable( List<int> partialComputation) {

            bool suitable = true;
            int lastColum = partialComputation.Count-1;
            int lastColumnValue = partialComputation.Last();
            for (int column = 0; column <= lastColum && suitable; column++) {
                int previosColumnValue = partialComputation[column];
                if ((previosColumnValue == lastColumnValue) || (Math.Abs(previosColumnValue - lastColumnValue) == Math.Abs(lastColum - column)))
                {
                    suitable = false;
                }
            }
            return suitable;
        }


    }
}
