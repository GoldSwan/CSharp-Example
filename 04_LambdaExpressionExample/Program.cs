using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LambdaExpressionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //람다식 예제
            //값 반환할 경우 : Func 대리자 형식
            //값 반환하지 않을 경우 : Action 대리자 형식
            Func<int, int> square = x => x * x;
            Console.WriteLine(square(5));

            //LINQ 사용예제
            int[] numbers = { 2, 3, 4, 5 };
            var squaredNumbers = numbers.Select(x => x * x);
            Console.WriteLine(string.Join(" ", squaredNumbers));
            
            //식 람다 : (input-parameters) => expression
            //식트리를 만들 수 있음
            Action lamda = () => Console.WriteLine("lamda test");
            lamda();

            Func<int, int, bool> testForEquality = (x, y) => x == y;
            Console.WriteLine((testForEquality(0, 1)));

            //입력 매개 변수 형식은 모두 명시적이거나 암시적이어야 한다.
            //잘못된 예제
            //Func<int, int, bool> testForEquality1 = (int x, y) => x == y;
            //Console.WriteLine((testForEquality(0, 1)));

            //문 람다 : (input-parameters) => { <sequence-of-statements> }
            //식 트리를 만들 수 없음
            //문 람다의 본문에 지정할 수 있는 문의 개수에는 제한이 없지만 일반적으로 2-3개 정도만 지정
            Action<string> greet = name =>
            {
                string greeting = "Hello" + name;
                Console.WriteLine(greeting);
            };
            greet("World");

            //표준 쿼리 연산자를 사용한 람다식
            int[] numbers1 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            int oddNumbers = numbers1.Count(n => n % 2 == 0);
            Console.WriteLine(string.Format(@"There are {0} even numbers in {1}", oddNumbers, string.Join(" ", numbers1)));

            int[] numbers2 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var firstNumbersLessThanSix = numbers2.TakeWhile(n => n < 6);
            Console.WriteLine(string.Join(" ", firstNumbersLessThanSix));

            externalVariablesInLamda();//람다 식에서 외부 변수 및 변수 범위 캡처 예제
        }

        public static void externalVariablesInLamda()
        {
            var game = new VariableCaptureGame();

            int gameInput = 5;
            game.Run(gameInput);

            int jTry = 10;
            bool result = game.isEqualToCapturedLocalVariable(jTry);
            Console.WriteLine(string.Format(@"Captured local variable is equal to {0} : {1}", jTry, result));//캡처된 local variable j는 새로 호출되어 가비지 수집 대상이 될 때까지 수집이 안되므로 10

            int anotherJ = 3;
            game.updateCapturedLocalVariable(anotherJ);//새로 호출되었으므로 10은 가비지 수집이 되고 3이 캡처됨

            bool equalToAnother = game.isEqualToCapturedLocalVariable(anotherJ);
            Console.WriteLine(string.Format(@"Another lambda observes a new value of captured variable: {0}", equalToAnother));
        }
    }

    public class VariableCaptureGame
    {
        //internal : 액세스가 현재 어셈블리로 제한
        internal Action<int> updateCapturedLocalVariable;
        internal Func<int, bool> isEqualToCapturedLocalVariable;

        public void Run(int input)
        {

            int j = 0;

            updateCapturedLocalVariable = x =>
            {
                j = x;
                bool result = j > input;
                Console.WriteLine(String.Format(@"{0} is greater than {1}: {2}", j, input, result));
            };

            isEqualToCapturedLocalVariable = x => x == j;

            Console.WriteLine(String.Format(@"Local variable before lambda invocation: {0}", j));
            updateCapturedLocalVariable(10);
            Console.WriteLine(String.Format(@"Local variable after lambda invocation: {0}", j));
        }
    }
}
