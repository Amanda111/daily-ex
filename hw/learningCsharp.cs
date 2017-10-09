using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace CSgrammar
{
    public class learningCsharp
    {
        static double testdomain;
		static void Main(string[] args)
		{
            // 数值类型 及 转换 boolean
            Console.Write("Test:数值类型转换\n");
            int intnum = 4;
            double doublenum = 4.003D;
            bool booladd = true;
            double sumnum = 0;
            char han = '圆';
            string str = "circle";

            var varstr = "javascript has var too!";
            var varnum = "111";
            int strtonum = int.Parse(varnum);
            //double testdomain; // won't work
            if(booladd){
                sumnum = intnum + doublenum;
                testdomain = (double) intnum;
            }
            Console.WriteLine(sumnum);
            Console.WriteLine(testdomain);
            Console.WriteLine("圆的汉字是：{0}", han);
            Console.WriteLine("圆的英文是：{0}", str);
            Console.WriteLine("用var定义的变量：{1},{0}", varstr, varnum);
            Console.WriteLine("用var定义再用int.Parse方法的变量：{0}", strtonum+3);
            Console.Write("---------------------\n\n");


			// Struct
			Console.WriteLine("Test:Sruct");
			ComplexNumber c1;
			c1.a = 1.5;
			c1.b = 3;
			ComplexNumber c2 = c1;
            c1.a = 2;
            c1.Write();
            c2.Write();
            Console.Write("---------------------\n\n");

            // Class
            Console.WriteLine("Test:Class");
            ComplexNum n1 = new ComplexNum();
            n1.a = 1.5;
            n1.b = 3;
            ComplexNum n2 = n1;
            n1.a = 2;
            n1.Write();
            n2.Write();
            Console.Write("---------------------\n\n");

			// enum
            Console.WriteLine("Test:enum\n");
			int k = (int)DateTime.Now.DayOfWeek;
            switch(k)
            {
              case (int)MyDate.Sun:Console.WriteLine("今天是星期日"); break;
              case (int)MyDate.Mon:Console.WriteLine("今天是星期一"); break;
              case (int)MyDate.Tue:Console.WriteLine("今天是星期二"); break;
              case (int)MyDate.Wed:Console.WriteLine("今天是星期三"); break;
              case (int)MyDate.Thi:Console.WriteLine("今天是星期四"); break;
              case (int)MyDate.Fri:Console.WriteLine("今天是星期五"); break;
              case (int)MyDate.Sat:Console.WriteLine("今天是星期六"); break;
			}
            Console.Write("---------------------\n\n");


			// Array from Class
			Console.WriteLine("Test:Array from Class\n");
            ComplexNum[] cn = new ComplexNum[4];
            cn[0] = n1;
            Console.Write(cn[0].a);
            Console.Write('\n');
            cn[1] = n1;
            cn[1].a = 3;
            Console.Write(cn[0].a);
            Console.Write('\n');
            Console.Write(cn[1].a);
            Console.Write('\n');
            cn[2] = new ComplexNum();
            cn[2].a = 4;
            cn[2].b = 5;
            Console.Write(cn[2].a + cn[2].b);
            Console.Write('\n');
            cn[3] = cn[1];
            Console.Write(cn[3].a);
            Console.Write('\n');
            Console.Write("---------------------\n\n");


            // Array
            Console.WriteLine("Test:Array\n");
			int[,] x = new int[2, 3] { { 1, 2, 3 }, { 3, 5, 8 } };
			int[,] y = new int[,] { { 10, 50 }, { 25, 75 }, { 50, 150 }, { 100, 80 } };
			int[,,] z = { { { 1, 2 }, { 3, 5 }, { 8, 13 } }, { { 1, 2 }, { 3, 5 }, { 8, 13 } } };
			Console.Write("数组x长度为: ");
			Console.WriteLine(x.Length);
			Console.WriteLine("各维长度: {0} * {1}", x.GetLength(0), x.GetLength(1));
            Console.Write("---------------------\n\n");

            // Abstract class and interface
            Console.WriteLine("Test:Abstract class and interface\n");
			Car car = new Car("小汽车");
			car.Show();
			car.Move();
			car.GetWheel();
			Plane plane = new Plane("飞机");
			plane.Show();
			plane.Move();
			plane.GetWheel();
			Console.ReadLine();
            Console.Write("---------------------\n\n");

            // 类型转换
            Console.WriteLine("Test:类型转换\n");
			Weekday w1 = 0;
			Weekday w2 = (Weekday)3; // 显式转换
			Weekday w3 = (Weekday)10; // 显式转换
			Console.WriteLine(w1);
			Console.WriteLine(w2);
			Console.WriteLine(w3);
			int xy = (int)Weekday.Friday; // 显式转换
			Console.WriteLine(xy);
            Console.Write("---------------------\n\n");

			// 引用类型之间的转换
            Console.WriteLine("Test:引用类型之间的转换\n");
			Graduate g1 = new Graduate();
			g1.name = "www";
			Student s1 = g1; // 向上隐式转换
			Student s2 = new Student();
			s2.name = "hhh";
			Graduate g2 = (Graduate)s1; // 显式转换
			Console.WriteLine(g2.name);
			// Graduate g3 = (Graduate)s2; // 向下显式转换，this will throw error

			Graduate[] gs1 = new Graduate[] { g1, g2 };
			Student[] ss1 = gs1; // 向上隐式转换
			Graduate[] gs2 = (Graduate[])ss1; // 向下显式转换
            Console.Write("---------------------\n\n");

			// 操作符
            Console.WriteLine("Test:操作符\n");
			bool[] boolarr = new bool[5];
			boolarr[0] = true;
            boolarr[1] = false;
			boolarr[2] = true;
            boolarr[3] = false;
			boolarr[4] = true;
			int cnt = 0;
			bool b = (boolarr[cnt++]) && (boolarr[cnt++] || boolarr[cnt]) && (boolarr[++cnt] || boolarr[++cnt]);
			Console.WriteLine("考核结果为: {0}", b);
			Console.WriteLine("判断次数为: {0}", cnt);
            Console.Write("---------------------\n\n");

			// as操作符
            Console.WriteLine("Test:as操作符\n");
			object[] objArray = new object[6];
			objArray[0] = new ComplexNum();
			objArray[1] = new ComplexNumber();
			objArray[2] = "hello";
			objArray[3] = 123;
			objArray[4] = 123.4;
			objArray[5] = null;

			for (int i = 0; i < objArray.Length; ++i)
			{
				string s = objArray[i] as string;//把数组元算转换为字符串
				Console.Write("{0}:", i);
				if (s != null)//如果转换结果不为空
				{
					Console.WriteLine("'" + s + "'");
				}
				else//否则
				{
					Console.WriteLine("不是字符串");
				}
			}
            Console.Write("---------------------\n\n");


			// is操作符
            Console.WriteLine("Test:is操作符\n");
			ClassA a1 = new ClassA();//声明类A的对象a1
			ClassB b2 = new ClassB();//声明类B的对象b1
			Test(a1);
			Test(b2);
			Test("a string");
            Console.Write("---------------------\n\n");

			// 泛型
            Console.WriteLine("Test:定义泛型\n");
			Stack<int> a = new Stack<int>(100);
			a.Push(10);
            a.Push(88);
			//a.Push("8888");//这一行编译不通过，因为类a只接收int类型的数据
			int result = a.Pop();
            Console.Write(result);
            Console.Write('\n');
            result = a.Pop();
			Console.Write(result);
			Console.Write('\n');
			//实例化只能保存string类型的类
			Stack<string> stackstr = new Stack<string>(100);
			stackstr.Push("hello");
			string stresult = stackstr.Pop();
            Console.Write(stresult);
            Console.Write('\n');
            Console.Write("---------------------\n\n");


		}
		static void Test(object o)
		{
			ClassA a;//声明类A的对象a
			ClassB b;//声明类B的对象b

			if (o is ClassA)//如果o是类A
			{
				Console.WriteLine("o 是类A");
				a = (ClassA)o;//可以把o转化为类A，而不出现异常
			}
			else if (o is ClassB)//如果o是类B
			{
				Console.WriteLine("o is 类B");
				b = (ClassB)o;//可以把o转化为类B，而不出现异常
			}
			else
			{
				Console.WriteLine("o 不是类A，也不是类B.");
				Console.WriteLine("o是{0}", o.GetType());//输出o的类型
			}
		}
    }
	struct ComplexNumber
	{
		public double a;
		public double b;

		public void Write()
		{
			Console.WriteLine("{0}+{1}i", a, b);
		}
	}

    class ComplexNum
    {
		public double a;
		public double b;

		public void Write()
		{
			Console.WriteLine("{0}+{1}i", a, b);
		} 
    }

	enum MyDate
	{
		Sun = 0,
		Mon = 1,
		Tue = 2,
		Wed = 3,
		Thi = 4,
		Fri = 5,
		Sat = 6
	}


    // abstract class
	abstract class Travel
	{
		protected string _name;//交通工具的名称

		public abstract string Name//定义抽象属性，表示交通工具的名称
		{
			get;
			set;
		}

		public void Show()//定义一般方法，用来显示是何种交通工具
		{
			Console.WriteLine("这是{0}", _name);
		}
		public abstract void GetWheel();//获取轮子的数量
	}

    // interface (Notice for the Caps I as the symbol of interface
	interface IAction
	{
		//注意这个方法同抽象类中的方法GetWheel的区别
		//任何东西都可以具有移动行为，而只有交通工具才有轮子
		void Move();//表示交通工具行驶的行为
	}

	class Car : Travel, IAction
	{
		public override string Name//重写抽象类属性
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
			}
		}
		public Car(string name)
		{
			_name = name;
		}
		public void Move()//实现接口方法
		{
			Console.WriteLine("小汽车行走在公路上");
		}

		public override void GetWheel()//重写抽象类方法
		{
			Console.WriteLine("小汽车有4个轮子");
		}
	}


	class Plane : Travel, IAction
	{
		public override string Name//重写抽象类属性
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
			}
		}
		public Plane(string name)
		{
			_name = name;
		}
		public void Move()//实现接口方法
		{
			Console.WriteLine("飞机在空中飞行");
		}

		public override void GetWheel()//重写抽象类方法
		{
			Console.WriteLine("飞机有6个轮子");
		}
	}

	enum Weekday
	{
		Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
	}

	// 继承和测试向上向下转换
	class Student
	{
		public string name;
		public int age;
		public int grade;
		public void Register() { }
	}

	class Graduate : Student
	{
		public string supervisor = null;
	}

	class ClassA { }
	class ClassB { }

	public class Stack<T> //定义一个堆栈，并使用<T>定义通用数据类型T
	{
        private T error;
		private T[] m_item;//定义一个T型的数组
        private int count = 0;
        private int length = 0;
		public T Pop() {
            if(this.count >= 0){
                return this.m_item[count--];
            }
            return error;
        }
		public void Push(T item) {
            if(this.count < this.length - 1)
            this.m_item[++count] = item;
        }
		public Stack(int i) //堆栈类的构造函数
		{
            this.length = i;
			this.m_item = new T[i]; //初始化数组

		}
    }

}

