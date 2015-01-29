using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mauricio_991296005_ADN_W15_DLABS
{
    class Program
    {
        static void Main(string[] args)
        {
            TestReg();
            Console.ReadLine();
        }

        //a.	A method to add a new course registration with parameters for the student number and course code
        public static void addCourseRegistration(String studentNum, string courseCode)
        {
            Console.WriteLine("addCourseRegistration() invoked.");
            using (var db = new Winter2015Lab1DBEntities())
            {
                Student stu = (from s in db.Students
                               where s.StudentNum == studentNum
                               select s).First();
                Course cou = (from c in db.Courses
                              where c.courseCode == courseCode
                              select c).First();

                cou.Students.Add(stu);
                db.SaveChanges();
            }
        }
        //b.	A method to drop a course registration with parameters for the student number and course code
        public static void dropCourseRegistration(string studentNum, string courseCode)
        {
            Console.WriteLine("dropCourseRegistration() invoked.");
            using(var db = new Winter2015Lab1DBEntities())
            {
                Student stu = (from s in db.Students
                               where s.StudentNum == studentNum
                               select s).First();

                Course cou = (from c in db.Courses
                              where c.courseCode == courseCode
                              select c).First();

                cou.Students.Remove(stu);
                db.SaveChanges();
            }
        }
        //c.	A method to display all course registrations for all students to the console.  This method should display course names, course codes and student names
        public static void displayCourseRegistration()
        {
            Console.WriteLine("displayCourseRegistration() invoked.");
            using (var db = new Winter2015Lab1DBEntities())
            {
                var q = from c in db.Courses
                        select c;

                foreach (Course course in q)
                {
                    Console.WriteLine("{0} - {1}", course.courseCode, course.courseName);
                }
            }
        }
        //d.	A method to display all course registrations for one student to the console based on a student number parameter.  This method should display course names, course codes and student names
        public static void allCoursesOneStudent(String studentNum)
        {
            Console.WriteLine("allCoursesOneStudent(String studentNum) invoked.");
            using (var db = new Winter2015Lab1DBEntities())
            {
                Student stu = (from s in db.Students
                               where s.StudentNum == studentNum
                               select s).First();
                Console.WriteLine("{0} - {1} {2}", stu.StudentNum, stu.firstName, stu.lastName);

                foreach (Course course in stu.Courses)
                {
                    Console.WriteLine("\t\t{0} - {1}", course.courseCode, course.courseName);
                }
            }
        }
        //e.	A method to display all students who are registered for a particular course on the console based on a course parameter.  This method should display course names, course codes and student names
        public static void allStudentsOneCourse(String courseCode)
        {
            Console.WriteLine("allStudentsOneCourse(String courseCode) invoked.");
            using (var db = new Winter2015Lab1DBEntities())
            {
                Course cou = (from c in db.Courses
                             where c.courseCode == courseCode
                             select c).First();
                Console.WriteLine("{0} - {1}", cou.courseCode, cou.courseName);

                foreach (Student student in cou.Students)
                {
                    Console.WriteLine("\t\t{0} {1}", student.firstName, student.lastName);
                }
            }
        }
        //f.	A method to remove all course registrations for all students in the database
        public static void removeCourseRegistrations()
        {
            Console.WriteLine("removeCourseRegistration() invoked.");
            using (var db = new Winter2015Lab1DBEntities())
            {
                var q = from c in db.Courses
                        select c;
                foreach (Course course in q)
                {
                    course.Students.Clear();
                }
            }
        }
        //g.	A Test Method which calls the other methods with hard coded values (you can define constants to make this code cleaner) to:
        public static void TestReg()
        {            
            //i.	Clear all existing course registrations (ie. start of semester)
            removeCourseRegistrations();
            //ii.	Add a few course registrations for different students
            addCourseRegistration("1234", "aaa1");
            addCourseRegistration("2345", "bbb1");
            //iii.	List all course registrations
            displayCourseRegistration();
            //iv.	List all courses that a particular student registered for
            allCoursesOneStudent("1234");
            //v.	List all students that are registered for a particular course
            allStudentsOneCourse("aaa1");
            //vi.	Drop one or more student course registrations
            dropCourseRegistration("1234", "aaa1");
            //vii.	Repeat steps iii to v above
        }
       



    }
}
