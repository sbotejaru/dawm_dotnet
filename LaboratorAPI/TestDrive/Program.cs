using System.Runtime.CompilerServices;
using static TestDrive.DelegateExamples;

namespace TestDrive;

public class Program
{
    public static void Main(string[] args)
    {
        //Delegate_Example();
        //Linq_Example();
    }

    public static void Delegate_Example()
    {
        string result;

        var delegateExamples = new DelegateExamples();
        var myDelegate = new MyMethodDelegate(delegateExamples.MyMethod);

        result = myDelegate(prop: 10);
        Console.WriteLine(result);

        myDelegate = delegateExamples.MySecondMethod;

        result = myDelegate(prop: 10);
        Console.WriteLine(result);
    }

    public static void Linq_Example()
    {
        var listOfStrings = new List<string>() { "a", "b", "c", "d", "e" };
        var result = listOfStrings.DoSomething();

        foreach(var item in result)
        {
            Console.Write(item + " ");
        }
    }
}

public static class ExtensionMethods
{
    public static List<string> DoSomething(this List<string> listOfStrings)
    {
        var another_list = new List<int> { 1, 2, 3, 4, 5 };

        return listOfStrings
            .Where(x => x != "a" && x != "b")
            .Select(x => x.ToUpper() + "_")
            .Union(another_list.Select(i => i.ToString()))
            .OrderByDescending(x => x)
            .ToList();
    }
}
