package Lab5;

import java.io.*;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        try {
            Student[] studs = ReadData("input.txt");
            runMenu(studs);
        } catch (IOException e) {System.out.println(e);}
    }

    private static Student[] ReadData(String fileName) throws IOException {

        File f = new File("src/Lab5/input.txt");

        BufferedReader bf = new BufferedReader(new FileReader(f));
        List<String> lines = new ArrayList<>();

        String line;

        while((line = bf.readLine()) != null) {
            lines.add(line);
        }
        bf.close();

        String[] text = lines.toArray(new String[]{});
        int linesLen = lines.size();

        Student[] students = new Student[linesLen];
        for (int i = 0; linesLen > 0; linesLen--, i++) {
            students[i] = new Student(text[i]);
        }
        return students;
    }

    private static void runMenu(Student[] studs)
    {
        while (true) {
            System.out.println("To execute first  option (made by Artur Stecenko)       Press 1");
            System.out.println("To execute second option (made by Yevhenii Ponomarenko) Press 2");
            System.out.println("\nPress 0 To Exit\n");

            try {
                int input = new Scanner(System.in).nextInt();

                if (input == 0) break;
                else if (input == 1) Var12.showStudWithSmallScholarship(studs);
                else if (input == 2) Var17.yourMethodYevhenii(studs);
                else System.out.println("Invalid number");

            } catch (java.util.InputMismatchException e) {
                System.out.println("Invalid input. Try again!");
            }
        }
    }
}
