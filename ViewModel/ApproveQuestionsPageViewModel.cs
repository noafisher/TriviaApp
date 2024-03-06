using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TriviaApp.Models;
using TriviaApp.Services;

namespace TriviaApp.ViewModel
{
    public class ApproveQuestionsPageViewModel:ViewModel
    {
        private TriviaAppService service;
        private ObservableCollection<Question> questions;
        public ObservableCollection<Question> Questions { get { return questions; } set { questions = value;OnPropertyChanged(); } }
        public ICommand ApproveQuestionCommand { get; private set; }
        public ApproveQuestionsPageViewModel(TriviaAppService service_)
        {
            this.service= service_;
            Questions=new ObservableCollection<Question>(service.GetPendingQuestions());
            ApproveQuestionCommand = new Command(async (Object obj) => ApproveQuestion(obj));
        }
        private async void ApproveQuestion(Object obj)
        {
            service.ApproveQuestion(((Question)obj));
            Questions = new ObservableCollection<Question>(service.GetPendingQuestions());
        }
    }
}
