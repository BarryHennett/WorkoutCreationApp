namespace WorkoutCreation.MVVM.Views;

public partial class WorkoutCreatePage : ContentPage
{
	public WorkoutCreatePage()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddExercisePage());
    }
}