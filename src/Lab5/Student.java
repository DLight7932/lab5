package Lab5;

import static java.lang.Integer.parseInt;

public class Student {
    String surName;
    String firstName;
    String patronymic;
    char sex;
    String dateOfBirth;
    char mathematicsMark;
    char physicsMark;
    char informaticsMark;
    int scholarship;

    public Student(String lineWithAllData) {
        String[] data = lineWithAllData.split(" +");

        surName = data[0];
        firstName = data[1];
        patronymic = data[2];

        sex = data[3].charAt(0);

        dateOfBirth = data[4];

        char[] marks = {data[5].charAt(0), data[6].charAt(0), data[7].charAt(0)};

        for (int i = 0; i < marks.length; i++) {
            if (!Character.isDigit(marks[i]) || marks[i] == '-') marks[i] = '2';
        }

        mathematicsMark = marks[0];
        physicsMark     = marks[1];
        informaticsMark = marks[2];

        try { scholarship = parseInt(data[8]);
        } catch (NumberFormatException e) { scholarship = 0; }
    }
}
