using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    using DataStructures;
    using System.Linq;
    public class BranchAndBound
    {

        protected class Node
        {
            public Node(int elements) {
                BackSack = new bool[elements];
            }

            public bool[] BackSack { get; set; }
            public int Depth { get; set; }
            public float TotalWeight { get; set; }
            public float TotalValue { get; set; }
            public float OptimisticEstimation { get; set; }
        }

        protected class NodeComparer : IComparer<Node>
        {
            public int Compare(Node x, Node y)
            {
                int result;
                if (x.OptimisticEstimation > y.OptimisticEstimation)
                {
                    result = 1;
                }
                else if (x.OptimisticEstimation < y.OptimisticEstimation)
                {
                    result = -1;
                }
                else {
                    result = 0;
                }

                return result;
            }
        }


        public (float weight, List<Item> items) SolveKnapSack(List<Item> items, int maxWeight)
        {
            float solutionValue = 0, lowerBound = 0;
            bool[] backSack = new bool[items.Count];

            NodeComparer nodeComparer = new NodeComparer();
            SortedSet<Node> pendingNodes = new SortedSet<Node>(nodeComparer);
                        
            items.OrderByDescending(x => x.getSpecificValue());

            Node node = new Node(items.Count);
            node.OptimisticEstimation = GetOptimisticEstimation(items, node, maxWeight);
            node.Depth = 0;
            pendingNodes.Append(node);
            lowerBound = GetPesimisticEstimation(items, node, maxWeight);
            while(pendingNodes.Count>0 && pendingNodes.First<Node>().OptimisticEstimation > lowerBound )
            {
                node = pendingNodes.First<Node>();
                pendingNodes.Remove(node);

                Node childNode = new Node(items.Count)
                {
                    Depth = node.Depth + 1
                };
                Array.Copy(childNode.BackSack, backSack, backSack.Length);

                Item nextItemToInclude = items[childNode.Depth];
                float childWeight = node.TotalWeight + nextItemToInclude.Weigth;

                if (childWeight < maxWeight)
                {
                    childNode.BackSack[childNode.Depth] = true;
                    childNode.TotalWeight = childWeight;
                    childNode.TotalValue = nextItemToInclude.Value;
                    childNode.OptimisticEstimation = node.OptimisticEstimation;
                    if (childNode.Depth == items.Count - 1)
                    {
                        if (solutionValue < childNode.TotalValue)
                        {
                            Array.Copy(childNode.BackSack, backSack, backSack.Length);
                            solutionValue = childNode.TotalValue;
                            lowerBound = childNode.TotalValue;

                        }
                    }
                    else
                    {
                        pendingNodes.Add(childNode);
                    }
                }
                else {
                    childNode.OptimisticEstimation = GetOptimisticEstimation(items, childNode, maxWeight);
                    if (childNode.OptimisticEstimation > lowerBound) {
                        childNode.BackSack[childNode.Depth] = false;
                        childNode.TotalWeight = node.TotalWeight;
                        childNode.TotalValue = node.TotalValue;
                        if (childNode.Depth == items.Count - 1)
                        {
                            if (solutionValue < childNode.TotalValue)
                            {
                                Array.Copy(childNode.BackSack, backSack, backSack.Length);
                                solutionValue = childNode.TotalValue;
                                lowerBound = childNode.TotalValue;

                            }
                        }
                        else
                        {
                            pendingNodes.Add(childNode);
                            float pesimisticEstimacion = GetPesimisticEstimation(items, childNode, maxWeight);
                            if (lowerBound < pesimisticEstimacion) {
                                lowerBound = pesimisticEstimacion;
                            }
                        }

                    }
                }


            }
            
            List<Item> includedItems = new List<Item>();
            for (int i = 0; i < backSack.Length; i++) {
                if (backSack[0]) {
                    includedItems.Add(items[i]);
                }
            }


            return (solutionValue, includedItems);
        }
        
        /// <summary>
        /// Generates an optimistic stimation of the solution that we could achieve with this node.
        /// It takes the total value of the items included in the bag. Then, try to adds new objects ordered by  specific value in descending order.
        /// If the object fits in the backsack, its value is included in the bag. If not,
        /// it includes the fraction of value that corresponds with the fraction of weight that could be included.
        /// </summary>
        /// <returns>float</returns>
        protected float GetOptimisticEstimation(List<Item> items, Node node, int maxWeight) {

            float capacity = maxWeight - node.TotalWeight;
            float estimation = node.TotalValue;

            for (int i= node.Depth-1; i<items.Count; i++)
            {
                Item item = items[i];
                if (item.Weigth <= capacity)
                {
                    estimation += item.Value;
                    capacity -= item.Weigth;
                }
                else
                {
                    estimation+= (capacity * item.getSpecificValue());
                }
            }
            return estimation;
        }

        /// <summary>
        /// Calculates a pesimistic estimation of the solution that we can achieve with this node.
        /// It only puts a item into the backsack if it fits.
        /// </summary>
        protected float GetPesimisticEstimation(List<Item> items, Node node, int maxWeight) {

            float capacity = maxWeight - node.TotalWeight;
            float estimation = node.TotalValue;

            for (int i = node.Depth -1; i < items.Count; i++)
            {
                Item item = items[i];
                if (item.Weigth <= capacity)
                {
                    estimation += item.Value;
                    capacity -= item.Weigth;
                }
            }
            return estimation;
        }


    }
}
