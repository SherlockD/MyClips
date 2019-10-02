using System.Collections.Generic;

namespace ReverseInference.DiscussTree
{
    public class Node
    {
        public string NodeObject;
        public string Feature;

        public Node Parent;
        private List<Node> _references = new List<Node>();
        
        public Node() {}

        public Node(string nodeObject, string feature)
        {
            NodeObject = nodeObject;
            Feature = feature;
        }

        public void AddReference(Node node)
        {
            _references.Add(node);
        }
        
        public Node GetReference(string feature) => _references.Find(node => node.Feature == feature);
        public List<Node> GetReferences() => _references;

        public bool HasFeature(string feature) => GetReference(feature) != null;
    }
}