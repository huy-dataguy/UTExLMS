using HandyControl.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UTExLMS.Models;
using UTExLMS.Service;

using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using UTExLMS.Views;
using System.IO;


namespace UTExLMS.ViewModels
{
    public class MaterialStudentViewModel
    {

        public MaterialStudentViewModel(ElementSection elementInfor) {
            ShowMaterial(elementInfor);
        }



        private void ShowMaterial(ElementSection elementInfor)
        {
            var material = new MaterialService().GetDocument(elementInfor.IdCourse, elementInfor.IdSection, elementInfor.IdElement);

            string pathFile = material.FilePath;

            ////////////// 

            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory; // Thư mục hiện tại của ứng dụng (bin)
            string projectRootDirectory = Path.GetFullPath(Path.Combine(baseDirectory, @"..\..\..")); // Thư mục gốc của dự án

            string relativePath = Path.Combine("Database", "Materials", "Bài 1 - Tổng quan về ATTT.pptx"); // Đường dẫn tương đối đến tệp Excel
            string fullPath = Path.Combine(projectRootDirectory, relativePath); // Đường dẫn tuyệt đối từ thư mục gốc đến tệp Excel

            if (File.Exists(fullPath))
            {
                try
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = fullPath,
                        UseShellExecute = true
                    });
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show($"Không thể mở tệp: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Tệp không tồn tại.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

    }
       
}
