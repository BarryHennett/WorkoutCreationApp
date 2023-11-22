using WorkoutCreation.MVVM.ViewModels;

namespace WorkoutCreation.MVVM.Views;

public partial class AddExercisePage : ContentPage
{
    private readonly WorkoutViewModel _viewModel;

    public AddExercisePage(WorkoutViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
        _viewModel = viewModel;
        
	}

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.LoadExercisesAsync();
    }

    //private void OnSaveExerciseClicked(object sender, EventArgs e)
    //{

    //    // Example:
    //    var exerciseName = exerciseNameEntry.Text;
    //    var setsCompleted = setsCompletedEntry.Text;
    //    var repsCompleted = repsCompletedEntry.Text;
    //    //SaveExercise(exerciseName);
    //    //SaveSets(setsCompleted);
    //    //SaveReps(repsCompleted);



    //    // Navigate back to the main page
    //    Navigation.PopAsync();
    //}
}