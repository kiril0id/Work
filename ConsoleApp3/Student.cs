using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drink
{
    class StudentComparer : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            if (x.DateOfBirth > y.DateOfBirth)
                return 1;
            else if (x.DateOfBirth < y.DateOfBirth)
                return -1;
            else
                return 0;
        }
    }

 

    class Student :IComparable
    {

        public DateTime DateOfBirth { get; }
        public string Name { get; }
        public string Addres{get; }
        public int SchoolNumber { get; }
        
        
        public Student(string str)
        {
            str.Trim();
            string[] words = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Name = words[0];
            DateOfBirth = Convert.ToDateTime(words[1]);
            Addres = words[2];
            SchoolNumber = Convert.ToInt32(words[3]);
            



        }
     

        public override string ToString()
        {
            return Name+" " + DateOfBirth.ToString("dd.MM.yyyy") + " " + Addres +" "+ SchoolNumber;
        }

        public int CompareTo(object obj)
        {
            Student student = obj as Student;
            if (student != null)
                return DateOfBirth.CompareTo(student.DateOfBirth);
            else
                throw new Exception("Невозможно сравнить два объекта");
        }
    }
}
