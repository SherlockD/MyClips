using System;
using ReverseInference.Fact;

namespace ReverseInference.Lecser.Lecsems
{
    public class AddFactLecsema : AbstractLecsema
    {
        public override void Initialize()
        {
            Initialize("assert");
        }

        protected override void ActionMethod(string[] arguments)
        {
            var fact = new Fact.Fact();

            fact.ObjectName = arguments[1];
            fact.Feature = arguments[2];
            
            FactsLibrary.Instance.Library.Add(fact);
        }

        protected override void OnBadInput()
        {
            Console.WriteLine("Ошбика при добавлении нового факта, проверьте ввод");
        }
    }
}