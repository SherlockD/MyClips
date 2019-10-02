using System;
using ReverseInference.Fact;

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
            DiscussTree.Tree.DiscussTree.Instance.PrintTree();
        }

        protected override void OnBadInput()
        {
            Console.WriteLine("Ошбика при выводе правил, проверьте ввод");
        }
    }
}