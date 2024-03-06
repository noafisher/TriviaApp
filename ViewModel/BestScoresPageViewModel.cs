
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;
using TriviaApp.Models;
using TriviaApp.Services;

namespace TriviaApp.ViewModel
{
    public class BestScoresPageViewModel : ViewModel
    {
        private User selectedUser;
        private string rank;
        private TriviaAppService triviaApp;
        private bool isRefreshing;
        private string email;
        private bool isOrdered; 

        public User SelectedUser { get=> selectedUser; set { selectedUser = value; UpdateFields(); } }
        public ObservableCollection<User> Users { get; set; }
        public ICommand LoadUsersCommand { get; private set; }
        public ICommand MessUsersCommand { get; private set; }
        public bool IsRefreshing { get => isRefreshing; set { isRefreshing = value; OnPropertyChanged(); } }
        public string Rank {  get => rank; set { rank = value; OnPropertyChanged(); } }  
        public string Email { get => email; set { email = value; OnPropertyChanged(); } }
        public BestScoresPageViewModel(TriviaAppService triviaApp)
        {
            IsRefreshing = false;
            this.triviaApp = triviaApp;
            Users = new ObservableCollection<User>();
            LoadUsersCommand = new Command(async () => await
            LoadUsers());
            MessUsersCommand = new Command(async () => await ReloadAndOrder());
            
        }

        private async Task LoadUsers()
        {
           
            IsRefreshing = true;
            Users.Clear();
            var list=  triviaApp.OrderUsers();
            
            foreach (User u in list)
            {
                Users.Add(u);
            }
            IsRefreshing = false;
            isOrdered = false;
        }

        private void UpdateFields()
        {
            if (SelectedUser != null)
            {
                Rank = SelectedUser.Rank.RankName;
                Email = SelectedUser.Email;
            }

        }

        private async Task ReloadAndOrder()
        {
           List<User> list;
            if (isOrdered)
            {
                list = triviaApp.MessUsers();
                isOrdered = false;
               
            }
            else
            {
                list = triviaApp.OrderUsers();
                
                isOrdered = true;
            }
            Users.Clear();
            foreach (User u in list)
            {
                Users.Add(u);
            }

        }
    }
}
