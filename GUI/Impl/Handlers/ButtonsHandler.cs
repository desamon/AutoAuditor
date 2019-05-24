using AutoAuditorFM.Impl;
using AutoAuditorFM.Interface;
using GUI.Impl.Extension;
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
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace GUI.Impl
{
    internal class ButtonsHandler : IHandler
    {
        #region Fields
        private ILog _logger;
        private StandardKernel _kernelParsing;
        private string _templatePath { get; set; }
        private object _dynamicElement { get; set; }
        private IParsing _parsing { get; set; }
        #endregion

        #region Constructors
        internal ButtonsHandler(ILog logger)
        {
            _logger = logger;
            _kernelParsing = new StandardKernel(new ParsingConfigModule());
        }
        #endregion

        #region Methods
        public void Restore(string path = null, object dynamicElement = null)
        {
            _templatePath = path;
            _dynamicElement = dynamicElement;
        }

        public void ButtonHandler(int buttonVersion)
        {
            switch ((ButtonVersion)buttonVersion)
            {
                case ButtonVersion.SaveResult:
                    break;
            }
        }

        public Element ButtonHandler<Element>(int buttonVersion, Element elem = null)
            where Element: class
        {
            switch ((ButtonVersion)buttonVersion)
            {
                case ButtonVersion.SaveTemplate:

                    _parsing = _kernelParsing
                        .Get<IParsingFactory>()
                        .Create(_logger, null);

                    SaveTemplate(elem as DataGrid);
                    break;

                case ButtonVersion.LoadTemplates:
                    LoadTemplates(elem as ListBox);
                    break;

                case ButtonVersion.Start:
                    Start(elem as Template[]);
                    break;
            }

            return null;
        }

        public Source ButtonHandler<Element, Source>(int buttonVersion, Element elem = null, Source source = null)
            where Element: class
            where Source: class
        {
            switch((ButtonVersion)buttonVersion)
            {
                case ButtonVersion.NewTemplate:
                    NewTemplate(elem as DataGrid, source as Template);
                    break;

                case ButtonVersion.LoadQuestions:
                    var sources = LoadQuestions(elem as LoadTemplate);
                    return sources as Source;

                case ButtonVersion.LoadResult:
                    var result = LoadResult(elem as LoadTemplate);
                    return result as Source;
            }

            return null;
        }

        private void Start(Template[] source)
        {
            var result = Extensions.ConvertResult(source);

            _parsing = _kernelParsing
                        .Get<IParsingFactory>()
                        .Create(_logger, null);

            var kernel = new StandardKernel(new ServiceConfigModule());
            var auditor = kernel
                .Get<IServiceFactory>()
                .Create(result, _logger, _parsing, (string)_dynamicElement);

            auditor.Invoke();

        }

        private ObservableCollection<SaveResult> LoadResult(LoadTemplate template)
        {
            var path = template.Path;
            var parsing = _kernelParsing.Get<IParsingFactory>().Create(_logger, path);
            var source = new ObservableCollection<SaveResult>();

            var templateParsing = parsing.LoadResult<List<SaveResult>>();
            foreach (var row in templateParsing)
                source.Add(row);

            return source;
        }

        private ObservableCollection<LoadQuestions> LoadQuestions(LoadTemplate template)
        {
            var path = template.Path;
            var parsing = _kernelParsing.Get<IParsingFactory>().Create(_logger, path);
            var source = new ObservableCollection<LoadQuestions>();

            var templateParsing = parsing.Start<List<TemplateParsing>>();
            var categories = templateParsing
                .Select(s => s.Categorie)
                .Distinct()
                .ToList();

            foreach(var cat in categories)
            {
                var questions = templateParsing
                    .Where(w => w.Categorie.Equals(cat))
                    .Select(s => s.Question)
                    .Distinct()
                    .ToList();

                foreach(var ques in questions)
                {
                    var answerList = new List<AnswerModel>();

                    var importQuestion = templateParsing
                        .Where(w => w.Categorie.Equals(cat)
                            && w.Question.Equals(ques))
                        .Select(s => s.ImportQuestion)
                        .Distinct()
                        .FirstOrDefault();

                    var answers = templateParsing
                        .Where(w => w.Categorie.Equals(cat)
                            && w.Question.Equals(ques))
                        .Select(s => s.Answer)
                        .Distinct()
                        .ToList();

                    foreach(var ans in answers)
                    {
                        var row = templateParsing
                            .Where(w => w.Categorie.Equals(cat)
                                && w.Question.Equals(ques)
                                && w.Answer.Equals(ans))
                            .Select(s => new AnswerModel
                            {
                                Answer = s.Answer,
                                ImportAnswer = Convert.ToDouble(s.ImportAnswer),
                                Comment = s.Comment
                            })
                            .Distinct()
                            .FirstOrDefault();

                        answerList.Add(row);
                    }
                    source.Add(new LoadQuestions
                    {
                        Categorie = cat,
                        Question = ques,
                        ImportQuestion = Convert.ToDouble(importQuestion),
                        Answers = answerList
                    });
                }
            }

            return source;
        }

        private void NewTemplate<Element, Source>(Element elem, Source source)
            where Element: DataGrid
            where Source: Template
        {
            var sources = new ObservableCollection<Template>();

            foreach(var row in elem.Items)
            {
                sources.Add((Template)row);
            }

            sources.Add(source);

            CallBackWindow.DGObserverCollection(elem, sources);
        }

        private void SaveTemplate<Element>(Element elem)
            where Element: DataGrid
        {
            var dict = new Dictionary<string, List<TemplateParsing>>();
            var listParsing = new List<TemplateParsing>();

            foreach(var item in elem.Items)
            {
                var oldRow = (Template)item;
                var newRow = Extensions.TemplateConvertor<Template, TemplateParsing>(oldRow);
                listParsing.Add(newRow);
            }

            dict.Add((string)_dynamicElement, listParsing);

            _parsing.Start(dict);
        }

        private void LoadTemplates<Element>(Element elem)
            where Element : ListBox
        {
            var path = "./xmls";
            var source = Extensions.GetFiles(path);

            CallBackWindow.ListBoxOutput(elem, source);
        }
        #endregion
    }
}
