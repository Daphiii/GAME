using System;

public class Game
{
    private int targetNumber;
    private int maxAttempts;
    private int attempts;

    public Game(int difficulty)
    {
        SetDifficulty(difficulty);
        targetNumber = new Random().Next(1, 101);
        attempts = 0;
    }

    private void SetDifficulty(int difficulty)
    {
        switch (difficulty)
        {
            case 1: maxAttempts = 15; break;
            case 2: maxAttempts = 10; break;
            case 3: maxAttempts = 5; break;
            default: maxAttempts = 10; break;
        }
    }

    public bool Play()
    {
        Console.WriteLine($"Я загадал число от 1 до 100. У вас есть {maxAttempts} попыток.");
        while (attempts < maxAttempts)
        {
            attempts++;
            Console.Write($"Попытка {attempts}/{maxAttempts}. Введите ваше число: ");
            if (int.TryParse(Console.ReadLine(), out int guess))
            {
                if (guess == targetNumber)
                {
                    Console.WriteLine("Поздравляю, вы угадали!");
                    return true;
                }
                else if (guess < targetNumber)
                {
                    Console.WriteLine("Загаданное число больше.");
                }
                else
                {
                    Console.WriteLine("Загаданное число меньше.");
                }
            }
            else
            {
                Console.WriteLine("Введите корректное число.");
            }
        }
        Console.WriteLine($"Вы исчерпали все попытки. Загаданное число было {targetNumber}.");
        return false;
    }
}
