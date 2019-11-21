using PEJournal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PEJournal.DataAccess
{
    //Fake Repository
    public class StudentRepository : RepositoryBase<Student>
    {
        private List<Student> fakeStudents = new List<Student>
        {
            new Student { Id = 1, FirstName = "Александр", LastName = "Лужков", MiddleName = "Иванович" },
            new Student { Id = 2, FirstName = "Андрей", LastName = "Колотаев", MiddleName = "Кириллович" },
            new Student { Id = 3, FirstName = "Юрий", LastName = "Кижиков", MiddleName = "Витальевич" }
        };

        public override IEnumerable<Student> GetAll()
        {
            return fakeStudents;
        }

        public override void Create(Student student)
        {
            fakeStudents.Add(student);
        }

        public override void Update(Student student)
        {
            Student updatedSudent = fakeStudents.First(fakeStudent => fakeStudent.Id == student.Id);
            updatedSudent.Id = student.Id;
            updatedSudent.FirstName = student.FirstName;
            updatedSudent.LastName = student.LastName;
            updatedSudent.MiddleName = student.MiddleName;
            updatedSudent.Birthday = student.Birthday;
        }

        public override void Delete(int id)
        {
            fakeStudents.Remove(fakeStudents.First(fakeStudent => fakeStudent.Id == id));
        }
    }
}
