using System;
using System.Collections.Generic;
using System.Ling;

namespace Todo
{
    class TodoLogic
    {
        private static TodoLogic _logic = new TodoLogic();

        public static TodoLogic Logic { get => _logic; set => _logic = value; }

        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            while (!string.IsNullOrWhiteSpace(input))
            {
                var splitInput = input.Split('/');
                var commandInput = splitInput[0].Trim();
                switch (commandInput.ToLower())
                {
                    case "add":
                        {
                            AddNewTodo(splitInput);
                            ReadToDos();
                            break;
                        }
                    case "read":
                        {
                            ReadToDos();
                            break;
                        }
                    case "update":
                        {
                            UpdateTodo(splitInput);
                            ReadToDos();
                            break;
                        }
                    case "delete":
                        {
                            DeleteTodo(splitInput);
                            ReadToDos();
                            break;
                        }
                    case "exit":
                        {
                            Console.WriteLine("Thank you for using the Todo app.");
                            return;
                        }
                    default:
                        {
                            Console.WriteLine("Options are \"Create\", \"Read\", \"Update\", \"Delete\", or \"Exit\"");
                            break;
                        }
                }

                input = Console.ReadLine();
            }
        }

        private static void AddNewTodo(string[] values)
        {
            var newmodel = ParseValues(values);
            Logic.Add(newModel);
        }

        private static void ReadToDos()
        {
            var models = Logic.Read();

            foreach (var item in models)
            {
                Console.WriteLine(item.Title);
            }
        }

        private static void UpdateTodo(string[] values)
        {
            var updatedModel = ParseValues(values);
            Logic.Update(updatedModel);
        }

        private static void DeleteTodo(string[] values)
        {
            var modelToDelete = ParseValues(values);
            Logic.Delete(modelToDelete);
        }

        private static TodoModel ParseValues(string[] values)
        {
            TodoModel model = new TodoModel();
            for (int i = 1; i < values.Length; i++)
            {
                var property = values[i].Split('=');
                switch (property[0].ToLower())
                {
                    case "key":
                        {
                            model.Key = int.Parse(property[1]);
                            break;
                        }
                    case "priority":
                        {
                            model.Priority = int.Parse(property[1]);
                            break;
                        }
                    case "title":
                        {
                            model.Title = property[1].Trim('"');
                            break;
                        }
                    case "details":
                        {
                            model.Details = property[1].Trim('"');
                            break;
                        }
                }
            }

            return model;
        }
    }
}

