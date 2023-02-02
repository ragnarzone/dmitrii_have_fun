using System;
using System.Threading;

class Multithreading{
    public static void method1(){
        for(int I = 0; I <= 10; I++){
            Console.WriteLine("Method1 is : {0}", I);
            Thread.Sleep(1000);
        }
    }

    public static void method2()
    {
        for (int J = 0; J <= 10; J++) {
            Console.WriteLine("Method2 is : {0}", J);
            Thread.Sleep(1000);

        }
    }
}