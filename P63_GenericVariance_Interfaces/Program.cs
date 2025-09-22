using System;
using System.Collections.Generic;

class Animal { public virtual string Name { get { return "Animal"; } } }
class Dog : Animal { public override string Name { get { return "Dog"; } } }

class Program
{
    static void PrintAll(IEnumerable<Animal> animals)
    {
        foreach(var a in animals) Console.WriteLine(a.Name);
    }

    static void SortDogs(List<Dog> dogs, IComparer<Animal> cmp)
    {
        dogs.Sort((d1,d2) => cmp.Compare(d1, d2));
    }

    static void Main()
    {
        IEnumerable<Dog> dogSeq = new List<Dog>{ new Dog(), new Dog() };
        PrintAll(dogSeq);

        List<Dog> pack = new List<Dog>{ new Dog(), new Dog() };
        IComparer<Animal> byName = Comparer<Animal>.Create((a,b) => string.Compare(a.Name, b.Name, StringComparison.Ordinal));
        SortDogs(pack, byName);
        Console.WriteLine("Sorted dogs = " + pack.Count);
    }
}
