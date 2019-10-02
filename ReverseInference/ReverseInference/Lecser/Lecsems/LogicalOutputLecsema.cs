using System;
using System.Runtime.CompilerServices;
using ReverseInference.DiscussTree;
using ReverseInference.Fact;

namespace ReverseInference.Lecser.Lecsems
{
    public class LogicalOutputLecsema : AbstractLecsema
    {
        public override void Initialize()
        {
            Initialize("logical-output");
        }

        protected override void ActionMethod(string[] arguments)
        {
            var discussTree = DiscussTree.Tree.DiscussTree.Instance;

            LogicalOnTree(discussTree.GetRoot());
        }

        protected override void OnBadInput()
        {
            Console.WriteLine("Ошибка при выводе логичекого вывода, проверьте вход");
        }

        private void LogicalOnTree(Node node)
        {
            var factsLibrary = FactsLibrary.Instance;

            if (factsLibrary.HasFact(node.NodeObject, node.Feature))
            {
                Console.WriteLine($"{node.Feature} ");
            
                foreach (var item in node.GetReferences())
                {
                    LogicalOnTree(item);
                }
                
            }
        }
    }
}