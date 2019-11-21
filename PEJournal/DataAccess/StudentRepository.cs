using PEJournal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PEJournal.DataAccess
{
    //Fake Repository
    public class StudentRepository : RepositoryBase<Student>
    {
        public override IEnumerable<Student> GetAll()
        {
            return new List<Student>
            {
                new Student { Id = 1, FirstName = "Александр", LastName = "Лужков", MiddleName = "Иванович" },
                new Student { Id = 2, FirstName = "Андрей", LastName = "Колотаев", MiddleName = "Кириллович" },
                new Student { Id = 3, FirstName = "Юрий", LastName = "Кижиков", MiddleName = "Витальевич" }
            };
        }

        public override void Create(Student item)
        {
            throw new NotImplementedException();
        }

        public override void Update(Student item)
        {
            throw new NotImplementedException();
        }

        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
