using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _02_DZ_a_b
	{
	class Program
		{
		static void Suma(int a , int b)
			{
			Thread.Sleep(999);
			Console.WriteLine($"{a}+{b} = {a + b}");
			}
		class P
			{
			public int a { get; set; }
			public int b { get; set; }
			}

		static void SuummaExt (object o)
			{
			P p = o as P;
			int a = p.a;
			int b = p.b;
			Suma(a,b);
			}
		static void Main(string[] args)
			{
			Task task = new Task(SuummaExt, new P { a = 21, b = 22 });
			task.Start();
			task.Wait();
			int a = 22, b = 33;
			Task newTask = new Task( 
				()=> Suma(a,b)
				);                      //супер лямбда-вираз. МЕНІ СПОДОБАЛОСЬ.
			newTask.Start();
			newTask.Wait();

			}
		}
	}
