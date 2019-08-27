using System;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            this.Type = Enums.GradeBookType.Ranked;
        }

        public override void CalculateStatistics()
        {
            if (this.Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");                
            }
            else
            {
                base.CalculateStatistics();
            }
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (this.Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if(this.Students.Count < 5)
            {
                Console.WriteLine("Your grading book requires at least 5 students");
                throw new InvalidOperationException();
            }

            // Calculate your threshold, the number of students equating to 20% of the total
            var threshold = (int)Math.Ceiling(Students.Count * .2);

            // Get all the average grades in descending order
            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            if(grades[threshold-1] <= averageGrade)
            {
                return 'A';
            }
            else if (grades[threshold * 2 - 1] <= averageGrade)
            {
                return 'B';
            }
            else if (grades[threshold * 3 - 1] <= averageGrade)
            {
                return 'C';
            }
            else if (grades[threshold * 4 - 1] <= averageGrade)
            {
                return 'D';
            }
            else
            {
                return 'F';
            }
 
        }
    }
}
