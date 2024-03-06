using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
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
        private bool isRefreshing;
        public bool IsRefreshing { get { return isRefreshing; } set { isRefreshing = value;OnPropertyChanged(); } }
        private SubjectQuestion selectedSubject;
        public SubjectQuestion SelectedSubject {  get { return selectedSubject; } set { selectedSubject = value;OnPropertyChanged();Filter(); } }
        private List<SubjectQuestion> subjectQuestions;
        public List<SubjectQuestion> SubjectQuestions {  get { return subjectQuestions; } set { subjectQuestions = value;OnPropertyChanged(); } }
        private ObservableCollection<Question> questions;
        public ObservableCollection<Question> Questions { get { return questions; } set { questions = value;OnPropertyChanged(); } }
        public ICommand ApproveQuestionCommand { get; private set; }
        public ICommand DeclineQuestionCommand { get; private set; }
        public ICommand RefreshCommand { get; private set; }
        public ApproveQuestionsPageViewModel(TriviaAppService service_)
        {
            this.service= service_;
            SubjectQuestions = service.GetSubjects();
            Refresh();
            ApproveQuestionCommand = new Command(async (Object obj) => ApproveQuestion(obj));
            DeclineQuestionCommand = new Command(async (Object obj) => DeclineQuestion(obj));
            RefreshCommand = new Command(async ()=> Refresh());
        }
        private async void Refresh()
        {
            IsRefreshing = true;
            SelectedSubject = null;
            Questions = new ObservableCollection<Question>(service.GetPendingQuestions());
            IsRefreshing =false;
        }
        private async void Filter()
        {
            if (SelectedSubject != null)
            {
                Questions = new ObservableCollection<Question>(service.GetPendingQuestionsBySubjectName(SelectedSubject.SubjectName));
            }
        }
        private async void ApproveQuestion(Object obj)
        {
            service.ApproveQuestion(((Question)obj));
            Refresh();
        }
        private async void DeclineQuestion(Object obj)
        {
            service.DeclineQuestion(((Question)obj));
            Refresh();
        }

    }
}
