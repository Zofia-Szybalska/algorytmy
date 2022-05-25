using System;
using System.Collections.Generic;

namespace lab_11 {
    class Program {
        interface IGraph {
            public bool AddEdge(int start, int end, int weight = 1);
            public bool AddDirectedEdge(int start, int end, int weight = 1);
            public bool RemoveEdge(int start, int end);
            public bool RemoveDirectedEdge(int start, int end);
        }
        class AdGraph : IGraph {
            int[,] _matrix;
            public AdGraph(int n) {
                _matrix = new int[n, n];
            }
            public bool AddEdge(int start, int end, int weight = 1) {
                if (start >= _matrix.GetLength(0) || end >= _matrix.GetLength(0))
                    return false;

                _matrix[start, end] = weight;
                _matrix[end, start] = weight;
                return true;
            }
            public bool AddDirectedEdge(int start, int end, int weight = 1) {
                if (start >= _matrix.GetLength(0) || end >= _matrix.GetLength(0))
                    return false;

                _matrix[start, end] = weight;
                return true;
            }
            public bool RemoveEdge(int start, int end) {
                return AddEdge(start, end, 0);
            }
            public bool RemoveDirectedEdge(int start, int end) {
                return AddDirectedEdge(start, end, 0);
            }
            public override string ToString() {
                string r = "";
                for (int row = 0; row < _matrix.GetLength(0); row++) {
                    for (int col = 0; col < _matrix.GetLength(1); col++) {
                        if (_matrix[row, col] != 0) {
                            r += $"edge ({row}, {col})\n";
                        }
                    }
                }
                return r;
            }
        }
        class InGraph : IGraph {
            int[,] _matrix;
            int edge = 0;
            public InGraph(int vertex, int edges) {
                _matrix = new int[vertex, edges];
            }
            public bool AddDirectedEdge(int start, int end, int weight = 1) {
                if (start >= _matrix.GetLength(0) || end >= _matrix.GetLength(1) || edge == _matrix.GetLength(1))
                    return false;
                _matrix[start, end] = 1;
                _matrix[end, start] = -1;
                edge++;
                return true;
            }
            public bool AddEdge(int start, int end, int weight = 1) {
                if (start >= _matrix.GetLength(0) || end >= _matrix.GetLength(1) || edge == _matrix.GetLength(1))
                    return false;
                _matrix[start, end] = 1;
                _matrix[end, start] = 1;
                edge++;
                return true;
            }

            public bool RemoveDirectedEdge(int start, int end) {
                if (start >= _matrix.GetLength(0) || end >= _matrix.GetLength(1))
                    return false;

                for (int col = 0; col < _matrix.GetLength(1); col++) {
                    if (_matrix[start, col] == 1 && _matrix[end, col] == -1) {
                        _matrix[start, col] = 0;
                        _matrix[end, col] = 0;
                        return true;
                    }
                }
                return false;
            }

            public bool RemoveEdge(int start, int end) {
                if (start >= _matrix.GetLength(0) || end >= _matrix.GetLength(1))
                    return false;

                for (int col = 0; col < _matrix.GetLength(1); col++) {
                    if (_matrix[start, col] == 1 && _matrix[end, col] == -1) {
                        _matrix[start, col] = 0;
                        _matrix[end, col] = 0;
                        return true;
                    }
                }
                return false;
            }
        }
        class Edge : IComparable<Edge> {
            public int Node { get; set; }
            public double Weight { get; set; }

            public int CompareTo(Edge other) {
                return Weight.CompareTo(other.Weight);
            }
        }
        class Graph {
            public Dictionary<int, List<Edge>> Edges = new Dictionary<int, List<Edge>>();
            public void AddDirectedEdge(int source, int destination, double weight) {
                if (!Edges.ContainsKey(source))
                    Edges.Add(source, new List<Edge>());
                if (!Edges.ContainsKey(destination))
                    Edges.Add(destination, new List<Edge>());
                Edges[source].Add(new Edge { Node = destination, Weight = weight });
            }
            public void AddUnDirectedEdge(int source, int destination, double weight) {
                AddDirectedEdge(source, destination, weight);
                AddDirectedEdge(destination, source, weight);
            }
            public void BFTraversal(int start, Action<int> action) {
                Queue<int> queue = new Queue<int>();
                ISet<int> visited = new HashSet<int>();
                queue.Enqueue(start);
                while (queue.Count > 0) {
                    var node = queue.Dequeue();
                    if (visited.Contains(node))
                        continue;

                    action.Invoke(node);
                    visited.Add(node);
                    foreach (var child in Edges[node])
                        queue.Enqueue(child.Node);
                }
            }
            //algorytm Dijkstry
            public double[] GetDistances(int start) {
                var distances = new double[Edges.Count + 1];
                var previous = new int[Edges.Count + 1];
                Array.Fill<double>(distances, int.MaxValue);
                distances[0] = -1;
                var queue = new Queue<int>();
                BFTraversal(start, s => queue.Enqueue(s));
                distances[start] = 0;
                previous[start] = start;
                while (queue.Count > 0) {
                    var node = queue.Dequeue();
                    foreach (var edge in Edges[node]) {
                        if (distances[edge.Node] > distances[node] + edge.Weight) {
                            distances[edge.Node] = distances[node] + edge.Weight;
                            previous[edge.Node] = node;
                        }
                    }
                }
                return distances;
            }
        }
        static void Main(string[] args) {
            /*var graph = new AdGraph(5);
            graph.AddEdge(1, 4);
            graph.AddEdge(3, 4);
            graph.AddEdge(2, 4);
            //Console.WriteLine(graph.ToString());
            var graph2 = new AdGraph(3);
            graph2.AddDirectedEdge(0, 1);
            graph2.AddDirectedEdge(1, 2);
            graph2.AddDirectedEdge(2, 1);
            graph2.AddDirectedEdge(1, 0);
            Console.WriteLine(graph2.ToString());*/
            Graph graph = new Graph();
            graph.AddDirectedEdge(1, 2, 1);
            graph.AddDirectedEdge(1, 3, 2);
            graph.AddDirectedEdge(1, 4, 3);
            graph.AddDirectedEdge(2, 5, 4);
            graph.AddDirectedEdge(5, 6, 5);
            graph.AddDirectedEdge(3, 6, 6);
            graph.AddDirectedEdge(4, 6, 7);
            graph.BFTraversal(2, n => Console.Write(n + " "));
        }
    }
}
