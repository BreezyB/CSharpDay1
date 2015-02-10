using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineWeek4Day1
{
    public class Program
    {
        // private => access modifier
        // static => class/member modifier
        // void => return type
        // Main => function name
        // string[] args => parameter
        private static void Main(string[] args)
        {
            //Default Constructor
            Person me = new Person();
            me.FirstName = "Jeremy";
            me.LastName = "Doucet";
            me.Age = 22;

            //Default Constructor
            Person you = new Person() { Age = 45, FirstName = "You", LastName = "Not ME!" };
            //Constructor
            Person notMe = new Person("Not Me", "For Sure", 77);

            List<Person> people = new List<Person>() { me, you }; //instantiate list with 2 elements inside of it
            people.Add(notMe);

            //calls our static method
            StaticClass.StaticMethod();
            StaticClass.StaticString = "This is our statis string";
            Console.WriteLine(StaticClass.StaticString);

            //Loops through people list, and writes the name and age
            foreach (Person person in people)
            {
                Console.WriteLine("My name is " + person.FullName + " and I am " + person.Age + " years old.");
            }

            List<AbstractClass> myList = new List<AbstractClass>()
            {
                new ChildClass() { AbstractString = "first" },
                new ChildClass2() { AbstractString = "second" },
                new ChildClass() { AbstractString = "third" },
                new ChildClass() { AbstractString = "fourth" },
                new ChildClass2() { AbstractString = "fifth" }
            };

            //loop through polymorphic list
            foreach (AbstractClass x in myList)
            {
                x.AbstractMethod();
                Console.WriteLine(x.InheritedString + " - " + x.AbstractString);
            }

            //Adds a break with our sentence at the bottom of the console
            Console.WriteLine();
            Console.WriteLine("Please press Enter to close the program");
            //freeze the console so we can read it
            Console.ReadLine();
        }
    }

    public class Person
    {
        private int age;
        //defining a property called FirstName
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value > 115 || value < 0)
                {
                    age = 0;
                }
                else
                {
                    age = value;
                }
            }
        }
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        //empty constructor
        public Person()
        {
        }

        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }
    }

    //STATIC
    //CANNOT Inherit
    //CANNOT Instantiate
    public static class StaticClass
    {
        public static string StaticString { get; set; }

        public static void StaticMethod()
        {
            Console.WriteLine("Running our StaticMethod()");
        }
    }

    //ABSTRACT
    //MUST Inherit
    //CANNOT Instantiate
    //Parent | Base Class
    public abstract class AbstractClass
    {
        public abstract string AbstractString { get; set; }
        public string InheritedString { get; set; }

        //CANNOT declare body, must be overwritten
        public abstract void AbstractMethod();
    }

    //Child | Derived class
    public class ChildClass : AbstractClass
    {
        public ChildClass()
        {
            InheritedString = "Look mom, no defining!";
        }

        public override string AbstractString { get; set; }

        public override void AbstractMethod()
        {
            Console.WriteLine("Running Abstract Method");
        }
    }

    public class ChildClass2 : AbstractClass
    {
        public override string AbstractString { get; set; }

        public override void AbstractMethod()
        {
            Console.WriteLine("Running method on ChildClass2");
        }

        public ChildClass2()
        {
            InheritedString = "Child Class 2";
        }
    }
}

//public => whole program
//private => only that class
//internal => only that assembly
//protected => only that class and any class that directly inherits
//internal protected => only that assembly OR {protected}