using System;
using System.Reflection;

//ref link:https://www.youtube.com/watch?v=VPlyPfM8hMQ&list=PLRwVmtr-pp05brRDYXh-OTAIi-9kYcw3r&index=25
//  google search - code access security - 

class Cow
{
    public string Name { get; set; }
    public int Age { get; set; }
    private int NumHeartBeats { get; set; }
    public void Beat() { NumHeartBeats++; }
    private void Digest() { Console.WriteLine("grind grind..."); }
}

class MainClass
{
    static void Main()
    {
        Cow betsy = new Cow { Name = "Betsy", Age = 5 };
        betsy.Beat(); betsy.Beat(); betsy.Beat(); betsy.Beat(); betsy.Beat();
        //Console.WriteLine(betsy.numHeartBeats);
        PropertyInfo propInfo = typeof(Cow).GetProperty("NumHeartBeats", 
            BindingFlags.NonPublic | BindingFlags.Instance);
        int numBeats = (int)propInfo.GetValue(betsy, null);
        Console.WriteLine(numBeats);
    }
}