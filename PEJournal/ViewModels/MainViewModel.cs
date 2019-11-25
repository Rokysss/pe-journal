using PEJournal.DataAccess;
using PEJournal.Models;
using System.Collections.ObjectModel;
using System.Linq;
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
                selectedStudent = value;
                EditedStudent = (Student)value?.Clone();
                NotifyPropertyChanged("SelectedStudent");
            }
        }

        private Student editedStudent;
        public Student EditedStudent
        {
            get { return editedStudent; }
            set
            {
                editedStudent = value;
                NotifyPropertyChanged("EditedStudent");
            }
        }

        private ICommand saveCommand;
        public ICommand SaveCommand
        {
            get
            {
                return saveCommand ?? (
                    saveCommand = new RelayCommand(
                        _ => SaveEditedStudent(),
                        _ => CanSaveEditedStudent()));
            }
        }

        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                    (deleteCommand = new RelayCommand(
                        _ => DeleteSelectedStudent(),
                        _ => CanDeleteSelectedStudent()));
            }
        }

        private ICommand cancelCommand;
        public ICommand CancelCommand
        {
            get
            {
                return cancelCommand ??
                    (cancelCommand = new RelayCommand(
                        _ => CancelEditing(),
                        _ => CanCancelEditing()));
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

        private void SaveEditedStudent()
        {
            if (EditedStudent != null)
            {
                if (EditedStudent.IsBlank())
                {
                    studentRepository.Create(EditedStudent);
                    UpdateStudents();
                }
                else
                {
                    if (!EditedStudent.Equals(SelectedStudent))
                    {
                        studentRepository.Update(EditedStudent);
                        UpdateStudents();
                    }
                }
            }
        }

        private bool CanSaveEditedStudent()
        {
            if (EditedStudent == null) return false;
            if (EditedStudent.Equals(SelectedStudent)) return false;
            if (string.IsNullOrEmpty(EditedStudent.FirstName)) return false;
            if (string.IsNullOrEmpty(EditedStudent.LastName)) return false;
            return true;
        }

        private void DeleteSelectedStudent()
        {
            if (SelectedStudent != null)
            {
                studentRepository.Delete(SelectedStudent.Id);
                UpdateStudents();
            }
        }

        private bool CanDeleteSelectedStudent()
        {
            return SelectedStudent != null;
        }

        private void CancelEditing()
        {
            SelectedStudent = null;
        }

        private bool CanCancelEditing()
        {
            return SelectedStudent != null;
        }
    }
}
