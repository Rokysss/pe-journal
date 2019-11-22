using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PEJournal.Models
{
    public class Student : Notifier, ICloneable, IEquatable<Student>
    {
        public int Id { get; set; }

        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                NotifyPropertyChanged("FullName");
            }
        }

        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                NotifyPropertyChanged("FullName");
            }
        }

        private string middleName;
        public string MiddleName
        {
            get { return middleName; }
            set
            {
                middleName = value;
                NotifyPropertyChanged("FullName");
            }
        }

        public DateTime? Birthday { get; set; }

        public string FullName
        {
            get
            {
                return $"{LastName} {FirstName} {MiddleName}";
            }
        }

        public bool IsBlank { get; private set; } = false;

        public static Student CreateBlank()
        {
            return new Student { IsBlank = true };
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public bool Equals(Student other)
        {
            return (Id == other.Id) &&
                (FirstName == other.FirstName) &&
                (LastName == other.LastName) &&
                (MiddleName == other.MiddleName) &&
                (Birthday == other.Birthday);
        }
    }
}
