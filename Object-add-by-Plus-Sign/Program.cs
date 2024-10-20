using System;
using System.Collections;
using System.Collections.Generic;

namespace ClassWithIEnumerable {
    class Program {
        public static void Main() {
            CustomObject obj1 = new CustomObject();
            obj1.Number = 20;
            obj1.Text = "Hello";
            CustomObject obj2 = new CustomObject();
            obj2.Number = 10;
            obj2.Text = "World";
            CustomObject obj3 = new CustomObject();
            obj3.Number = 3;
            obj3.Text = "World";
            CustomObject result = obj1 + obj2;
            CustomObject result2 = obj1 * obj2;
            CustomObject result3 = obj1 - obj2;
            CustomObject result4 = obj1 / obj2;
            CustomObject result5 = obj1 % obj3;
            Console.WriteLine($"obj1: 20, 'Hello'");
            Console.WriteLine($"obj2: 10, 'World'");
            Console.WriteLine($"obj3: 3, 'World'");
            Console.WriteLine($"obj1 + obj2 => .Number={result.Number}, .Text={result.Text}");
            Console.WriteLine($"obj1 * obj2 => .Number={result2.Number}, .Text={result2.Text}");
            Console.WriteLine($"obj1 - obj2 => .Number={result3.Number}, .Text={result3.Text}");
            Console.WriteLine($"obj1 / obj2 => .Number={result4.Number}, .Text={result4.Text}");
            Console.WriteLine($"obj1 % obj3 => .Number={result5.Number}, .Text={result5.Text}");
        }
    }
    public class CustomObject
    {
        public int Number { get; set; }
        public string Text { get; set; }

        public static CustomObject operator +(CustomObject obj1, CustomObject obj2)
        {
            CustomObject result = new CustomObject();
            result.Number = obj1.Number + obj2.Number;
            result.Text = obj1.Text + "+" + obj2.Text;
            return result;
        }
        public static CustomObject operator *(CustomObject obj1, CustomObject obj2)
        {
            CustomObject result = new CustomObject();
            result.Number = obj1.Number * obj2.Number;
            result.Text = obj1.Text + "*" + obj2.Text;
            return result;
        }
        public static CustomObject operator -(CustomObject obj1, CustomObject obj2)
        {
            CustomObject result = new CustomObject();
            result.Number = obj1.Number - obj2.Number;
            result.Text = obj1.Text + "-" + obj2.Text;
            return result;
        }
        public static CustomObject operator /(CustomObject obj1, CustomObject obj2)
        {
            CustomObject result = new CustomObject();
            float divrst = (float)obj1.Number / (float)obj2.Number;
            result.Number = (int)divrst;
            result.Text = obj1.Text + "/" + obj2.Text;
            return result;
        }
        public static CustomObject operator %(CustomObject obj1, CustomObject obj2)
        {
            CustomObject result = new CustomObject();
            result.Number = obj1.Number % obj2.Number;
            result.Text = obj1.Text + "%" + obj2.Text;
            return result;
        }
    }

}
// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
