using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Lesson_2_Inheritance
{
    public static partial class Practice
    {
        /// <summary>
        /// A.L2.P1/1. Создать консольное приложение, которое может выводить 
        /// на печатать введенный текст  одним из трех способов: 
        /// консоль, файл, картинка. 
        /// </summary>
        public static void A_L2_P1_1()
        {
			
			Console.WriteLine(" Choose print type: ");
			Console.WriteLine("1 - Console");
			Console.WriteLine("2 - File");
			Console.WriteLine("3 - Image");
			Console.Write(" >> ");
			var type = Console.ReadLine();
			IPrinter printer = null;

			switch(type)
			{
				case "1":
					{
						printer = new ConsolePrinter(ConsoleColor.DarkBlue);
						//printer.Print();
						//Console.WriteLine("You have chosen printing into console");
						break;
					}
				case "2":
					{
						printer = new FilePrinter("PrintingText");
						//printer.Print();
						//Console.WriteLine("You have chosen printing into file");
						break;
					}
				case "3":
					{
						printer = new BitmapPrinter("testImage");
						//printer.Print(Console);
						//Console.WriteLine("You have chosen printing into image");
						break;
					}

			}
			Console.WriteLine("Write text");
			for (int i = 0; i < 1; i++)
			{
				Console.Write(" >> ");
				printer.Print(Console.ReadLine());
				//printer.Print();
			}
		}
		public interface IPrinter
		{
			void Print(string str);
		}
		//class Printer
		//{
		//	public string PrintingText { get; set; }
		//	public Printer(string text)
		//	{
		//		PrintingText = text;
		//	}
		//	//public abstract void Print();
		//}
		public class ConsolePrinter:IPrinter
		{
			public void Print(string str)
			{
				Console.ForegroundColor = _color;
				Console.WriteLine(str);
				Console.ResetColor();
			}
			public ConsolePrinter(ConsoleColor color)
			{
				_color = color;
			}
			private ConsoleColor _color;
		}
		public class FilePrinter : IPrinter
		{
			public void Print(string str)
			{
				//Console.ForegroundColor = _color;
				System.IO.File.AppendAllText($@"D:\{_fileName}.txt", str);
				Console.WriteLine(str);
				Console.ResetColor();
			}
			public FilePrinter(string fileName)
			{
				_fileName = fileName;
			}
			private string _fileName;
		}
		public class ImagePrinter : IPrinter
		{
			public void Print(string str)
			{
				Console.ForegroundColor = _color;
				Console.WriteLine(str);
				Console.ResetColor();
			}
			public ImagePrinter(string text, ConsoleColor color)
			{
				_color = color;
			}
			private ConsoleColor _color;
		}

		public class BitmapPrinter : IPrinter
		{
			public string FileName { get; }
			public void Print(string str)
			{
				Bitmap bitmap = new Bitmap(500, 300);
				Font drawFont = new Font("Arial", 16);
				SolidBrush drawBrush = new SolidBrush(Color.Black);
				float x = 10.0F;
				float y = 10.0F;
				StringFormat drawFormat = new StringFormat();
				drawFormat.FormatFlags = StringFormatFlags.DisplayFormatControl;
				Graphics graphics = Graphics.FromImage(bitmap);
				graphics.DrawString(str, drawFont, drawBrush, x, y, drawFormat);
				bitmap.Save($@"D:\{FileName}.png");
			}
			public BitmapPrinter(string fileName)
			{
				FileName = fileName;
			}
		}

	}
}
