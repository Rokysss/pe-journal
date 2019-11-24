using PEJournal.DataAccess;
using PEJournal.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PEJournal.ViewModels
{
    public class MainViewModel : Notifier
    {
        private readonly StudentRepository studentRepository;

        private ObservableCollection<Student> students;
        public ObservableCollection<Student> Students
        {
            get { return students; }
            set
            {
                students = value;
                NotifyPropertyChanged("Students");
            }
        }

        private Student selectedStudent;
        public Student SelectedStudent
        {
            get { return selectedStudent; }
            set
            {
                selectedStudent = (Student)value?.Clone();
                NotifyPropertyChanged("SelectedStudent");
            }
        }

        private ICommand saveCommand;
        public ICommand SaveCommand
        {
            get
            {
                return saveCommand ??
                    (saveCommand = new RelayCommand(_ => SaveSelectedStudent()));
            }
        }

        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                    (deleteCommand = new RelayCommand(_ => DeleteSelectedStudent()));
            }
        }

        private ICommand cancelCommand;
        public ICommand CancelCommand
        {
            get
            {
                return cancelCommand ??
                    (cancelCommand = new RelayCommand(_ => CancelEditing()));
            }
        }

        public MainViewModel()
        {
            studentRepository = new StudentRepository();
            UpdateStudents();
        }

        private void UpdateStudents()
        {
            Students = new ObservableCollection<Student>(studentRepository.GetAll());
            CreateBlankStudent();
        }

        private void CreateBlankStudent()
        {
            Students.Add(Student.CreateBlank());
        }

        private void SaveSelectedStudent()
        {
            if(SelectedStudent != null)
            {
                if (SelectedStudent.IsBlank())
                {
                    studentRepository.Create(SelectedStudent);
                    UpdateStudents();
                }
                else
                {
                    Student oldStudent = Students.First(student => student.Id == SelectedStudent.Id);
                    if (!oldStudent.Equals(SelectedStudent))
                    {
                        studentRepository.Update(SelectedStudent);
                        UpdateStudents();
                    }
                }
            }
        }

        private void DeleteSelectedStudent()
        {
            if(SelectedStudent != null)
            {
                studentRepository.Delete(SelectedStudent);
                UpdateStudents();
            }
        }

        private void CancelEditing()
        {
            SelectedStudent = null;
        }
    }
}
