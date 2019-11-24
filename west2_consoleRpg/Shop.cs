using System;
using System.Collections.Generic;
using System.Text;

namespace west2_consoleRpg
{
    class Shop
    {
        private static void BuyWeapon()
        {
    hape:    Console.Clear();
            Console.WriteLine("\t武器:");
            for (int i = 1; i < 6; i++)
            {
                _ = new Weapon();
                Weapon weapon = GameRes.GetWeapon(i);
                Console.WriteLine("id:{0}\t武器名:{1}\t攻击力:{2}\t价格:{3}", weapon.id, weapon.name, weapon.atk, weapon.price);
            }
                Console.SetCursorPosition(0, 20);
                for (int a = 0; a < 79; a++)
                {
                    Console.Write("-");
                }
                Console.SetCursorPosition(0, 21);
                Console.WriteLine("你的选择:（输入武器id购买，输入0返回商店）");
                Console.SetCursorPosition(0, 22);
            hehe:
                string cs = Console.ReadLine();
                if (cs == "")
                    goto hehe;
                int n = int.Parse(cs);
                switch (n)
                {
                    case 0 : shop();break;
                    case 1 :
                        if (Playerrole.Instance.gold >= GameRes.GetWeapon(1).price)
                        {
                            Playerrole.weapon = GameRes.GetWeapon(1);
                        Console.WriteLine("购买成功.你还有{0}金币", Playerrole.Instance.gold);
                        Console.ReadKey();
                        Console.Clear();
                        goto hape;
                    }
                        else
                        {
                            Console.WriteLine("没钱你还想买，白嫖吗？，想peach");
                            Console.ReadKey();
                            goto hehe;
                        }
                    case 2 :
                        if (Playerrole.Instance.gold >= GameRes.GetWeapon(2).price)
                        {
                            Playerrole.weapon = GameRes.GetWeapon(2);
                        Console.WriteLine("购买成功.你还有{0}金币", Playerrole.Instance.gold);
                        Console.ReadKey();
                        Console.Clear();
                        goto hape;
                    }
                        else
                        {
                            Console.WriteLine("没钱你还想买，白嫖吗？，想peach");
                            Console.ReadKey();
                            goto hehe;
                        }
                    case 3 :
                        Console.Clear();
                        if (Playerrole.Instance.gold >= GameRes.GetWeapon(3).price)
                        {
                            Playerrole.weapon = GameRes.GetWeapon(3);
                            Playerrole.Instance.gold -= Playerrole.weapon.price;
                        Console.WriteLine("购买成功.你还有{0}金币", Playerrole.Instance.gold);
                        Console.ReadKey();
                        Console.Clear();
                        goto hape;
                    }
                        else
                        {
                            Console.WriteLine("没钱你还想买，白嫖吗？，想peach");
                            Console.ReadKey();
                            goto hehe;
                        }
                    case 4 :
                        if (Playerrole.Instance.gold >= GameRes.GetWeapon(4).price)
                        {
                            Playerrole.weapon = GameRes.GetWeapon(4);
                            Playerrole.Instance.gold -= Playerrole.weapon.price;
                        Console.WriteLine("购买成功.你还有{0}金币", Playerrole.Instance.gold);
                        Console.ReadKey();
                        Console.Clear();
                        goto hape;
                    }
                        else
                        {
                            Console.WriteLine("没钱你还想买，白嫖吗？，想peach");
                            Console.ReadKey();
                            goto hehe;
                        }
                    case 5:
                        if (Playerrole.Instance.gold >= GameRes.GetWeapon(5).price)
                        {
                            Playerrole.weapon = GameRes.GetWeapon(5);
                            Playerrole.Instance.gold -= Playerrole.weapon.price;
                        Console.WriteLine("购买成功.你还有{0}金币", Playerrole.Instance.gold);
                        Console.ReadKey();
                        Console.Clear();
                        goto hape;
                        }
                        else
                        {
                            Console.WriteLine("没钱你还想买，白嫖吗？，想peach");
                            Console.ReadKey();
                            goto hehe;
                        }
                default:
                    goto hape;
                }
            
            
        }
        private static void BuyEquip()
        {
    hape:    Console.Clear();
            Console.WriteLine("\t装备");
            for (int i = 1; i < 9; i++)
            {
                _ = new Equip();
                Equip equip = GameRes.GetEquip(i);
                Console.WriteLine("id:{0}\t装备名:{1}\t血量:{2}\t法力值:{3}\t价格:{4}", equip.id, equip.name, equip.hp, equip.mp, equip.price);
            }
            Console.SetCursorPosition(0, 20);
            for (int a = 0; a < 79; a++)
                {
                    Console.Write("-");
                }
                Console.SetCursorPosition(0, 21);
                Console.WriteLine("你的选择:（输入装备id购买，输入0返回商店）");
                Console.SetCursorPosition(0, 22);
           hehe: 
                string cs = Console.ReadLine();
                if (cs == "")
                    goto hehe;
                int n = int.Parse(cs);
                switch (n)
                {
                    case 0: shop(); break;
                    case 1:
                        if (Playerrole.Instance.gold >= GameRes.GetEquip(1).price)
                        {
                            Playerrole.equip1 = GameRes.GetEquip(1);
                            Playerrole.Instance.gold -= Playerrole.equip1.price;
                        Console.WriteLine("购买成功.你还有{0}金币", Playerrole.Instance.gold);
                        Console.ReadKey();
                        Console.Clear();
                        goto hape;
                    }
                        else
                        {
                            Console.WriteLine("没钱你还想买，白嫖吗？，想peach");
                            Console.ReadKey();
                            goto hehe;
                        }
                    case 2:
                        if (Playerrole.Instance.gold >= GameRes.GetEquip(2).price)
                        {
                            Playerrole.equip1 = GameRes.GetEquip(2);
                            Playerrole.Instance.gold -= Playerrole.equip1.price;
                        Console.WriteLine("购买成功.你还有{0}金币", Playerrole.Instance.gold);
                        Console.ReadKey();
                        Console.Clear();
                        goto hape;
                    }
                        else
                        {
                            Console.WriteLine("没钱你还想买，白嫖吗？，想peach");
                            Console.ReadKey();
                            goto hehe;
                        }
                    case 3:
                        if (Playerrole.Instance.gold >= GameRes.GetEquip(3).price)
                        {
                            Playerrole.equip1 = GameRes.GetEquip(3);
                            Playerrole.Instance.gold -= Playerrole.equip1.price;
                        Console.WriteLine("购买成功.你还有{0}金币", Playerrole.Instance.gold);
                        Console.ReadKey();
                        Console.Clear();
                        goto hape;
                    }
                        else
                        {
                            Console.WriteLine("没钱你还想买，白嫖吗？，想peach");
                            Console.ReadKey();
                            goto hehe;
                        }
                    case 4:
                        if (Playerrole.Instance.gold >= GameRes.GetEquip(4).price)
                        {
                            Playerrole.equip2 = GameRes.GetEquip(4);
                            Playerrole.Instance.gold -= Playerrole.equip2.price; 
                        Console.WriteLine("购买成功.你还有{0}金币", Playerrole.Instance.gold);
                        Console.ReadKey();
                        Console.Clear();
                        goto hape;
                    }
                        else
                        {
                            Console.WriteLine("没钱你还想买，白嫖吗？，想peach");
                            Console.ReadKey();
                            goto hehe;
                        }
                    case 5:
                        if (Playerrole.Instance.gold >= GameRes.GetEquip(5).price)
                        {
                            Playerrole.equip2 = GameRes.GetEquip(5);
                            Playerrole.Instance.gold -= Playerrole.equip2.price;
                        Console.WriteLine("购买成功.你还有{0}金币", Playerrole.Instance.gold);
                        Console.ReadKey();
                        Console.Clear();
                        goto hape;
                    }
                        else
                        {
                            Console.WriteLine("没钱你还想买，白嫖吗？，想peach");
                            Console.ReadKey();
                            goto hehe;
                        }
                    case 6:
                        if (Playerrole.Instance.gold >= GameRes.GetEquip(6).price)
                        {
                            Playerrole.equip3 = GameRes.GetEquip(6);
                            Playerrole.Instance.gold -= Playerrole.equip3.price;
                        Console.WriteLine("购买成功.你还有{0}金币", Playerrole.Instance.gold);
                        Console.ReadKey();
                        Console.Clear();
                        goto hape;
                    }
                        else
                        {
                            Console.WriteLine("没钱你还想买，白嫖吗？，想peach");
                            Console.ReadKey();
                            goto hehe;
                        }
                    case 7:
                        if (Playerrole.Instance.gold >= GameRes.GetEquip(7).price)
                        {
                            Playerrole.equip3 = GameRes.GetEquip(7);
                            Playerrole.Instance.gold -= Playerrole.equip3.price;
                        Console.WriteLine("购买成功.你还有{0}金币", Playerrole.Instance.gold);
                        Console.ReadKey();
                        Console.Clear();
                        goto hape;
                    }
                        else
                        {
                            Console.WriteLine("没钱你还想买，白嫖吗？，想peach");
                            Console.ReadKey();
                            goto hehe;
                        }
                    case 8:
                        if (Playerrole.Instance.gold >= GameRes.GetEquip(8).price)
                        {
                            Playerrole.equip1 = GameRes.GetEquip(8);
                            Playerrole.Instance.gold -= Playerrole.equip1.price;
                        Console.WriteLine("购买成功.你还有{0}金币", Playerrole.Instance.gold);
                        Console.ReadKey();
                        Console.Clear();
                        goto hape;
                    }
                        else
                        {
                            Console.WriteLine("没钱你还想买，白嫖吗？，想peach");
                            Console.ReadKey();
                            goto hehe;
                        }
                  default:
                        goto hape;
                }
            }
        private static void BuyItem()
        {
     hape:  Console.Clear();
            Console.WriteLine("\t道具");
            for (int i = 1; i < 6; i++)
            {
                _ = new Item();
                Item item = GameRes.GetItem(i);
                Console.WriteLine("id:{0}\t道具名:{1}\t回复血量:{2}\t回复法力值:{3}\t价格:{4}", item.id, item.name, item.hp, item.mp, item.price);
            }
                Console.SetCursorPosition(0, 21);
                Console.WriteLine("你的选择:（输入装备id购买，输入0返回商店）");
                Console.SetCursorPosition(0, 22);
            hehe:
                string cs = Console.ReadLine();
                if (cs == "")
                    goto hehe;
                int n = int.Parse(cs);
                switch (n)
                {
                    case 0: shop(); break;
                    case 1:
                        if (Playerrole.Instance.gold >= GameRes.GetItem(1).price)
                        {
                            Playerrole.item1 = GameRes.GetItem(1);
                            Playerrole.i1++;
                            Playerrole.Instance.gold -= Playerrole.item1.price;
                        Console.WriteLine("购买成功.你还有{0}金币", Playerrole.Instance.gold);
                        Console.ReadKey();
                        Console.Clear();
                        goto hape;
                    }
                        else
                        {
                            Console.WriteLine("没钱你还想买，白嫖吗？，想peach");
                            Console.ReadKey();
                            goto hape;
                        }
                    case 2:
                        if (Playerrole.Instance.gold >= GameRes.GetItem(2).price)
                        {
                            Playerrole.item2 = GameRes.GetItem(2);
                            Playerrole.i2++;
                            Playerrole.Instance.gold -= Playerrole.item2.price;
                        Console.WriteLine("购买成功.你还有{0}金币", Playerrole.Instance.gold);
                        Console.ReadKey();
                        Console.Clear();
                        goto hape;
                    }
                        else
                        {
                            Console.WriteLine("没钱你还想买，白嫖吗？，想peach");
                            Console.ReadKey();
                            goto hehe;
                        }
                    case 3:
                        if (Playerrole.Instance.gold >= GameRes.GetItem(3).price)
                        {
                            Playerrole.item3 = GameRes.GetItem(3);
                            Playerrole.i3++;
                            Playerrole.Instance.gold -= Playerrole.item1.price;
                        Console.WriteLine("购买成功.你还有{0}金币", Playerrole.Instance.gold);
                        Console.ReadKey();
                        Console.Clear();
                        goto hape;
                    }
                        else
                        {
                            Console.WriteLine("没钱你还想买，白嫖吗？，想peach");
                            Console.ReadKey();
                            goto hehe;
                        }
                    case 4:
                        if (Playerrole.Instance.gold >= GameRes.GetItem(4).price)
                        {
                            Playerrole.item4 = GameRes.GetItem(4);
                            Playerrole.i4++;
                            Playerrole.Instance.gold -= Playerrole.item4.price;
                        Console.WriteLine("购买成功.你还有{0}金币", Playerrole.Instance.gold);
                        Console.ReadKey();
                        Console.Clear();
                        goto hape;
                    }
                        else
                        {
                            Console.WriteLine("没钱你还想买，白嫖吗？，想peach");
                            Console.ReadKey();
                            goto hehe;
                        }
                    case 5:
                        if (Playerrole.Instance.gold >= GameRes.GetItem(5).price)
                        {
                            Playerrole.item5 = GameRes.GetItem(5);
                            Playerrole.i5++;
                            Playerrole.Instance.gold -= Playerrole.item5.price;
                        Console.WriteLine("购买成功.你还有{0}金币", Playerrole.Instance.gold);
                        Console.ReadKey();
                        Console.Clear();
                        goto hape;
                    }
                        else
                        {
                            Console.WriteLine("没钱你还想买，白嫖吗？，想peach");
                            Console.ReadKey();
                            goto hehe;
                        }
                default:
                    goto hape;
                }
            
        }
        public static void shop()
        {
            Console.Clear();
            Console.WriteLine("欢迎来到商店（本店只卖不买，更换后原有装备消失）");
            Console.WriteLine("\t武器:");
            for(int i=1;i<6; i++)
            {
                _ = new Weapon();
                Weapon weapon = GameRes.GetWeapon(i);
                Console.WriteLine("id:{0}\t武器名:{1}\t攻击力:{2}\t价格:{3}",weapon.id,weapon.name,weapon.atk,weapon.price);
            }
            Console.WriteLine("\t装备:");
            for(int i = 1; i < 9; i++)
            {
                _ = new Equip();
                Equip equip = GameRes.GetEquip(i);
                Console.WriteLine("id:{0}\t装备名:{1}\t血量:{2}\t法力值:{3}\t价格{4}", equip.id, equip.name, equip.hp,equip.mp, equip.price);
            }
            Console.WriteLine("\t道具:");
            for (int i = 1; i < 6; i++)
            {
                _ = new Item();
                Item item = GameRes.GetItem(i);
                Console.WriteLine("id:{0}\t道具名:{1}\t回复血量:{2}\t回复法力值:{3}\t价格:{4}", item.id, item.name, item.hp, item.mp, item.price);
            }
            Console.SetCursorPosition(65, 3);
            Console.WriteLine("选择行动:");
            Console.SetCursorPosition(65, 4);
            Console.WriteLine("0.返回主界面");
            Console.SetCursorPosition(65, 5);
            Console.WriteLine("1.购买武器");
            Console.SetCursorPosition(65, 6);
            Console.WriteLine("2.购买装备");
            Console.SetCursorPosition(65, 7);
            Console.WriteLine("3.购买道具");
            Console.SetCursorPosition(0, 22);
            for (int i = 0; i < 79; i++)
            {
                Console.Write("-");
            }
            Console.SetCursorPosition(0, 23);
            Console.WriteLine("你的选择:");
            Console.SetCursorPosition(0, 24);
        hehe:
            string cs = Console.ReadLine();
            if (cs == "")
                goto hehe;
            int n = int.Parse(cs);
            switch (n)
            {
                case 1: BuyWeapon();break;
                case 2: BuyEquip();break;
                case 3: BuyItem();break;
                case 0: Program.Mainui();break;
                default:
                    goto hehe;

            }
            
        }
    }
}
