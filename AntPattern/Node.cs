using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntPattern
{
    class Node<T>
    {
        private T value;
        private Node<T> next;

        public Node(T value)
        {
            this.value = value;
            this.next = null;
        }

        public Node(T value, Node<T> next)
        {
            this.value = value;
            this.next = next;
        }


        //public static Node<int> BuildList(int zakif)
        //{
        //    Node<int> first = null, last;
        //    Console.WriteLine("Enter a number. For end, enter " + zakif);
        //    int num = int.Parse(Console.ReadLine());
        //    if (num != zakif)
        //    {
        //        first = new Node<int>(num);
        //        last = first;
        //        Console.WriteLine("Enter a number. For end, enter " + zakif);
        //        num = int.Parse(Console.ReadLine());
        //        while (num != zakif)
        //        {
        //            last.SetNext(new Node<int>(num));
        //            last = last.GetNext();
        //            Console.WriteLine("Enter a number. For end, enter " + zakif);
        //            num = int.Parse(Console.ReadLine());
        //        }
        //    }
        //    return first;
        //}



        public T GetValue()
        {
            return this.value;
        }

        public Node<T> GetNext()
        {
            return this.next;
        }
            
        public bool HasNext()
        {
            return this.next != null;
        }

        public void SetValue(T value)
        {
            this.value = value;
        }

        public void SetNext(Node<T> next)
        {
            this.next = next;
        }

        public override string ToString()
        {
            return this.value.ToString();
        }
    }
}
