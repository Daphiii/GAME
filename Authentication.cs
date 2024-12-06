using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class Authentication
{
    private const string FilePath = "UsersData.json";
    private Dictionary<string, List<string>> users;

    public Authentication()
    {
        if (File.Exists(FilePath))
        {
            var jsonData = File.ReadAllText(FilePath);
            users = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(jsonData) ?? new Dictionary<string, List<string>>();
        }
        else
        {
            users = new Dictionary<string, List<string>>();
        }
    }

    public string Login()
    {
        Console.Write("Введите имя пользователя: ");
        var username = Console.ReadLine();
        if (!users.ContainsKey(username))
        {
            Console.WriteLine("Новый пользователь. Регистрация...");
            users[username] = new List<string>();
        }
        else
        {
            Console.WriteLine($"Добро пожаловать, {username}!");
        }
        return username;
    }

    public void SaveResult(string username, bool result)
    {
        var outcome = result ? "Победа" : "Unluck";
        users[username].Add(outcome);
        File.WriteAllText(FilePath, JsonConvert.SerializeObject(users));
    }

    public void ShowResults(string username)
    {
        if (users.ContainsKey(username))
        {
            Console.WriteLine("Ваши результаты:");
            foreach (var result in users[username])
            {
                Console.WriteLine($"- {result}");
            }
        }
        else
        {
            Console.WriteLine("Нет данных о результатах.");
        }
    }
}
