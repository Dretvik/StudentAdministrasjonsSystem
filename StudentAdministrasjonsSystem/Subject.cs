using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAdministrationsSystem
{
    public class Subject
    {
        public string SubjectCode { get; set; }
        public string SubjectName { get; set; }
        public int Credits { get; set; }


        public Subject(string subjectCode, string subjectName, int credits)
        {
            SubjectCode = subjectCode;
            SubjectName = subjectName;
            Credits = credits;
        }

        public void PrintOutInfo()
        {
            Console.WriteLine($"\nSubject Code: {SubjectCode}");
            Console.WriteLine($"Subject Name: {SubjectName}");
            Console.WriteLine($"Credits: {Credits}");
        }
    }
}
