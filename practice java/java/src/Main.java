import java.util.List;
import java.util.Scanner;

public class Main {
    private static DoublyLinkedList studentList = new DoublyLinkedList();
    private static Scanner scanner = new Scanner(System.in);

    public static void main(String[] args) {
        boolean exit = false;

        while (!exit) {
            System.out.println("1. Додати студента");
            System.out.println("2. Видалити студента");
            System.out.println("3. Вивести список студентів");
            System.out.println("4. Знайти студентів жінок на 2 му курсі");
            System.out.println("5. Сортування");
            System.out.println("6. Вийти");
            System.out.println();

            System.out.print("Введіть номер опції: ");
            String choice = scanner.nextLine();
            System.out.println();

            switch (choice) {
                case "1":
                    addStudent();
                    break;
                case "2":
                    removeStudent();
                    break;
                case "3":
                    printStudentList();
                    break;
                case "4":
                    findFemaleStudents();
                    break;
                case "5":
                    studentList.sort();
                    printStudentList();
                    break;
                case "6":
                    exit = true;
                    break;
                default:
                    System.out.println("Невірний вибір. Спробуйте ще раз.");
                    break;
            }

            System.out.println();
        }
    }

    private static void addStudent() {
        System.out.println("Доступні імена студентів:");
        for (Names availableName : Names.values()) {
            System.out.println(availableName);
        }

        System.out.println();

        Names name = null;
        boolean validName = false;

        do {
            System.out.print("Ім'я студента: ");
            String input = scanner.nextLine();

            if (input.matches("[A-Za-z]+")) {
                try {
                    name = Names.valueOf(input);
                    validName = true;
                } catch (IllegalArgumentException e) {
                    validName = false;
                }
            }

            if (!validName) {
                System.out.println("Невірне ім'я студента. Будь ласка, введіть ім'я з доступних варіантів.");
            }
        } while (!validName);

        boolean validCourse = false;
        int course = 0;
        do {
            System.out.print("Курс студента: ");
            try {
                course = Integer.parseInt(scanner.nextLine());
                if (course > 0 && course < 5) {
                    validCourse = true;
                } else {
                    System.out.println("Невірний номер курсу студента. Будь ласка, введіть правильне число.");
                }
            } catch (NumberFormatException e) {
                System.out.println("Невірний ріст студента. Будь ласка, введіть правильне число.");
            }
        } while (!validCourse);

        boolean validGender = false;
        char gender = 0;
        do {
            System.out.print("Стать студента M/F: ");
            try {
                gender = Character.toUpperCase(scanner.nextLine().charAt(0));
                if (gender == 'F' || gender == 'M') {
                    validGender = true;
                } else {
                    System.out.println("Невірна стать студента. ");
                }
            } catch (Exception e) {
                System.out.println("Невірна стать студента. ");
            }
        } while (!validGender);

        Student student = new Student(name, course, gender);
        studentList.addToEnd(student);

        System.out.println("Студент доданий до списку.");
        printStudentList();
    }

    private static void removeStudent() {
        System.out.print("Введіть індекс студента, якого потрібно видалити: ");
        try {
            int index = Integer.parseInt(scanner.nextLine());

            if (index >= 0 && index < studentList.getLength()) {
                studentList.removeAt(index);
                System.out.println("Студент видалений зі списку.");
            } else {
                System.out.println("Невірний індекс студента.");
            }
        } catch (NumberFormatException e) {
            System.out.println("Невірний індекс студента.");
        }
        printStudentList();
    }

    private static void printStudentList() {
        System.out.println("Список студентів:");
        System.out.println("--------------------------------------");
        System.out.printf("%-10s%-10s%-10s%-10s%n", "Індекс", "Ім'я", "Курс", "Стать");
        System.out.println("--------------------------------------");

        for (int i = 0; i < studentList.getLength(); i++) {
            Student student = studentList.get(i);
            System.out.printf("%-10d%-10s%-10d%-10c%n", i, student.getName(), student.getCourse() , student.getGender());

        }

        System.out.println("--------------------------------------");
    }

    private static void findFemaleStudents() {
        List<Student> students = studentList.findFemaleStudentsSecondCourse();

        System.out.println("Студенти жінки 2го курсу:");
        System.out.println("----------------------------");
        System.out.printf("%-10s%-10s%-10s%n", "Ім'я", "Курс", "Стать");
        System.out.println("----------------------------");

        for (Student student : students) {
            System.out.printf("%-10s%-10d%-10c%n",  student.getName(), student.getCourse() , student.getGender());
        }

        System.out.println("----------------------------");
    }
}