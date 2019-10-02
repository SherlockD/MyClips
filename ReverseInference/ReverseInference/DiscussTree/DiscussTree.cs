using System;
using ReverseInference.DiscussNode;

namespace ReverseInference.DiscussTree.Tree
{
    public class DiscussTree
    {
        public static DiscussTree Instance;
        
        private Node _root;

        public DiscussTree()
        {
            if (Instance == null)
                Instance = this;
        }

        public void AddDiscuss(Discuss discuss)
        {
            var newNode = new Node(discuss.ObjectName, discuss.Feature);
            
            if (_root == null)
            {
                _root = newNode;

                var conditionNode = new Node(discuss.ObjectName, discuss.Condition);
                conditionNode.Parent = _root;
                
                newNode.AddReference(conditionNode);
                return;
            }

            var findedNode = FindNode(discuss.ObjectName, discuss.Condition, _root);

            newNode.Parent = findedNode;
            findedNode.AddReference(newNode);
        }
        
        public Node FindNode(string nodeObjectName, string feature, Node node)
        {
            Node result = null;

            if (node.NodeObject == nodeObjectName && node.Feature == feature)
            {
                return node;
            }

            foreach (var item in node.GetReferences())
            {
                result = FindNode(nodeObjectName, feature, item);
                        
                if (result != null)
                    break;
            }

            return result;
        }

        public void PrintTree()
        {
            PrintTreeFromRoot(_root);
        }
        
        private void PrintTreeFromRoot(Node node)
        {
            Console.WriteLine($"{node.NodeObject} : {node.Feature}");
            
            foreach (var item in node.GetReferences())
            {
                PrintTreeFromRoot(item);
            }
        }

        public Node GetRoot() => _root;
    }
}
