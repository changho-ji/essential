using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu();
        }

        // 메인메뉴
        static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("메뉴를 선택하세요");
            Console.WriteLine("1. 이전계산식 전체조회 ");
            Console.WriteLine("2. 계산기");
            Console.WriteLine("3. 종료");
            string inNum = Console.ReadLine();

            switch (inNum)
            {
                case "1":
                    ShowHistory();
                    break;
                case "2":
                    Calculator();
                    break;
                case "3":
                    break;
                default:
                    MainMenu();
                    break;
            }
        }

        // 계산 내역 조회
        static void ShowHistory()
        {
            Console.Clear();

            Console.WriteLine("계산 내역");
            History.ShowHistory();
            Console.WriteLine("\n");
            Console.WriteLine("메뉴를 선택하세요");
            Console.WriteLine("1. 메인메뉴 ");
            Console.WriteLine("2. 계산기");
            Console.WriteLine("3. 종료");
            string inNum = Console.ReadLine();

            switch (inNum)
            {
                case "1":
                    MainMenu();
                    break;
                case "2":
                    Calculator();
                    break;
                case "3":
                    break;
                default:
                    MainMenu();
                    break;
            }
        }

        // 계산기
        static void Calculator()
        {
            string inputVal = "";
            List<string> listExpr = new List<string>();

            // 숫자 및 연산자 반복 입력("=" 이 입력되면 입력종료)
            while (inputVal != "=")
            {
                Console.Clear();
                Console.WriteLine("계산기(숫자와, 연산자를 한번씩 입력하고, 엔터를 입력하세요)");
                Console.Write("계산식: ");

                for (int i = 0; i < listExpr.Count; i++)
                {
                    Console.Write(listExpr[i]);
                }

                Console.WriteLine();

                inputVal = Console.ReadLine();

                // TODO Validation 체크
                // 수식이 음수로 시작되면 listExpr 제일 앞에 0 입력
                // 숫자와 +,-,*,-,= 을 제외한 숫자 입력 방지
                // 숫자 다음에 숫자, 연산자 다음에 영산자는 올수 없음

                listExpr.Add(inputVal);
            }

            // 계산 결과
            Console.Clear();
            Console.Write("계산결과: ");

            string sExpr = "";

            for (int i = 0; i < listExpr.Count; i++)
            {
                sExpr += listExpr[i];
            }

            Calculate calc = new Calculate(listExpr);

            // 수식 계산 값
            sExpr += calc.Calculation().ToString();

            Console.WriteLine(sExpr);

            // 계산 날짜 추가
            sExpr = "(" + DateTime.Now + ") " + sExpr;

            // 계산 내역 저장
            History.AddHistory(sExpr);

            Console.WriteLine();
            Console.WriteLine("메뉴를 선택하세요");
            Console.WriteLine("1. 메인메뉴");
            Console.WriteLine("2. 이전계산식 전체조회 ");
            Console.WriteLine("3. 계산기");
            Console.WriteLine("4. 종료");
            string inNum = Console.ReadLine();

            switch (inNum)
            {
                case "1":
                    MainMenu();
                    break;
                case "2":
                    ShowHistory();
                    break;
                case "3":
                    Calculator();
                    break;
                case "4":
                    break;
                default:
                    MainMenu();
                    break;
            }
        }
    }
}