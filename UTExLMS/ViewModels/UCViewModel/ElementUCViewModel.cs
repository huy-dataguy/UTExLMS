﻿using HandyControl.Tools.Extension;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using UTExLMS.Models;
using UTExLMS.Service;
using UTExLMS.Views;

namespace UTExLMS.ViewModels.UCViewModel
{
    public class ElementUCViewModel
    {
        public ElementUCViewModel(ElementSection inforElement) {
            CheckTypeElement(inforElement);

        }
       
        public ElementUCViewModel() { }

        public void CheckTypeElement(ElementSection inforElement)
        {
            switch (inforElement.NameType)
            {
                case "Material":

                    new MaterialStudentViewModel(inforElement);
                    break;
            


                case "Test":
                    MessageBox.Show("heelo test");
                    break;


                case "Assignment":



                    new AssignmentStudentPView(inforElement).Show();
                     break;

                case "Discussion":
                    // Handle Discussion case
                    MessageBox.Show("discuss");
                    break;

                default:
                    break;
            }
        }


       
    }
}
