using System;
using System.Collections.Generic;

namespace ReverseInference.Tree
{
    public class Node
    {
        public string Question;
        public string Feature;

        public bool IsQuestion;

        public Node Parent;

        public int Index;

        protected List<Node> _references = new List<Node>();

        public Node() {}

        public Node(string feature,int index, bool isQuestion = false, string question = null)
        {
            Feature = feature;

            IsQuestion = isQuestion;
            Question = question;

            Index = index;
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