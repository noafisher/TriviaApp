using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriviaApp.Models;

namespace TriviaApp.Services
{
    public class TriviaAppService
    {
        List<User> users;
        List<Question> questions;
        List<StatusQuestion> statusQuestions;
        List<SubjectQuestion> subjectQuestions;

        public TriviaAppService()
        {
            users = new List<User>();
            users.Add(new User() { UserName = "NoaF", Password = "110907n", Points = 1000, Rank = new Rank{ RankId = 1, RankName = "Manager" } , Email="noa.fisher.2007@gmail.com" });
            users.Add(new User() { UserName = "Shahar", Password = "290807s", Points=500 ,Rank = new Rank { RankId = 2, RankName = "Master" }, Email="shahr.oz298@gmail.com" });
            statusQuestions = new List<StatusQuestion>();
            statusQuestions.Add(new StatusQuestion() { StatusId = 1, StatusDescription = "pending" });
            statusQuestions.Add(new StatusQuestion() { StatusId = 2, StatusDescription = "approved" });
            statusQuestions.Add(new StatusQuestion() { StatusId = 3, StatusDescription = "declined" });
            subjectQuestions= new List<SubjectQuestion>();
            subjectQuestions.Add(new SubjectQuestion() { SubjectId = 1, SubjectName ="Animals"});
            subjectQuestions.Add(new SubjectQuestion() { SubjectId = 2, SubjectName = "Celebrities" });
            subjectQuestions.Add(new SubjectQuestion() { SubjectId = 3, SubjectName = "TV shows" });
            subjectQuestions.Add(new SubjectQuestion() { SubjectId = 4, SubjectName = "Movies" });
            questions = new List<Question>();
            questions.Add(new Question() { QuestionId = 1, Subject = subjectQuestions.Where(x=>x.SubjectId==1).FirstOrDefault(), CreatedBy = "NoaF", Status = statusQuestions.Where(x=>x.StatusId==1).FirstOrDefault(), Text="how many arms does an octopus have?", Ranswer="8", Wanswer1="10", Wanswer2="4", Wanswer3="30" });
        }

        public bool Login(string name, string pass)
        {
            return users.Where(u=>u.UserName == name && u.Password == pass ).FirstOrDefault() != null;
        }

        public List<User> OrderUsers() 
        {
            return this.users.OrderByDescending(u => u.Points).ToList();
        }
        public List<SubjectQuestion> GetSubjects()
        {
            return subjectQuestions;
        }
        public List<Question> GetPendingQuestionsBySubjectName(string SubjectName)
        {
            return questions.Where(x => x.Status.StatusId == 1&&x.Subject.SubjectName==SubjectName).ToList();
        }

        public List<User> MessUsers()
        {
            return this.users.OrderBy(u => u.Points).ToList();
        }

        public List<User> GetUsers()
        {
            return users;
        }

       public List<Question> GetPendingQuestions()
        {
            return questions.Where(x=>x.Status.StatusId == 1).ToList();
        }
        public void ApproveQuestion(Question q)
        {
            q.Status= statusQuestions.Where(x => x.StatusId == 2).FirstOrDefault();
        }
        public void DeclineQuestion(Question q)
        {
            q.Status = statusQuestions.Where(x => x.StatusId == 3).FirstOrDefault();
        }

        public List<User> GetPlayerByLevel(string l)
        {
            return users.Where(x => x.Rank.RankName == l).ToList();
        }
        public void UpdatePlayer(User user)
        {
            var us = users.Where(x=>x.UserName==user.UserName).FirstOrDefault();
            us.Points = user.Points;

        }
    }
}
