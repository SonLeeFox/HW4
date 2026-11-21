namespace WorkerApp;

class Manager : Worker
{
    private readonly Random random = new();

    public Manager(string name) : base(name)
    {
        Position = "Менеджер";
    }

    public override void FillWorkDay()
    {
        CallSeveralTimes(random.Next(1, 11));
        Relax();
        CallSeveralTimes(random.Next(1, 6));
    }

    private void CallSeveralTimes(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Call();
        }
    }
}
