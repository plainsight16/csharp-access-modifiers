using System;

namespace AccessModifiersExample
{
    public class Animal
    {
        protected string Name { get; set; }
        protected string Sound { get; set; }

        public Animal(string name, string sound)
        {
            Name = name;
            Sound = sound;
        }

        public virtual void MakeSound()
        {
            Console.WriteLine($"{Name} says {Sound}.");
        }

        public static void NumberOfLegs()
        {
            Console.WriteLine("This animal has 4 legs.");
        }
    }

    public partial class Dog : Animal
    {
        public Dog(string name) : base(name, "bark")
        {
        }

        partial void Bark();

        public override void MakeSound()
        {
            Bark();
            base.MakeSound();
        }
    }

    public partial class Dog
    {
        partial void Bark()
        {
            Console.WriteLine("Woof!");
        }
    }

    class Program
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool MessageBeep(uint uType);

        static void Main(string[] args)
        {
            Animal.NumberOfLegs();

            Dog myDog = new Dog("Fido");
            myDog.MakeSound();

            MessageBeep(0x00000040);
            Console.ReadLine();
        }
    }
}
