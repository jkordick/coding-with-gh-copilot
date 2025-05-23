// Create a Program class with a Main method
// Create several Person objects
// Create several Student objects
// Create a Course object and enroll some students
// Display information about all objects

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Creating Person objects:");
        Console.WriteLine("------------------------");
        
        Person person1 = new Person("John", "Doe", 35, "john.doe@example.com");
        Person person2 = new Person("Jane", "Smith", 28, "jane.smith@example.com");
        
        Console.WriteLine(person1);
        Console.WriteLine(person2);
        
        Console.WriteLine("\nCreating Student objects:");
        Console.WriteLine("--------------------------");
        
        Student student1 = new Student("Alice", "Johnson", 20, "alice.j@university.edu", "S12345", 3.8);
        Student student2 = new Student("Bob", "Williams", 22, "bob.w@university.edu", "S12346", 2.9);
        Student student3 = new Student("Charlie", "Brown", 19, "charlie.b@university.edu", "S12347", 1.9);
        
        Console.WriteLine(student1);
        Console.WriteLine(student2);
        Console.WriteLine(student3);
        
        Console.WriteLine("\nCreating Course and enrolling students:");
        Console.WriteLine("---------------------------------------");
        
        Course course = new Course("CS101", "Introduction to Programming", 3, "Dr. Smith");
        
        course.EnrollStudent(student1);
        course.EnrollStudent(student2);
        course.EnrollStudent(student3);
        
        Console.WriteLine("\nCourse Information:");
        Console.WriteLine(course);
        
        Console.WriteLine("\nUnenrolling a student:");
        course.UnenrollStudent(student3);
        
        Console.WriteLine("\nUpdated Course Information:");
        Console.WriteLine(course);
        
        Console.WriteLine("\nTrying to enroll a student again:");
        course.EnrollStudent(student1);
        
        Console.WriteLine("\nTrying to unenroll a student who is not enrolled:");
        Person person3 = new Person("Invalid", "Student", 25, "invalid@example.com");
        Student student4 = new Student("Invalid", "Student", 25, "invalid@example.com", "S99999", 0.0);
        course.UnenrollStudent(student4);
    }
}