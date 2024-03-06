using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriviaApp.Models;
using TriviaApp.Services;

namespace TriviaApp.ViewModel
{
    public class ApproveQuestionsPageViewModel:ViewModel
    {
        private TriviaAppService service;
        public ApproveQuestionsPageViewModel(TriviaAppService service_)
        {
            this.service= service_;
        }
    }
}
