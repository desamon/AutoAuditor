using GUI.Impl.Models;
using GUI.Interface;
using LoggerFM.Interface;
using Ninject;
using ParsingFM.Impl;
using ParsingFM.Impl.Models;
using ParsingFM.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GUI.Impl.Handlers
{
    internal class ComboBoxHandler : Handlerss, IComboBoxHandler
    {
        #region Fields
        private ILog _logger;
        #endregion

        #region Constructors
        public ComboBoxHandler(ILog logger)
        {
            _logger = logger;
        }
        #endregion

        #region Methods
        public LoadQuestions[] GetArray(ObservableCollection<LoadQuestions> source)
            => source
                .Select(s => s)
                .ToArray();

        public void ViewAnswer<Element>(Element elem, 
            Label categorie, Label question, Label import,
            LoadQuestions[] array, int index)
            where Element: ListBox
        {
            var value = array[index];
            var categorieName = value.Categorie;
            var questionName = value.Question;
            var questionImport = value.ImportQuestion;
            var answers = value.Answers;
            var source = new ObservableCollection<NewTemplate>();
            foreach(var answer in answers)
                source.Add(new NewTemplate
                {
                    Answer = answer.Answer,
                    Import = answer.ImportAnswer,
                    Comment = answer.Comment
                });

            categorie.Content = categorieName;
            question.Content = questionName;
            import.Content = questionImport;
            elem.ItemsSource = source;
        }


        #endregion
    }
}
