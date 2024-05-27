namespace NoteApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override async void OnStart()
        {
            // Navigate to starting page
            await Shell.Current.GoToAsync("//main");

            base.OnStart();
        }
    }
}
