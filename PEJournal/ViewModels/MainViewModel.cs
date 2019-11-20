using PEJournal.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PEJournal.ViewModels
{
    public class MainViewModel : Notifier
    {
        public ObservableCollection<Student> Students { get; set; }

        private Student selectedStudent;
        public Student SelectedStudent
        {
            get { return selectedStudent; }
            set
            {
                selectedStudent = value;
                NotifyPropertyChanged("SelectedStudent");
            }
        }
        public MainViewModel()
        {
            Students = new ObservableCollection<Student>
            {
                new Student { Id = 1, FirstName = "Александр", LastName = "Лужков", MiddleName = "Иванович" },
                new Student { Id = 2, FirstName = "Андрей", LastName = "Колотаев", MiddleName = "Кириллович" },
                new Student { Id = 3, FirstName = "Юрий", LastName = "Кижиков", MiddleName = "Витальевич" }
            };
        }
    }
}
