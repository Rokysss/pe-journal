using PEJournal.DataAccess;
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
        private StudentRepository studentRepository;
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
            studentRepository = new StudentRepository();
            Students = new ObservableCollection<Student>(studentRepository.GetAll());
        }
    }
}
