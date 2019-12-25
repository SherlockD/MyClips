using System;
namespace ReverseInference.Lecser.Lecsems
{
    public class GetHelpLecsema : AbstractLecsema
    {
        private AbstractLecsema[] _lecsemas;

        public GetHelpLecsema(AbstractLecsema[] lecsemas)
        {
            _lecsemas = lecsemas;
        }

        public override void Initialize()
        {
            Initialize("help");
        }

        protected override void ActionMethod(string[] arguments)
        {
            foreach(var lecsema in _lecsemas)
            {
                lecsema.PrintDescription();
            }
        }

        protected override void OnBadInput(string message)
        {
            Console.WriteLine($"Error by getting help: {message} ");
        }

        public override void PrintDescription()
        {
            Console.WriteLine($"{CommandName}: Вывести помощь");
        }
    }
}
