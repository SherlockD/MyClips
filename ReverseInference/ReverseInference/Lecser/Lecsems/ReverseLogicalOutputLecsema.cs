using System;
using System.ComponentModel;
using ReverseInference.DiscussTree;

namespace ReverseInference.Lecser.Lecsems
{
    public class ReverseLogicalOutputLecsema : AbstractLecsema
    {
        public override void Initialize()
        {
            Initialize("reverse-logical-output");
        }

        protected override void ActionMethod(string[] arguments)
        {
            var discussTree = DiscussTree.Tree.DiscussTree.Instance;
            
            PrintToParent(discussTree.FindNode(arguments[1],arguments[2],discussTree.GetRoot()));
        }

        protected override void OnBadInput()
        {
            Console.WriteLine("Ошибка при выводе обратного логического вывода, проверьте ввод");
        }

        private void PrintToParent(Node node)
        {
            Console.WriteLine();
            if (node.Parent != null)
            {
                Console.Write($"{node.Feature} ->");
                PrintToParent(node.Parent);
            }
            else
            {
                Console.Write($"{node.Feature}");
            }
        }
    }
}