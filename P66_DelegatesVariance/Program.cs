using System;

class Animal { }
class Dog : Animal { }

class Program
{
    static Dog MakeDog() { return new Dog(); }
    static void ConsumeAnimal(Animal a) { Console.WriteLine("Got an animal"); }

    static void Main()
    {
        Func<Dog> dogFactory = MakeDog;
        Func<Animal> animalFactory = dogFactory; // covariance
        Animal a = animalFactory();

        Action<Animal> eater = ConsumeAnimal;
        Action<Dog> dogEater = eater; // contravariance
        dogEater(new Dog());

        Console.WriteLine("Done");
    }
}
