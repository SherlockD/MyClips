using System;
using ReverseInference.DiscussNode;
using ReverseInference.Tree;

public class DiscussTree
{
    public static DiscussTree Instance;
        
    private Node _root;

    private int index = 0;

    public DiscussTree()
    {
        if (Instance == null)
            Instance = this;
    }

    public void AddQuestion(Question question)
    {
        index++;
        var yesNode = new Node(question.FeatureOne,index);
        index++;
        var noNode = new Node(question.FeatureTwo, index);

        if (_root == null)
        {
            index++;
            var newNode = new Node("null",index, true, question.QuestionString);

            _root = newNode;

            newNode.AddReference(yesNode);
            newNode.AddReference(noNode);
        }
        else
        {
            var findedNode = FindNode(question.Condition, _root);

            findedNode.IsQuestion = true;

            findedNode.Question = question.QuestionString;

            findedNode.AddReference(yesNode);
            findedNode.AddReference(noNode);
        }
    }
        
    public void AddDiscuss(Discuss discuss)
    {
        index++;
        var newNode = new Node(discuss.Feature,index);

        var findedNode = FindNode(discuss.Condition, _root);

        findedNode.AddReference(newNode);
    }
        
    public Node FindNode(string feature, Node node)
    {
        Node result = null;

        if (node.Feature == feature)
        {
            return node;
        }

        foreach (var item in node.GetReferences())
        {
            result = FindNode(feature, item);
                        
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
        Console.WriteLine($"{node.Feature}");
            
        foreach (var item in node.GetReferences())
        {
            PrintTreeFromRoot(item);
        }
    }

    public Node GetRoot() => _root;
}
