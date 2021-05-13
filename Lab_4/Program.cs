using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace painting
{
    static class DLL
    {
        [DllImport("User32.dll")] public static extern IntPtr GetDC(IntPtr Window);

        [DllImport("User32.dll")] public static extern void ReleaseDC(IntPtr Window, IntPtr dc);
    }



    class Program
    {
        public static int ChooseColor()
        {
            Console.Clear();
            int choice;
            string str;
            bool result;
            Console.WriteLine($"1.Aqua");
            Console.WriteLine($"2.Black");
            Console.WriteLine($"3.Yellow");
            Console.WriteLine($"4.Coral");
            Console.WriteLine($"5.Green");
            Console.WriteLine($"Your choice: ");
            do
            {
                str = Console.ReadLine();
                result = Int32.TryParse(str, out choice);
                if (result == false) 
                {
                    Console.WriteLine("Incorrect input, try again!");
                }
            } while (result == false);
            return choice;
        }
        
        static void Main()
        {
            string str, path, answer;
            int color;
            IntPtr ptrOfDesktop = DLL.GetDC(IntPtr.Zero);
            Graphics graf = Graphics.FromHdc(ptrOfDesktop);
            SolidBrush myBrash = new SolidBrush(Color.White);
            do
            {
                Console.WriteLine("Enter your path to the image: ");
                path = Console.ReadLine();
                Console.WriteLine("Enter your string to write: ");
                str = Console.ReadLine();
                color = ChooseColor();
                switch (color)
                {
                    case 1:
                        {
                            myBrash = new SolidBrush(Color.Aqua);
                            break;
                        }
                    case 2:
                        {
                            myBrash = new SolidBrush(Color.Black);
                            break;
                        }
                    case 3:
                        {
                            myBrash = new SolidBrush(Color.Yellow);
                            break;
                        }
                    case 4:
                        {
                            myBrash = new SolidBrush(Color.Blue);
                            break;
                        }
                    case 5:
                        {
                            myBrash = new SolidBrush(Color.Green);
                            break;
                        }
                    default: break;

                } 
                Font myFont = new Font("NewTimesRoman", 60); // шрифт , размер
                StringFormat myFormat = new StringFormat();
                myFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft; // указываем горизонтальное выравнивание
                Point pnt_1 = new Point(800, 300);
                Point pnt_2 = new Point(1500, 100);
                while (true) 
                {
                    graf.DrawString(str, myFont, myBrash, pnt_2, myFormat);
                    graf.DrawImage(Image.FromFile("path"), pnt_1);
                    graf.Dispose();
                    DLL.ReleaseDC(IntPtr.Zero, ptrOfDesktop);
                }
                Console.WriteLine("Do you want to try again?");
                answer = Console.ReadLine();
                while(answer != "no" || answer != "yes")
                {
                    Console.WriteLine("Incorrect input, write only yes/no answers");
                    answer = Console.ReadLine();
                }
            } while (answer == "yes");
        }
    }
}
