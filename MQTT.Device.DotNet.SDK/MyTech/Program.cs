using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyTech
{
    public class Test {
        public Test() {
        }
    }
    public class Worker
    {
        public delegate void MyHandler(object sender, EventArgs args);
        public MyHandler MyDelegateHandler;

        public event MyHandler MyDelegateEventHandler;
        public event EventHandler MyEventHandler;


        // test
        //public delegate void delegate_prototype(object sender, EventArgs args);
        //public delegate_prototype delegate_object_unit;

        //public event delegate_prototype delegate_event_unit;
        //public event EventHandler event_handler_event_unit;
        

        public void Dowork()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Dowork {i}");
                OnWorkByEvent(i);
                OnWorkByDelegate(i);
                OnWorkByDelegateEvent(i);
            }
        }
        private void OnWorkByEvent(int i)
        {
            var fooHandler = MyEventHandler;
            if (fooHandler != null)
            {
                Console.WriteLine($"OnWorkByEvent raise {i}");
                fooHandler(this, EventArgs.Empty);
            }
        }

        private void OnWorkByDelegate(int i)
        {
            var fooHandler = MyDelegateHandler;
            if (fooHandler != null)
            {
                Console.WriteLine($"OnWorkByDelegate raise {i}");
                fooHandler(this, EventArgs.Empty);
            }
        }

        private void OnWorkByDelegateEvent(int i)
        {
            var fooHandler = MyDelegateEventHandler;
            if (fooHandler != null)
            {
                Console.WriteLine($"OnWorkByDelegateEvent raise {i}");
                fooHandler(this, EventArgs.Empty);
            }
        }


    }
    public class Program
    {
        public static Worker fooWorker = new Worker();

        public static Random Rm = new Random(DateTime.Now.Millisecond);

        public event EventHandler<Test> testEvent;

        public void Board(string message)
        {
            PostMessage(message);
        }

        public void PostMessage(string message)
        {
            Console.WriteLine(message);
        }

        static void Main(string[] args)
        {
            //public event EventHandler<test> testfunc;
            fooWorker.MyDelegateHandler += MyDelegateListener;
            fooWorker.MyEventHandler += MyDelegateListener;
            fooWorker.MyDelegateEventHandler += MyDelegateListener;

            fooWorker.Dowork();

            Console.ReadKey();
        }

        private static void MyDelegateListener(object sender, EventArgs args)
        {
            var foo = Rm.Next(500, 2000);
            //var foo = 1000;
            Console.WriteLine($"Sleep {foo}");
            Thread.Sleep(foo);
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
