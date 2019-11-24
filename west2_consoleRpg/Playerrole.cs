using System;
using System.Collections.Generic;
using System.Text;

namespace west2_consoleRpg
{
    class Playerrole
    {
        public string name;
        public int atk;
        public int hp;
        public int mp;
        public int baseatk;
        public int basehp;
        public int basemp;
        public int jobid;
        public int gold;
        public int level;
        public static Weapon weapon;
        public int hprate;
        public int mprate;
        public int atkrate;
        public static Equip equip1, equip2, equip3;
        public static Skill skill1, skill2, skill3, skill4, skill5;
        public static Item item1=GameRes.GetItem(1), item2=GameRes.GetItem(2), item3=GameRes.GetItem(3), item4=GameRes.GetItem(4),item5=GameRes.GetItem(5);
        public static int i1=0, i2=0, i3=0, i4=0,i5=0;
        public static Playerrole Instance = new Playerrole();
        
        public static void CreatPlayer()
        {
            Console.WriteLine("\n\t\t\t创建角色");
            Console.WriteLine("\t角色名称:");
            Console.Write("\t");
            Playerrole.Instance.name = Console.ReadLine();
            Console.WriteLine("\t角色职业:1.战士  2.刺客  3.法师（每个职业成长率不同，技能相同）\n\tps:因为太麻烦了...");
            Console.Write("\t");
            Playerrole.Instance.jobid = int.Parse(Console.ReadLine());
            Console.WriteLine("\t1.确认  2.重新输入");
            Console.Write("\t");
        hehe:
            string cs = Console.ReadLine();
            if (cs == "")
                goto hehe;
            int n = int.Parse(cs);
            if (n == 1)
            {
                Instance.basehp = GameRes.GetJob(Instance.jobid).hp;
                Instance.basemp = GameRes.GetJob(Instance.jobid).mp;
                Instance.baseatk = GameRes.GetJob(Instance.jobid).atk;
                Instance.hprate = GameRes.GetJob(Instance.jobid).hprate;
                Instance.mprate = GameRes.GetJob(Instance.jobid).mprate;
                Instance.atkrate = GameRes.GetJob(Instance.jobid).atkrate;
                Playerrole.weapon = GameRes.GetWeapon(1);
                Playerrole.equip1 = GameRes.GetEquip(1);
                Playerrole.equip2 = GameRes.GetEquip(4);
                Playerrole.equip3 = GameRes.GetEquip(6);
                Playerrole.skill1 = GameRes.GetSkill(1);
                Playerrole.skill2 = GameRes.GetSkill(2);
                Playerrole.skill3 = GameRes.GetSkill(3);
                Playerrole.skill4 = GameRes.GetSkill(4);
                Playerrole.skill5 = GameRes.GetSkill(5);

                Program.Mainui();
            }
        }
        public static void Zhuangbei()
        {
            Console.Clear();
            try
            {
                Console.WriteLine("\t\t\t{0}", Instance.name);
                Console.WriteLine("\t\t\t{0}", GameRes.GetJob(Instance.jobid).name);
                Console.WriteLine("\t\t武器:{0}", Playerrole.weapon.name);
                Console.WriteLine("\t\t胸甲:{0}", equip1.name);
                Console.WriteLine("\t\t腰带:{0}", equip2.name);
                Console.WriteLine("\t\t靴子:{0}", equip3.name);
                Console.WriteLine("ps:可以去商店买装备哦");
                Console.ReadKey();
                Program.Mainui();
            }
            catch
            {
                Console.WriteLine("你啥都没，别康惹");
                Console.ReadKey();
                Program.Mainui();
            }
            
        }
        public static void Shuxing()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t{0}", Instance.name);
            Console.WriteLine("\t\t\t  职业：{0}", GameRes.GetJob(Instance.jobid).name);
            Console.WriteLine("\t\t\t等级:{0}", Instance.level);
            Console.WriteLine("\t\t\t攻击:{0}", Instance.atk);
            Console.WriteLine("\t\t\t血量:{0}", Instance.hp);
            Console.WriteLine("\t\t\t法力值:{0}", Instance.mp);
            Console.WriteLine("\t\t\t金币:{0}", Instance.gold);
            Console.WriteLine("这么弱，还怎么干坦克");
            Console.ReadKey();
            Program.Mainui();
        }
        public static void Jineng()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t{0}", Instance.name);
            if (Instance.level < 5)
            {
                Console.WriteLine("康什么康，快去升级");
            }
            else if (Instance.level >= 5 && Instance.level < 10)
            {
                Console.WriteLine("\t\t\t技能1:{0} 消耗:{1}mp 造成{2}倍攻击力的伤害", skill1.name, skill1.mp, skill1.rate);
            }
            else if (Instance.level >= 10 && Instance.level < 15)
            {
                Console.WriteLine("\t\t\t技能1:{0} 消耗:{1}mp 造成{2}倍攻击力的伤害", skill1.name, skill1.mp, skill1.rate);
                Console.WriteLine("\t\t\t技能2:{0} 消耗:{1}mp 造成{2}倍攻击力的伤害", skill2.name, skill2.mp, skill2.rate);
            }
            else if (Instance.level >= 15 && Instance.level < 20)
            {
                Console.WriteLine("\t\t\t技能1:{0} 消耗:{1}mp 造成{2}倍攻击力的伤害", skill1.name, skill1.mp, skill1.rate);
                Console.WriteLine("\t\t\t技能2:{0} 消耗:{1}mp 造成{2}倍攻击力的伤害", skill2.name, skill2.mp, skill2.rate);
                Console.WriteLine("\t\t\t技能3:{0} 消耗:{1}mp 造成{2}倍攻击力的伤害", skill3.name, skill3.mp, skill3.rate);

            }
            else if (Instance.level >= 20 && Instance.level < 25)
            {
                Console.WriteLine("\t\t\t技能1:{0} 消耗:{1}mp 造成{2}倍攻击力的伤害", skill1.name, skill1.mp, skill1.rate);
                Console.WriteLine("\t\t\t技能2:{0} 消耗:{1}mp 造成{2}倍攻击力的伤害", skill2.name, skill2.mp, skill2.rate);
                Console.WriteLine("\t\t\t技能3:{0} 消耗:{1}mp 造成{2}倍攻击力的伤害", skill3.name, skill3.mp, skill3.rate);
                Console.WriteLine("\t\t\t技能4:{0} 消耗:{1}mp 造成{2}倍攻击力的伤害", skill4.name, skill4.mp, skill4.rate);

            }
            else
            {
                Console.WriteLine("\t\t\t技能1:{0} 消耗:{1}mp 造成{2}倍攻击力的伤害", skill1.name, skill1.mp, skill1.rate);
                Console.WriteLine("\t\t\t技能2:{0} 消耗:{1}mp 造成{2}倍攻击力的伤害", skill1.name, skill1.mp, skill1.rate);
                Console.WriteLine("\t\t\t技能3:{0} 消耗:{1}mp 造成{2}倍攻击力的伤害", skill3.name, skill3.mp, skill3.rate);
                Console.WriteLine("\t\t\t技能4:{0} 消耗:{1}mp 造成{2}倍攻击力的伤害", skill4.name, skill4.mp, skill4.rate);
                Console.WriteLine("\t\t\t技能5:{0} 消耗:{1}mp 造成{2}倍攻击力的伤害", skill5.name, skill5.mp, skill5.rate);
            }
            Console.ReadKey();
            Program.Mainui();
        }
   
    }    
}

