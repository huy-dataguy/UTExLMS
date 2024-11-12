using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace UTExLMS.ViewModels.UCViewModel
{
    public class ElementUCViewModel
    {
        public ElementUCViewModel() { }
        public void ShowTestt(int id)
        {
            //var elements = new ListElementService().GetListElement(1, id);
            //foreach(var i in elements)
            {
                MessageBox.Show(id.ToString());
                //MessageBox.Show(i.NameType);
            }

        }
    }
}
