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

        static void CreatePlayer(JobType jobType, out Player player)
        {
            switch(jobType) // 직업에 따른 기본스텟 자동 분배
            {
                case JobType.Knight:
                    player.hp = 100;
                    player.power = 10;
                    break;
                case JobType.Archer:
                    player.hp = 75;
                    player.power = 12;
                    break;
                case JobType.Mage:
                    player.hp = 50;
                    player.power = 15;
                    break;
                default:
                    player.hp = 0;
                    player.power = 0;
                    break;
            }
        }

        static JobType SelectJob() // 직업 선택 메서드
        {
            JobType jobType = JobType.None;

            while (jobType == JobType.None) // 제대로 입력하기 전까지 무한 반복
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

        struct Player
        {
            public int hp;
            public int power;
        }

        static void Main(string[] args)
        {
            JobType jobType;
            jobType = SelectJob();

            Player player;
            CreatePlayer(jobType, out player);

        }
    }
}