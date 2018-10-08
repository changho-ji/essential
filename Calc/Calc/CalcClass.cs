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

            // 덧셈
            while (true)
            {
                index = ListExpr.FindIndex(x => x == "+");

                if (index == -1) break;

                // 덧셈 후 불필요 List 아이템 삭제
                ListExpr[index - 1] = (float.Parse(ListExpr[index - 1]) + float.Parse(ListExpr[index + 1])).ToString();
                ListExpr.RemoveAt(index);
                ListExpr.RemoveAt(index);
            }

            // 뺄셈
            while (true)
            {
                index = ListExpr.FindIndex(x => x == "-");

                if (index == -1) break;

                // 뺄셈 후 불필요 List 아이템 삭제
                ListExpr[index - 1] = (float.Parse(ListExpr[index - 1]) - float.Parse(ListExpr[index + 1])).ToString();
                ListExpr.RemoveAt(index);
                ListExpr.RemoveAt(index);
            }

            return float.Parse(ListExpr[0]);
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

    // 검증 클래스
    static public class Validate
    {
        // TODO 입력값 검증
        static public Boolean InputValidatiton()
        {
            Boolean rtn = false;

            return rtn;
        }
    }
}