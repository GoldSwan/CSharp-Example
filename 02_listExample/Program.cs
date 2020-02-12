using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace listExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //목록(List Collections)
            var names = new List<string> { "Bob", "Alice", "Happy" };

            //List Add, Remove
            names.Add("Sam");
            names.Add("Joker");
            names.Remove("Happy");

            foreach (var name in names)
            {
                Console.WriteLine("Hello! " + name);
            }

            //Index로 바로 접근 가능
            Console.WriteLine(names[2]);

            //List IndexOf로 값에 해당하는 index return
            var index = names.IndexOf("Alice");
            if (index != -1)
                Console.WriteLine(names[index] + ":" + index);

            index = names.IndexOf("Trudy");
            Console.WriteLine(index);//찾을 수 없는 경우 -1 return

            //List 정렬
            names.Sort();

            foreach (var name in names)
            {
                Console.WriteLine(name.ToUpper());
            }

            Program.makeFibonacciNumbers(10);//피보나치 수열 생성
        }

        static void makeFibonacciNumbers(int size)
        {
            //List 를 통한 피보나치 수열 생성
            var fibonacciNumbers = new List<int> { 1, 1 };

            while (fibonacciNumbers.Count < size)
            {
                var previous = fibonacciNumbers[fibonacciNumbers.Count - 1];
                var previous2 = fibonacciNumbers[fibonacciNumbers.Count - 2];

                fibonacciNumbers.Add(previous + previous2);
            }

            foreach (var item in fibonacciNumbers)
                Console.WriteLine(item);
        }
    }
}
