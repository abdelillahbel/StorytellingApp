namespace StorytellingApp;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
    }

   
    private void OnExploreStoriesButtonClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new StoriesPage());
    }

    private void OnHowToUseButtonClicked(object sender, EventArgs e)
    {
        DisplayAlert("How to Use", "You clicked on How to Use", "OK");
    }

    private void OnShareFeedbackButtonClicked(object sender, EventArgs e)
    {
        DisplayAlert("Share Feedback", "You clicked on Share Feedback", "OK");
    }
}