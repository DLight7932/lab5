using System;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace struct_lab_student
{
    partial class Program
    {
        static Student[] ReadData(string fileName)
        {
            // TODO   implement this method.
            // It should read the file whose fileName has been passed and fill

            Console.OutputEncoding = Encoding.Unicode;

            string fileFullPath = Path.Combine(Directory.GetCurrentDirectory(), fileName);
            StreamReader file = new StreamReader(fileFullPath);

            List<string> lines = File.ReadLines(fileFullPath).Where(line => line != "").ToList();
            int listLen = lines.Count;

            Student[] students = new Student[listLen];
            for(int i = 0; listLen > 0; listLen--, i++)
            {
                students[i] = new Student(lines[i]);
            }
            file.Close();

            return students;
        }

        internal static void runMenu(Student[] studs)
        {
            // TODO   implement this method
            // It should call method(s) for concrete variant(s)
            bool execut = true;

            while (execut)
            {
                Console.WriteLine("To execute first  option (made by Artur Stecenko)       Press 1");
                Console.WriteLine("To execute second option (made by Yevhenii Ponomarenko) Press 2");
                Console.WriteLine("To execute third  option (made by Lera Bonarenko)       Press 3");
                Console.WriteLine("To execute fourth option (made by Dmitry Moiseev)       Press 4");
                Console.WriteLine("\nPress 0 To Exit\n");
                
                switch (Console.ReadLine())
                {
                    case "0": execut = false;
                        break;
                    case "1": Variant12.ShowStudWithSmallScholarship(studs);
                        break;
                    case "2": Variant17.YourMethodYevhenii(studs);
                        break;
                    case "3": Variant5.YourMethodLera(studs);
                        break;
                    case "4": Variant4.YourMethodDima(studs);
                        break;
                }
            }
        }

        static void Main(string[] args)
        {
            Student[] studs = ReadData("input.txt");
            runMenu(studs);
        }
    }
}
