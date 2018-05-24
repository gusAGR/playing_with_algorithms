using System;
using Xunit;
using System.Collections.Generic;
namespace AlgorithmsTest
{
    using Algorithms;
    using DataStructures;
    public class DijkstraTest { 
    
        private Graph<int> GenerateTestGraph()
        {
            Graph<int> graph = new Graph<int>();

            GraphNode<int> one = new GraphNode<int>(1);
            GraphNode<int> two = new GraphNode<int>(2);
            GraphNode<int> three = new GraphNode<int>(3);
            GraphNode<int> four = new GraphNode<int>(4);
            GraphNode<int> five = new GraphNode<int>(5);
            GraphNode<int> six = new GraphNode<int>(6);
            GraphNode<int> seven = new GraphNode<int>(7);
            graph.AddNode(one);
            graph.AddNode(two);
            graph.AddNode(three);
            graph.AddNode(four);
            graph.AddNode(five);
            graph.AddNode(six);
            graph.AddNode(seven);
            graph.AddDirectedEdge(one, two, 10);
            graph.AddDirectedEdge(one, five, 6);
            graph.AddDirectedEdge(two, three, 5);
            graph.AddDirectedEdge(two, four, 2);
            graph.AddDirectedEdge(three, four, 4);
            graph.AddDirectedEdge(four, one, 5);
            graph.AddDirectedEdge(four, one, 5);
            graph.AddDirectedEdge(five, seven, 1);
            graph.AddDirectedEdge(five, six, 9);
            graph.AddDirectedEdge(six, seven, 8);
            graph.AddDirectedEdge(six, four, 3);
            graph.AddDirectedEdge(six, three, 2);

            return graph ;

        }

        private Graph<int> GenerateGraphToRecalculatePath() {

            Graph<int> graph = new Graph<int>();

            GraphNode<int> one = new GraphNode<int>(1);
            GraphNode<int> two = new GraphNode<int>(2);
            GraphNode<int> three = new GraphNode<int>(3);
            GraphNode<int> four = new GraphNode<int>(4);
            graph.AddNode(one);
            graph.AddNode(two);
            graph.AddNode(three);
            graph.AddNode(four);
            graph.AddDirectedEdge(one, two, 7);
            graph.AddDirectedEdge(one, three, 5);
            graph.AddDirectedEdge(two, four, 3);
            graph.AddDirectedEdge(three, four, 15);

            return graph;

        }

        [Fact]
        public void givenGraphWhenDijkstraThenReturnShortestPaths()
        {
            Dictionary<int, List<int>> expected = new Dictionary<int, List<int>>();
            expected.Add(2, new List<int> { 1 });
            expected.Add(3, new List<int> { 1, 2});
            expected.Add(4, new List<int> { 1, 2, 3});
            expected.Add(5, new List<int> { 1});
            expected.Add(6, new List<int> { 1, 5});
            expected.Add(7, new List<int> { 1, 5, 6 });
            Graph <int> graph = GenerateTestGraph();
            Dijkstra dijkstra = new Dijkstra();

            Dictionary<int,List<int>> shortPaths = dijkstra.FindShortestPath(1, graph);

            Assert.Equal(shortPaths, expected);
        }
        
        [Fact]
        public void givenGrapWithTwoPathsWhenDijkstraThenReturnTheShortest() {

            Dictionary<int, List<int>> expected = new Dictionary<int, List<int>>();
            expected.Add(2, new List<int> { 1});
            expected.Add(3, new List<int> { 1});
            expected.Add(4, new List<int> { 1, 2 });
            Graph<int> graph = GenerateGraphToRecalculatePath();
            Dijkstra dijkstra = new Dijkstra();
            
            Dictionary<int, List<int>> shortPaths = dijkstra.FindShortestPath(1, graph);

            Assert.Equal(shortPaths, expected);
        }

    }

}
