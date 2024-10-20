using System;
using System.Collections;
using System.Collections.Generic;

namespace ClassWithIEnumerable {
    class Program
    {
        public static int Main()
        {
            ICollection<string> icollection = new List<string>();                   //System.Collections.Generic.List`1[System.String]
            var collection = new MyCollection<int>(new int[] { 1, 2, 3, 4, 5 });    //ClassWithIEnumerable.MyCollection`1[System.Int32]
            var uintcolls = new MyCollection<uint>(new uint[] { 1, 2, 3, 4, 5 });   //ClassWithIEnumerable.MyCollection`1[System.UInt32]
            var longcolls = new MyCollection<long>(new long[] { 1, 2, 3, 4, 5 });
            var ulongcolls = new MyCollection<ulong>(new ulong[] { 1, 2, 3, 4, 5 });
            var digits = new MyCollection<string>(new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" });
            var floats = new MyCollection<float>(new float[] { 1.0f, 1.1f, 2.3f });
            var doubles = new MyCollection<double>(new double[] { 1.0d, 1.1d, 2.3d, 3.5d });
            Console.WriteLine($"{collection.GetType()}");
            Console.WriteLine($"{uintcolls.GetType()}");
            Console.WriteLine($"{icollection.GetType()}");
            foreach (var item in collection) { Console.WriteLine($"1# {item}"); }
            foreach (var item in digits) { Console.WriteLine($"2# {item}"); }

            int[] numbers = { 1, 2, 3, 4, 5 };
            MyEnumerator<int> enumerator = new MyEnumerator<int>(numbers);
            while (enumerator.MoveNext())
            {
                int currentNumber = enumerator.Current;
                Console.WriteLine($"3# {currentNumber}");
            }
            enumerator.Reset();
            enumerator.Dispose();

            var Sycollection = new SyCollection<int>();
            Sycollection.Add(1);
            Sycollection.Add(2);
            Sycollection.Add(3);
            foreach (var item in Sycollection) {  Console.WriteLine($"4# {item}"); }

            return 0;
        }
    }
    public class MyCollection<T> : IEnumerable<T>
    {
        private T[] items;
        
        public MyCollection(T[] items)
        {
            this.items = items;
            Console.Write($"Type={items.GetType()}; ");
            if (items is int[]) {
                Console.Write("Type is array of int.");
            } else if (items is string[]) {
                Console.Write("Type is array of string.");
            } else {
                Console.Write($"Type is {items.GetType()}.");
            }
            Console.WriteLine();
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            return new MyEnumerator<T>(items);
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class MyEnumerator<T> : IEnumerator<T>
    {
        private T[] items;
        private int currentIndex;
        
        public MyEnumerator(T[] items)
        {
            this.items = items;
            currentIndex = -1;
        }
        
        public T Current
        {
            get
            {
                if (currentIndex < 0 || currentIndex >= items.Length)
                    throw new InvalidOperationException();
                
                return items[currentIndex];
            }
        }
        
        object IEnumerator.Current => Current;
        
        public bool MoveNext()
        {
            currentIndex++;
            return currentIndex < items.Length;
        }
        
        public void Reset()
        {
            currentIndex = -1;
        }
        
        public void Dispose()
        {
            // Dispose any resources here
        }
    }
    public class SyCollection<T> : IEnumerable<T>
    {
        private List<T> items = new List<T>();
        public void Add(T item)
        {
            items.Add(item);
        }
        public IEnumerator<T> GetEnumerator()
        {
            return items.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public class SyEnumerator<T> : IEnumerator<T>
    {
        private List<T> items;
        private int currentIndex = -1;
        public SyEnumerator(List<T> items)
        {
            this.items = items;
        }
        public T Current => items[currentIndex];
        object IEnumerator.Current => Current;
        public bool MoveNext()
        {
            currentIndex++;
            return currentIndex < items.Count;
        }
        public void Reset()
        {
            currentIndex = -1;
        }
        public void Dispose()
        {
            // Dispose any resources if needed
        }
    }
}
// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
