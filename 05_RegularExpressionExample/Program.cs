using System;
using System.Text.RegularExpressions;

namespace RegularExpressionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            RegPartternExample1();
            RegPartternExample2();
            RegPartternExample3();
        }

        static void RegPartternExample1()
        {
            Console.WriteLine("예제1");
            string pattern = "^\"|\"$|\"\r\n$";
            string input = "\"개행된\r\n문자\r\n입니다.\"\r\n";//앞뒤 쌍따옴표, 마지막 개행 제거하는 정규표현식
            Console.WriteLine("변경전");
            Console.WriteLine(input);
            Console.WriteLine();

            Console.WriteLine("일치 여부 확인");
            Console.WriteLine(Regex.IsMatch(input, pattern));
            Console.WriteLine();

            input = Regex.Replace(input, pattern, string.Empty);
            Console.WriteLine("변경후");
            Console.WriteLine(input);
            Console.WriteLine();
        }

        static void RegPartternExample2()
        {
            Console.WriteLine("예제2");
            string str = "나열된 단어1 단어2 단어3 단어4 입니다.";
            Regex regex = new Regex(@"\b(\w+?)\b", RegexOptions.IgnoreCase);//단어별로 구분하는 정규표현식

            foreach (Match m in regex.Matches(str))
            {
                Group g = m.Groups[1];
                Console.WriteLine("{0}:{1}", g.Index, g.Value);//시작 인덱스, 값 출력
            }
        }

        static void RegPartternExample3()
        {
            Console.WriteLine("예제3");
            string[] strArray = new string[5] { "file file1.txt", "file.file2.jpg", "file3.png", "file4.dll", "file5.jpeg" };
            Regex regex = new Regex(@"\.(jpeg|gif|png|jpg)$", RegexOptions.IgnoreCase);//파일명 확장자가 이미지인지 체크하는 정규표현식

            foreach (string str in strArray)
            {
                Console.WriteLine("파일이름:{0}, 이미지여부:{1}", str, regex.IsMatch(str));
            }
        }
    }
}
