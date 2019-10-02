using System;
using ReverseInference.DiscussNode;

namespace ReverseInference.Lecser.Lecsems
{
    public class AddRuleLecsema : AbstractLecsema
    {
        public override void Initialize()
        {
            Initialize("defrule");
        }

        protected override void ActionMethod(string[] arguments)
        {
            var discuss = new Discuss(arguments[1], arguments[2], arguments[3]);
            
            DiscussTree.Tree.DiscussTree.Instance.AddDiscuss(discuss);
        }

        protected override void OnBadInput()
        {
            Console.WriteLine("Ошибка при добавлении предиката, проверьте ввод");
        }
    }
}