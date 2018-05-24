using System;
using System.Collections.Generic;

namespace Algorithms
{
    using DataStructures;
    using System.Linq;

    public class Dijkstra
    {

        /// <summary>
        /// Generates the shortest path to each node starting from the given origin node. If the origin node
        /// doesn't belong to the graph, then returns an empty dictionary.
        /// </summary>
        /// <param name="origin">Initial node</param>
        /// <param name="graph">Node structure that you are going to analize.</param>
        /// <returns>Returns</returns>
        public Dictionary<int, List<int>> FindShortestPath(int origin, Graph<int> graph) {

            int collectionsSize = graph.Count - 1;
            List<int> pendings = new List<int>(collectionsSize);
            Dictionary<int, List<int>> paths = new Dictionary<int, List<int>>(collectionsSize);
            Dictionary<int, int> specialPath = new Dictionary<int, int>(collectionsSize);

            GraphNode<int> originNode = (GraphNode<int>) graph.Nodes.FindByValue(origin);
            if (originNode != null)
            {
                foreach (GraphNode<int> node in graph.Nodes)
                {
                    if (node.Value != origin)
                    {
                        pendings.Add(node.Value);
                        List<int> path = new List<int> { origin };
                        paths.Add(node.Value, path);
                        specialPath.Add(node.Value, GetDistance(originNode.Value, node.Value, graph));
                    }
                }

                while (pendings.Count > 0)
                {
                    Dictionary<int, int> specialPathOfPendings = specialPath.Where(kv => pendings.Contains(kv.Key)).ToDictionary(i => i.Key, i => i.Value);
                    int nodeIdWithMinPath = GetNodeIdWithMinPath(specialPathOfPendings);
                    pendings.Remove(nodeIdWithMinPath);

                    foreach (int pendingNode in pendings)
                    {
                        int nodeDistance = specialPath[pendingNode];
                        int distanceBetweenThem = GetDistance(nodeIdWithMinPath, pendingNode, graph);
                        if (distanceBetweenThem != Int32.MaxValue)
                        {
                            int candidateDistance = specialPath[nodeIdWithMinPath] + distanceBetweenThem;
                            if (nodeDistance == Int32.MaxValue) {
                                paths[pendingNode].Add(nodeIdWithMinPath);
                            } else
                            {
                                List<int> pendingNodePath = paths[pendingNode];
                                pendingNodePath.Insert(pendingNodePath.Count - 1, nodeIdWithMinPath);
                            }
                        }
                    }
                }
            }
            return paths;
        }

        /// <summary>
        /// Gets the value of a directed edge between two nodes if they are linked. It they aren't, it returns Int32.Max32 value.
        /// </summary>
        /// <param name="nodeId">origin node</param>
        /// <param name="otherNodeId">target node</param>
        /// <param name="graph">graph where we are going to search</param>
        /// <returns></returns>
        protected int GetDistance(int nodeId, int otherNodeId, Graph<int> graph)
        {
            int distance = Int32.MaxValue; 
            GraphNode<int> node = (GraphNode<int>)graph.Nodes.FindByValue(nodeId);
            GraphNode<int> otherNode = (GraphNode<int>)graph.Nodes.FindByValue(otherNodeId);

            int index = node.Neighbors.IndexOf(otherNode);
            if (index>=0)
            {
                distance = node.Costs[index];
            }
            return distance;
        }

        protected int GetNodeIdWithMinPath(Dictionary<int, int> specialPath)
        {
            int currentValue = specialPath.Values.First<int>(); ;
            int currentId = specialPath.Keys.First<int>(); ;

            if (specialPath.Count > 1)
            {
                for (int i = 1; i < specialPath.Keys.Count; i++)
                {
                    KeyValuePair<int, int> kv = specialPath.ElementAt(i);
                    if (kv.Value < currentValue)
                    {
                        currentValue = kv.Value;
                        currentId = kv.Key;
                    }
                }
            }

            return currentId;
        }
    }
}
