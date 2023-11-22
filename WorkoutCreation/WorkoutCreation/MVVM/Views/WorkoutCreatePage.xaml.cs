using WorkoutCreation.MVVM.ViewModels;

namespace WorkoutCreation.MVVM.Views;

public partial class WorkoutCreatePage : ContentPage
{
    private readonly WorkoutViewModel _viewModel;

    public WorkoutCreatePage()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
       await Navigation.PushAsync(new AddExercisePage(_viewModel));

    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ViewExercisePage());
    }
}