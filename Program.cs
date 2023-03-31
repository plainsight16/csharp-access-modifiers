using System;

namespace AccessModifiersExample
{
    // public access modifier - this class can be accessed by code outside of this namespace
    public class Animal
    {
        // protected access modifier - these properties can only be accessed by derived classes
        protected string Name { get; set; }
        protected string Sound { get; set; }

        // public access modifier - this constructor can be accessed by code outside of this class
        public Animal(string name, string sound)
        {
            Name = name;
            Sound = sound;
        }

        // abstract virtual access modifiers - this method must be implemented by derived classes and can be overridden
        public virtual void MakeSound()
        {
            Console.WriteLine($"{Name} says {Sound}.");
        }

        // static access modifier - this method can be called without creating an instance of the class
        public static void NumberOfLegs()
        {
            Console.WriteLine("This animal has 4 legs.");
        }
    }

    // partial access modifier - this class is split across multiple files
    public partial class Dog : Animal
    {
        // public access modifier - this constructor can be accessed by code outside of this class
        public Dog(string name) : base(name, "bark")
        {
        }

        // partial method declaration - this method must be implemented in another part of the partial class
        partial void Bark();

        // override access modifier - this method overrides the base class's MakeSound method
        public override void MakeSound()
        {
            Bark();
            base.MakeSound();
        }
    }

    // partial access modifier - this class is split across multiple files
    public partial class Dog
    {
        // partial method implementation - this method must be implemented in another part of the partial class
        partial void Bark()
        {
            Console.WriteLine("Woof!");
        }
    }

    // default access modifier - this class is only accessible within this namespace
    class Program
    {
        // external access modifier - this method imports a function from a native Windows library
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool MessageBeep(uint uType);

        // static access modifier - this method can be called without creating an instance of the class
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
