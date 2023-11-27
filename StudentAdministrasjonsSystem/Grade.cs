
namespace StudentAdministrationsSystem
{
    public class Grade
    {
        public Student Student { get; set; }
        public Subject Subject { get; set; }
        public int GradeValue { get; set; }

        public Grade(Student student, Subject subject, int gradeValue)
        {
            Student = student;
            Subject = subject;
            GradeValue = gradeValue;
        }

        public void PrintOutInfo()
        {
            Console.WriteLine($"\nGrade Information: \nStudent: {Student.Name}\nSubject: {Subject.SubjectName}\nGrade: {GradeValue}\n");
        }
    }
}
