using System;

namespace ReverseInference.Lecser
{
    public abstract class AbstractLecsema
    {
        public string CommandName;
        private Action<string[]> _action;
        
        protected void Initialize(string commandName)
        {
            CommandName = commandName;
            _action = ActionMethod;
        }

        public abstract void Initialize();
        protected abstract void ActionMethod(string[] arguments);
        protected abstract void OnBadInput();

        public virtual void Dispatch(string[] arguments)
        {
            try
            {
                _action?.Invoke(arguments);
            }
            catch
            {
                OnBadInput();
            }
        }
    }
}