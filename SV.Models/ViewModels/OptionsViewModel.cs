using Microsoft.AspNetCore.Http;
using SV.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SV.Models.ViewModels
{
    public class OptionsViewModel
    {
        public OptionsViewModel()
        {

        }

        public OptionsViewModel(Question question)
        {
            Question = question;

            if (question.Type == "Radio" || question.Type == "Dropdown Menu" || question.Type == "Multiple Choice" || question.Type == "Logic")
            {
                if (!string.IsNullOrWhiteSpace(question.OptionsText))
                {
                    try
                    {
                        var strs = question.OptionsText.Trim().Replace("\r", "").Split("\n").ToList();

                        if (strs.Count > 0)
                        {
                            Options = strs;
                        }
                    }
                    catch (Exception)
                    {
                        
                    }
                }
            }

            if (question.Type == "Yes or No")
            {
                try
                {
                    if (!string.IsNullOrWhiteSpace(question.OptionsText))
                    {
                        var strs = question.OptionsText.Split("\n").ToList();

                        if (strs.Count > 0)
                        {
                            YesText = strs.ElementAtOrDefault(0);
                            NoText = strs.ElementAtOrDefault(1);
                        }
                    }
                }
                catch (Exception)
                {

                }
            }

            if (question.Type == "Net Promoter Score")
            {
                try
                {
                    if (!string.IsNullOrWhiteSpace(question.OptionsText))
                    {
                        var strs = question.OptionsText.Split("\n").ToList();

                        if (strs.Count > 0)
                        {
                            MinText = strs.ElementAtOrDefault(0);
                            MaxText = strs.ElementAtOrDefault(1);
                        }
                    }
                }
                catch (Exception)
                {

                }
            }

            if (question.Type == "Matrix Single" || question.Type == "Matrix Multi Select" || question.Type == "Semantic Question")
            {
                try
                {
                    if (!string.IsNullOrWhiteSpace(question.OptionsText))
                    {
                        var strs = question.OptionsText.Split("MH_MR_SP").ToList();

                        if (strs.Count > 0)
                        {
                            MatrixHeader = strs.ElementAtOrDefault(0);
                            MatrixRows = strs.ElementAtOrDefault(1);
                        }

                        if (!string.IsNullOrWhiteSpace(MatrixHeader))
                        {
                            MatrixHeaderOptions = MatrixHeader.Split("\n").ToList();
                        }

                        if (!string.IsNullOrWhiteSpace(MatrixRows))
                        {
                            MatrixRowsOptions = MatrixRows.Split("\n").ToList();
                        }
                    }
                }
                catch (Exception)
                {

                }
            }
        }

        public Question Question { get; set; }
        public string QuestionTextArabic { get; set; }
        public Answer Answer { get; set; }
        public int AnswerIndex { get; set; }

        public List<string> Options { get; set; } = new List<string>();
        public string YesText { get; set; }
        public string NoText { get; set; }
        public string MinText { get; set; }
        public string MaxText { get; set; }
        public string MatrixHeader { get; set; }
        public List<string> MatrixHeaderOptions { get; set; } = new List<string>();
        public string MatrixRows { get; set; }
        public List<string> MatrixRowsOptions { get; set; } = new List<string>();
    }
}
