using GUI.Impl;
using GUI.Impl.Extension;
using GUI.Impl.Handlers;
using GUI.Impl.Models;
using GUI.Interface;
using LoggerFM.Impl;
using LoggerFM.Interface;
using Ninject;
using ParsingFM.Impl;
using ParsingFM.Impl.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Fields
        private IHandler _buttonHandler;
        private IListBoxHandler _listBoxHandler;
        private IComboBoxHandler _comboBoxHandler;
        private ILog _logger;
        private static int _index { get; set; }
        private static LoadQuestions[] _questionArray { get; set; }
        private static Template[] _result { get; set; }
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            InitializeObjects();
            ElementBindings.Binding(dataGridQuestion, comboBoxTemplates, comboBoxResult);
        }

        private void InitializeObjects()
        {
            var logger = new StandardKernel(new LogConfigModule());
            _logger = logger.Get<ILogFactory>().Create();

            _buttonHandler = new ButtonsHandler(_logger);
            _listBoxHandler = new ListBoxHandler(_logger);
            _comboBoxHandler = new ComboBoxHandler(_logger);
        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            var item = comboBoxTemplates.SelectedItem as LoadTemplate;
            var name = item.TemplateName;

            _buttonHandler.Restore(dynamicElement: name);
            _buttonHandler.ButtonHandler(1, _result);
        }

        private void ButtonQuestion_Click(object sender, RoutedEventArgs e)
        {
            var templateName = textBoxTemplateName.Text;

            _buttonHandler.Restore(dynamicElement: templateName);
            _buttonHandler.ButtonHandler(2, dataGridQuestion);
        }

        private void ButtonNewTemplate_Click(object sender, RoutedEventArgs e)
        {
            var question = new Template
            {
                Categorie = textBoxQuestionCategorie.Text,
                Question = textBoxQuestion.Text,
                Answer = textBoxAnswer.Text,
                ImportQuestion = textBoxQuestionImport.Text,
                ImportAnswer = textBoxAnswerImport.Text,
                Comment = textBoxComment.Text
            };

            _buttonHandler.ButtonHandler(4, dataGridQuestion, question);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _buttonHandler.ButtonHandler(5, listBoxTemplate);
        }

        private void ListBoxTemplate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = listBoxTemplate.SelectedItem as LoadTemplate;

            textBoxTemplateName.Text = item.TemplateName;
            _listBoxHandler.LoadSelectedTemplate(item, dataGridQuestion);
        }

        private void buttonDataGridQuestionClear_Click(object sender, RoutedEventArgs e)
        {
            dataGridQuestion.ItemsSource = null;
        }

        private void buttonDataGridDeleteRows_Click(object sender, RoutedEventArgs e)
        {
            var index = dataGridQuestion.SelectedIndex;
            dataGridQuestion.Items.RemoveAt(index);
        }

        private void ButtonStartTest_Click(object sender, RoutedEventArgs e)
        {
            _index = 0;
            _questionArray = null;
            var item = comboBoxTemplates.SelectedItem as LoadTemplate;
            var source = _buttonHandler.ButtonHandler<LoadTemplate, ObservableCollection<LoadQuestions>>(6, item);
            _questionArray = _comboBoxHandler.GetArray(source);
            _result = new Template[_questionArray.Count()];
            _comboBoxHandler.ViewAnswer(listBoxAnswers, label1, label1_Copy, labelQuestionImport, _questionArray, _index);

        }

        private void ButtonNextQuestion_Click(object sender, RoutedEventArgs e)
        {
            if (_index >= _questionArray.Count()-1)
                _index = _questionArray.Count()-1;
            else
                _index++;

            _comboBoxHandler.ViewAnswer(listBoxAnswers, label1, label_Copy, labelQuestionImport, _questionArray, _index);
        }

        private void ButtonBackQuestion_Click(object sender, RoutedEventArgs e)
        {
            if (_index <= 0)
                _index = 0;
            else
                _index--;

            _comboBoxHandler.ViewAnswer(listBoxAnswers, label1, label_Copy, labelQuestionImport, _questionArray, _index);
        }

        private void ListBoxAnswers_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var items = listBoxAnswers.SelectedItem as NewTemplate;

            _result[_index] = new Template
            {
                Categorie = label1.Content.ToString(),
                Question = label1_Copy.Content.ToString(),
                Answer = items.Answer,
                ImportQuestion = labelQuestionImport.Content.ToString(),
                ImportAnswer = items.Import.ToString(),
                Comment = items.Comment
            };
        }

        private void ButtonLoadResult_Click(object sender, RoutedEventArgs e)
        {
            var items = comboBoxResult.SelectedItem as LoadTemplate;
            var source = _buttonHandler.ButtonHandler<LoadTemplate, ObservableCollection<SaveResult>>(7, items);

            treeViewResult.ItemsSource = source;
        }
    }
}