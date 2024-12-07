class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Добро пожаловать! Выберите действие:");
        Console.WriteLine("1. Играть в игру угадывания числа");
        Console.WriteLine("2. Проверить слово на наличие только русских букв");
        Console.Write("Введите ваш выбор: ");
        
        int choice;
        if (int.TryParse(Console.ReadLine(), out choice))
        {
            if (choice == 1)
            {
                // Запуск игры (реализовано ранее)
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
            else if (choice == 2)
            {
                // Проверка слова
                Console.Write("Введите слово для проверки: ");
                string word = Console.ReadLine();

                if (WordValidator.IsValidRussianWord(word))
                {
                    Console.WriteLine("Слово состоит только из русских букв.");
                }
                else
                {
                    Console.WriteLine("Слово содержит недопустимые символы или буквы не из русского алфавита.");
                }
            }
            else
            {
                Console.WriteLine("Неверный выбор.");
            }
        }
        else
        {
            Console.WriteLine("Пожалуйста, введите число.");
        }
    }
}
