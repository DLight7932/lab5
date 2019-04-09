package Lab5;

import java.util.ArrayList;
import java.util.List;

class Var12 {
    static void showStudWithSmallScholarship(Student[] data) {
        double average = getAverage(data);
        double bound = (average * 20) / 100;

        List<Pair<String, Integer>> studInfo = setStudentsWithMoney(data);

        System.out.println("\nStudents that have 20% less money from scholarship average:");
        for (Pair<String, Integer> stringIntegerPair : studInfo) {
            if (average - bound > stringIntegerPair.item2) {
                System.out.println(stringIntegerPair.item1);
            }
        }
    }
    private static List<Pair<String, Integer>> setStudentsWithMoney(Student[] stud){

        List<Pair<String, Integer>> studInfo = new ArrayList<>();
        String fullName;
        int indx = 0;

        for (Student student : stud) {
            if (student.scholarship > 123 & student.scholarship < 2345) {
                fullName = student.surName + " " + student.firstName + " " + student.patronymic;
                studInfo.add(indx,new Pair<>(fullName, student.scholarship));
                indx++;
            }
        }
        return studInfo;
    }

    private static double getAverage(Student[] data) {

        double average = 0.0;

        int count = 0;
        for (Student s : data) {
            if (s.scholarship > 123 & s.scholarship < 2345) {
                average += s.scholarship;
                ++count;
            }
        }

        if (count > 0) return average / count;
        else return 1;
    }
}
