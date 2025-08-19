namespace tickets_trading.Application;

class A
{ }

class B : A
{
    private int j;
    
    public B(int i)
    {
        j = i;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("SANDBOX: Application");
    }
}