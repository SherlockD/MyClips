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
                Console.WriteLine("This command doesen't exist");
            }
        }
        
        public void InitializeLecsemas()
        {
            _lecsemas.Add(new AddRuleLecsema());
            _lecsemas.Add(new GetRulesLecsema());
            _lecsemas.Add(new RunExpertSystemLecsema());
            _lecsemas.Add(new LoadRulesFromFileLecsema());
            _lecsemas.Add(new PrintTreeLecsema());
            _lecsemas.Add(new GetHelpLecsema(_lecsemas.ToArray()));
            
            _lecsemas.ForEach((lecsema) => lecsema.Initialize());
        }
    }
}