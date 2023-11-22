using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using WorkoutCreation.MVVM.Data;
using WorkoutCreation.MVVM.Models;
using WorkoutCreation.MVVM.Views;

namespace WorkoutCreation.MVVM.ViewModels;

    public partial class WorkoutViewModel : ObservableObject
{

    private readonly DatabaseContext _context;
    public WorkoutViewModel(DatabaseContext context)
    {
        _context = context;
    }

    [ObservableProperty]
    private ObservableCollection<Exercise> _exercises;

    [ObservableProperty]
    private Exercise _operatingExercise = new();

    [ObservableProperty]
    private bool _isBusy;

    [ObservableProperty]
    private string _busyText;

    [RelayCommand]
    public async Task LoadExercisesAsync()
    {
        await ExecuteAsync(async () =>
        {
            var exercises = await _context.GetAllAsync<Exercise>();
            if (exercises is not null && exercises.Any())
            {
                if (Exercises is null)
                    Exercises = new ObservableCollection<Exercise>();

                foreach (var exercise in exercises)
                {
                    Exercises.Add(exercise);
                }
            }
        }, "Fetching Exercises");
    }

    [RelayCommand]
    public void SetOperatingExercise(Exercise exercise) => OperatingExercise = exercise ?? new();

    [RelayCommand]
    public async Task SaveExerciseAsync()
    {
        if (OperatingExercise is null)
            return;
        var busyText = OperatingExercise.Id == 0 ? "Creating Exercise" : "Updating Exercise";
        await ExecuteAsync(async () =>
        {
            if (OperatingExercise.Id == 0)
            {
                //Creating Exercise
                await _context.AddExerciseAsync<Exercise>(OperatingExercise);
                Exercises.Add(OperatingExercise);
            }
            else
            {
                //Update Exercise
                await _context.UpdateExerciseAsync<Exercise>(OperatingExercise);

                var exerciseCopy = OperatingExercise.Clone();

                var index = Exercises.IndexOf(OperatingExercise);
                Exercises.RemoveAt(index);

                Exercises.Insert(index, exerciseCopy);
            }
            SetOperatingExerciseCommand.Execute(new());
        }, busyText);

        
    }

    [RelayCommand]
    public async Task DeleteExerciseAsync(int id)
    {
        await ExecuteAsync(async () =>
        {
            if (await _context.DeleteExerciseByKeyAsync<Exercise>(id))
            {
                var exercise = Exercises.FirstOrDefault(e => e.Id == id);
                Exercises.Remove(exercise);
            }
            else
            {
                await Shell.Current.DisplayAlert("Delete Error", "Exercise Not Deleted", "Ok");
            }
        }, "Deleting Exercise");
    }

    public async Task ExecuteAsync(Func<Task> operation, string busyText = null)
    {
        IsBusy = true;
        BusyText = busyText ?? "Processing";
        try
        {
            await operation?.Invoke();
        }
        finally
        {
            IsBusy = false;
            BusyText = "Processing";

        }
    }

}


//public WorkoutViewModel()
//{
//    Items = new ObservableCollection<string>();
//}




//[ObservableProperty]
//ObservableCollection<string> items;

//[ObservableProperty]
//string name;

//[ObservableProperty]
//string sets;

//[ObservableProperty]
//string reps;

//[RelayCommand]

//void Add()
//{
//    //Adding Name
//    if (string.IsNullOrWhiteSpace(name))
//        return;
//    if (string.IsNullOrWhiteSpace(sets))
//        return;
//    if (string.IsNullOrWhiteSpace(reps))
//        return;

//    Items.Add(name);
//    Items.Add(sets);
//    Items.Add(reps);

//    name = string.Empty;
//    sets = string.Empty;
//    reps = string.Empty;


//}

//[RelayCommand]

//void Delete(string s)
//{
//    if (Items.Contains(s))
//    { Items.Remove(s); }

//}

//}