using System;

namespace struct_lab_student
{
    partial class Variant17
    {
        internal static void YourMethodYevhenii(Student[] data)
        {
            TupleList<string, double> NameWithAvarageMark = new TupleList<string, double>();
            Task(data, ref NameWithAvarageMark);
            Console.WriteLine("\nStudents who have an avarage mark of more than 4.5:");
            for (int i = 0;i < NameWithAvarageMark.Count;i++)
            {
                Console.WriteLine(NameWithAvarageMark[i].Item1 + " " + NameWithAvarageMark[i].Item2);
            }
            Console.WriteLine();
        }
        static void Task(Student[] data, ref TupleList<string, double> NameWithAvarageMark)
        {
            string FullName = "";
            foreach (var Student in data)
            {
                int inf = (int)Char.GetNumericValue(Student.informaticsMark);
                int math = (int)Char.GetNumericValue(Student.mathematicsMark);
                int phys = (int)Char.GetNumericValue(Student.physicsMark);
                int sum = inf + math + phys;
                if ((double)sum / 3 > 4.5)
                {
                    FullName = Student.surName + " " + Student.firstName + " " + Student.patronymic;
                    NameWithAvarageMark.Add(FullName, (double)sum / 3);
                }
            }
        }
    }
}
