using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeSolver2
{
    public class Node
    {
        public string NodeID { get; set; }
        public List<Node> NodesConnected { get; set; }

        public Node(string id)
        {
            this.NodeID = id;
            this.NodesConnected = new List<Node>();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Node: {this.NodeID} - ");

            foreach (Node n in NodesConnected)
            {
                if (n == NodesConnected[NodesConnected.Count - 1])
                {
                    sb.Append(n.NodeID);
                }
                else
                {
                    sb.Append($"{n.NodeID}, ");
                }
            }

            return sb.ToString();
        }
    }
}
