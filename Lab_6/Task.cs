using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab
{   
    public enum PinguinsLife : int
    {
        Sleep = 1,
        Eat,  
        Dance,
        FindFood,
        Fight,
        BringUp,
        Swim,
        Sing,
        Fly, 
        Walk,
        Exit, 
        Info,
    }

    interface IBird
    {
        void Info2();
        void Fly();
        void Swim();
        void Sing();
    }

    abstract class Animals
    {
        public string name;
        public int age;
        protected int Health;
        protected int Mood;
        public Animals(int health, int mood)
        {
            this.Health = health;
            this.Mood = mood;
        }

        public abstract void Info1();
        public abstract void CheckLife();
        public abstract int Menu();
        public abstract void Sleep(int hours);
        public abstract void Eat(string food);
        public abstract void FindFood();
        public abstract void BringUp();
        public abstract void Walking();
    }

    class Birds : Animals, IBird
    {
        public int Strength;
        public Birds(int Health, int Mood, int Strength) : base(Health, Mood)
        {
            this.Strength = Strength;
        }

        public override void Info1()
        {
            Console.WriteLine($"Name : {name}");
            Console.WriteLine($"Age : {age}");
            Console.WriteLine($"Health : {Health}");
            Console.WriteLine($"Mood : {Mood}");
        }

        public override void CheckLife()
        {
            if (this.Health == 0)
            {
                Console.WriteLine("Oooooops! Your pinguin died!");
                Environment.Exit(0);
            }
        }

        public override int Menu()
        {
            Console.WriteLine("\nWhat we will do?\n");
            Console.WriteLine("1.Sleep a lot");
            Console.WriteLine("2.Eat delicious fish");
            Console.WriteLine("3.Dance!!!");
            Console.WriteLine("4.Find some food");
            Console.WriteLine("5.Fight with bad pinguin boys");
            Console.WriteLine("6.Take care of little pinguins");
            Console.WriteLine("7.Swimming");
            Console.WriteLine("8.Sing Maksim,s songs");
            Console.WriteLine("9.Learn, how to fly");
            Console.WriteLine("10.Go for a walk");
            Console.WriteLine("11.Maybe you want to end this life?");
            Console.WriteLine("12.Information");
            Console.WriteLine("Enter your choice as a number please:");
            int answer = Int32.Parse(Console.ReadLine());
            while (answer > 12 || answer < 1)
            {
                Console.WriteLine("Darling, choose a number between 1 and 11");
                answer = Int32.Parse(Console.ReadLine());
            }
            return answer;
        }

        public override void Sleep(int hours)
        {
            Console.WriteLine($"You were sleeping {hours} hours");
            if (hours >= 6)
            {
                this.Health += 4;
                this.Mood += 5;
                Console.WriteLine("That's so good!!!");
            }
            else
            {
                this.Health += 2;
                this.Mood -= 2;
                Console.WriteLine("You should sleep more!!!");
            }
            Console.WriteLine($"Your health now: {this.Health}");
            Console.WriteLine($"Your mood now: {this.Mood}");
        }

        public override void Eat(string food)
        {
            if (food == "fish")
            {
                this.Health += 6;
                this.Mood += 6;
                Console.WriteLine("Bon appetite, darling!!!");
            }
            else
            {
                this.Health += 2;
                this.Mood -= 2;
                Console.WriteLine($"{food} is too bad for your stomach!!!");
            }
            Console.WriteLine($"Your health now: {this.Health}");
            Console.WriteLine($"Your mood now: {this.Mood}");

        }

        public override void FindFood()
        {
            this.Health -= 6;
            Console.WriteLine($"Your health now: {this.Health}");
            Console.WriteLine($"Your mood now: {this.Mood}");
        }
        public override void BringUp()
        {
            this.Health -= 3;
            this.Mood += 4;
            Console.WriteLine("You've decided to take of your children! How cute!");
            Console.WriteLine($"Your health now: {this.Health}");
            Console.WriteLine($"Your mood now: {this.Mood}");
        }

        public override void Walking()
        {
            this.Health += 5;
            this.Mood += 5;
            Console.WriteLine("What about watching the sunset over the castle on the icrberg?");
            Console.WriteLine($"Your health now: {this.Health}");
            Console.WriteLine($"Your mood now: {this.Mood}");
        }

        public void Info2()
        {
            Console.WriteLine($"Name : {name}");
            Console.WriteLine($"Age : {age}");
            Console.WriteLine($"Health : {Health}");
            Console.WriteLine($"Mood: {Mood}");
            Console.WriteLine($"Strength : {this.Strength}");
        }

        public void Fly()
        {
            this.Health -= 2;
            this.Strength -= 2;
            this.Mood -= 2;
            Console.WriteLine("Good joke, guy!!!");
            Console.WriteLine($"Your health now: {this.Health}");
            Console.WriteLine($"Your mood now: {this.Mood}");
            Console.WriteLine($"Your strength now: {this.Strength}");
        }

        public void Swim()
        {
            if (this.Health < 10)
            {
                Console.WriteLine("Sorry, I think you shoulde cure!");
                this.Mood--;
            }
            else
            {
                this.Mood += 3;
                this.Strength += 6;
                Console.WriteLine("Wow, great choice!!!");
            }
            Console.WriteLine($"Your health now: {this.Health}");
            Console.WriteLine($"Your mood now: {this.Mood}");
            Console.WriteLine($"Your strength now: {this.Strength}");
        }

        public void Sing()
        {
            Console.WriteLine("ZNAESH LI TY VDOL' NOCHNYH DOROG!!!!!!\nSHLA BOSIKOM NE ZHALEYA NOG!!!!!");
            this.Mood += 6;
            Console.WriteLine($"Your health now: {this.Health}");
            Console.WriteLine($"Your mood now: {this.Mood}");
            Console.WriteLine($"Your strength now: {this.Strength}");
        }
    }

        class Pinguins : Birds
        {
            public Pinguins(int Health, int Mood, int Strength) : base(Health, Mood, Strength)
            {

            }
            public void Dance()
            {
                if(this.Mood < 10)
                {
                    Console.WriteLine("You are too tired to dance :(");
                }    
                else
                {
                    Console.WriteLine("You are the queen of the dancefloor!!!");
                    this.Mood++;
                    this.Strength++;
                    this.Health++;
                }
                Console.WriteLine($"Your health now: {this.Health}");
                Console.WriteLine($"Your mood now: {this.Mood}");
                Console.WriteLine($"Your strength now: {this.Strength}");
            }

            public void Fight()
            {
                var random = new Random();
                int a = random.Next(1, 10);
                if (this.Health < 10 || this.Strength < 10)
                {
                    Console.WriteLine("Your strength and health are too low!");
                }
                else
                {
                    Console.WriteLine("1! 2! 3! FIGHT!");
                    this.Health -= 5;
                    this.Strength -= 5;
                }

                if (a > 10)
                {
                    Console.WriteLine("You are a winner!");
                    this.Mood += 7;
                    this.Strength += 7;
                }
                else
                {
                    Console.WriteLine("You are a loser!");
                    this.Mood -= 4;
                    this.Strength -= 4;
                }
                Console.WriteLine($"Your health now: {this.Health}");
                Console.WriteLine($"Your mood now: {this.Mood}");
                Console.WriteLine($"Your strength now: {this.Strength}");
            }
        }

    class Program
    {
        public static bool Word(string item)
        {
            if (item.All(i => ((i >= 'A' && i <= 'Z') || (i >= 'a' && i <= 'z'))))
            {
                return false;
            }
            return true;
        }

        public static string Number(string item)
        {
            if (item.All(i => i <= '9' && i >= '.' && i != '/'))
            {
                return item;
            }
            return "0";
        }
        static void Main()
        {
            Pinguins pin = new Pinguins(10, 10, 10);

            Console.WriteLine("Enter your name : ");
            pin.name = Console.ReadLine();
            while (Word(pin.name) || pin.name == "")
            {
                Console.WriteLine("You are liar.Enter your name correctly : ");
                pin.name = Console.ReadLine();
            }
         
            Console.WriteLine("Enter your age : ");
            bool testage = Int32.TryParse(Console.ReadLine(), out pin.age);
            while (pin.age > 25 || pin.age <= 0 || testage == false)
            {
                Console.WriteLine("Please re-enter your age :");
                testage = Int32.TryParse(Console.ReadLine(), out pin.age);
            }
            
            while (true)
            {
                pin.CheckLife();
                switch (pin.Menu())
                {
                    case (int)PinguinsLife.Sleep:
                        {
                            Console.Clear();
                            pin.Sleep(8);
                            break;
                        }
                    case (int)PinguinsLife.Eat:
                        {
                            Console.Clear();
                            string food;
                            Console.WriteLine("What do you want to eat?");
                            food = Console.ReadLine();
                            while (Word(food) || food == "")
                            {
                                Console.WriteLine("You are liar.Enter your name correctly : ");
                                food = Console.ReadLine();
                            }
                            pin.Eat(food);
                            break;
                        }

                    case (int)PinguinsLife.Dance:
                        {
                            Console.Clear();
                            pin.Dance();
                            break;
                        }

                    case (int)PinguinsLife.FindFood:
                        {
                            Console.Clear();
                            pin.FindFood();
                            break;
                        }

                    case (int)PinguinsLife.Fight:
                        {
                            Console.Clear();
                            pin.Fight();
                            break;
                        }

                    case (int)PinguinsLife.BringUp:
                        {
                            Console.Clear();
                            pin.BringUp();
                            break;
                        }

                    case (int)PinguinsLife.Swim:
                        {
                            Console.Clear();
                            pin.Swim();
                            break;
                        }

                    case (int)PinguinsLife.Sing:
                        {
                            Console.Clear();
                            pin.Sing();
                            break;
                        }

                    case (int)PinguinsLife.Fly:
                        { 
                            Console.Clear();
                            pin.Fly();
                            break;
                        }

                    case (int)PinguinsLife.Walk:
                        {
                            Console.Clear();
                            pin.Walking();
                            break;
                        }

                    case (int)PinguinsLife.Info:
                        {
                            Console.Clear();
                            pin.Info();
                            break;
                        }
                    case (int)PinguinsLife.Exit:
                        {
                            Console.Clear();
                            Console.WriteLine("Good by!");
                            Environment.Exit(0);
                            break;
                        }
                }
            }

        }
    }
}
