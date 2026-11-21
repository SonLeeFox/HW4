namespace WorkerApp;

class Team
{
    private readonly List<Worker> workers = new();

    public string Name { get; }

    public Team(string name)
    {
        Name = name;
    }

    public void AddWorker(Worker worker)
    {
        worker.FillWorkDay();
        workers.Add(worker);
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Команда: {Name}");

        if (workers.Count == 0)
        {
            Console.WriteLine("У команді поки немає співробітників.");
            return;
        }

        foreach (Worker worker in workers)
        {
            Console.WriteLine(worker.Name);
        }
    }

    public void PrintDetailedInfo()
    {
        Console.WriteLine($"Команда: {Name}");

        if (workers.Count == 0)
        {
            Console.WriteLine("У команді поки немає співробітників.");
            return;
        }

        foreach (Worker worker in workers)
        {
            Console.WriteLine($"{worker.Name} - {worker.Position} - {worker.WorkDay}");
        }
    }
}
