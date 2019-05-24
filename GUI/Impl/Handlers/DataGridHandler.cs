using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GUI.Impl
{
    public class DataGridHandler
    {
        #region Fields

        #endregion

        #region Constructors

        #endregion

        #region Methods
        public void DGHandler<Element>(int dgVersion, Element elem)
            where Element: DataGrid
        {
            if (dgVersion == 1)
            {
                NewTemplateDG(elem);
            }
        }

        private void NewTemplateDG<Element>(Element elem)
            where Element: DataGrid
        {
        }

        #endregion
    }
}
