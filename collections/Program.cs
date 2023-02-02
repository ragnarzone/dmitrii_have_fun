using System.Collections.Generic;
using System.Linq;

class Program{
    public static void Main(){
        //ListTest();
        Thread thr1 = new Thread(Multithreading.method1);
        Thread thr2 = new Thread(Multithreading.method2);

        thr1.Start();
        thr2.Start();
    }

    private static void ListTest(){
        var salmons = new List<string>();
        salmons.Add("chinook");
        salmons.Add("coho");
        salmons.Add("pink");
        salmons.Add("sockeye");

        salmons.ForEach(
            salmon => Console.Write(salmon + " \n"));
    }
}

