using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace struct_lab_student
{
    class Variant5
    {
        /*5.	Для студентів, що мають хоча б одну незадовільну оцінку або неявку, замінити величину стипендії на нуль 
         * (результати вивести у файл data_new.txt). Вивести (на екран) прізвища цих студентів і їх оцінки по всіх предметах.*/
        static bool AlphaMalesSelector(Student t)
        {
            var array = new[] { t.physicsMark, t.informaticsMark, t.mathematicsMark };
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < '3')
                    return true;
            }
            return false;
        }

        static void PrintToConsole(Student s)
        {
            var text = $"{s.surName} " +
                $"" +
                $"" +
                $"{s.mathematicsMark} " +
                $"{s.physicsMark} "+
                $"{s.informaticsMark} ";

            Console.WriteLine(text);
        }

        internal static void YourMethodLera(Student[] data)
        {
            var alphaMales = data.Where(AlphaMalesSelector).ToArray();

            Student UpdateStudent(Student _)
            {               
                Student current = alphaMales.FirstOrDefault(t => t.Equals(_));

                bool isAlphaMale = !current.Equals(default(Student));

                if (isAlphaMale)
                {
                    current.scholarship = 0;
                    return current;
                }
                else
                    return _;
            }

            var updatedData = data.Select(UpdateStudent).ToArray();

            for (int i = 0; i < alphaMales.Length; i++)
            {
                alphaMales[i].scholarship = 0;
            }

            const string path = "data_new.txt";

            var builder = new StringBuilder(256);

            foreach(var i in alphaMales)
            {
                PrintToConsole(i);
            }

            foreach(var i in updatedData)
            {
                Debug.WriteLine(i.ToString());
                builder.AppendLine(i.ToString());
            }

            File.WriteAllText(path, builder.ToString());
        }
    }
}
