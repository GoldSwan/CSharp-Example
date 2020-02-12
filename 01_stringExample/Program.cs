using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace stringExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //Replace : 문자열 치환
            string sayIntro = "I am swan";
            Console.WriteLine(sayIntro);
            sayIntro = sayIntro.Replace("swan", "blackswan");
            Console.WriteLine(sayIntro);//I am blackswan

            //문자열 검색
            string songLyrics = "happy birthday to you";

            //Contains : 문자열포함여부
            Console.WriteLine(songLyrics.Contains("birthday"));
            Console.WriteLine(songLyrics.Contains("monday"));
            //StartsWith : 문자열 시작을 기준으로 문자열포함여부
            Console.WriteLine(songLyrics.StartsWith("happy"));
            Console.WriteLine(songLyrics.StartsWith("sad"));
            //EndsWith : 문자열 끝을 기준으로 문자열포함여부
            Console.WriteLine(songLyrics.EndsWith("you"));
            Console.WriteLine(songLyrics.EndsWith("me"));

            //문자열 대소문자 변환
            Console.WriteLine(songLyrics.ToUpper());
            Console.WriteLine(songLyrics.ToLower());
        }
    }
}
