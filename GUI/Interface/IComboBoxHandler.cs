using GUI.Impl.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GUI.Interface
{
    public interface IComboBoxHandler
    {
        void ViewAnswer<Element>(Element elem, Label categorie, Label question, Label import,
            LoadQuestions[] array, int index)
            where Element : ListBox;

        LoadQuestions[] GetArray(ObservableCollection<LoadQuestions> source);
    }
}
