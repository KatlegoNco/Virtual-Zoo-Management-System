using System;
using System.Collections.Generic;

// Define Animal class with common properties and methods
abstract class Animal
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Animal(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public virtual void Eat()
    {
        Console.WriteLine("Animal is eating...");
    }

    public virtual void Sleep()
    {
        Console.WriteLine("Animal is sleeping...");
    }
}

// Define specific animal classes inheriting from Animal
class Lion : Animal
{
    public Lion(string name, int age) : base(name, age) { }

    public override void Eat()
    {
        Console.WriteLine("Lion is eating meat...");
    }

    public override void Sleep()
    {
        Console.WriteLine("Lion is sleeping...");
    }
}

class Parrot : Animal
{
    public Parrot(string name, int age) : base(name, age) { }

    public override void Eat()
    {
        Console.WriteLine("Parrot is eating seeds...");
    }

    public override void Sleep()
    {
        Console.WriteLine("Parrot is sleeping...");
    }
}

class Elephant : Animal
{
    public Elephant(string name, int age) : base(name, age) { }

    public override void Eat()
    {
        Console.WriteLine("Elephant is eating grass...");
    }

    public override void Sleep()
    {
        Console.WriteLine("Elephant is sleeping...");
    }
}

class Zebra : Animal
{
    public Zebra(string name, int age) : base(name, age) { }

    public override void Eat()
    {
        Console.WriteLine("Zebra is grazing...");
    }

    public override void Sleep()
    {
        Console.WriteLine("Zebra is sleeping...");
    }
}

// Zoo class to manage animals
class Zoo
{
    private List<Animal> animals = new List<Animal>();

    // Constructor to add default animals
    public Zoo()
    {
        AddDefaultAnimals();
    }

    private void AddDefaultAnimals()
    {
        animals.Add(new Lion("Mufasa", 5));
        animals.Add(new Parrot("Polly", 3));
        animals.Add(new Elephant("Ellie", 10));
        animals.Add(new Zebra("Marty", 7));
    }

    public void AddAnimal(Animal animal)
    {
        animals.Add(animal);
        Console.WriteLine($"Added {animal.GetType().Name} '{animal.Name}' to the zoo.");
    }

    public void DisplayAnimals()
    {
        Console.WriteLine("Animals in the zoo:");
        foreach (Animal animal in animals)
        {
            Console.WriteLine($"Name: {animal.Name}, Type: {animal.GetType().Name}, Age: {animal.Age}");
        }
    }

    public void FeedAnimal(string name)
    {
        Animal animal = animals.Find(a => a.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (animal != null)
        {
            animal.Eat();
        }
        else
        {
            Console.WriteLine($"Animal '{name}' not found!");
        }
    }

    public void MakeAnimalSleep(string name)
    {
        Animal animal = animals.Find(a => a.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (animal != null)
        {
            animal.Sleep();
        }
        else
        {
            Console.WriteLine($"Animal '{name}' not found!");
        }
    }
}

// Main program entry point
class Program
{
    static void Main(string[] args)
    {
        Zoo zoo = new Zoo();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Zoo Management System");
            Console.WriteLine("1. Add Animal");
            Console.WriteLine("2. Display Animals");
            Console.WriteLine("3. Feed Animal");
            Console.WriteLine("4. Make Animal Sleep");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.Write("Enter animal name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter animal age: ");
                        int age;
                        if (int.TryParse(Console.ReadLine(), out age))
                        {
                            Console.WriteLine("Select animal type:");
                            Console.WriteLine("1. Lion");
                            Console.WriteLine("2. Parrot");
                            Console.WriteLine("3. Elephant");
                            Console.WriteLine("4. Zebra");
                            Console.Write("Enter choice (1/2/3/4): ");
                            int animalType;
                            if (int.TryParse(Console.ReadLine(), out animalType))
                            {
                                switch (animalType)
                                {
                                    case 1:
                                        zoo.AddAnimal(new Lion(name, age));
                                        break;
                                    case 2:
                                        zoo.AddAnimal(new Parrot(name, age));
                                        break;
                                    case 3:
                                        zoo.AddAnimal(new Elephant(name, age));
                                        break;
                                    case 4:
                                        zoo.AddAnimal(new Zebra(name, age));
                                        break;
                                    default:
                                        Console.WriteLine("Invalid animal type!");
                                        break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid input! Please enter a valid number.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input! Please enter a valid age.");
                        }
                        break;

                    case 2:
                        zoo.DisplayAnimals();
                        break;

                    case 3:
                        Console.Write("Enter the name of the animal to feed: ");
                        string animalToFeed = Console.ReadLine();
                        zoo.FeedAnimal(animalToFeed);
                        break;

                    case 4:
                        Console.Write("Enter the name of the animal to make sleep: ");
                        string animalToSleep = Console.ReadLine();
                        zoo.MakeAnimalSleep(animalToSleep);
                        break;

                    case 5:
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice! Please enter a number from 1 to 5.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input! Please enter a valid number.");
            }
        }
    }
}
