using ParsingFM.Impl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ParsingFM.Interface
{
    public interface IParsing
    {
        void Start<Input>(Input elem)
            where Input : class;

        Output Start<Output>()
            where Output : class;

        Output Start<Input, Output>(Input elem)
            where Input : class
            where Output : class;

        void Save(string name, List<XmlSave> value);

        Output LoadResult<Output>()
            where Output : class;
    }
}
