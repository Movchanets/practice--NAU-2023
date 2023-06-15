using System;

namespace ClassLibrary
{
    public enum Names
    {
        Max,
        Slavik,
        Dima,
        Sasha,
        Vova,
        Vitya,
        Kolya,
        Petya,
        Vasya,
        Misha,
        Yura,
        Roma,
        Oleg,
        Andrey,
        Kirill,
        Denis,
        Nikita,
        Vlad,
        Kamila,
        Dasha,
        Masha,
        Yulya,
        Sveta,
        Nastya,
        Katya,
    }
    public class Student : IComparable<Student>
    {
        public Names Name { get; set; }
        public int Height { get; set; }
        public double Weight { get; set; }

        public Student()
        {
        
        }
        public Student(Names name, int height, double weight)
        {
            Name = name;
            Height = height;
            Weight = weight;
        }

        public override string ToString()
        {
            return $"{Name} , {Height} cm ,{Weight} kg";
        }

        public int CompareTo(Student other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("other", "Student cannot be null");
            }

            // Compare students based on their height
            return Height.CompareTo(other.Height);
        }
    }

}