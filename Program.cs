using System;

class Program
{
    static void Main(string[] args)
    {
        var auth = new Authentication();
        var username = auth.Login();

        Console.WriteLine("Выберите уровень сложности: 1 - Легкий, 2 - Средний, 3 - Сложный");
        if (int.TryParse(Console.ReadLine(), out int difficulty) && difficulty >= 1 && difficulty <= 3)
        {
            var game = new Game(difficulty);
            var result = game.Play();

            auth.SaveResult(username, result);
            auth.ShowResults(username);
        }
        else
        {
            Console.WriteLine("Неверный выбор уровня сложности.");
        }
    }
}
