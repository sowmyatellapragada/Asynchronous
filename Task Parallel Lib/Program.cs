using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Task t1 = Task.Factory.StartNew(() => { Process(1, 1000); });
            Task t2 = Task.Factory.StartNew(() => { Process(2, 2000); });
            Task t3 = Task.Factory.StartNew(() => { Process(3, 3000); });

            Task t4 = Task.Factory.StartNew(() => { return GetStudents(); })
                .ContinueWith(t =>
                {
                    t.Result.CalculateTotalFeeToCollege();
                    Console.WriteLine("{0}'s Total Allowance is {1}", t.Result.StudentName, t.Result.TotalAllowance);
                });


            List<Task> taskList = new List<Task> { t1, t2, t3, t4 };

            Task.WaitAll(taskList.ToArray());

            Console.WriteLine("Going to start Parallel.ForEach");

            List<Students> StudentList = GetStudentList();
            ParallelOptions po = new ParallelOptions();
            po.MaxDegreeOfParallelism = Environment.ProcessorCount;

            Parallel.ForEach(StudentList, po, (Students) =>
            {
                Console.WriteLine("started calculating Allowance for {0}", Students.StudentName);
                Students.CalculateTotalFeeToCollege();
                Console.WriteLine("calculated Allowance for {0} is {1}", Students.StudentName, Students.TotalAllowance);
                Console.WriteLine("Students {0} processed by Task - {1}", Students.StudentName, Task.CurrentId);
            });

            Console.WriteLine("press any key to quit");
            Console.ReadLine();
        }

        static void Process(int taskId, int delayTime)
        {
            Console.WriteLine("Task {0} started !!!!", taskId);
            Thread.Sleep(delayTime);
            Console.WriteLine("Task {0} completed...", taskId);
        }

        static Students GetStudents()
        {
            Students s1 = new Students
            {
                Id = 4,
                StudentName = "Sowmya",
                Allowance = 5000,
                StudentFee = 10000
            };

            return s1;
        }

        static List<Students> GetStudentList()
        {
            List<Students> StudentList = new List<Students>();

            Students stu1 = new Students
            {
                Id = 1,
                StudentName = "Pranav",
                StudentFee = 10000,
                Allowance = 5000
            };
            StudentList.Add(stu1);

            Students stu2 = new Students
            {
                Id = 2,
                StudentName = "Dhanvee",
                StudentFee = 5000,
                Allowance = 2580
            };
            StudentList.Add(stu2);

            Students stu3 = new Students
            {
                Id = 3,
                StudentName = "Sriram",
                StudentFee = 3200,
                Allowance = 1200
            };
            StudentList.Add(stu3);

            return StudentList;
        }
    }
}
