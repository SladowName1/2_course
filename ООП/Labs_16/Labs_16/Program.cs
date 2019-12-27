using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;

using System.Threading;
using System.Collections;
using System.Diagnostics;

namespace Labs_16
{
    class Program
    {
        static BlockingCollection<object> Block = null;
        static void Main(string[] args)
        {
            Task task = new Task(multiplication_of_mattress);
            task.RunSynchronously();
            Console.WriteLine($"{task.Id}   {task.IsCompleted}   {task.Status}");

            CancellationTokenSource token = new CancellationTokenSource();
            new Task(multiplication_of_mattress, token.Token).RunSynchronously();
            token.Cancel();

            int a = 5;
            int b = 23;
            int c = -3;
            Task.Run(() => First(ref a));
            Task.Run(() => Second(ref b));
            Task.Run(() => Third(ref c));
            Thread.Sleep(300);
            Task.Run(() =>
            {
                int d = a / c + b;
                Console.WriteLine(d);
            });
            Thread.Sleep(500);

            Task t1 = new Task(First1);

            Task t2 = t1.ContinueWith(Second2);
            Task t3 = t2.ContinueWith(Third3);
            t1.Start();
            t1.Wait();
            t2.Wait();
            t3.Wait();
            t1 = new Task(First1);

            Parallel.For(1, 10, Out);
            Console.WriteLine();
            Thread.Sleep(500);
            Parallel.ForEach(new List<int> { 1, 2, 3, 4, 5 }, Out);

            Parallel.Invoke(() => multiplication_of_mattress(), () => tmultiplication_of_mattress());

            Block = new BlockingCollection<object>(10);
            Task Sup = new Task(Supplier);
            Task Con = new Task(Consumer);

            Sup.Start();
            Con.Start();
            Task.WaitAll(Con, Sup);
            Sup.Dispose();
            Con.Dispose();

            Async();
            Console.ReadLine();
        }
        static void Print(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write("{0} ", a[i, j]);
                }
                Console.WriteLine();
            }
        }
        static void multiplication_of_mattress()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Random rand = new Random();
            Console.WriteLine("Введите матрицу А");
            int[,] A = new int[Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine())];
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    A[i, j] = rand.Next(1, 1000);
                }
            }

            Console.WriteLine("Введите матрицу Б");
            int[,] B = new int[Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine())];
            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    B[i, j] = rand.Next(1, 1000);
                }
            }
            if (A.GetLength(1) != B.GetLength(0))
            {
                throw new Exception("Нельзя перемножить");
            }
            int[,] C = new int[A.GetLength(0), B.GetLength(1)];

            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    for (int k = 0; k < B.GetLength(0); k++)
                    {
                        C[i, j] += A[i, k] * B[k, j];
                    }
                }
            }
            Console.WriteLine("Матрица А");
            Print(A);
            Console.WriteLine("Матрица Б");
            Print(B);
            Console.WriteLine("Матрица С");
            Print(C);
            stopwatch.Stop();
            TimeSpan time = stopwatch.Elapsed;
            Console.WriteLine($"\t{time.Seconds} {time.Milliseconds}");
        }
        static void tmultiplication_of_mattress()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Random rand = new Random();

            Console.WriteLine("Введите матрицу А");
            int[,] A = new int[Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine())];
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    A[i, j] = rand.Next(1, 1000);
                }
            }

            Console.WriteLine("Введите матрицу Б");
            int[,] B = new int[Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine())];
            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    B[i, j] = rand.Next(1, 1000);
                }
            }
            if (A.GetLength(1) != B.GetLength(0))
            {
                throw new Exception("Нельзя перемножить");
            }
            int[,] C = new int[A.GetLength(0), B.GetLength(1)];

            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    for (int k = 0; k < B.GetLength(0); k++)
                    {
                        C[i, j] += A[i, k] * B[k, j];
                    }
                }
            }
            Console.WriteLine("Матрица А");
            Print(A);
            Console.WriteLine("Матрица Б");
            Print(B);
            Console.WriteLine("Матрица С");
            Print(C);
            stopwatch.Stop();
            TimeSpan time = stopwatch.Elapsed;
            Console.WriteLine($"\t{time.Seconds} {time.Milliseconds}");
        }

        static int First(ref int a)
        {
            for (int i = 0; i < a; i++)
            {
                a += a;
            }
            return a;
        }
        static int Second(ref int a)
        {
            int i = 10;
            if (i > a)
                return a = 10;
            else
                for (; i < a; i++)
                {
                    a += a;
                }
            return a;
        }
        static int Third(ref int a)
        {
            a += 1000 + 10;
            return a;
        }
        static void First1()
        {
            Console.WriteLine("Fisrt task");
        }

        static void Second2(Task t)
        {
            Console.WriteLine("Second task");
        }

        static void Third3(Task t)
        {
            Console.WriteLine("Third task");
        }

        static void Out(int x)
        {
            Console.WriteLine(x);
            Thread.Sleep(10);
        }
        static void Supplier()
        {
            int x;
            Random random = new Random();
            ArrayList products = new ArrayList() { "Шкаф", "Диван", "Тумбочка", "Стул", "Стол" };
            for (int i = 0; i < 5; i++)
            {
                x = random.Next(0, products.Count - 1);
                Task.Run(() => Sup1(products[0]));
                Task.Run(() => Sup2(products[1]));
                products.Remove(x);
                Task.Run(() => Sup3(products[2]));
                Task.Run(() => Sup4(products[3]));
                products.Remove(x);
                Task.Run(() => Sup5(products[4]));
            }
            Thread.Sleep(1000);
            Block.CompleteAdding();
            if (Block.IsAddingCompleted)
            {
                Console.WriteLine("Рабочий день закончен");
            }
        }

        static void Sup1(object item)
        {
            Block.Add(item);
            Thread.Sleep(100);
        }

        static void Sup2(object item)
        {
            Block.Add(item);
            Thread.Sleep(200);
        }

        static void Sup3(object item)
        {
            Block.Add(item);
            Thread.Sleep(150);
        }

        static void Sup4(object item)
        {
            Block.Add(item);
            Thread.Sleep(120);
        }

        static void Sup5(object item)
        {
            Block.Add(item);
            Thread.Sleep(300);
        }
        static void Consumer()
        {
            object str;
            while (!Block.IsCompleted)
            {
                if (Block.TryTake(out str))
                {
                    Console.WriteLine($"Был куплен товар {str}");
                }
                else
                    Console.WriteLine("Покупатель ушел");
                Thread.Sleep(5);
            }
        }
        static async void Async()
        {
            Console.WriteLine();
            await Task.Run(() => multiplication_of_mattress());
            await Task.Run(() => tmultiplication_of_mattress());

        }
    }
}
