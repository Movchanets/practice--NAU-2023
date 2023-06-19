using System;
using System.Collections.Generic;
using ClassLibrary;

namespace practice
{
    internal class Program
    {
        static DoublyLinkedList studentList = new DoublyLinkedList();

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("1. Додати студента");
                Console.WriteLine("2. Видалити студента");
                Console.WriteLine("3. Вивести список студентів");
                Console.WriteLine("4. Знайти студентів з ідеальною вагою");
                Console.WriteLine("5. Вийти");
                Console.WriteLine();

                Console.Write("Введіть номер опції: ");
                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        AddStudent();
                        break;
                    case "2":
                        RemoveStudent();
                        break;
                    case "3":
                        PrintStudentList();
                        break;
                    case "4":
                        FindStudentsWithIdealWeight();
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void AddStudent()
        {
            Console.WriteLine("Доступні імена студентів:");
            foreach (Names availableName in Enum.GetValues(typeof(Names)))
            {
                Console.WriteLine(availableName);
            }

            Console.WriteLine();

            Names name;
            bool validName = false;

            do
            {
                Console.Write("Ім'я студента: ");
                string input = Console.ReadLine();

                if (Enum.TryParse(input, out name))
                {
                    if (Enum.IsDefined(typeof(Names), name))
                    {
                        validName = true;
                    }
                }

                if (!validName)
                {
                    Console.WriteLine("Невірне ім'я студента. Будь ласка, введіть ім'я з доступних варіантів.");
                }
            } while (!validName);

            bool validHeight = false;
            int height = 0;
            do
            {
                Console.Write("Ріст студента (в см): "); 
                height = Convert.ToInt32(Console.ReadLine());
                if (height > 130 && height < 250)
                {
                    validHeight = true;
                }
                else
                {
                    Console.WriteLine("Невірний ріст студента. Будь ласка, введіть реальне число.");
                }

            } while (!validHeight);
            bool validWeight = false;
            double weight = 0;
            do
            {
                Console.Write("Вага студента (в кг): "); 
                 weight = Convert.ToDouble(Console.ReadLine());
               if(weight > 30 && weight < 150)
                {
                    validWeight = true;
                }
                else
                {
                    Console.WriteLine("Невірний ріст студента. Будь ласка, введіть реальне число.");
                }
                

            } while (!validWeight);

            Console.Write("Вага студента (в кг): ");
        

            Student student = new Student(name, height, weight);
            studentList.AddToEnd(student);

            Console.WriteLine("Студент доданий до списку.");
            PrintStudentList();
        }

        static void RemoveStudent()
        {
            Console.Write("Введіть індекс студента, якого потрібно видалити: ");
            int index = Convert.ToInt32(Console.ReadLine());

            try
            {
                studentList.RemoveAt(index);
                Console.WriteLine("Студент видалений зі списку.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            PrintStudentList();
        }

        static void PrintStudentList()
        {
            Console.WriteLine("Список студентів:");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine($"{"Індекс",-10}{"Ім'я",-10}{"Ріст",-10}{"Вага",-10} ");
            Console.WriteLine("--------------------------------------");

            for (int i = 0; i < studentList.Length; i++)
            {
                Student student = studentList[i];
                Console.WriteLine($"{i,-10}{student.Name,-10}{student.Height,-10}{student.Weight,-10}");
            }

            Console.WriteLine("--------------------------------------");
        }

        static void FindStudentsWithIdealWeight()
        {
            List<Student> students = studentList.FindStudentsWithIdealWeight();

            Console.WriteLine("Студенти з ідеальною вагою (ріст - вага = 110):");
            Console.WriteLine("----------------------------");
            Console.WriteLine($"{"Ім'я",-10}{"Ріст",-10}{"Вага",-10} ");
            Console.WriteLine("----------------------------");

            foreach (Student student in students)
            {
                Console.WriteLine($"{student.Name,-10}{student.Height,-10}{student.Weight,-10}");
            }

            Console.WriteLine("----------------------------");
        }
    }
}