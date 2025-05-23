// Create a Course class with properties for CourseId, Title, Credits, and Instructor
// Include a list of enrolled students
// Add methods to enroll and unenroll students
// Add a method to calculate the average GPA of enrolled students

using System;
using System.Collections.Generic;
using System.Linq;

public class Course
{
    public string CourseId { get; set; }
    public string Title { get; set; }
    public int Credits { get; set; }
    public string Instructor { get; set; }
    public List<Student> EnrolledStudents { get; private set; }

    public Course()
    {
        EnrolledStudents = new List<Student>();
    }

    public Course(string courseId, string title, int credits, string instructor)
    {
        CourseId = courseId;
        Title = title;
        Credits = credits;
        Instructor = instructor;
        EnrolledStudents = new List<Student>();
    }

    public void EnrollStudent(Student student)
    {
        if (!EnrolledStudents.Contains(student))
        {
            EnrolledStudents.Add(student);
            Console.WriteLine($"Enrolled {student.GetFullName()} in {Title}");
        }
        else
        {
            Console.WriteLine($"{student.GetFullName()} is already enrolled in {Title}");
        }
    }

    public void UnenrollStudent(Student student)
    {
        if (EnrolledStudents.Contains(student))
        {
            EnrolledStudents.Remove(student);
            Console.WriteLine($"Unenrolled {student.GetFullName()} from {Title}");
        }
        else
        {
            Console.WriteLine($"{student.GetFullName()} is not enrolled in {Title}");
        }
    }

    public double CalculateAverageGPA()
    {
        if (EnrolledStudents.Count == 0)
            return 0;

        return EnrolledStudents.Average(s => s.GradePointAverage);
    }

    public override string ToString()
    {
        return $"Course: {CourseId} - {Title}, Credits: {Credits}, Instructor: {Instructor}, " +
               $"Enrolled Students: {EnrolledStudents.Count}, Average GPA: {CalculateAverageGPA():F2}";
    }
}