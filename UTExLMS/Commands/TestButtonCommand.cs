using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UTExLMS.Commands
{
    public class TestButtonCommand : CommandBase
    {
        public override void Execute(object? parameter)
        {
            MessageBox.Show("this is btn okkkk");
        }
    }
}
