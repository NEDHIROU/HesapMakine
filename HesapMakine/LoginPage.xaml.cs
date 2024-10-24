namespace HesapMakine
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent(); // This links to your XAML components
        }

        // Other code...
    

private async void OnLoginClicked(object sender, EventArgs e)
{
    string username = "admin";
    string password = "password";

    if (UsernameEntry.Text == username && PasswordEntry.Text == password)
    {
                await Navigation.PushAsync(new MainPage());
            }
    else
    {
        await DisplayAlert("Error", "Invalid username or password", "OK");
    }
}
    }
}

