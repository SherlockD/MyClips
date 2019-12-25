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
            var discuss = new Discuss(arguments[1], arguments[2]);
            
            DiscussTree.Instance.AddDiscuss(discuss);
        }

        protected override void OnBadInput(string message)
        {
            Console.WriteLine($"Error by adding a rule: {message} ");
        }

        public override void PrintDescription()
        {
            Console.WriteLine("defrule: Добавить новое правило");
        }
    }
}