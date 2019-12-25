using System;
using System.IO;
using System.Text;
using ReverseInference.DiscussNode;

namespace ReverseInference.Lecser.Lecsems
{
    public class LoadRulesFromFileLecsema: AbstractLecsema
    {
        private DiscussTree _tree = DiscussTree.Instance;

        public override void Initialize()
        {
            Initialize("load");
        }

        protected override void ActionMethod(string[] arguments)
        {
            LoadTree(arguments[1]);
        }

        protected override void OnBadInput(string message)
        {
            Console.WriteLine($"Error by loading a rules: {message} ");
        }
        
        private void LoadTree(string path)
        {
            using (StreamReader streamReader = new StreamReader(path, Encoding.UTF8))
            {
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();

                    line = line.Remove(line.Length - 1);
                    var parse = line.Split(',', '(');

                    switch (parse[0])
                    {
                        case "add_question":
                            _tree.AddQuestion(ParseLineToQuestion(parse));
                            break;
                        case "add_rule":
                            _tree.AddDiscuss(ParseLineToNode(parse));
                            break;
                    }
                }
            }
        }

        private Discuss ParseLineToNode(string[] parse) => new Discuss(parse[2], parse[1]);

        private Question ParseLineToQuestion(string[] parse) => new Question(parse[3], parse[4], parse[1], true, parse[2]);

        public override void PrintDescription()
        {
            Console.WriteLine($"{CommandName}: Загрузить правила их файла");
        }
    }
}
