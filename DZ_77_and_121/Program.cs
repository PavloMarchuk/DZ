using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DZ_77_and_121
	{
	//Реализовать метод – который принимает параметр Limit типа int, и выводит на консоль все числа от 0 – до Limit, которые делятся на 77 и 121. Выполнить метод как задачу.

	class Program
		{
		static void Numbers_77_121(object Limit)
			{
			Console.WriteLine("Працює");
			for(int i =121; i < ((int)Limit); i++)
				{
				if(i%77 ==0 & i%121==0)
					{
					Console.Write(i + "\t");
					Thread.Sleep(50);
					}
				}
			}

		static void Main(string[] args)
			{
			Task t = new Task(Numbers_77_121, 123456);
			t.Start();
			t.Wait();
			//Task.WaitAll(t);
			}
		}
	}
