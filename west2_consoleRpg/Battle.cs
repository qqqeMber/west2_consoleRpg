using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace west2_consoleRpg
{
    class Battle
    {
        private static Monster monster;
        public enum STATE
        {
            DEAD = -1,
            ALIVE = 0,
            VECTORY = 1,
            ERROR = 2
        }


        public static void Explore()
        {
            Console.Clear();
            while (true)
            {
                Program.Shuaxin_shuxing();
                Console.WriteLine("\t\t\t探险中");
                Console.SetCursorPosition(5, 5);
                Console.WriteLine("{0}", Playerrole.Instance.name);
                Console.WriteLine("\t等级:{0}", Playerrole.Instance.level);
                Console.WriteLine("\t金币:{0}", Playerrole.Instance.gold);
                Console.WriteLine("\n\n输入 1 继续探险 \n输入 0 返回主界面");
                Console.SetCursorPosition(0, 22);
                for (int i = 0; i < 79; i++)
                {
                    Console.Write("-");
                }
                Console.SetCursorPosition(0, 23);
            hehe:
                string cs = Console.ReadLine();
                if (cs == "")
                    goto hehe;
                int n = int.Parse(cs);
                switch (n)
                {
                    case 1:
                        if (Playerrole.Instance.level <= 10)
                        {
                            monster = GameRes.GetMonster(1).Clone();
                            Console.Clear();
                            StartBattle();
                        }
                        else if (Playerrole.Instance.level <= 20)
                        {
                            monster = GameRes.GetMonster(2).Clone();
                            Console.Clear();
                            StartBattle();
                        }
                        else if (Playerrole.Instance.level <= 100)
                        {
                            monster = GameRes.GetMonster(3).Clone();
                            Console.Clear();
                            StartBattle();
                        }

                        else
                        {
                            Console.WriteLine("你这么diao，怎么不去打boss？？？");
                        }
                        continue;
                    case 0: Program.Mainui();break;
                    default:
                        goto hehe;
                }
            }
        }
        public static void Boss()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("坦克们正在跃跃欲试地等你挑战呢");
            int i = 4;
            for (; i < 8; i++)
            {
                monster = GameRes.GetMonster(i).Clone();
                Console.Clear();
                StartBattle();
                Console.Clear(); 
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("哇兄弟nb啊你打败了第{0}个boss,后面还有{1}个boss等着你呢",i - 3,8-i-1);
                Console.ReadKey();
                Console.ForegroundColor = ConsoleColor.White;
            }
            if (i == 8)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\t\t\t恭喜你,你通关了\n\t你成功地打败了蔡徐坤和乔碧萝，战胜了坦克，成为了世界的主宰\n\tbyebye");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }
        public static void StartBattle()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                PrintInfo();
            hehe:
                string cs = Console.ReadLine();
                if (cs == "")
                    goto hehe;
                int n = int.Parse(cs);
                STATE state;
                switch (n)
                {
                    case 1:
                        state = DoaAttack();
                        break;
                    case 2:
                        state = SkillAttack();
                        break;

                    case 3:
                        state = Useitem();
                        break;
                    default:
                        state = STATE.ERROR;
                        Console.WriteLine("你输你horse呢");
                        Console.ReadKey();
                        break;
                }
                if (state != STATE.ERROR && state != STATE.ALIVE)
                {
                    BattleResult(state);
                    break;
                }
            }

        }
        private static void PrintInfo()
        {
            Console.Clear();
            Console.SetCursorPosition(5, 5);
            Console.WriteLine("{0}",Playerrole.Instance.name);
            Console.WriteLine("\t等级:{0}", Playerrole.Instance.level);
            Console.WriteLine("\t血量:{0}",Playerrole.Instance.hp);
            Console.WriteLine("\t法力值:{0}" ,Playerrole.Instance.mp);
            Console.WriteLine("\t攻击力:{0}", Playerrole.Instance.atk);
            Console.SetCursorPosition(50, 5);
            Console.WriteLine("{0}", monster.name);
            Console.SetCursorPosition(50, 6);
            Console.WriteLine("血量:"+ monster.hp);
            Console.SetCursorPosition(60, 15);
            Console.WriteLine("选择行动:");
            Console.SetCursorPosition(60, 16);
            Console.WriteLine("1.攻击");
            Console.SetCursorPosition(60, 17);
            Console.WriteLine("2.技能");
            Console.SetCursorPosition(60, 18);
            Console.WriteLine("3.道具");
            Console.SetCursorPosition(0, 20);
            for (int i = 0; i < 79; i++)
            {
                Console.Write("-");
            }
            Console.SetCursorPosition(0, 21);
            Console.WriteLine("你的选择:");
        }
        private static STATE DoaAttack()
        {
            int damage = Playerrole.Instance.atk;
            monster.hp -= damage;
            Console.SetCursorPosition(0, 14);
            Console.WriteLine("你对{0}使用普通攻击,造成{1}点伤害", monster.name, damage);

            if (monster.hp <= 0)
            {
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("他死了");
                Console.ReadKey();
                return STATE.VECTORY;
            }
            
            damage = monster.atk;
            Playerrole.Instance.hp -= damage;
            Console.SetCursorPosition(0, 17);
            Console.WriteLine("{0}对你进行攻击,造成{1}点伤害", monster.name, damage);
            Console.ReadKey();
            if (Playerrole.Instance.hp <= 0)
            {
                Console.ReadKey();
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(35, 15);
                Console.WriteLine("菜");
                Console.ReadKey();
                return STATE.DEAD;
            }
            return STATE.ALIVE;

        }
        private static void BattleResult(STATE result)
        {
            switch (result)
            {
                case STATE.DEAD:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("你死了，你号没了，别玩了。\n这都能死，你也太菜了，你被榜一抓去和乔碧萝结婚了");
                    Environment.Exit(0);
                    break;
                case STATE.VECTORY:
                    Console.Clear();
                    Console.SetCursorPosition(35, 10);
                    Console.WriteLine("你赢了\n\t\t你升了一级（对 就是打一个怪升一级）\n\t\t你获得了40g（固定的），还要继续吗？");
                    Playerrole.Instance.level++;
                    Playerrole.Instance.gold += 40;
                    Playerrole.Instance.atk = Playerrole.Instance.baseatk + Playerrole.Instance.atkrate * Playerrole.Instance.level + Playerrole.weapon.atk;
                    Playerrole.Instance.hp = Playerrole.Instance.basehp + Playerrole.Instance.hprate * Playerrole.Instance.level + Playerrole.equip1.hp + Playerrole.equip2.hp + Playerrole.equip3.hp;
                    Playerrole.Instance.mp = Playerrole.Instance.basemp + Playerrole.Instance.mprate * Playerrole.Instance.level + Playerrole.equip1.mp + Playerrole.equip2.mp + Playerrole.equip3.mp;


                    Console.ReadKey();
                    Console.Clear();
                    break;
            }
        }
        private static STATE SkillAttack()
        {
            Console.Clear();
                float damage= Playerrole.Instance.atk;
            if (Playerrole.Instance.level < 5)
            {
                Console.WriteLine("康什么康,没技能，快去升级");
                Console.ReadKey();
                return STATE.ALIVE;
            }
            else if (Playerrole.Instance.level >= 5 && Playerrole.Instance.level < 10)
            {
                Console.SetCursorPosition(0, 15);
                Console.WriteLine("技能1:{0} 消耗:{1}mp 造成{2}倍攻击力的伤害", Playerrole.skill1.name, Playerrole.skill1.mp, Playerrole.skill1.rate);
                
            }
            else if (Playerrole.Instance.level >= 10 && Playerrole.Instance.level < 15)
            {

                Console.SetCursorPosition(0, 15);
                Console.WriteLine("技能1:{0} 消耗:{1}mp 造成{2}倍攻击力的伤害", Playerrole.skill1.name, Playerrole.skill1.mp, Playerrole.skill1.rate);
                Console.SetCursorPosition(0, 16);
                Console.WriteLine("\t\t\t技能2:{0} 消耗:{1}mp 造成{2}倍攻击力的伤害", Playerrole.skill2.name, Playerrole.skill2.mp, Playerrole.skill2.rate);
            }
            else if (Playerrole.Instance.level >= 15 && Playerrole.Instance.level < 20)
            {

                Console.SetCursorPosition(0, 15);
                Console.WriteLine("\t\t\t技能1:{0} 消耗:{1}mp 造成{2}倍攻击力的伤害", Playerrole.skill1.name, Playerrole.skill1.mp, Playerrole.skill1.rate);
                Console.SetCursorPosition(0, 16);
                Console.WriteLine("\t\t\t技能2:{0} 消耗:{1}mp 造成{2}倍攻击力的伤害", Playerrole.skill2.name, Playerrole.skill2.mp, Playerrole.skill2.rate);
                Console.SetCursorPosition(0, 17);
                Console.WriteLine("\t\t\t技能3:{0} 消耗:{1}mp 造成{2}倍攻击力的伤害", Playerrole.skill3.name, Playerrole.skill3.mp, Playerrole.skill3.rate);

            }
            else if (Playerrole.Instance.level >= 20 && Playerrole.Instance.level < 25)
            {

                Console.SetCursorPosition(0, 15);
                Console.WriteLine("\t\t\t技能1:{0} 消耗:{1}mp 造成{2}倍攻击力的伤害", Playerrole.skill1.name, Playerrole.skill1.mp, Playerrole.skill1.rate);
                Console.SetCursorPosition(0, 16);
                Console.WriteLine("\t\t\t技能2:{0} 消耗:{1}mp 造成{2}倍攻击力的伤害", Playerrole.skill2.name, Playerrole.skill2.mp, Playerrole.skill2.rate);
                Console.SetCursorPosition(0, 17);
                Console.WriteLine("\t\t\t技能3:{0} 消耗:{1}mp 造成{2}倍攻击力的伤害", Playerrole.skill3.name, Playerrole.skill3.mp, Playerrole.skill3.rate);
                Console.SetCursorPosition(0, 18);
                Console.WriteLine("\t\t\t技能4:{0} 消耗:{1}mp 造成{2}倍攻击力的伤害", Playerrole.skill4.name, Playerrole.skill4.mp, Playerrole.skill4.rate);

            }
            else
            {

                Console.SetCursorPosition(0, 15);
                Console.WriteLine("\t\t\t技能1:{0} 消耗:{1}mp 造成{2}倍攻击力的伤害", Playerrole.skill1.name, Playerrole.skill1.mp, Playerrole.skill1.rate);
                Console.SetCursorPosition(0, 16);
                Console.WriteLine("\t\t\t技能2:{0} 消耗:{1}mp 造成{2}倍攻击力的伤害", Playerrole.skill2.name, Playerrole.skill2.mp, Playerrole.skill2.rate);
                Console.SetCursorPosition(0, 17);
                Console.WriteLine("\t\t\t技能3:{0} 消耗:{1}mp 造成{2}倍攻击力的伤害", Playerrole.skill3.name, Playerrole.skill3.mp, Playerrole.skill3.rate);
                Console.SetCursorPosition(0, 18);
                Console.WriteLine("\t\t\t技能4:{0} 消耗:{1}mp 造成{2}倍攻击力的伤害", Playerrole.skill4.name, Playerrole.skill4.mp, Playerrole.skill4.rate);
                Console.SetCursorPosition(0, 19);
                Console.WriteLine("\t\t\t技能5:{0} 消耗:{1}mp 造成{2}倍攻击力的伤害", Playerrole.skill5.name, Playerrole.skill5.mp, Playerrole.skill5.rate);
            }
            Console.SetCursorPosition(0, 22);
            for (int i = 0; i < 79; i++)
            {
                Console.Write("-");
            }
            Console.SetCursorPosition(0, 23);
            Console.WriteLine("你的选择(输入0返回):");
                int n = int.Parse(Console.ReadLine());
            try
            {
                Skill skill=new Skill();
                switch (n)
                {
                    case 0: return STATE.ALIVE;
                    case 1: damage = Playerrole.skill1.rate * Playerrole.Instance.atk; skill = Playerrole.skill1; break;
                    case 2: damage = Playerrole.skill2.rate * Playerrole.Instance.atk; skill = Playerrole.skill2; break;
                    case 3: damage = Playerrole.skill3.rate * Playerrole.Instance.atk; skill = Playerrole.skill3; break;
                    case 4: damage = Playerrole.skill4.rate * Playerrole.Instance.atk; skill = Playerrole.skill4; break;
                    case 5: damage = Playerrole.skill5.rate * Playerrole.Instance.atk; skill = Playerrole.skill5; break;
                }
                Console.Clear();
                PrintInfo();
                Playerrole.Instance.mp -= skill.mp;
                if (Playerrole.Instance.mp <= 0)
                {

                    Playerrole.Instance.mp += skill.mp;
                    Console.WriteLine("没蓝了用什么技能,菜");
                    Console.ReadKey();
                    return STATE.ALIVE;
                }
                    monster.hp -= Convert.ToInt32(damage);
                Console.SetCursorPosition(10, 14);
                
                Console.WriteLine("你对{0}使用{2},造成{1}点伤害", monster.name, damage, skill.name);

                if (monster.hp <= 0)
                {
                    Console.ReadKey();
                    return STATE.VECTORY;
                }

                damage = monster.atk;
                Playerrole.Instance.hp -= Convert.ToInt32(damage);
                Console.SetCursorPosition(10, 17);
                Console.WriteLine("{0}对你进行攻击,造成{1}点伤害", monster.name, damage);
                if (Playerrole.Instance.hp <= 0)
                {
                    Console.ReadKey();
                    return STATE.DEAD;
                }

                Console.ReadKey();
                return STATE.ALIVE;
            }
            catch
            {
                Console.WriteLine("你等级不够");
                return STATE.ALIVE;
            }


        }
        private static STATE Useitem()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 15);
            Console.WriteLine("道具1:{0}\t回复血量:{1}\t回复法力:{2}\t数量:{3}", Playerrole.item1.name, Playerrole.item1.hp, Playerrole.item1.mp,Playerrole.i1);
            Console.SetCursorPosition(0, 16);
            Console.WriteLine("道具2:{0}\t回复血量:{1}\t回复法力:{2}\t数量:{3}", Playerrole.item2.name, Playerrole.item2.hp, Playerrole.item2.mp, Playerrole.i2);
            Console.SetCursorPosition(0, 17);
            Console.WriteLine("道具3:{0}\t回复血量:{1}\t回复法力:{2}\t数量:{3}", Playerrole.item3.name, Playerrole.item3.hp, Playerrole.item3.mp, Playerrole.i3);
            Console.SetCursorPosition(0, 18);
            Console.WriteLine("道具4:{0}\t回复血量:{1}\t回复法力:{2}\t数量:{3}", Playerrole.item4.name, Playerrole.item4.hp, Playerrole.item4.mp, Playerrole.i4);
            Console.SetCursorPosition(0, 19);
            Console.WriteLine("道具5:{0}\t回复血量:{1}\t回复法力:{2}\t数量:{3}", Playerrole.item5.name, Playerrole.item5.hp, Playerrole.item5.mp, Playerrole.i5);
            Console.SetCursorPosition(0, 22);
            for (int i = 0; i < 79; i++)
            {
                Console.Write("-");
            }
            Console.SetCursorPosition(0, 23);
            Console.WriteLine("你的选择(输入0返回):");
        hehe:
            string cs = Console.ReadLine();
            if (cs == "")
                goto hehe;
            int n = int.Parse(cs);
            switch (n)
            {
                case 0: return STATE.ALIVE;
                case 1:
                    if (Playerrole.i1 == 0)
                    {
                        Console.WriteLine("一个都没还想用，想啥呢");
                        Console.ReadKey();
                        return STATE.ALIVE;
                    }
                    else
                    {
                        Item item = Playerrole.item1;
                        Playerrole.Instance.hp += item.hp;
                        Playerrole.Instance.mp += item.mp;
                        Console.SetCursorPosition(10, 14);
                        Console.WriteLine("你使用了{0},回复生命{1},回复法力{2}", item.name, item.hp, item.mp);
                        Playerrole.i1--;
                        Console.ReadKey();
                        break;
                    }
                case 2:
                    if (Playerrole.i2 == 0)
                    {
                        Console.WriteLine("一个都没还想用，想啥呢");
                        Console.ReadKey();
                        return STATE.ALIVE;
                    }
                    else
                    {
                        Item item = Playerrole.item2;
                        Playerrole.Instance.hp += item.hp;
                        Playerrole.Instance.mp += item.mp;
                        Console.SetCursorPosition(10, 14);
                        Console.WriteLine("你使用了{0},回复生命{1},回复法力{2}", item.name, item.hp, item.mp);
                        Console.ReadKey();
                        break;
                    }
                case 3:
                    if (Playerrole.i3 == 0)
                    {
                        Console.WriteLine("一个都没还想用，想啥呢");
                        Console.ReadKey();
                        return STATE.ALIVE;
                    }
                    else
                    {
                        Item item = Playerrole.item3;
                        Playerrole.Instance.hp += item.hp;
                        Playerrole.Instance.mp += item.mp;
                        Console.SetCursorPosition(10, 14);
                        Console.WriteLine("你使用了{0},回复生命{1},回复法力{2}", item.name, item.hp, item.mp);
                        Console.ReadKey();
                        break;
                    }
                case 4:
                    if (Playerrole.i4 == 0)
                    {
                        Console.WriteLine("一个都没还想用，想啥呢");
                        Console.ReadKey();
                        return STATE.ALIVE;
                    }
                    else
                    {
                        Item item = Playerrole.item4;
                        Playerrole.Instance.hp += item.hp;
                        Playerrole.Instance.mp += item.mp;
                        Console.SetCursorPosition(10, 14);
                        Console.WriteLine("你使用了{0},回复生命{1},回复法力{2}", item.name, item.hp, item.mp);
                        Console.ReadKey();
                        break;

                    }
                case 5:
                    if (Playerrole.i5 == 0)
                    {
                        Console.WriteLine("一个都没还想用，想啥呢");
                        Console.ReadKey();
                        return STATE.ALIVE;
                    }
                    else
                    {
                        Item item = Playerrole.item5;
                        Playerrole.Instance.hp += item.hp;
                        Playerrole.Instance.mp += item.mp;
                        Console.SetCursorPosition(10, 14);
                        Console.WriteLine("你使用了{0},回复生命{1},回复法力{2}", item.name, item.hp, item.mp);
                        Console.ReadKey();
                        break;

                    }
                default:
                    return STATE.ALIVE;


            }
            int damage = monster.atk;
            Playerrole.Instance.hp -= damage;
            Console.SetCursorPosition(0, 17);
            Console.WriteLine("{0}对你进行攻击,造成{1}点伤害", monster.name, damage);
            if (Playerrole.Instance.hp <= 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(35, 15);
                Console.WriteLine("菜");
                Console.ReadKey();
                return STATE.DEAD;
            }
            Console.ReadKey();
            return STATE.ALIVE;

        }
    }
}
