using System;
using System.Collections.Generic;

namespace Task1
{
    // ==========================================
    // ЗАВДАННЯ 4:
    // ==========================================
    public class Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Animal(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            return $"Тварина: {Name}, Вік: {Age}";
        }
    }
    public class GenericList<T> where T : Animal
    {
        private class Node
        {
            public Node Next { get; set; }
            public T Data { get; set; }

            public Node(T t)
            {
                Next = null;
                Data = t;
            }
        }

        private Node head;

        public GenericList()
        {
            head = null;
        }

        public void AddHead(T t)
        {
            Node n = new Node(t);
            n.Next = head;
            head = n;
        }
        public void PrintAll()
        {
            Node current = head;
            while (current != null)
            {
                Console.WriteLine(current.Data.ToString());
                current = current.Next;
            }
        }
        public T FindByName(string name)
        {
            Node current = head;
            while (current != null)
            {
                if (current.Data.Name == name)
                {
                    return current.Data;
                }
                current = current.Next;
            }
            return null;
        }
    }

    // ==========================================
    // ЗАВДАННЯ 3: 
    // ==========================================
    public class NumberComparator<T> where T : IComparable<T>
    {
        public NumberComparator()
        {
          
        }

        public T GetSmaller(T a, T b)
        {
            if (a.CompareTo(b) < 0)
                return a;
            else
                return b;
        }
    }

    class Program
    {
        // ==========================================
        // ЗАВДАННЯ 1: 
        // ==========================================
        static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp;
            temp = lhs;
            lhs = rhs;
            rhs = temp;
        }

        // ==========================================
        // ЗАВДАННЯ 2:
        // ==========================================
        static void FindMinMax<T>(T[] array, out T min, out T max) where T : IComparable<T>
        {
            if (array == null || array.Length == 0)
            {
                throw new ArgumentException("Масив не може бути порожнім");
            }

            min = array[0];
            max = array[0];

            foreach (T item in array)
            {
                if (item.CompareTo(min) < 0) min = item;
                if (item.CompareTo(max) > 0) max = item;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("=== Завдання 1:===");

            double d1 = 1.5;
            double d2 = 9.9;
            Console.WriteLine($"До обмiну (double): {d1}, {d2}");
            Swap<double>(ref d1, ref d2);
            Console.WriteLine($"Пiсля обмiну (double): {d1}, {d2}");

            string s1 = "Hello";
            string s2 = "World";
            Console.WriteLine($"До обмiну (string): {s1} {s2}");
            Swap<string>(ref s1, ref s2);
            Console.WriteLine($"Пiсля обмiну (string): {s1} {s2}");
            Console.WriteLine();

            Console.WriteLine("=== Завдання 2: ===");

            int[] intArr = { 5, 1, 8, 3, 10, -2 };
            int minInt, maxInt;
            FindMinMax(intArr, out minInt, out maxInt);
            Console.WriteLine($"Int Array: [{string.Join(", ", intArr)}]");
            Console.WriteLine($"Min: {minInt}, Max: {maxInt}");

            double[] doubleArr = { 3.14, 1.0, 5.5, 0.01, 9.99 };
            double minDouble, maxDouble;
            FindMinMax(doubleArr, out minDouble, out maxDouble);
            Console.WriteLine($"Double Array: [{string.Join(", ", doubleArr)}]");
            Console.WriteLine($"Min: {minDouble}, Max: {maxDouble}");
            Console.WriteLine();

            Console.WriteLine("=== Завдання 3: ===");

            NumberComparator<int> intComparer = new NumberComparator<int>();
            int val1 = 10, val2 = 20;
            Console.WriteLine($"Менше з {val1} та {val2} це: {intComparer.GetSmaller(val1, val2)}");

            NumberComparator<double> doubleComparer = new NumberComparator<double>();
            double val3 = 5.55, val4 = 5.54;
            Console.WriteLine($"Менше з {val3} та {val4} це: {doubleComparer.GetSmaller(val3, val4)}");
            Console.WriteLine();

            Console.WriteLine("=== Завдання 4: ===");

            GenericList<Animal> zooList = new GenericList<Animal>();

            zooList.AddHead(new Animal("Лев", 5));
            zooList.AddHead(new Animal("Зебра", 3));
            zooList.AddHead(new Animal("Слон", 10));

            Console.WriteLine("Список тварин:");
            zooList.PrintAll();

            Console.WriteLine("\nПошук 'Зебра':");
            Animal found = zooList.FindByName("Зебра");
            if (found != null)
                Console.WriteLine($"Знайдено: {found}");
            else
                Console.WriteLine("Не знайдено.");

            Console.ReadKey(); 
        }
    }
}