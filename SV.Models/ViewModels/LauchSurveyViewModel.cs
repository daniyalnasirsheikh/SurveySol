using SV.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SV.Models.ViewModels
{
    public class LauchSurveyViewModel
    {
        public LauchSurveyViewModel()
        {

        }

        public LauchSurveyViewModel(Survey survey, List<Question> questions)
        {
            Survey = survey;

            foreach (var question in questions)
            {
                var optionsViewModel = new OptionsViewModel(question);
                
                if (survey.Language == "Bilingual")
                {
                    var strs = optionsViewModel.Question.QuestionText.Split("EQ_AQ_SP").ToList();
                    optionsViewModel.Question.QuestionText = strs.ElementAtOrDefault(0);
                    optionsViewModel.QuestionTextArabic = strs.ElementAtOrDefault(1);
                }

                Options.Add(optionsViewModel);
            }
        }

        public Survey Survey { get; set; }
        public List<OptionsViewModel> Options { get; set; } = new List<OptionsViewModel>();
    }
}
