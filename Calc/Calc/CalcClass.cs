using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    // 계산 클래스
    class Calculate
    {
        public Calculate(List<string> listExpr)
        {
            ListExpr = listExpr;
        }

        // 입력된 전체수식 리스트
        private List<string> ListExpr { get; set; }

        // 입력된 전체수식 계산
        public float Calculation()
        {
            int index = 0;

            // 곱셈
            while (true)
            {
                index = ListExpr.FindIndex(x => x == "*");

                if (index == -1) break;

                // 곱셈 후 불필요 List 아이템 삭제
                ListExpr[index - 1] = (float.Parse(ListExpr[index - 1]) * float.Parse(ListExpr[index + 1])).ToString();
                ListExpr.RemoveAt(index);
                ListExpr.RemoveAt(index);
            }

            // 나눗셈
            while (true)
            {
                index = ListExpr.FindIndex(x => x == "/");

                if (index == -1) break;

                // 나눗셈 후 불필요 List 아이템 삭제
                ListExpr[index - 1] = (float.Parse(ListExpr[index - 1]) / float.Parse(ListExpr[index + 1])).ToString();
                ListExpr.RemoveAt(index);
                ListExpr.RemoveAt(index);
            }

            // 덧셈 + 뺄셈 ------ TODO 덧셈 따로, 뺄셈 따로 프로세스 문제에 대해 설명 필요
            while (true)
            {
                if (ListExpr.Count != 2)
                {
                    // 순서대로 덧셈 및 뺄셈
                    if (ListExpr[1] == "+")
                    {
                        ListExpr[0] = (float.Parse(ListExpr[0]) + float.Parse(ListExpr[2])).ToString();
                    }

                    if (ListExpr[1] == "-")
                    {
                        ListExpr[0] = (float.Parse(ListExpr[0]) - float.Parse(ListExpr[2])).ToString();
                    }

                    ListExpr.RemoveAt(1);
                    ListExpr.RemoveAt(1);
                }
                else
                {
                    break;
                }
            }
            return float.Parse(ListExpr[0]);
        }
    }

    // 입력값 검증 및 입력 클래스
    class Validate
    {
        public Validate(List<string> listExpr)
        {
            ListExpr = listExpr;
        }

        // 입력된 전체수식 리스트
        private List<string> ListExpr { get; set; }

        public void Validatiton()
        {
            ConsoleKeyInfo cki;

            string iStr = "";

            while (true)
            {
                cki = Console.ReadKey(true);

                if ((cki.KeyChar >= '0' && cki.KeyChar <= '9') || cki.KeyChar == '.') // 숫자
                {
                    if (cki.KeyChar == '0')
                    {
                        if (ListExpr.Count == 0 || ListExpr[ListExpr.Count - 1] != "/")   // 0으로 나누기 안됨
                        {
                            Console.Write(cki.KeyChar);
                            iStr += cki.KeyChar;
                        }
                    }
                    else if (cki.KeyChar == '.')
                    {
                        if (iStr != "")
                        {
                            Console.Write(cki.KeyChar);
                            iStr += cki.KeyChar;
                        }
                    }
                    else
                    {
                        if (iStr != "0")
                        {
                            Console.Write(cki.KeyChar);
                            iStr += cki.KeyChar;
                        }
                    }
                }
                else if (cki.KeyChar == '*' || cki.KeyChar == '/' || cki.KeyChar == '+' || cki.KeyChar == '-') // 연산자
                {
                    // 연산자 앞에 . 은 올수 없음 ex) 1+20.+
                    // 연산자 중복 입력 방지
                    if ((iStr != "") && (iStr.Substring(iStr.Length - 1) != "."))
                    {
                        // 숫자 검증
                        CheckNumber(iStr);

                        ListExpr.Add(iStr);
                        ListExpr.Add(cki.KeyChar.ToString());
                        iStr = "";
                        Console.Write(cki.KeyChar);
                    }
                    else if (ListExpr.Count == 0 && cki.KeyChar == '-') // 처음 숫자가 음수로 시작될 경우 제일 첫번째에 0 값을 추가
                    {
                        ListExpr.Add("0");
                        ListExpr.Add(cki.KeyChar.ToString());
                        iStr = "";
                        Console.Write(cki.KeyChar);
                    }
                }
                else if (iStr != "" && cki.KeyChar == '=') // 수식 계산
                {
                    // 숫자 검증
                    CheckNumber(iStr);

                    ListExpr.Add(iStr);
                    ListExpr.Add(cki.KeyChar.ToString());
                    break;
                }
            }
        }

        private void CheckNumber(string value)
        {
            // 숫자 검증
            try
            {
                float.Parse(value);
            }
            catch (Exception e)
            {
                Console.WriteLine("");
                Console.WriteLine(e.Message);
                Environment.Exit(0);
            }
        }
    }

    // 계산결과 내역 클래스
    static public class History
    {
        static private List<string> ListHistory = new List<string>();

        // 계산결과 저장하기
        static public void AddHistory(string history)
        {
            ListHistory.Add(history);
        }

        // 계산결과 내역 보기
        static public void ShowHistory()
        {
            for (int i = 0; i < ListHistory.Count; i++)
            {
                Console.WriteLine(ListHistory[i]);
            }
        }
    }

    // 숫자 꾸미기
    static public class Deco
    {
        // 숫자에 콤마 붙이기
        static public string AddComma(string number)
        {
            string rtnValue = "";

            if (number == "*" || number == "/" || number == "+" || number == "-" || number == "=")
            {
                rtnValue = number;
            }
            else
            {
                rtnValue = string.Format("{0:#,##0.##}", float.Parse(number));
            }

            return rtnValue;
        }

        // 숫자에 콤마 빼기
        static public string RemoveComma(string number)
        {
            return number.Replace(",", "");
        }
    }
}