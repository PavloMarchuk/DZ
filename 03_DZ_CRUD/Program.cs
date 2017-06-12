using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_DZ_CRUD
	{
	public class Book: IComparable
		{
		public string Title { get; set; }
		public string Author { get; set; }
		 
		public override string ToString()
			{
			return $"автор={Author} назва={Title}";
			}
		public int CompareTo(object obj)
			{
			string str = obj as String;
			if(str == this.Title)
				{
				return 0;
				}
			else return 1;			
			}
		}

	public class Library 
		{
		public List<Book> Library_List { get; set; }
		
		public Library()
			{
			Library_List = new List<Book>
				{
				new Book { Author = "Дмитро Донцов", Title= "Дух нашої давнини"},
				new Book { Author = "Дмитро Донцов", Title= "Націоналізм"},
				new Book { Author = "Юрій Липа", Title= "Призначення України"},
				new Book { Author = "Микола Міхновський", Title= "Десять заповідей"},
				new Book { Author = "Микола Міхновський", Title= "Десять заповідей УНП"},
				new Book { Author = "", Title= "44 правила українського націоналіста"}
				};
			}
		public override string ToString()
			{
			StringBuilder sb = new StringBuilder();
			int i = 1;
			foreach(var item in Library_List)
				{
				sb.Append (i++.ToString() +". " + item.ToString() + "\n") ;
				}
			return sb.ToString();
			}
		public Library GetAll()
			{
			return this;
			}
		public Library Get(object book_name)
			{
			Library res = new Library();
			res.Library_List = Library_List.Where(x => x.Title == book_name.ToString()).ToList();
			if(res.Library_List.Count == 0)
				{
				throw new Exception("ТАКА КНИГА ВІДСУТНЯ В КАТАЛОЗІ");
				}
			return res;
			}
		public Library Update(object param_3_str)
			{
			List<string> str_l = param_3_str as List<string>;
			string old_name = str_l[0];
			string new_author = str_l[1];
			string new_name = str_l[2];
			Library res = this.Get(old_name);
			//var povtor = Library_List.Find(x => x.Title==);
			res.Library_List.First().Title = new_name;
			res.Library_List.First().Author = new_author;
			return res;
			}

		public Library Insert(object param_2_str)
			{
			List<string> str_l = param_2_str as List<string>;	
			Book res = new Book { Author = str_l[0], Title = str_l[1]};
			this.Library_List.Add(res);
			return this;
			}
		public Library Delete(object param_1_str)
			{
			string str = param_1_str as String;
			Book x = Library_List.Where(n => n.Title == str).First();
			
				Library_List.Remove(x);
			return this;
			}
		}

	class Program
		{
		static void Main(string[] args)
			{
			Console.OutputEncoding = new UTF8Encoding();
			Library li00 = new Library();
		
			//////GetAll()			
			Console.WriteLine("GetAll():\n" + Task.Factory.StartNew<Library>(li00.GetAll).Result);
			///////////Get();
			Console.WriteLine("Get():\n" + Task.Factory.StartNew<Library>(li00.Get, "Націоналізм").Result);
			////////////Update()
			Console.WriteLine("Update():\n" + Task.Factory.StartNew(li00.Update, new List<string> { "Націоналізм", "Донцов", "Націоналізм" }).Result);
			////////////Insert()
			Console.WriteLine("Insert():\n" + Task.Factory.StartNew(li00.Insert, new List<string> { "Донцов", "Інтегральний націоналізм" }).Result);
			////////////Delete()
			Console.WriteLine("Delete():\n" + Task.Factory.StartNew(li00.Delete,  "Націоналізм" ).Result);
			}
		}
	}

//Реализовать класс, в котором реализованы CRUD операции – GetAll, Get, Update, Insert and Delete. В консольном приложении вызвать каждый из методов – как задачу.

