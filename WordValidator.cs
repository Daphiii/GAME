using System;
using System.Text.RegularExpressions;

public class WordValidator
{
    /// <summary>
    /// Проверяет, состоит ли слово только из букв русского алфавита.
    /// </summary>
    /// <param name="word">Введённое пользователем слово</param>
    /// <returns>True, если слово состоит только из русских букв, иначе False</returns>
    public static bool IsValidRussianWord(string word)
    {
        // Регулярное выражение для проверки только русских букв.
        string pattern = "^[а-яА-ЯёЁ]+$";
        return Regex.IsMatch(word, pattern);
    }
}
