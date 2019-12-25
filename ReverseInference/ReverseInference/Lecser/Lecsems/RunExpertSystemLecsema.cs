using System;
using System.Collections.Generic;
using ReverseInference.Tree;

namespace ReverseInference.Lecser.Lecsems
{
    public class RunExpertSystemLecsema: AbstractLecsema
    {
        private DiscussTree _tree = DiscussTree.Instance;

        public override void Initialize()
        {
            Initialize("run-expert-system");
        }

        protected override void ActionMethod(string[] arguments)
        {
            var currentNode = _tree.GetRoot();

            while (currentNode.IsQuestion)
            {
                Console.Clear();

                Console.WriteLine(currentNode.Question + "?");
                Console.Write(" y/n \n");

                if (currentNode.GetReferences().Count == 2)
                {
                    string input = Console.ReadLine();

                    switch (input)
                    {
                        case "y":
                            currentNode = currentNode.GetReferences()[0];
                            break;
                        case "n":
                            currentNode = currentNode.GetReferences()[1];
                            break;
                        default:
                            throw new Exception("Bad input");
                    }
                }
            }

            Console.Clear();

            if(currentNode.GetReferences().Count == 0)
            {
                StartUserMode(currentNode);
                return;
            }
            if(currentNode.GetReferences().Count > 1)
            {
                ConflictStrategy(currentNode);
            }

            Console.WriteLine($"The answer is: {currentNode.GetReferences()[0].Feature}");
        }

        private void StartUserMode(Node currentNode)
        {
            Console.WriteLine("Данной ветки не существует, добавить новую? y\n ");
            if (Console.ReadLine() != "y")
                return;

            Console.WriteLine("1)Добавить новый вопрос\n2)Ввести ответ ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Введите вопрос\n");
                    string question = Console.ReadLine();
                    Console.WriteLine("Введите Положительный ответ\n");
                    string featureOne = Console.ReadLine();
                    Console.WriteLine("Введите Отрицательный ответ\n");
                    string featureTwo = Console.ReadLine();

                    _tree.AddQuestion(new Question(featureOne, featureTwo, currentNode.Feature, true, question));
                    break;
                case "2":
                    Console.WriteLine("Введите ответ");
                    string answer = Console.ReadLine();

                    _tree.AddDiscuss(new DiscussNode.Discuss(answer, currentNode.Feature));
                    break;
                default:
                    throw new Exception("Bad input");
            }
        }

        private void ConflictStrategy(Node currentNode)
        {
            int hidestIndex = 0;

            List<int> indexesToDelete = new List<int>();

            foreach(var node in currentNode.GetReferences())
            {
                if (node.Index > hidestIndex)
                    hidestIndex = node.Index;
            }

            for(int i = 0; i < currentNode.GetReferences().Count; i++)
            {
                if(currentNode.GetReferences()[i].Index < hidestIndex)
                {
                    indexesToDelete.Add(i);
                }
            }

            foreach(var index in indexesToDelete)
            {
                currentNode.GetReferences().RemoveAt(index);
            }
        }

        protected override void OnBadInput(string message)
        {
            Console.WriteLine($"Error during runing expert system: {message} ");
        }

        public override void PrintDescription()
        {
            Console.WriteLine($"{CommandName}: Запустить экспертную систему");
        }
    }
}
