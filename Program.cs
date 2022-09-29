using System;

namespace CSharp
{
    class Program
    {
        enum JobType
        {
            None = 0,
            Knight = 1,
            Archer = 2,
            Mage = 3
        }

        JobType SelectJob()
        {
            JobType jobType = JobType.None;

            while (jobType == JobType.None)
            {
                Console.WriteLine("직업을 선택하세요!\n[1] 기사\n[2] 궁수\n[3] 마법사");
                string? input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        jobType = JobType.Knight;
                        break;
                    case "2":
                        jobType = JobType.Archer;
                        break;
                    case "3":
                        jobType = JobType.Mage;
                        break;
                }
            }

            return jobType;
        }

        static void Main(string[] args)
        {
            JobType jobType;
            Program p = new Program();
            jobType = p.SelectJob();

        }
    }
}