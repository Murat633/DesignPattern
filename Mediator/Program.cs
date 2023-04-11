using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mediator mediator = new Mediator();
            Teacher murat = new Teacher(mediator){Name="Murat"};
            mediator.Teacher = murat;
            
            Student derin = new Student(mediator);
            derin.Name = "derin";
            

            Student salih = new Student(mediator);
            salih.Name = "salih";

            mediator.Students = new List<Student>()
            {
                derin,salih
            };

            murat.SendNewImageUrl("slide1.jpg");
            murat.RecieveQuestion("is it true", salih);

            Console.ReadLine();
        }
    }

    abstract class CourseMember
    {
        protected Mediator Mediator;

        protected CourseMember(Mediator mediator)
        {
            Mediator = mediator;
        }
    }

    class Teacher : CourseMember
    {
        public string Name { get; internal set; }

        public Teacher(Mediator mediator) : base(mediator)
        {
        }

        public void RecieveQuestion(string question, Student student)
        {
            Console.WriteLine($"Teacher Recieved a question from {student.Name},{question}");
        }

        public void SendNewImageUrl(string url)
        {
            Console.WriteLine("Teacher changed slide : {0}",url);
            Mediator.UpdateImage(url);
        }

        public void AnswerQuestion(string answer, Student student)
        {
            Console.WriteLine("Teacher answered question {0},{1}",student.Name,answer);
        }
    }

    class Student : CourseMember
    {
        public Student(Mediator mediator) : base(mediator)
        {
        }

        public object Name { get; set; }

        internal void RecieveImage(string url)
        {
            Console.WriteLine("{1} received image : {0}",url,Name);
        }

        internal void RecieveAnswer(string answer)
        {
            Console.WriteLine("{1} received answer {0}", answer, Name);
        }
    }

    class Mediator
    {
        public List<Student> Students { get; set;}
        public Teacher Teacher { get; internal set; }

        public void UpdateImage(string url)
        {
            foreach (var student in Students)
            {
                student.RecieveImage(url);       
            }
        }

        public void SendQuestion(string question,Student student)
        {
            Teacher.RecieveQuestion(question, student);
        }

        public void SendAnswer(string answer,Student student) 
        {
            student.RecieveAnswer(answer);
        }
    }
}
