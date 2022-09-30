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

        struct Player
        {
            public int hp;
            public int power;
        }

        enum MonsterType
        {
            None = 0,
            Slime = 1,
            Orc = 2,
            Skeleton = 3
        }

        struct Monster
        {
            public int hp;
            public int power;
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

        static void CreateRandomMonster(out Monster monster) // 몬스터 랜덤 생성 메서드
        {
            Random random = new Random(); // 랜덤 객체 생성
            int randMonster = random.Next(1, 4);
            
            switch (randMonster) // int값에 따라 몬스터 생성
            {
                case (int)MonsterType.Slime:
                    Console.WriteLine("슬라임이 스폰되었습니다!");
                    monster.hp = 20;
                    monster.power = 2;
                    break;
                case (int)MonsterType.Orc:
                    Console.WriteLine("오크가 스폰되었습니다!");
                    monster.hp = 40;
                    monster.power = 4;
                    break;
                case (int)MonsterType.Skeleton:
                    Console.WriteLine("스켈레톤이 스폰되었습니다!");
                    monster.hp = 30;
                    monster.power = 3;
                    break;
                default:
                    monster.hp = 0;
                    monster.power = 0;
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
                Console.WriteLine("---------------------------");

                switch (input) // 입력값에 따라 직업 설정
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

        static void PrintBothNowHealth(ref Player player, ref Monster monster)
        {
            Console.WriteLine("현재 플레이어의 체력: {0}", player.hp);
            Console.WriteLine("현재 몬스터의 체력: {0}", monster.hp);
            Console.WriteLine("---------------------------");
        }

        static void Fight(ref Player player, ref Monster monster, ref bool isPlayerAlive)
        {
            PrintBothNowHealth(ref player, ref monster); // 시작할 때 체력 프린트
            Console.WriteLine("전투를 시작합니다!");
            while (true)
            {   
                monster.hp -= player.power; // 플레이어의 공격
                if (player.hp <= 0)
                {
                    PrintBothNowHealth(ref player, ref monster); // 죽었을때 체력 프린트
                    Console.WriteLine("플레이어가 사망했습니다!");
                    Console.WriteLine("---------------------------");
                    isPlayerAlive = false; // 죽었으면 false 반환
                    break;
                }

                player.hp -= monster.power; // 몬스터의 반격
                PrintBothNowHealth(ref player, ref monster); // 한대 주고 받은뒤 체력 프린트
                if (monster.hp <= 0)
                {
                    Console.WriteLine("몬스터를 처치했습니다!");
                    isPlayerAlive = true; // 살아있으면 true 반환
                    Console.WriteLine("마을로 복귀합니다!");
                    Console.WriteLine("---------------------------");
                    break;
                }
            }
        }

        static void EnterGame(ref Player player)
        {
            bool isPlayerAlive = true;
            while (true)  // 제대로 입력하기 전까지 무한 반복
            {
                if (isPlayerAlive == false) // 필드에서 돌아온 후 죽어있다면 게임 강제종료
                {
                    break;
                }

                Console.WriteLine("마을에 입장하셨습니다!");
                Console.WriteLine("[1] 필드로 들어가기");
                Console.WriteLine("[2] 로비로 돌아가기");
                string? input = Console.ReadLine();
                Console.WriteLine("---------------------------");
                if (input == "1")
                {
                    EnterField(ref player, ref isPlayerAlive); // 필드 입장
                } 
                else if (input == "2")
                {
                    break; // 마을에서 탈출
                }
            }
        }

        static void EnterField(ref Player player, ref bool isPlayerAlive)
        {
            Console.WriteLine("필드에 입장하셨습니다!");

            Monster monster;
            CreateRandomMonster(out monster); // 몬스터 랜덤 생성

            while (true)
            {
                Console.WriteLine("[1] 전투 모드로 돌입");
                Console.WriteLine("[2] 마을로 도망치기 (50%)");
                string? input = Console.ReadLine();

                if (input == "1")
                {
                    Console.WriteLine("---------------------------");
                    Fight(ref player, ref monster, ref isPlayerAlive); // 싸움 붙이기
                    break;
                }
                else if (input == "2")
                {
                    Random random = new Random(); // 랜덤 객체 생성
                    int rand = random.Next(0, 2);
                    if (rand == 0) // 50%로 도망 실패
                    {
                        Console.WriteLine("도망치는데 실패했습니다!");
                        Console.WriteLine("---------------------------");
                        Fight(ref player, ref monster, ref isPlayerAlive); // 싸움 붙이기
                    }
                    else if (rand == 1) // 50%로 도망 성공
                    {
                        Console.WriteLine("도망치는데 성공했습니다!");
                        Console.WriteLine("---------------------------");
                    }
                    break; // 싸움이 끝나면 혹은 도망에 성공하면 마을로 복귀
                }
            }
        }

        static void Main(string[] args)
        {
            JobType jobType;
            jobType = SelectJob();

            Player player;
            CreatePlayer(jobType, out player); // 플레이어 생성하기 (스텟 정하기)

            EnterGame(ref player); // 마을 입장하기
            Console.WriteLine("게임을 종료합니다!"); // 마을에서 나오면 프로그램 종료
        }
    }
}