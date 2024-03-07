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
    public class UserAdminPageViewModel:ViewModel
    {
        private string filterEntry;
        private TriviaAppService service;
        private bool isRefreshing;
        private User newUser;
        public ObservableCollection<User> Users { get; set; }
        public User NewUser { get => newUser; set { newUser = value; OnPropertyChanged(); } }
        public bool IsRefreshing { get => isRefreshing; set { isRefreshing = value; OnPropertyChanged(); } }
        public ICommand NavigateUserAdmim { get; private set; }
        public ICommand LoadUsersCommand { get; private set; }
        public ICommand RefreshCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand ResetCommand { get; private set; }
        public ICommand InsertCommand { get; private set; }
        public ICommand FilterByLevelCommand { get; private set; }

        public UserAdminPageViewModel(TriviaAppService service)
        {
            IsRefreshing = false;
            Users = new ObservableCollection<User>();
            NewUser = new() { Rank = service.GetRankByID(3) };
            RefreshCommand = new Command(async () => await Refresh());
            LoadUsersCommand = new Command(async () => await LoadUsers());
            DeleteCommand = new Command<User>(( obj) => Delete(obj));
            ResetCommand = new Command<User>(( obj) => Reset(obj));
            InsertCommand = new Command(( ) => Insert());
            FilterByLevelCommand = new Command<string>((x) => FilterByLevel(x));
            this.service = service;
            LoadUsers();
        }

        private async Task LoadUsers()
        {
            IsRefreshing = true;
            Users = new ObservableCollection<User>(service.GetUsers());
            OnPropertyChanged(nameof(Users));
            IsRefreshing = false;

        }
        private async Task Refresh()
        {
            IsRefreshing = true;
            await LoadUsers();
            IsRefreshing = false;
        }
        private void Delete(User s)
        {
         
            if (s != null)
                Users.Remove(s);
        }
        private void Reset(User s)
        {
           
            s.Points = 0;
            service.UpdatePlayer(s); 
            int pos=Users.IndexOf(s);
            Users.RemoveAt(pos);
            Users.Insert(pos,s);
            
        }
        private void Insert()
        {
            if (!Users.Any(x => x.Email == NewUser.Email))
            {
                Users.Add(new User() { Email = NewUser.Email, Password = NewUser.Password, Points = 0, Rank = NewUser.Rank, UserName = NewUser.UserName}) ;
                service.AddUser(NewUser);
            }
            else
            AppShell.Current.DisplayAlert("שגיאה", "משתמש כבר קיים", "אישור");
        }
        private void FilterByLevel(string filter)
        {
            List<User> filterUsers = service.GetPlayerByLevel(filter);
            Users.Clear();
            foreach (User u in filterUsers)
            {
                Users.Add(u);
            }
        }

    }
}
