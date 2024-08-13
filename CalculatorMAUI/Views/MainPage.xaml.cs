namespace CalculatorMAUI.Views;

public partial class MainPage : ContentPage
{
    // The MainPage constructor takes a MainViewModel as a parameter, this is the ViewModel that will be bound to the page
    // This is part of the dependency injection setup
    public MainPage(MainViewModel viewModel)
	{
		InitializeComponent();
        // Set the BindingContext of the page to the ViewModel
        BindingContext = viewModel;
	}
}
