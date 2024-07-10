using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Person
{
    public string Name { get; set; }
    public string Id { get; set; }
}

public interface Kpi
{
    float kpi();
}

public class Student : Person, Kpi
{
    private string _department;

    public string Department
    {
        get { return _department; }
        set
        {
            if (value == "ICT" || value == "ECO")
                _department = value;
            else
                throw new ArgumentException("Department must be either 'ICT' or 'ECO'");
        }
    }

    public float GPA { get; set; }

    public Student(string name, string id, string department, float gpa)
    {
        Name = name;
        if (id.Length == 8 && id.All(char.IsDigit))
            Id = id;
        else
            throw new ArgumentException("Id must be 8 digits");
        Department = department;
        GPA = gpa;
    }

    public float kpi()
    {
        return GPA;
    }
}

class Program
{
    static void Main()
    {
        Person obs = null;

        obs = new Student("Nguyễn Tiến Dũng", "12345678", "ICT", 3.5f);
        Console.WriteLine("KPI: " + ((Student)obs).kpi());

        try
        {
            obs = new Student("Nguyễn Tiến Dũng", "12345", "IT", 3.5f);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }

        List<Person> list1 = new List<Person>();
        List<Person> list2 = new List<Person>();

        void EnterStudents(List<Person> list, string tableName)
        {
            while (true)
            {
                Console.WriteLine($"Enter student for {tableName} (enter # to stop):");
                Console.Write("Name: ");
                string name = Console.ReadLine();
                if (name == "#") break;

                Console.Write("Id: ");
                string id = Console.ReadLine();

                Console.Write("Department: ");
                string department = Console.ReadLine();

                Console.Write("GPA: ");
                float gpa = float.Parse(Console.ReadLine());

                try
                {
                    list.Add(new Student(name, id, department, gpa));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        EnterStudents(list1, "bàn 1 lớp 23IT5 ngày 25/06/2024");
        EnterStudents(list2, "bàn 2 lớp 23IT6 ngày 25/06/2024");

        void DisplayList(List<Person> list, string listName)
        {
            Console.WriteLine($"--- {listName} ---");
            foreach (Student student in list)
            {
                Console.WriteLine($"Name: {student.Name}, Id: {student.Id}, Department: {student.Department}, GPA: {student.GPA}");
            }
        }

        DisplayList(list1, "List1");
        DisplayList(list2, "List2");

        List<List<Person>> list_list = new List<List<Person>> { list1, list2 };

        void DisplayListList(List<List<Person>> listList)
        {
            for (int i = 0; i < listList.Count; i++)
            {
                DisplayList(listList[i], $"List {i + 1}");
            }
        }

        DisplayListList(list_list);

        Dictionary<string, Student> dict1 = list1
            .OfType<Student>()
            .ToDictionary(student => student.Id);

        var studentsNamedNam = dict1.Values
            .Where(student => student.Name.Contains("Nam"))
            .ToList();

        foreach (var student in studentsNamedNam)
        {
            Console.WriteLine($"Found student named Nam: {student.Name}, Id: {student.Id}, Department: {student.Department}, GPA: {student.GPA}");
        }
    }
}
