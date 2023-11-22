using WorkoutCreation.MVVM.Views;
using WorkoutCreation.MVVM.ViewModels;

namespace WorkoutCreation;
public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new NavigationPage(new WorkoutCreatePage());
    }
}

