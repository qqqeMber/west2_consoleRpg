using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace west2_consoleRpg
{
    public class Monster
    {
        public int id;
        public string name;
        public int atk;
        public int hp;

        public Monster Clone()
        {
            Monster temp = new Monster
            {
                id = this.id,
                name = this.name,
                atk = this.atk,
                hp = this.hp
            };

            return temp;
        }
    };
    public class Equip 
    {
        public int id;
        public string name;
        public int hp;
        public int mp;
        public int price;

    };  
    public class Item
    {
        public int id;
        public string name;
        public int hp;
        public int mp;
        public int price;

    };
    public class Weapon
    {
        public int id;
        public string name;
        public int atk;
        public int price;

    };
    public class Job
    {
        public int id;
        public string name;
        public int atk;
        public int hp;
        public int mp;
        public int atkrate;
        public int mprate;
        public int hprate;
    };
    public class Skill
    {
        public int id;
        public string name;
        public int mp;
        public float rate;
    }
    class GameRes
    {
        public static Dictionary<int, Weapon> Weapons = new Dictionary<int, Weapon>();
        public static Dictionary<int, Item> Items = new Dictionary<int, Item>();
        public static Dictionary<int, Job> Jobs = new Dictionary<int, Job>();
        public static Dictionary<int, Monster> Monsters = new Dictionary<int, Monster>();
        public static Dictionary<int, Equip> Equips = new Dictionary<int, Equip>();
        public static Dictionary<int, Skill> Skills = new Dictionary<int, Skill>();
        private const string Respath = "config.xml";
        public static bool LoadGameRes()
        {
            XmlDocument xml = new XmlDocument();

            try
            {
                xml.Load(Respath);
                XmlNode root = xml.SelectSingleNode("config");
                XmlNodeList list = root.SelectNodes("job");
                foreach (XmlNode nd in list)
                {
                    Job jb = new Job
                    {
                        id = int.Parse(nd.Attributes["id"].Value),
                        name = nd.Attributes["name"].Value,
                        atk = int.Parse(nd.Attributes["atk"].Value),
                        hp = int.Parse(nd.Attributes["hp"].Value),
                        mp = int.Parse(nd.Attributes["mp"].Value),
                        hprate = int.Parse(nd.Attributes["hprate"].Value),
                        mprate = int.Parse(nd.Attributes["mprate"].Value),
                        atkrate = int.Parse(nd.Attributes["atkrate"].Value)
                    };
                    Jobs.Add(jb.id,jb);
                }
                 list = root.SelectNodes("weapon");
                 foreach(XmlNode nd in list)
                 {
                    Weapon wp = new Weapon
                    {
                        id = int.Parse(nd.Attributes["id"].Value),
                        name = (nd.Attributes["name"].Value),
                        atk = int.Parse(nd.Attributes["atk"].Value),
                        price = int.Parse(nd.Attributes["price"].Value)
                    };
                    Weapons.Add(wp.id, wp);
                 }
                 list = root.SelectNodes("item");
                 foreach (XmlNode nd in list)
                 {
                    Item item = new Item
                    {
                        id = int.Parse(nd.Attributes["id"].Value),
                        name = nd.Attributes["name"].Value,
                        hp = int.Parse(nd.Attributes["hp"].Value),
                        mp = int.Parse(nd.Attributes["mp"].Value),
                        price = int.Parse(nd.Attributes["price"].Value)
                    };
                    Items.Add(item.id, item);
                 }
                 list = root.SelectNodes("monster");
                 foreach (XmlNode nd in list)
                 {
                    Monster monster = new Monster
                    {
                        id = int.Parse(nd.Attributes["id"].Value),
                        name = (nd.Attributes["name"].Value),
                        hp = int.Parse(nd.Attributes["hp"].Value),
                        atk = int.Parse(nd.Attributes["atk"].Value)
                    };
                    Monsters.Add(monster.id, monster);
                 }
                 list = root.SelectNodes("equip");
                 foreach (XmlNode nd in list)
                 {
                    Equip equip = new Equip
                    {
                        id = int.Parse(nd.Attributes["id"].Value),
                        name = nd.Attributes["name"].Value,
                        hp = int.Parse(nd.Attributes["hp"].Value),
                        mp = int.Parse(nd.Attributes["mp"].Value),
                        price = int.Parse(nd.Attributes["price"].Value)
                    };
                    Equips.Add(equip.id, equip);
                 }
                 list = root.SelectNodes("skill");
                 foreach (XmlNode nd in list)
                {
                    Skill skill = new Skill
                    {
                        id = int.Parse(nd.Attributes["id"].Value),
                        name = nd.Attributes["name"].Value,
                        mp = int.Parse(nd.Attributes["mp"].Value),
                        rate = float.Parse(nd.Attributes["rate"].Value)
                    };
                    Skills.Add(skill.id, skill);
                }

            }
            catch
            {
                return false;
            }

            return true;
        }
        //获取
        public static Weapon GetWeapon(int id)
        {
            if (Weapons.ContainsKey(id))
            {
                return Weapons[id];
            }

            return null; 
        }
        public static Item GetItem(int id)
        {
            if (Items.ContainsKey(id))
            {
                return Items[id];
            }

            return null;
        }
        public static Job GetJob(int id)
        {
            if (Jobs.ContainsKey(id))
            {
                return Jobs[id];
            }

            return null;
        }
        public static Monster GetMonster(int id)
        {
            if (Monsters.ContainsKey(id))
            {
                return Monsters[id];
            }

            return null;
        }
        public static Equip GetEquip(int id)
        {
            if (Equips.ContainsKey(id))
            {
                return Equips[id];
            }

            return null;
        }
        public static Skill GetSkill(int id)
        {
            if (Skills.ContainsKey(id))
            {
                return Skills[id];
            }
            return null;
        }
    }
}
