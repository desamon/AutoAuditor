using GUI.Impl.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Interface
{
    public interface IHandler
    {
        void Restore(string path = null, object dynamicElement = null);

        void ButtonHandler(int buttonVersion);

        Element ButtonHandler<Element>(int buttonControl, Element elem = null)
            where Element : class;

        Source ButtonHandler<Element, Source>(int buttonControl, Element elem = null, Source source = null)
            where Element : class
            where Source : class;
    }
}
