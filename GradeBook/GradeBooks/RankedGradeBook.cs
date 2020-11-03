using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name,isWeighted)
        {
            Type = GradeBookType.Ranked;
        }
        /*Provide the appropriate grades based on how the input grade compares to other students. (One way to solve this is to figure out how many students make up 20%, then loop through all the grades and check how many scored higher than the input average, every N students where N is that 20% value drop a letter grade.)
        If there are less than 5 students throw an InvalidOperationException.
        Return A if the input grade is in the top 20% of the class.
        Return B if the input grade is between the top 20 and 40% of the class.
    Return C if the input grade is between the top 40 and 60% of the class.
    Return D if the input grade is between the top 60 and 80% of the class.
        Return F if the grade is below the top 80% of the class.*/

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("too small amount of students.");
            }

            var hejahej = (int)Math.Ceiling(Students.Count * 0.2);
            var grades = Students.OrderByDescending(a => a.AverageGrade).Select(a => a.AverageGrade).ToList();

            if (grades[hejahej - 1] <= averageGrade)
            {
                return 'A';
            }
            else if (grades[hejahej * 2 - 1] <= averageGrade)
            {
                return 'B';
            }
            else if (grades[hejahej * 3 - 1] <= averageGrade)
            {
                return 'C';
            }
            else if (grades[hejahej * 4 - 1] <= averageGrade)
            {
                return 'D';
            }
            else
            {
                return 'F';
            }
        }

        /*
         * Short circuit the method if there are less than 5 students.
        If there are less than 5 students write "Ranked grading requires at least 5 students." to the Console.
          If there are 5 or more students call the base class's CalculateStatistics method using base.CalculateStatistics.
        */
        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }
            base.CalculateStatistics();
        }
        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }
    }
}

