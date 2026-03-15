using System;

class Program
{
    static int LevenshteinDistance(string str1, string str2)
    {
        if (str1 == null || str2 == null) return -1;
        
        int n = str1.Length;
        int m = str2.Length;
        
        if (n == 0) return m;
        if (m == 0) return n;
        

        string s1 = str1.ToUpper();
        string s2 = str2.ToUpper();
        
        int[,] dp = new int[n + 1, m + 1];
        
        for (int i = 0; i <= n; i++) dp[i, 0] = i;
        for (int j = 0; j <= m; j++) dp[0, j] = j;
        
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= m; j++)
            {
                int cost = (s1[i - 1] == s2[j - 1]) ? 0 : 1;
                dp[i, j] = Math.Min(
                    Math.Min(dp[i - 1, j] + 1, dp[i, j - 1] + 1),
                    dp[i - 1, j - 1] + cost
                );
            }
        }
        return dp[n, m];
    }

    static int DamerauLevenshteinDistance(string str1, string str2)
    {
        if (str1 == null || str2 == null) return -1;
        
        int n = str1.Length;
        int m = str2.Length;
        
        if (n == 0) return m;
        if (m == 0) return n;
        

        string s1 = str1.ToUpper();
        string s2 = str2.ToUpper();
        
        int[,] dp = new int[n + 1, m + 1];
        
        for (int i = 0; i <= n; i++) dp[i, 0] = i;
        for (int j = 0; j <= m; j++) dp[0, j] = j;
        
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= m; j++)
            {
                int cost = (s1[i - 1] == s2[j - 1]) ? 0 : 1;
                dp[i, j] = Math.Min(
                    Math.Min(dp[i - 1, j] + 1, dp[i, j - 1] + 1),
                    dp[i - 1, j - 1] + cost
                );
                

                if (i > 1 && j > 1 && 
                    s1[i - 1] == s2[j - 2] && 
                    s1[i - 2] == s2[j - 1])
                {
                    dp[i, j] = Math.Min(dp[i, j], dp[i - 2, j - 2] + 1);
                }
            }
        }
        return dp[n, m];
    }

    static void Main()
    {
        Console.WriteLine("Программа вычисления расстояния Левенштейна и Дамерау-Левенштейна");
        Console.WriteLine("Для выхода введите 'exit' в качестве первой строки\n");
        
        while (true)
        {
            Console.Write("Введите первую строку: ");
            string s1 = Console.ReadLine();
            
            if (s1?.ToLower() == "exit")
            {
                Console.WriteLine("Программа завершена.");
                break;
            }
            
            Console.Write("Введите вторую строку: ");
            string s2 = Console.ReadLine();
            
            if (s2 == null) s2 = "";
            
            Console.WriteLine($"\nПервая строка: \"{s1}\", вторая строка: \"{s2}\"");
            Console.WriteLine($"Расстояние Левенштейна: {LevenshteinDistance(s1, s2)}");
            Console.WriteLine($"Расстояние Дамерау-Левенштейна: {DamerauLevenshteinDistance(s1, s2)}");
            Console.WriteLine();
        }
    }
}