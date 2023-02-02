using System.Collections.Generic;
using System.Linq;

class Program{
    public static void Main(){
        ListTest();
    }

    private static void ListTest(){
        var salmons = new List<string>();
        salmons.Add("chinook");
        salmons.Add("coho");
        salmons.Add("pink");
        salmons.Add("sockeye");

        salmons.FaorEach(
            salmon => Console.Write(salmon + " \n"));
    }
}

