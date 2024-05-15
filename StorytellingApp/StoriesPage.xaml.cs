using Microsoft.Maui.Controls;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;

namespace StorytellingApp
{
    public partial class StoriesPage : ContentPage
    {
        public StoriesPage()
        {
            InitializeComponent();

            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(StoriesPage)).Assembly;
            Stream? stream = assembly.GetManifestResourceStream("StorytellingApp.Resources.stories.json");

            using (var reader = new StreamReader(stream!))
            {
                var json = reader.ReadToEnd();
                var stories = JsonSerializer.Deserialize<List<Story>>(json);
                StoriesCollection.ItemsSource = stories;
            }
        }

        private void OnStoryTapped(object sender, EventArgs e)
        {
            var story = (sender as Grid)!.BindingContext as Story;
            Navigation.PushAsync(new ShowStoryPage(story!));
        }
    }
}