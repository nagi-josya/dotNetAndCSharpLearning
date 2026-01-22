using Day3ofLearning.Models;
class Program
{
    static Publisher publisher = new();
    static void Main(string[] args)
    {
        for (int i = 0; i < 1_000_000; i++)
        {
            new SmallObject();
        }

        for (int i = 0; i < 10_000; i++)
        {
            new LargeObject();
        }

        for (int i = 0; i < 100_000; i++)
        {
            new Subscriber(publisher);
        }

        Demo();
    }

    static void Demo()
    {
        var obj = new SmallObject();
        Console.WriteLine("Created");
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }

}

class Publisher
{
    public event Action OnData;
}

class Subscriber : IDisposable
{
    Publisher _pub;

    public Subscriber(Publisher pub)
    {
        _pub = pub;
        _pub.OnData += Handle;
    }

    public void Dispose()
    {
        _pub.OnData -= Handle;
    }

    void Handle() { }
}





