using Microsoft.AspNetCore.Identity;
using SV.Models.Entities;
using System.Collections.Generic;

namespace SV.Models.ViewModels
{
    public class SurveyShareViewModel
    {
        public SurveyShareViewModel()
        {
            Users = new List<SurveyShareUserViewModel>();
        }

        public SurveyShareViewModel(Survey survey, List<IdentityUser> users, List<UserShareSurvey> userShareSurveys)
        {
            SurveyId = survey.Id;
            SurveyName = survey.Name;
            Users = new List<SurveyShareUserViewModel>();
            users.RemoveAt(1);

            foreach (var user in users)
            {
                Users.Add(new SurveyShareUserViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    IsChecked = userShareSurveys.Exists(x => x.UserId == user.Id)
                });
            }
        }

        public int SurveyId { get; set; }
        public string SurveyName { get; set; }
        public List<SurveyShareUserViewModel> Users { get; set; }
    }

    public class SurveyShareUserViewModel
    {
        public string UserId { get; set; }
        public string UserName {  get; set; }
        public bool IsChecked { get; set; }
    }
}
