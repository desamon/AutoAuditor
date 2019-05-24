using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace GUI.Impl.Extension
{
    internal static class CallBackWindow
    {
        internal static void DGAddItem<Source>(DataGrid elem, Source source)
            where Source : class
            => elem.Items.Add(source);

        internal static void DGObserverCollection<Source>(DataGrid elem, ObservableCollection<Source> source)
            where Source: class
           => elem.ItemsSource = source;

        internal static void ListBoxOutput<Source>(ListBox elem, ObservableCollection<Source> source)
            where Source: class
           => elem.ItemsSource = source;

    }
}
