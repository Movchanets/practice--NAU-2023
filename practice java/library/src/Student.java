public class Student implements Comparable<Student> {
    private Names name;
    private int course;
    private char gender;
    public Student() {

    }
    public Student(Names name, int course, char gender) {
        this.name = name;
        this.course = course;
        this.gender = gender;
    }
    public Names getName() {
        return name;
    }
    public void setName(Names name) {
        this.name = name;
    }
    public int getCourse() {
        return course;
    }
    public void setCourse(int course) {
        this.course = course;
    }
    public char getGender() {
        return gender;
    }
    public void setGender(char gender) {
        this.gender = gender;
    }
    @Override
    public String toString() {
        return name + " , " + course + " course  , " + gender;
    }
    @Override
    public int compareTo(Student other) {
        if (other == null) {
            throw new IllegalArgumentException("Student cannot be null");
        }

        return Integer.compare(course, other.getCourse());
    }
}
