using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            DateTime date1 = DateTime.Now;//현재 날짜 및 시간
            DateTime date2 = DateTime.UtcNow;//UTC 세계협정시
            DateTime date3 = DateTime.Today;//현재 날짜
            DateTime startDate = new DateTime(2020, 2, 12, 00, 00, 00);//시작일
            string startHour = "23";//시작 시
            string startMinute = "30";//시작 분
            DateTime endDate = new DateTime(2020, 2, 13, 00, 00, 00);//종료일
            string endHour = "01";//종료 시
            string endMinute = "00";//종료 분

            Console.WriteLine(date1);
            Console.WriteLine(date2);
            Console.WriteLine(date3);

            //시작일과 종료일의 시간차 계산 예제
            calculateTimeDifference(startDate, startHour, startMinute, endDate, endHour, endMinute);
            
        }
        static void calculateTimeDifference(DateTime startDate, string startHour, string startMinute, DateTime endDate, string endHour, string endMinute)
        {
            StringBuilder sb = new StringBuilder();

            startDate = makeDatetime(startDate, startHour, startMinute);
            endDate = makeDatetime(endDate, endHour, endMinute);

            Console.WriteLine("시작일:" + startDate);
            Console.WriteLine("종료일:" + endDate);

            TimeSpan dateDiff = endDate - startDate;//시간 차이

            double dffDays = dateDiff.TotalDays;
            double dffHours = dateDiff.TotalHours;
            double dffMinutes = dateDiff.TotalMinutes;
            double dffSeconds = dateDiff.TotalSeconds;

            sb.Append("dffDays:").Append(dffDays).Append("\r\n");
            sb.Append("dffHours:").Append(dffHours).Append("\r\n");
            sb.Append("dffMinutes:").Append(dffMinutes).Append("\r\n");
            sb.Append("dffSeconds:").Append(dffSeconds).Append("\r\n");
            //시작일과 종료일 일, 시간, 분, 초 차이 출력
            Console.WriteLine(sb.ToString());
        }
        static DateTime makeDatetime(DateTime date, string strHour, string strMinute)
        {//시분초를 제외한 시작일과 종료일, string 문자열의 시분이 주어질 때 시간 생성 

            string strDate = date.ToString("yyyyMMdd");//yyyyMMdd 형식으로 변환
            int year = Convert.ToInt32(strDate.Substring(0,4));
            int month = Convert.ToInt32(strDate.Substring(4,2));
            int day = Convert.ToInt32(strDate.Substring(6,2));
            int hour = Convert.ToInt32(strHour);
            int minute = Convert.ToInt32(strMinute);
            int second = 00;

            //DateTime 생성자를 이용해 시간 임의 생성 (시간 : 00~23 , 분초 : 00~59)
            DateTime returnDate = new DateTime(year, month, day, hour, minute, second);

            return returnDate;
        }
    }
}
