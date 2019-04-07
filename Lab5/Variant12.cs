using System;

namespace struct_lab_student
{
    partial class Variant12
    {
        /*TODO: 
        1) Find scholarship average
        2) Print student inisials that has scholarship value < average - 20 %
        (include only those students which have scholarship and exectly less than average - 20 % from average)
        */
        internal static void ShowStudWithSmallScholarship(Student[] data)
        {
            TupleList<string, int> studInfo = new TupleList<string, int>();
            double average = GetAverage(data, ref studInfo);
            double bound = (average * 20) / 100;

            Console.WriteLine("\nStudents that have 20% less money from scholarship average:");
            for(int i = 0; i < studInfo.Count; i++)
            {
                if (average - bound > studInfo[i].Item2)
                {
                    Console.WriteLine(studInfo[i].Item1);
                }
            }
            Console.WriteLine();
        }

        static double GetAverage(Student[] data, ref TupleList<string, int> studInfo)
        {
            double average = 0.0;

            int count = 0;
            string fullName;

            foreach (var stud in data)
            {
                if (stud.scholarship > 123 & stud.scholarship < 2345)
                {
                    fullName = stud.surName + " " + stud.firstName + " " + stud.patronymic;
                    studInfo.Add(fullName, stud.scholarship);
                    average += stud.scholarship;
                    ++count;
                }
            }
            return count > 0 ? average /= count : 1;
        }
    }
}
