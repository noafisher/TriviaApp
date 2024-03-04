using TriviaApp.View;

namespace TriviaApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("BestScoresPage", typeof(BestScoresPage));
        }
    }
}