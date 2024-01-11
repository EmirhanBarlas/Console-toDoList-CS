using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<string> todoList = new List<string>();
    static string todoFileName = "todolist.txt";

    static void Main()
    {
        Console.WriteLine("ToDo List Uygulamasına Hoş Geldiniz!");
        LoadTasks();

        while (true)
        {
            Console.WriteLine("\nLütfen bir seçenek seçin:");
            Console.WriteLine("1. Görevleri Listele");
            Console.WriteLine("2. Yeni Görev Ekle");
            Console.WriteLine("3. Görev Tamamlandı");
            Console.WriteLine("4. Çıkış");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ListTasks();
                    break;
                case "2":
                    AddTask();
                    break;
                case "3":
                    CompleteTask();
                    break;
                case "4":
                    SaveTasks();
                    Console.WriteLine("Uygulamadan çıkılıyor...");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Geçersiz seçenek, lütfen tekrar deneyin.");
                    break;
            }
        }
    }

    static void LoadTasks()
    {
        if (File.Exists(todoFileName))
        {
            todoList = new List<string>(File.ReadAllLines(todoFileName));
        }
    }

    static void SaveTasks()
    {
        File.WriteAllLines(todoFileName, todoList);
    }

    static void ListTasks()
    {
        Console.WriteLine("\nGörevleriniz:");
        if (todoList.Count == 0)
        {
            Console.WriteLine("Henüz bir görev eklenmemiş.");
        }
        else
        {
            for (int i = 0; i < todoList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {todoList[i]}");
            }
        }
    }

    static void AddTask()
    {
        Console.WriteLine("\nYeni görev ekleyin:");
        string newTask = Console.ReadLine();
        todoList.Add(newTask);
        Console.WriteLine("Görev başarıyla eklendi!");
        SaveTasks();
    }

    static void CompleteTask()
    {
        ListTasks();

        if (todoList.Count == 0)
        {
            Console.WriteLine("Tamamlanacak görev bulunmuyor.");
            return;
        }

        Console.WriteLine("\nTamamlanan görevin numarasını girin:");
        if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber > 0 && taskNumber <= todoList.Count)
        {
            string completedTask = todoList[taskNumber - 1];
            todoList.RemoveAt(taskNumber - 1);
            Console.WriteLine($"{completedTask} görevi tamamlandı!");
            SaveTasks();
        }
        else
        {
            Console.WriteLine("Geçersiz görev numarası, lütfen tekrar deneyin.");
        }
    }
}
