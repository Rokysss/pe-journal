using PEJournal.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace PEJournal.DataAccess
{
    //Fake Repository
    public class StudentRepository : RepositoryBase<Student>
    {
        public override IEnumerable<Student> GetAll()
        {
            return db.Students;
        }

        public override void Create(Student student)
        {
            db.Students.Add(student);
            Save();
        }

        public override void Update(Student student)
        {
            Student updatedStudent = db.Students.Find(student.Id).Update(student);
            db.Entry(updatedStudent).State = EntityState.Modified;
            Save();
        }

        public override void Delete(int id)
        {
            db.Students.Remove(db.Students.Find(id));
            Save();
        }
    }
}
