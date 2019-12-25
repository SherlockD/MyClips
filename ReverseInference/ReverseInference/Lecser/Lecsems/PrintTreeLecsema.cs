using System;
using ReverseInference.Tree;

namespace ReverseInference.Lecser.Lecsems
{
    public class PrintTreeLecsema : AbstractLecsema
    {
        private DiscussTree _tree = DiscussTree.Instance;

        public override void Initialize()
        {
            Initialize("print-tree");
        }

        protected override void ActionMethod(string[] arguments)
        {
            _tree.PrintTree();   
        }

        protected override void OnBadInput(string message)
        {
            Console.WriteLine($"Something go wrong, on printing tree: {message}");
        }

        public override void PrintDescription()
        {
            Console.WriteLine($"{CommandName}: Вывести дерево");
        }
    }
}
