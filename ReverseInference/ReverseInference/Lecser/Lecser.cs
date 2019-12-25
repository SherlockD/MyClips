using System;

namespace ReverseInference.Lecser
{
    public class Lecser
    {
        private CommandManager _commandManager;

        public Lecser()
        {
            _commandManager = new CommandManager();
        }
        
        public void InputCommandFromConsole()
        {
            string[] input = Console.ReadLine()?.Split('(', ')', ',', ' ');
            
            _commandManager.Execute(input);
        }
    }
}