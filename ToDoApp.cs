using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ToDoList
{
    public class ToDoApp
    {
        List<string> toDoListApp = new List<string>();
        public void IntroduceToDo()
        {
            Console.WriteLine("Welcome in ToDoApp you can register tasks here");

        }

        public void addToDo()
        {
            Console.WriteLine("Write task to save");
            string newTask = Console.ReadLine();
            toDoListApp.Add(newTask);
            Console.WriteLine("Task dodano do listy");
        }

        public void deteleToDo()
        {
            showList();
            Console.WriteLine("Select number of task to delete");
            int taskNumber = Convert.ToInt32(Console.ReadLine());
            toDoListApp.RemoveAt(taskNumber);
        }

        public void selectTaskToCompleted()
        {
            showList();
           

            int taskNumber = Convert.ToInt32(Console.ReadLine());
            string completedTask = toDoListApp[taskNumber];
            string cmpt = "Completed" + " : " + completedTask;

            Console.WriteLine(cmpt);
            toDoListApp[taskNumber] = cmpt;
          
           





        }

        public void editTodo()
        {
            Console.WriteLine("Select task number to edit");
            showList();
            int taskNumber = Convert.ToInt32(Console.ReadLine());
           
            Console.WriteLine(toDoListApp[taskNumber]);
            String taskToEdit = toDoListApp[taskNumber];
            Console.WriteLine("What word do you want replace?");
            string oldWord = Console.ReadLine();
            Console.WriteLine("Please write a new word");
            string newWord = Console.ReadLine();
            string editString = taskToEdit.Replace(oldWord, newWord);
            Console.WriteLine(editString);
            toDoListApp[taskNumber] = editString;





        }

        public void showList ()
        {
            for (int i = 0; i < toDoListApp.Count; i++)
            {
                Console.WriteLine(i + " : " + toDoListApp[i]);
                toDoListApp.Sort();

            }

          


        }

        public void askWhatDo()
        {

            string option = " ";
            while (option != "6")
            {
                Console.WriteLine("What do you want do");
                Console.WriteLine("1. Add task");
                Console.WriteLine("2. Remove task");
                Console.WriteLine("3. Edit task");
                Console.WriteLine("4. Show task");
                Console.WriteLine("5. Select a task to complete");
                Console.WriteLine("6. Exit");


                option = Console.ReadLine();
                if (option == "1")
                {
                    addToDo();
                } else if (option == "2")
                {
                    deteleToDo();

                } else if (option == "3") {

                    editTodo();
                } else if (option == "4")
                    
                {
                    showList();

                } else if (option == "5")
                    
                {
                    selectTaskToCompleted();


                }
                else if (option == "6")
                {
                    Console.WriteLine("Exiting progrsam ");


                } else
                {
                    Console.WriteLine("Invalid option try again");
                }
              


            }


        }
    }
}
