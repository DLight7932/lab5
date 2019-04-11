using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace struct_lab_student
{
    class Variant4
    {
        // Для студентів, що здали всі предмети на оцінку 5, замінити(у файл data_new.txt) величину стипендії на підвищену і вивести(на екран) про них всю інформацію, за винятком статі.
        // Величину підвищеної стипендії можна просто «захардкодити» («зашити») безпосередньо у свій текст програми.

        static bool GoodStudentSelector(Student t)
        {
            var array = new[] { t.physicsMark, t.informaticsMark, t.mathematicsMark };
            bool result = true;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < '5')
                    result = false;
            }
            return result;
        }

        static void ConsolePrint(Student s)
        {
            var text = 
                $"{s.surName} " +
                $"{s.firstName} " +
                $"{s.patronymic} " +
                $"{s.mathematicsMark} " +
                $"{s.physicsMark} " +
                $"{s.informaticsMark} " +
                $"{s.scholarship} ";

            Console.WriteLine(text);
        }

        internal static void YourMethodDima(Student[] data)
        {
            var goodStudents = data.Where(GoodStudentSelector).ToArray();

            Student UpdateStudent(Student _)
            {
                Student current = goodStudents.FirstOrDefault(t => t.Equals(_));

                bool isGoodStudent = !current.Equals(default(Student));

                if (isGoodStudent)
                {
                    current.scholarship = 1900;
                    return current;
                }
                else
                    return _;
            }

            var updatedData = data.Select(UpdateStudent).ToArray();

            for (int i = 0; i < goodStudents.Length; i++)
            {
                goodStudents[i].scholarship = 1900;
            }

            const string path = "data_new.txt";

            var builder = new StringBuilder(256);

            foreach (var i in goodStudents)
            {
                ConsolePrint(i);
            }

            foreach (var i in updatedData)
            {
                Debug.WriteLine(i.ToString());
                builder.AppendLine(i.ToString());
            }

            File.WriteAllText(path, builder.ToString());
        }
    }
}
