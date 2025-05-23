// Create a Student class that inherits from Person
// Add properties for StudentId and GradePointAverage
// Override the ToString method to include all properties
// Add a method to determine if the student is in good standing (GPA >= 2.0)

using System;

public class Student : Person
{
    public string StudentId { get; set; }
    public double GradePointAverage { get; set; }

    public Student()
        : base()
    {
        // Default constructor
    }

    public Student(string firstName, string lastName, int age, string email, string studentId, double gradePointAverage)
        : base(firstName, lastName, age, email)
    {
        StudentId = studentId;
        GradePointAverage = gradePointAverage;
    }

    public bool IsInGoodStanding()
    {
        return GradePointAverage >= 2.0;
    }

    public override string ToString()
    {
        return $"Student: {GetFullName()}, Age: {Age}, Email: {Email}, ID: {StudentId}, GPA: {GradePointAverage:F2}, Standing: {(IsInGoodStanding() ? "Good" : "Probation")}";
    }
}