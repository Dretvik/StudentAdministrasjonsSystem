using System;

namespace StudentAdministrationsSystem
{
    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string StudyProgram { get; set; }
        public int StudentID { get; set; }
        public List<Subject> Subjects { get; set; }
        public List<Grade> Grades { get; set; }


        public Student(string name, int age, string studyProgram, int studentId)
        {
            Name = name;
            Age = age;
            StudyProgram = studyProgram;
            StudentID = studentId;
            Subjects = new List<Subject>();
            Grades = new List<Grade>();
        }

        public void AddSubject(Subject subject)
        {
            Subjects.Add(subject);
        }

        public void AddGrade(Grade grade)
        {
            Grades.Add(grade);
        }

        public void PrintOutInfo()
        {
            Console.WriteLine($"\nName of student: {Name}");
            Console.WriteLine($"Student Age: {Age}");
            Console.WriteLine($"StudyProgram: {StudyProgram}");
            Console.WriteLine($"Student ID: {StudentID}");

            if (Subjects.Count != 0)
            {
                Console.WriteLine("\nSubjects enrolled:");
                foreach (var subject in Subjects)
                {
                    Console.WriteLine($"- {subject.SubjectName}");
                }
            }
            else
            {
                Console.WriteLine($"\n{Name} is not connected to any subjects yet.");
            }

            if (Grades.Count != 0)
            {
                Console.WriteLine("\nGrades:");
                foreach (var grade in Grades)
                {
                    Console.WriteLine($"- {grade.Subject.SubjectName}: {grade.GradeValue}");
                }

                double averageGrade = Grades.Select(grade => grade.GradeValue).Average();
                Console.WriteLine($"\nAverage Grade: {averageGrade:F2}");
            }
            else
            {
                Console.WriteLine($"\n{Name} has no recorded grades yet.");
            }
            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }
    }
}