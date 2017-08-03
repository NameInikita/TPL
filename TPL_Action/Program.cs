using System;
using System.Threading;
using System.Threading.Tasks;

namespace TPL_Action
{
    class Program
    {
        //Метод, который планируется запустить асинхронно

        static void MyTask()
        {
            int threadID = Thread.CurrentThread.ManagedThreadId;

            Console.Write("MyTask запущен в потоке {0}, CurrentId {1}", threadID,Task.CurrentId);

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write(j+ " ");
                    Thread.Sleep(100);
                }
                Console.WriteLine();
            }
            Console.WriteLine("MyTask завершился в потоке {0}, CurrentId {1}", threadID,Task.CurrentId);

        }

        static void Main(string[] args)
        {
            int threadID = Thread.CurrentThread.ManagedThreadId;

            Console.WriteLine("Main запущен в потоке {0}", threadID);

            Action action = new Action(MyTask);

            Task taskAction = new Task(action);//Создание  экземпляра задачи через делегат Action 
            //taskAction.Start();              //Запуск задачи на выполнение асинхронно.
            taskAction.RunSynchronously();    //Запуск задачи на выполнение синхронно.
            taskAction.Wait();                // Ожидание завершения асинхронной задачи.
            Task taskAction2 = new Task(action);//для проверки  CurrentId
            //taskAction2.Start();
            taskAction2.RunSynchronously();



            //Task task = new Task(MyTask);//Создание  экземпляра задачи на классе Task
            //task.Start();                //Запуск задачи на выполнение асинхронно.
            ////task.RunSynchronously();   //Запуск задачи на выполнение синхронно.

            Console.ReadKey();
        }
    }
}
