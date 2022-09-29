using System;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isJobSelectTrue = false;

            while(!isJobSelectTrue)
            {
                Console.WriteLine("직업을 선택하세요!\n[1] 기사\n[2] 궁수\n[3] 마법사");
                int jobSelectNum = Convert.ToInt32(Console.ReadLine());
                if (jobSelectNum == 1 || jobSelectNum == 2 || jobSelectNum == 3)
                {
                    isJobSelectTrue = true;
                    break;
                }
            }

        }
    }
}