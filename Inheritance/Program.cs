using System;
using System.Collections.Generic;
using System.Linq;
Main main = new Main();
main.Test();
internal class Person
{
    public string Name { get; set; } = "NULL";
    public string Surname { get; set; } = "NULL";
    public int Age { get; set; } = 0;
    public string Phone { get; set; } = "NULL";

    public Person() { }
    public Person(string name, string surname, int age, string phone)
    {
        Name = name;
        Surname = surname;
        Age = age;
        Phone = phone;
    }

    public void Print() =>
        Console.WriteLine($"Name: {Name}\nSurname: {Surname}\nAge: {Age}\nPhone: {Phone}");
}

internal class Student : Person
{
    public double AvgGrade { get; set; } = 0.0;
    public int Group { get; set; } = 0;

    public Student() { }
    public Student(string name, string surname, int age, string phone, double avgGrade, int group)
        : base(name, surname, age, phone)
    {
        AvgGrade = avgGrade;
        Group = group;
    }

    public new void Print()
    {
        base.Print();
        Console.WriteLine($"Average grade: {AvgGrade}\nGroup: {Group}");
    }
}

internal class AcademyGroup
{
    private List<Student> group = new List<Student>();

    public void Add(Student student) =>
        group.Add(student);
    public void Remove(string surname) =>
        group.RemoveAll(student => student.Surname == surname);
    public void Edit(string surname)
    {
        Student student = group.FirstOrDefault(s => s.Surname == surname);
        if (student != null)
        {
            Console.WriteLine("Enter new info: ");
            Console.Write("Name: ");
            student.Name = Console.ReadLine();

            Console.Write("Surname: ");
            student.Surname = Console.ReadLine();

            Console.Write("Age: ");
            student.Age = int.Parse(Console.ReadLine());

            Console.Write("Phone: ");
            student.Phone = Console.ReadLine();

            Console.Write("Avg. Grade: ");
            student.AvgGrade = double.Parse(Console.ReadLine());

            Console.Write("Group: ");
            student.Group = int.Parse(Console.ReadLine());

            Console.WriteLine("Successfully updated info.");
        }
        else
        {
            Console.WriteLine("No student with such surname.");
        }
    }

    public void Print()
    {
        foreach (Student student in group)
        {
            student.Print();
            Console.WriteLine("-------------------");
        }
    }

    public void Save(string path) =>
        Console.WriteLine($"Info successfully uploaded to the {path}");

    public void Load(string path) =>
        Console.WriteLine($"Info successfully downloaded from the {path}");

    public void Search(object info)
    {
        foreach (Student student in group)
        {
            if (student.Name.Equals(info?.ToString(), StringComparison.OrdinalIgnoreCase) ||
                student.Surname.Equals(info?.ToString(), StringComparison.OrdinalIgnoreCase) ||
                student.Phone.Equals(info?.ToString(), StringComparison.OrdinalIgnoreCase))
                student.Print();
            if (info is int age)
                if (student.Age == age)
                    student.Print(); 
        }
    }
}


class Main
{
    public void Test()
    {
        AcademyGroup group = new AcademyGroup();

        group.Add(new Student("John", "Doe", 20, "123456789", 85.5, 1));
        group.Add(new Student("Jane", "Smith", 22, "987654321", 90.2, 2));

        Console.WriteLine("Список студентов:");
        group.Print();

        Console.WriteLine("Редактирование студента с фамилией Doe:");
        group.Edit("Doe");

        Console.WriteLine("\nСписок студентов после редактирования:");
        group.Print();

        Console.WriteLine("Удаление студента с фамилией Smith.");
        group.Remove("Smith");

        Console.WriteLine("\nСписок студентов после удаления:");
        group.Print();
    }
}