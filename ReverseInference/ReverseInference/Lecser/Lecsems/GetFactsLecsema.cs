using System;
using ReverseInference.Fact;

namespace ReverseInference.Lecser.Lecsems
{
    public class GetFactsLecsema : AbstractLecsema
    {
        public override void Initialize()
        {
            Initialize("facts-list");
        }

        protected override void ActionMethod(string[] arguments)
        {
            FactsLibrary.Instance.PrintFacts();
        }

        protected override void OnBadInput()
        {
            Console.WriteLine("Ошбика при выводе фактов, проверьте ввод");
        }
    }
}