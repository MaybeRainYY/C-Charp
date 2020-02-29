using System;
using System.IO;

namespace Lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool SingeltonLocker = true;
            bool exit = true;

            while (exit)
            {
                Console.WriteLine
                    (
                    "Choice action:\n" +
                    "0-Clear console\n"+
                    "1-create knight\n" +
                    "2-Create wizzard\n" +
                    "3-Create ranger\n" +
                    "4-Create chief\n" +
                    "5-Enter reward for first quest\n" +
                    "6-Enter reward for second quest\n"+
                    "999-To exit\n"
                    );
                int switcherVariable = Convert.ToInt32((Console.ReadLine()));
                string choice;

                switch (switcherVariable)
                {
                    case 0:
                        Console.Clear();
                        break;
                    case 1:
                        Hero knight = new Hero(new KnightConcern());
                        Console.WriteLine("Knight created:");
                        knight.Characteristics();
                        Console.WriteLine("Do u wanna create leader?(Y-yes,N-no)");
                        choice = Console.ReadLine();
                        if (choice.ToUpper() == "Y" && SingeltonLocker)
                        {
                            Console.WriteLine("Type leader name");
                            string Name = Console.ReadLine();
                            knight.Create(Name);
                            SingeltonLocker=false;
                            Console.WriteLine($"Leader Name:{knight.weyrleader.Name}\n");
                        }
                        else
                        {
                            Console.WriteLine("U type NO or leader already exist");
                        }
                        break;
                    case 2:
                        Hero wizzard = new Hero(new WizzardConcern());
                        Console.WriteLine("Wizzard created:");
                        wizzard.Characteristics();
                        Console.WriteLine("Do u wanna create leader?(Y-yes,N-no)");
                        choice = Console.ReadLine();
                        if (choice.ToUpper() == "Y" && SingeltonLocker)
                        {
                            Console.WriteLine("Type leader name");
                            string Name = Console.ReadLine();
                            wizzard.Create(Name);
                            SingeltonLocker=false;
                            Console.WriteLine($"Leader Name:{wizzard.weyrleader.Name}\n");
                        }
                        else
                        {
                            Console.WriteLine("U type NO or leader already exist\n");
                        }
                        break;
                    case 3:
                        Hero ranger= new Hero(new Ranger());
                        Console.WriteLine("Ranger created:");
                        ranger.Characteristics();
                        Console.WriteLine("Do u wanna create leader?(Y-yes,N-no)");
                        choice = Console.ReadLine();
                        if (choice.ToUpper() == "Y" && SingeltonLocker)
                        {
                            Console.WriteLine("Type leader name");
                            string Name = Console.ReadLine();
                            ranger.Create(Name);
                            SingeltonLocker=false;
                            Console.WriteLine($"Leader Name:{ranger.weyrleader.Name}\n");
                        }
                        else
                        {
                            Console.WriteLine("U type NO or leader already exist\n");
                        }
                        break;
                    case 4:
                        Hero chief = new Hero(new Chief());
                        Console.WriteLine("Chief created:");
                        chief.Characteristics();
                        Console.WriteLine("Do u wanna create leader?(Y-yes,N-no)");
                        choice = Console.ReadLine();
                        if (choice.ToUpper() == "Y" && SingeltonLocker)
                        {
                            Console.WriteLine("Type leader name");
                            string Name = Console.ReadLine();
                            chief.Create(Name);
                            SingeltonLocker=false;
                            Console.WriteLine($"Leader Name:{chief.weyrleader.Name}\n");
                        }
                        else
                        {
                            Console.WriteLine("U type NO or leader already exist\n");
                        }
                        break;
                    case 5:
                        QuestRewardBuilder questReward = new RewardFirst();
                        Console.WriteLine("Enter gold:");
                        int gold = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter type of stuff:");
                        string thing = Console.ReadLine();
                        Console.WriteLine("Enter expirience:");
                        int exp = int.Parse(Console.ReadLine());
                        Director director = new Director(questReward, gold, thing, exp);
                        QuestReward questReward1 = questReward.GetReward();
                        questReward1.Print();
                        break;
                    case 6:
                        QuestRewardBuilder questRewardTwo = new RewardFirst();
                        Console.WriteLine("Enter gold:");
                        int goldScnd = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter type of stuff:");
                        string thingScnd = Console.ReadLine();
                        Console.WriteLine("Enter expirience:");
                        int expScnd = int.Parse(Console.ReadLine());
                        Director directorScnd = new Director(questRewardTwo, goldScnd, thingScnd, expScnd);
                        QuestReward questReward2 = questRewardTwo.GetReward();
                        questReward2.Print();
                        break;
                    case 999:
                        exit = false;
                        break;

                }
            }
            Console.WriteLine("Hero creation finished\a\n");


            IClone n1 = new Naruto("Shadow clone");
            IClone n2 = n1.Clone();
            Console.WriteLine(((Naruto)n1).Name);
            Console.WriteLine(((Naruto)n2).Name);

            Console.Read();
        }
    }

    abstract class Weapon
    {
        public abstract void Hit();
    }

    abstract class Movement
    {
        public abstract void Move();
    }

    class Rod : Weapon
    {
        public override void Hit()
        {
            Console.WriteLine("Fire ball");
        }
    }

    class Bow : Weapon
    {
        public override void Hit()
        {
            Console.WriteLine("Damage from arrow");
        }
    }

    class Sword : Weapon
    {
        public override void Hit()
        {
            Console.WriteLine("Damage from sword");
        }
    }

    class Daggers : Weapon
    {
        public override void Hit()
        {
            Console.WriteLine("Damage from dagger");
        }
    }

    class Fly:Movement
    {
        public override void Move()
        {
            Console.WriteLine("Fly");
        }
    }

    class Runing:Movement
    {
        public override void Move()
        {
            Console.WriteLine("Run");
        }
    }

    class Teleportation:Movement
    {
        public override void Move()
        {
            Console.WriteLine("Teleportation");
        }
    }

    abstract class Factory
    {
        public abstract Weapon CreateCharacteristicFirst();
        public abstract Movement CreateCharacteristicSecond();
    }

    class KnightConcern:Factory
    {
        public override Weapon CreateCharacteristicFirst()
        {
            return new Sword();
        }

        public override Movement CreateCharacteristicSecond()
        {
            return new Runing();
        }
    }

    class WizzardConcern:Factory
    {
        public override Weapon CreateCharacteristicFirst()
        {
            return new Rod();
        }

        public override Movement CreateCharacteristicSecond()
        {
            return new Teleportation();
        }
    }

    class Ranger:Factory
    {
        public override Weapon CreateCharacteristicFirst()
        {
            return new Bow();
        }

        public override Movement CreateCharacteristicSecond()
        {
            return new Fly();
        }
    }

    class Chief:Factory
    {
        public override Weapon CreateCharacteristicFirst()
        {
            return new Daggers();
        }

        public override Movement CreateCharacteristicSecond()
        {
            return new Runing();
        }
    }

    class Hero
    {
        public Weapon weapon;
        public Movement movement;

        public Hero(Factory factory)
        {
            this.weapon = factory.CreateCharacteristicFirst();
            this.movement = factory.CreateCharacteristicSecond();
        }

        public void Characteristics()
        {
            weapon.Hit();
            movement.Move();
        }

        public Weyrleader weyrleader;
        public void Create(string name)
        {
            weyrleader = Weyrleader.CreateWeyrleader(name);
        }
    }

    class Gold
    {
        public int Count { get; set; }
    }

    class Stuff
    {
        public string Name { get; set; }
    }

    class Expirience
    {
        public int Count { get; set; }
    }

    class Director
    {
        public Director(QuestRewardBuilder questRewardBuilder,int gold,int exp)
        {
            questRewardBuilder.setGoldReward(gold);
            questRewardBuilder.setExpirience(exp);
        }

        public Director(QuestRewardBuilder questRewardBuilder,int gold,string thingName,int exp):this(questRewardBuilder,gold,exp)
        {
            questRewardBuilder.setStuffReward(thingName);
        }
    }

    class QuestReward
    {
        public Gold gold;
        public Stuff thing;
        public Expirience exp;

        public void Print()
        {
            Console.WriteLine($"Gold:{gold.Count}\nStuff:{thing.Name}\nExpirience:{exp.Count}\n");
        }
    }

    abstract class QuestRewardBuilder
    {
        public abstract void setGoldReward(int count);
        public abstract void setStuffReward(string thing);
        public abstract void setExpirience(int count);

        public abstract QuestReward GetReward();
    }

    class RewardFirst:QuestRewardBuilder
    {
        QuestReward QuestReward = new QuestReward();
        public override void setGoldReward(int count)
        {
            QuestReward.gold = new Gold();
            this.QuestReward.gold.Count = count;
        }

        public override void setStuffReward(string thing)
        {
            QuestReward.thing = new Stuff();
            QuestReward.thing.Name = thing;
        }

        public override void setExpirience(int count)
        {
            QuestReward.exp = new Expirience();
            QuestReward.exp.Count = count;
        }

        public override QuestReward GetReward()
        {
            return QuestReward;
        }
    }

    class RewardSecond : QuestRewardBuilder
    {
        QuestReward QuestReward = new QuestReward();
        public override void setGoldReward(int count)
        {
            QuestReward.gold = new Gold();
            QuestReward.gold.Count = count;
        }

        public override void setStuffReward(string thing)
        {
            
        }

        public override void setExpirience(int count)
        {
            QuestReward.exp.Count = count;
        }

        public override QuestReward GetReward()
        {
            return QuestReward;
        }
    }

    public class Weyrleader
    {
        private Weyrleader()
        { }

        public object Name { get; private set; }

        protected Weyrleader(string name)
        {
            this.Name = name;
        }

        private static Weyrleader instance = null;

        public static Weyrleader CreateWeyrleader(string name)
        {
            if (instance == null)
                instance = new Weyrleader(name);
            return instance;
        }
    }

    interface IClone
    {
        IClone Clone();
    }

    class Naruto:IClone
    {
        public string Name { get; set; }

        public Naruto(string name)
        {
            this.Name = name;
        }

        public IClone Clone()
        {
            return new Naruto(this.Name);
        }
    }
}
