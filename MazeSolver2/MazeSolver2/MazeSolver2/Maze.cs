using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeSolver2
{
    public class Maze
    {

        List<Node> AllNodes = new List<Node>();
        string[] ArrayOfInputs;
        Dictionary<string, Node> NodeDict = new Dictionary<string, Node>();
        Dictionary<int, Node> ValidSolutions = new Dictionary<int, Node>();

        public List<Node> FindPath(string start, string end)
        {
            List<Node> ListOfNodes = new List<Node>();
            Node startNode = NodeDict[start];
            Node endNode = NodeDict[end];
            List<Node> nodePath = new List<Node>();
            bool foundSolution = false;
            do
            {
                if (!nodePath.Contains(startNode))
                    nodePath.Add(startNode);            
                if (startNode != endNode)
                {
                    ListOfNodes.Add(startNode);
                    foreach (Node n in startNode.NodesConnected)
                    {
                        if (n == endNode)
                        {
                            nodePath.Add(n);
                            foundSolution = true;
                        }
                        else
                        {
                            ListOfNodes.Add(n);
                            ListOfNodes.RemoveAt(0);                        
                        }
                    }
                }
                startNode = ListOfNodes[0];
            } while (!foundSolution);
            nodePath.Reverse();
            List<Node> tett = new List<Node>();
            Node temp = nodePath[0];
            tett.Add(temp);
            while(temp.NodeID != start)
            {
                temp = temp.NodesConnected[0];
                tett.Add(temp);
            }

            //foreach (Node nk in nodePath)
            //{
            //    temp = nk.NodesConnected[0];
            //    tett.Add(temp);

            //}
            tett.Reverse();
            foreach (Node item in tett)
            {
                Console.WriteLine(item.NodeID);
            }

            return nodePath;
        }
        public void PrintSolution(List<Node> n)
        {
            foreach (Node item in n)
            {
                Console.Write($",{item.NodeID.ToString()}");
            }
        }
        public void BuildMaze(string file)
        {

            List<string> AllInputs = new List<string>();

            //Reading the File and Storing all the inputs 
            foreach (string s in System.IO.File.ReadAllLines(file))
            {
                ArrayOfInputs = new string[s.Length];
                ArrayOfInputs[0] = s.Replace(",", "");
                AllInputs.Add(ArrayOfInputs[0]);
             }

            //Creating new Nodes and storing into a Dictionary for easy access later on
            foreach (char s in AllInputs[0])
            {
                Node newNode = new Node(s.ToString());
                NodeDict.Add(s.ToString(), newNode);
                AllNodes.Add(newNode);
            }

            // get the line with parent + connections
            for (int i = 2; i < AllInputs.Count; i++)
            {
                // for each line, add that node's neighbors
                char[] chars = AllInputs[i].ToCharArray();
                Node parentNode = NodeDict[chars[0].ToString()];

                // go from 1 to n
                for (int k = 1; k < chars.Length; k++)
                {
                    // get next connected node to the parent
                    Node connectedNode = NodeDict[chars[k].ToString()];
                    parentNode.NodesConnected.Add(connectedNode);
                }
            }
            
            Console.Write(this.ToString());
            FindPath(AllInputs[1][0].ToString(), AllInputs[1][1].ToString());
        }
        public void PrintConnect()
        {
            foreach (Node n in AllNodes)
            {
                for (int i = 0; i < n.NodesConnected.Count; i++)
                {
                    Console.WriteLine(n.NodesConnected[i].NodeID);
                }

                break;
            }


        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Node n in AllNodes)
            {
                sb.Append($"{n.ToString()}\n");
            }

            return sb.ToString();
        }
    }
}
