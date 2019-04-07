using System;

namespace struct_lab_student
{
    struct Student
    {
        public string surName;
        public string firstName;
        public string patronymic;
        public char sex;
        public string dateOfBirth;
        public char mathematicsMark;
        public char physicsMark;
        public char informaticsMark;
        public int scholarship;
        public double[] allMarks;

        public Student(string lineWithAllData)
        {
            // TODO   you SHOULD IMPLEMENT constructor with exactly this signature
            // lineWithAllData is string contating all data about one student, as described in statement
            string[] data = lineWithAllData.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            surName    = data[0];
            firstName  = data[1];
            patronymic = data[2];

            sex = Convert.ToChar(data[3]);

            dateOfBirth = data[4];

            char[] marks = { Convert.ToChar(data[5]), Convert.ToChar(data[6]), Convert.ToChar(data[7]) };
            double[] dMarks = new double[3];

            for(int i = 0; i < marks.Length; i++)
            {
                marks[i] = !char.IsNumber(marks[i]) 
                           || marks[i].Equals('-') ? '2' : 
                              marks[i] > 53 ? '5'        : marks[i];

                dMarks[i] = char.GetNumericValue(marks[i]);
            }

            allMarks = dMarks;

            mathematicsMark = marks[0];
            physicsMark     = marks[1];
            informaticsMark = marks[2];

            scholarship = int.TryParse(data[8], out scholarship) && scholarship > 122  ? scholarship :
                                                                    scholarship > 2346 ? 2345        : 0;
        }
    }
}
