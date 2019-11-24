using System;

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

        private const int BLANK_ID = -1;

        public static Student CreateBlank()
        {
            return new Student { Id = BLANK_ID };
        }

        public bool IsBlank()
        {
            return (Id == BLANK_ID);
        }

        public Student Update(Student updated)
        {
            Id = updated.Id;
            FirstName = updated.FirstName;
            LastName = updated.LastName;
            MiddleName = updated.MiddleName;
            Birthday = updated.Birthday;
            return this;
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
