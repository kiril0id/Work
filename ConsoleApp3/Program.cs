using System;
using Drink;
using System.Collections.Generic;
using System.IO;

namespace WordAndDrink
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Student> students = new List<Student>();
                var path = @"..\input.txt";
                var writePath = @"..\output.txt";
            int school = 2;

            using (StreamReader sr = new StreamReader(path))
            {
                string str;
                while ((str = sr.ReadLine()) != null)
                {
                    Student temp = new Student(str);
                    students.Add(temp);

                }
            }
                
                

                
                
              foreach (var student in students)
              {
                Console.WriteLine(student);
              }
                                 
                  
          
              // students.Sort();//с помощью реализации структурой интерфейса IComparable
            
               students.Sort(new StudentComparer());//помощью класса Comparer, унаследованного от интерфейса IComparer<T>
            
                using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                {
                foreach (var student in students)
                {
                    if (student.SchoolNumber == school )
                    {
                        sw.WriteLine(student);
                    }
                   

                }
            }
            
         
            Console.ReadKey();
            }
        }
    }

