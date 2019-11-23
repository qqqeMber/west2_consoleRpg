using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace west2_consoleRpg
{
    public class Program
    {
        static void Main(string[] args)
        {
            if (GameRes.LoadGameRes())
                Startgame();
            else
            {
                Console.WriteLine("你号没了（康康是不是xml文件不在根目录下面）");
                Console.ReadKey();
            }

        }
        public static void Startgame()
        {
            Console.Title = "真丶坦克大战";
            Console.WriteLine("\n\t\t\t欢迎进入坦克世界");
            Console.WriteLine("\n\n\n\n\t\t是否开始游戏？\n\t\t1.我已准备好了\n\t\t0.我再想想看");
            Console.SetCursorPosition(0,22);
            for(int i = 0; i < 79; i++)
            {
                Console.Write("-");
            }
            Console.SetCursorPosition(0, 23);
            int select = int.Parse(Console.ReadLine());
            if (select == 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\t\t\t下次再见");
                Thread.Sleep(500);
                Environment.Exit(0);
            }
            Thread.Sleep(500);
            Console.Clear();
            string story = "\t\t\t\t鸡你太美\n今有一男，年二十余，喜篮球，每触及之，必大喊：唱跳music。\n又有一女，五十有八，为某榜一所好，隐面，作萝莉状，恐怖如魑魅。\n勇士，你是否能鼓起勇气去挑战他们,当上真正的榜一呢？\n不过在此之前，请先创建你的账号吧";
            foreach (char s in story)
            {
                Console.Write(s);
                Thread.Sleep(10);
            }
            Playerrole.CreatPlayer();
        }
        public static void Mainui()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\n\t\t\t{0}\n\n\n\n\t\t\t1.角色装备\n\n\t\t\t2:角色状态\n\n\t\t\t3.角色技能\n\n\t\t\t4.商店\n\n\t\t\t5.探险\n\n\t\t\t6.开坦克(真)",Playerrole.Instance.name);
            shuaxin_shuxing();
        hehe:
            string cs = Console.ReadLine();
            if (cs == "")
                goto hehe;
            int n = int.Parse(cs);
            switch (n)
            {
                    case 1: Playerrole.Zhuangbei(); break;
                    case 2: Playerrole.Shuxing(); break;
                    case 3: Playerrole.Jineng(); break;
                    case 4: Shop.shop(); break;
                    case 5: Battle.Explore(); break;
                    case 6: Battle.Boss(); break;
            }
        }
       public static void shuaxin_shuxing()
        {
            Playerrole.Instance.atk = Playerrole.Instance.baseatk + Playerrole.Instance.atkrate * Playerrole.Instance.level+ Playerrole.weapon.atk;
            Playerrole.Instance.hp = Playerrole.Instance.basehp + Playerrole.Instance.hprate * Playerrole.Instance.level+Playerrole.equip1.hp+Playerrole.equip2.hp+Playerrole.equip3.hp;
            Playerrole.Instance.mp = Playerrole.Instance.basemp + Playerrole.Instance.mprate * Playerrole.Instance.level+ Playerrole.equip1.mp + Playerrole.equip2.mp + Playerrole.equip3.mp;
            
        }

                
    }
}
