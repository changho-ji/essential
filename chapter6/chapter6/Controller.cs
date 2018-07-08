using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chapter6
{
    public class Controller
    {
        public void Start()
        {
            // 중요 코드
        }

        private void Run()
        {
            Start();
            InternalRun();
            Stop();
        }

        protected virtual void InternalRun()
        {
            // 기본 구현
        }

        public void Stop()
        {
            // 중요 코드
        }
    }
}
