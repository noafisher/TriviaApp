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
        private TriviaAppService service;
        private bool isRefreshing;

        public ObservableCollection<User> Users { get; set; }
        public User SelectedUser { get; set; }
        public bool IsRefreshing { get => isRefreshing; set { isRefreshing = value; OnPropertyChanged(); } }
        public ICommand NavigateUserAdmim { get; private set; }
        public ICommand LoadUsersCommand { get; private set; }
        public ICommand RefreshCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand ResetCommand { get; private set; }
        public ICommand InsertCommand { get; private set; }

        public UserAdminPageViewModel(TriviaAppService service)
        {
            IsRefreshing = false;
            Users = new ObservableCollection<User>();
            RefreshCommand = new Command(async () => await Refresh());
            LoadUsersCommand = new Command(async () => await LoadUsers());
            DeleteCommand = new Command((object obj) => Delete(obj));
            ResetCommand = new Command((object obj) => Reset(obj));
            InsertCommand = new Command((object obj) => Insert(obj));
            this.service = service;
            LoadUsers();
        }

        private async Task LoadUsers()
        {
            IsRefreshing = true;
            Users = new ObservableCollection<User>(service.GetUsers());
            
            IsRefreshing = false;

        }
        private async Task Refresh()
        {
            IsRefreshing = true;
            await LoadUsers();
            IsRefreshing = false;
        }
        private void Delete(object obj)
        {
            User s = obj as User;
            if (s != null)
                Users.Remove(s);
        }
        private void Reset(object obj)
        {
            User s = obj as User;
            s.Points = 0;
            
        }
        private void Insert(object user)
        {
            Users.Add((User)user);
        }

    }
}
