using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6Objects
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create an object of type student
            Student s1 = new Student();
            s1.FirstName = "John";
            s1.LastName = "Doe";
            s1.Id = "12345";
            s1.Enroll("Computing");
            //s1.Put();

            //Create an object of type student
            Student s2 = new Student();
            s2.FirstName = "Jane";
            s2.LastName = "Doe";
            s2.Id = "23456";
            s2.Enroll("Chemistry");
            //s2.Put();

            //s2.enroll("Engineering");
            s2.Course = "Engineering";
            //s2.Put();

            //Create an object using a constructor
            Student s3 = new Student("Charlie", "Brown", "345678");
            s3.Enroll("Computing");
            //s3.Put();

            //Create student object using empty constructor.
            Student s4 = new Student();
            s4.FirstName = "John";
            s4.LastName = "Smith";
            s4.Id = "987654";

            //Create student object using constructor with args.
            Student s5 = new Student("Jack", "Jones", "876543");

            //Enroll John & Jack in Computing & Engineering respectively.
            s4.Enroll("Computing");
            s5.Enroll("Engineering");

            //Print both students' details.
            //s4.Put();
            //s5.Put();

            //Create array of 5 students
            Student[] ComputingStudents = new Student[5];
            ComputingStudents[0] = new Student("Fred", "Flinstone", "123456");
            ComputingStudents[1] = new Student("Barnie", "Rubble", "234567");
            ComputingStudents[2] = new Student("Wilma", "Flinstone", "345678");
            ComputingStudents[3] = new Student("Betty", "Rubble", "456789");
            ComputingStudents[4] = new Student("Pebbles", "Flinstone", "567890");

            //Enroll all students in ComputingStudents array in computing.
            foreach (var students in ComputingStudents)
            {
                students.Enroll("Computing");
                //students.Put();
            }

            //Change course from computing to other course.
            ComputingStudents[0].Enroll("Computing");
            ComputingStudents[1].Enroll("Engineering");
            ComputingStudents[2].Enroll("Chemistry");
            ComputingStudents[3].Enroll("Maths");
            ComputingStudents[4].Enroll("Physics");

            //Print students details
            foreach (var students in ComputingStudents)
            {
                students.Put();
            }
    
            //Console.WriteLine("There are {0} students in the cohort", Student.CohortSize);
            Console.WriteLine("There are {0} students in the cohort.", ComputingStudents.Length);
            Console.ReadLine();

        }
    }

    class Student
    { 
        //Properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Id { get; set; }
        public static int CohortSize
        {
            get
            {
                return cohortSize;
            }
        }
        public bool isEnrolled //read only propety
        {
            get
            {
                return enrolled;
            }
        }
        public string Course
        {
            get
            {
                return course;
            }

            set //we can do validation here eg check the course name is valid
            {
                if (value.Equals("Computing") || value.Equals("Engineering") || value.Equals("Chemistry") ||
                    value.Equals("Maths") || value.Equals("Physics"))
                {
                    course = value;
                }

                else
                {
                    course = "Invalid Option";
                }
            }
        }

        //private members
        private bool enrolled = false;
        private string course;
        private static int cohortSize = 0;

        //Class consructors
        public Student() { cohortSize++; }
        public Student(string firstName, string lastName, string id)
        {
            FirstName = firstName;
            LastName = lastName;
            Id = id;
            cohortSize++;
        }

        //methods
        public void Enroll(string course)
        {
            enrolled = true;
            Course = course; //Use the public property set method to validate the input
        }

        public void Put() //Output student details to console.
        {
            Console.WriteLine("Student Details: {0}\t{1}\t{2}\t{3}\tEnrollment status:\t {4}", FirstName, LastName, Id, Course, isEnrolled);
            return;
        }
    }
}
