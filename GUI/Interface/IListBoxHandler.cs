using GUI.Impl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GUI.Interface
{
    public interface IListBoxHandler
    {
        void LoadSelectedTemplate<Element>(LoadTemplate template, Element elem)
            where Element : DataGrid;
    }
}
