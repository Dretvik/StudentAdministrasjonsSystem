using System;
using System.Diagnostics;

namespace StudentAdministrationsSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Students
            List<Student> students = new List<Student>
            {
                new Student("Ellie Marie", 30, "Get Academy", 100),
                new Student("Espen", 30, "Get Academy", 200),
                new Student("Blazej", 28, "Get Academy", 300),
                new Student("Mathias", 18, "Get Academy", 400),
                new Student("Said", 34, "Get Academy", 500)
            };

            // Subjects
            Subject programming = new Subject("C101", "Programming", 15);
            Subject math = new Subject("M202", "Math", 10);
            Subject english = new Subject("E201", "English", 10);

            while (true)
            {
                Console.Clear();

                Console.WriteLine($"Hello and welcome to Student Administration System");
                Console.WriteLine($"Please choose an option:");
                Console.WriteLine($"1. Show class list \n2. Search for a student by ID  \n3. Add a new student\n\n0. Exit Program");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ClassListChoises(students);
                        break;
                    case "2":
                        SearchStudentByID(students);
                        break;
                    case "3":
                        AddNewStudent(students);
                        break;
                    case "0":
                        Console.WriteLine("Exiting the program.");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }


            static void ClassListChoises(List<Student> students)
            {
                while (true)
                {
                    Console.Clear();

                    Console.WriteLine($"Hello and welcome to Student Administration System");
                    Console.WriteLine($"Please choose a student or option:");
                    for (int i = 0; i < students.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {students[i].Name}");
                    }
                    Console.WriteLine($"\n{students.Count + 1}. Add a new student");
                    Console.WriteLine($"0.Go back");

                    string choice = Console.ReadLine();

                    if (int.TryParse(choice, out int selectedOption) && selectedOption >= 1 && selectedOption <= students.Count)
                    {
                        PerformStudentActions(students[selectedOption - 1]);
                    }
                    else if (selectedOption == students.Count + 1)
                    {
                        AddNewStudent(students);
                    }
                    else if (selectedOption == 0)
                    {
                        Console.WriteLine("Go back..");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Please try again.");
                    }
                }
            }

            static void AddNewStudent(List<Student> students)
            {
                Console.Clear();
                Console.WriteLine("Adding a new student:");

                Console.Write("Enter the name of the student: ");
                string name = Console.ReadLine();

                Console.Write("Enter the age of the student: ");
                if (int.TryParse(Console.ReadLine(), out int age))
                {
                    Console.Write("Enter the school of the student: ");
                    string school = Console.ReadLine();

                    Console.Write("Enter the student ID: ");
                    if (int.TryParse(Console.ReadLine(), out int studentID))
                    {
                        students.Add(new Student(name, age, school, studentID));
                        Console.WriteLine($"\nStudent {name} added successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid integer for Student ID.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer for Age.");
                }
                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }

            static void SearchStudentByID(List<Student> students)
            {
                Console.Clear();
                Console.WriteLine("Search for a student by ID:");

                Console.Write("Enter the Student ID: ");
                if (int.TryParse(Console.ReadLine(), out int studentID))
                {
                    Student foundStudent = FindStudentByID(students, studentID);
                    if (foundStudent != null)
                    {
                        Console.WriteLine($"\nStudent found:");
                        PerformStudentActions(foundStudent);
                    }
                    else
                    {
                        Console.WriteLine($"No student found with ID: {studentID}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer for Student ID.");
                }

                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }

            static Student FindStudentByID(List<Student> students, int studentID)
            {
                foreach (Student student in students)
                {
                    if (student.StudentID == studentID)
                    {
                        return student; 
                    }
                }
                return null;
            }

            return;

                static void PerformStudentActions(Student student)
                {
                    while (true)
                    {
                        Console.Clear();

                        Console.WriteLine($"\nChoose what you want to do with {student.Name}:");
                        Console.WriteLine(
                            $"\n1. View student info \n2. Add subjects \n3. Add Subject Grade \n\n0. Go back");

                        string choice = Console.ReadLine();
                        switch (choice)
                        {
                            case "1":
                                Console.Clear();
                                student.PrintOutInfo();
                                break;
                            case "2":
                                AddSubjects(student);
                                break;
                            case "3":
                                AddSubjectsGrade(student);
                                break;
                            case "0":
                                Console.Clear();
                                return;
                        }
                    }
                }

                static void AddSubjects(Student student)
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine($"\nAdd Subject to {student.Name}:");
                        Console.WriteLine($"1. Add Math \n2. Add Programming \n3. Add English");
                        Console.WriteLine("\n0.Go back to other student actions");

                        string choice = Console.ReadLine();

                        switch (choice)
                        {
                            case "1":
                                AddSubjectToStudent(student, "M202", "Math", 10);
                                break;
                            case "2":
                                AddSubjectToStudent(student, "C101", "Programming", 15);
                                break;
                            case "3":
                                AddSubjectToStudent(student, "E201", "English", 10);
                                break;
                        case "0":
                                Console.Clear();
                                return;
                            default:
                                Console.WriteLine("Invalid choice. Please try again.");
                                break;
                        }
                    }
                }

                static void AddSubjectToStudent(Student student, string subjectCode, string subjectName,
                    int subjectCredits)
                {
                    // Checking if the student already has the subject
                    if (student.Subjects.Any(subject => subject.SubjectCode == subjectCode))
                    {
                        Console.WriteLine($"{student.Name} already has {subjectName} in their subjects.");
                        return;
                    }

                    Subject newSubject = new Subject(subjectCode, subjectName, subjectCredits);
                    student.AddSubject(newSubject);

                    Console.WriteLine($"{subjectName} is added to {student.Name}'s subjects");
                    Console.WriteLine("\nPress Enter to continue...");
                    Console.ReadLine();
            }

                static void AddSubjectsGrade(Student student)
                {
                    Console.Clear();
                    Console.WriteLine($"Add Grades to {student.Name}'s Subjects:");

                    if (student.Subjects.Count == 0)
                    {
                        Console.WriteLine(
                            $"{student.Name} has no subjects to add grades to. Please add subjects first.");
                        return;
                    }

                    Console.WriteLine("List of Subjects:");
                    for (int i = 0; i < student.Subjects.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {student.Subjects[i].SubjectName}");
                    }

                    Console.WriteLine("\nChoose a subject to add a grade (enter the corresponding number):");
                    string subjectChoise = Console.ReadLine();

                    if (int.TryParse(subjectChoise, out int subjectIndex) && subjectIndex >= 1 &&
                        subjectIndex <= student.Subjects.Count)
                    {
                        Subject selectedSubject = student.Subjects[subjectIndex - 1];

                        Console.WriteLine($"Enter the grade for {selectedSubject.SubjectName} (1-100):");
                        int grade = int.Parse(Console.ReadLine());

                        Grade newGrade = new Grade(student, selectedSubject, grade);
                        student.AddGrade(newGrade);

                        Console.WriteLine($"Grade {grade} added for {selectedSubject.SubjectName}.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Please enter a valid number.");
                    }

                    Console.WriteLine("\nPress Enter to continue...");
                    Console.ReadLine();
                }
        }
    }
}