using System;
using ReverseInference.Tree;

namespace ReverseInference.Lecser.Lecsems
{
    public class GetRulesLecsema : AbstractLecsema
    {
        public override void Initialize()
        {
            Initialize("rules-list");
        }

        protected override void ActionMethod(string[] arguments)
        {
            DiscussTree.Instance.PrintTree();
        }

        protected override void OnBadInput(string message)
        {
            Console.WriteLine($"Error by output a rule: {message} ");
        }

        public override void PrintDescription()
        {
            Console.WriteLine("rules-list: Вывести список правил");
        }
    }
}