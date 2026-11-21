namespace WorkerApp;

abstract class Worker
{
    private readonly List<string> actions = new();

    public string Name { get; }
    public string Position { get; protected set; } = string.Empty;
    public string WorkDay => string.Join(", ", actions);

    protected Worker(string name)
    {
        Name = name;
    }

    public void Call() => actions.Add("дзвінок");

    public void WriteCode() => actions.Add("написання коду");

    public void Relax() => actions.Add("відпочинок");

    public abstract void FillWorkDay();
}
