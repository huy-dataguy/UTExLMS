using UTExLMS.Models;
using UTExLMS.Service;
using UTExLMS.Commands;
using System.Windows.Input;
using Microsoft.Win32;
using System.Windows;
using System.IO;
using Newtonsoft.Json.Linq;
namespace UTExLMS.ViewModels
{
    public class AssignmentStudentViewModel : ViewModelBase
    {
        private string _chosenFilePath = "";
        private StudentAssignment _assignmentSubmited;

        public string InforAssignment { get; set; } 

        public StudentAssignment AssignmentSubmited
        { 
            get => _assignmentSubmited;
            set
            {
                SetProperty(ref _assignmentSubmited, value);
            }
    }


    public string ChosenFilePath
        {
            get => _chosenFilePath;
            set
            {
                SetProperty(ref _chosenFilePath, value);
            }
        }


        public Assignment Assignment { get; set; }


        public ICommand ChooseFile { get; private set; }
        public ICommand SubmitFile { get; private set; }



        public AssignmentStudentViewModel(ElementSection elementInfor) {
            Assignment = new AssignmentService().GetAssignment(elementInfor.IdCourse, elementInfor.IdSection, elementInfor.IdElement);
            InforAssignment = SetStatusAssignment(Assignment);

            _assignmentSubmited = new AssignmentService().GetAssignmentSubmited(elementInfor.IdCourse, elementInfor.IdSection, elementInfor.IdElement, elementInfor.IdStudent);




            ChooseFile = new RelayCommand(_ => OpenFileDialog());
            SubmitFile = new RelayCommand(_ => SubmitButtonFile(elementInfor, Assignment));


        }

        private string SetStatusAssignment(Assignment assignment)
        {
            var status = "";

            if (assignment.EndDate > DateTime.Today)
            {
                status = "Bài tập vẫn còn thời hạn";

            }
            else
                status = "Quá hạn nộp bài tập";

            return status;

        }

        private void OpenFileDialog()
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Tất cả các tệp (*.*)|*.*",
                Title = "Chọn tệp",  
                Multiselect = false  
            };

            bool? result = openFileDialog.ShowDialog();

            if (result == true)  
            {
                this.ChosenFilePath = openFileDialog.FileName;
                MessageBox.Show($"Đã chọn tệp: {this.ChosenFilePath}");
            }
            else
            {
                MessageBox.Show("Không có tệp nào được chọn.");
            }
        }


        private void SubmitButtonFile(ElementSection elementInfor, Assignment assignment)
        {
            string selectedFilePath = ChosenFilePath;

            if (string.IsNullOrEmpty(selectedFilePath))
            {
                MessageBox.Show("Vui lòng chọn tệp trước khi nộp.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Lấy thư mục gốc của dự án
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory; // Thư mục bin hiện tại
            string projectRootDirectory = Path.GetFullPath(Path.Combine(baseDirectory, @"..\..\..")); // Đưa về thư mục gốc của dự án

            // Xây dựng đường dẫn đến thư mục Materials trong thư mục gốc của dự án
            string materialsDirectory = Path.Combine(projectRootDirectory, "Database", "Materials");

            // Kiểm tra xem thư mục đã tồn tại chưa, nếu chưa thì tạo mới
            if (!Directory.Exists(materialsDirectory))
            {
                Directory.CreateDirectory(materialsDirectory);
            }

            // Đảm bảo tệp sẽ được lưu vào thư mục Materials với tên tệp gốc

            string nameFile = Path.GetFileName(selectedFilePath);
            string targetFilePath = Path.Combine(materialsDirectory, nameFile);

            try
            {
                // Sao chép tệp vào thư mục Materials
                File.Copy(selectedFilePath, targetFilePath, true); // true để ghi đè nếu tệp đã tồn tại

                if (AssignmentSubmited == null)
                {
                    AssignmentSubmited = new StudentAssignment
                    {
                        IdStudent = elementInfor.IdStudent,
                        IdCourse = elementInfor.IdCourse,
                        IdSection = elementInfor.IdSection,
                        IdAssign = assignment.IdAssign,
                        DateSubmit = DateTime.Now,
                        PathFile = nameFile
                    };
                }
                new AssignmentService().UpdateStudentAssignment(elementInfor, assignment, nameFile, DateTime.Now);

                AssignmentSubmited.DateSubmit = DateTime.Now;
                AssignmentSubmited.PathFile = nameFile;
                OnPropertyChanged(nameof(AssignmentSubmited));

                MessageBox.Show("Nộp bài thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi nộp bài: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }






    }
}
