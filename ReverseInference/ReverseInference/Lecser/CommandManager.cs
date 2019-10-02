using System;
using System.Collections.Generic;
using ReverseInference.Lecser.Lecsems;

namespace ReverseInference.Lecser
{
    public class CommandManager
    {
        private List<AbstractLecsema> _lecsemas = new List<AbstractLecsema>();
        
        public CommandManager()
        {
            InitializeLecsemas();
        }

        public void Execute(string[] arguments)
        {
            var lecsema = _lecsemas.Find(lecs => lecs.CommandName == arguments[0]);

            if (lecsema != null)
            {
                lecsema.Dispatch(arguments);
            }
            else
            {
                Console.WriteLine("Данной комманды не существует");
            }
        }
        
        public void InitializeLecsemas()
        {
            _lecsemas.Add(new AddFactLecsema());
            _lecsemas.Add(new AddRuleLecsema());
            _lecsemas.Add(new GetFactsLecsema());
            _lecsemas.Add(new GetRulesLecsema());
            _lecsemas.Add(new LogicalOutputLecsema());
            _lecsemas.Add(new ReverseLogicalOutputLecsema());
            
            _lecsemas.ForEach((lecsema) => lecsema.Initialize());
        }
    }
}