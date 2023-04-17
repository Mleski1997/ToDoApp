using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.IO;
using System.Linq.Expressions;
using System.Reflection.PortableExecutable;
using System.Collections;
using System.Runtime.ExceptionServices;
using System.Linq;

namespace ToDoList
{
    public class ToDoApp
    {
        List<string> toDoListApp = new List<string>();
        List<string> toDoListApp2 = new List<string>();

        
        int nextId = 0;
        string filePath = @"D:\Users\Michałek\Projects\ToDoList\todolist.txt";



        public void IntroduceToDo()
        {
            Console.WriteLine("Welcome in ToDoApp you can register tasks here");

        }

        public void writeFile()

        {


            StreamWriter sw;

            if (!File.Exists(filePath))
            {
                sw = File.CreateText(filePath);
                Console.WriteLine("Plik utworzony");
            }
            else
            {
                sw = new StreamWriter(filePath, true);

            }
            for (int i = 0; i < toDoListApp.Count; i++) {
                sw.WriteLine(nextId++ + ":" + toDoListApp[i]);

            }
            sw.Close();

        }

        
        public void writeFile2()
        {
            StreamWriter sw;

            if (!File.Exists(filePath))
            {
                sw = File.CreateText(filePath);
                Console.WriteLine("Plik utworzony");
            }
            else
            {
                sw = new StreamWriter(filePath, true);

            }
            for (int i = 0; i < toDoListApp2.Count; i++)
            {
                sw.WriteLine(i + ":" + toDoListApp2[i]);

            }
            sw.Close();
        }
    


        public void readFile()
        {
  
   
             StreamReader sr = File.OpenText(filePath);
            string line = "";
            int i = 0;

            Console.WriteLine("Lista ToDo");
            while((line = sr.ReadLine()) != null) {

       
                
                var lineTimes = line.Split(':'); 
                int id = int.Parse(lineTimes[0]);
                string todo = lineTimes[1];
               

                nextId = Math.Max(nextId, id);
                nextId++;
                

               
                toDoListApp2.Add(todo);

            }
            sr.Close();
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

            toDoListApp2.RemoveAt(taskNumber);
            File.WriteAllText(filePath, string.Empty);

            StreamWriter sw;

            writeFile2();

        }

        public void selectTaskToCompleted()
        {
            showList();

            int taskNumber = Convert.ToInt32(Console.ReadLine());
            string completedTask = toDoListApp2[taskNumber];
            string cmpt ="Completed"+ " " + completedTask;

            

            Console.WriteLine(cmpt);
            toDoListApp2[taskNumber] = cmpt;

            
            File.WriteAllText(filePath, string.Empty);

            StreamWriter sw;


            writeFile2();

        }

        public void editTodo()
        {
            Console.WriteLine("Select task number to edit");
            showList();
            int taskNumber = Convert.ToInt32(Console.ReadLine());
           
            Console.WriteLine(toDoListApp2[taskNumber]);
            String taskToEdit = toDoListApp2[taskNumber];
            Console.WriteLine("What word do you want replace?");
            string oldWord = Console.ReadLine();
            Console.WriteLine("Please write a new word");
            string newWord = Console.ReadLine();
            string editString = taskToEdit.Replace(oldWord, newWord);
            Console.WriteLine(editString);
            toDoListApp2[taskNumber] = editString;

            File.WriteAllText(filePath, string.Empty);

            StreamWriter sw;

            writeFile2();

        }

        public void showList ()
        {
           for (int i = 0; i < toDoListApp2.Count; i++)
            {
                Console.WriteLine(i  + " : " + toDoListApp2[i]);
                
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
