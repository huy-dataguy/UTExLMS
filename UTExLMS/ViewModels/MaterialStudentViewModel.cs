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


    

            if (File.Exists(pathFile))
            {
                try
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = pathFile,
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
                System.Windows.MessageBox.Show("Tệp không còn tồn tại.");
            }

        }

    }
       
}
