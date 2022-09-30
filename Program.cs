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
            switch(jobType)
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

        static JobType SelectJob()
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

        struct Player
        {
            public int hp;
            public int power;
        }

        static void Main(string[] args)
        {
            Player player;

            JobType jobType;
            jobType = SelectJob();

            CreatePlayer(jobType, out player);

        }
    }
}