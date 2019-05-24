using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace GUI.Impl.Extension
{
    internal static class ElementBindings
    {
        internal static void Binding(DataGrid dgq, ComboBox cbt, ComboBox cbr)
        {
            DataGridQuestion(dgq);
            ComboBoxTemplates(cbt);
            ComboBoxResult(cbr);
        }

        private static void DataGridQuestion(DataGrid dgq)
        {
            var categorie = new DataGridTextColumn();
            categorie.Header = "Категория";
            categorie.Binding = new Binding("Categorie");
            dgq.Columns.Add(categorie);

            var question = new DataGridTextColumn();
            question.Header = "Вопрос";
            question.Binding = new Binding("Question");
            dgq.Columns.Add(question);

            var questionImport = new DataGridTextColumn();
            questionImport.Header = "Вес вопроса";
            questionImport.Binding = new Binding("ImportQuestion");
            dgq.Columns.Add(questionImport);

            var answer = new DataGridTextColumn();
            answer.Header = "Ответ";
            answer.Binding = new Binding("Answer");
            dgq.Columns.Add(answer);

            var answerImport = new DataGridTextColumn();
            answerImport.Header = "Вес ответа";
            answerImport.Binding = new Binding("ImportAnswer");
            dgq.Columns.Add(answerImport);

            var comment = new DataGridTextColumn();
            comment.Header = "Рекомендация";
            comment.Binding = new Binding("Comment");
            dgq.Columns.Add(comment);
        }

        private static void ComboBoxTemplates(ComboBox cbt)
        {
            var path = "./xmls";
            var source = Extensions.GetFiles(path);

            cbt.ItemsSource = source;
        }

        public static void ComboBoxResult(ComboBox cbr)
        {
            var path = "./xmlResult";
            var source = Extensions.GetFiles(path);

            cbr.ItemsSource = source;
        }
    }
}
