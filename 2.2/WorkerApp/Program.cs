namespace WorkerApp;

static class Program
{
    private static readonly List<Team> teams = new();

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("1 - Створити команду");
            Console.WriteLine("2 - Додати співробітника до команди");
            Console.WriteLine("3 - Інформація про команду");
            Console.WriteLine("4 - Детальна інформація про команду");
            Console.WriteLine("0 - Вихід");

            switch (ReadInt("Виберіть пункт меню: ", 0, 4))
            {
                case 1:
                    CreateTeam();
                    break;
                case 2:
                    AddWorker();
                    break;
                case 3:
                    ChooseTeam()?.PrintInfo();
                    break;
                case 4:
                    ChooseTeam()?.PrintDetailedInfo();
                    break;
                case 0:
                    return;
            }
        }
    }

    private static void CreateTeam()
    {
        teams.Add(new Team(ReadText("Введіть назву команди: ")));
        Console.WriteLine("Команду створено.");
    }

    private static void AddWorker()
    {
        Team? team = ChooseTeam();
        if (team is null)
        {
            return;
        }

        string name = ReadText("Введіть ПІБ співробітника: ");
        int position = ReadInt("Посада (1 - Розробник, 2 - Менеджер): ", 1, 2);

        team.AddWorker(position == 1 ? new Developer(name) : new Manager(name));
        Console.WriteLine("Співробітника додано.");
    }

    private static Team? ChooseTeam()
    {
        if (teams.Count == 0)
        {
            Console.WriteLine("Спочатку створіть команду.");
            return null;
        }

        for (int i = 0; i < teams.Count; i++)
        {
            Console.WriteLine($"{i + 1} - {teams[i].Name}");
        }

        return teams[ReadInt("Виберіть команду: ", 1, teams.Count) - 1];
    }

    private static string ReadText(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();

            if (input is null)
            {
                Environment.Exit(0);
            }

            if (!string.IsNullOrWhiteSpace(input))
            {
                return input.Trim();
            }

            Console.WriteLine("Значення не може бути порожнім.");
        }
    }

    private static int ReadInt(string prompt, int min, int max)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();

            if (input is null)
            {
                Environment.Exit(0);
            }

            if (int.TryParse(input, out int value) && value >= min && value <= max)
            {
                return value;
            }

            Console.WriteLine($"Введіть ціле число від {min} до {max}.");
        }
    }
}
