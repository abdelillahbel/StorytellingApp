using System.Speech.Synthesis;

namespace StorytellingApp
{
    public partial class ShowStoryPage : ContentPage
    {
        public Story Story { get; set; }

        public ShowStoryPage(Story story)
        {
            InitializeComponent();

            Story = story;
            BindingContext = this;
        }

        CancellationTokenSource cts;

        private async void OnSpeakButtonClicked(object sender, EventArgs e)
        {
            cts = new CancellationTokenSource();
            var locales = await TextToSpeech.GetLocalesAsync();
            var locale =
                locales.FirstOrDefault(l => l.Country.Equals("AR", StringComparison.InvariantCultureIgnoreCase));

            var settings = new SpeechOptions()
            {
                Pitch = 1.0f, // 0.0 - 2.0
                Volume = 0.75f, // 0.0 - 1.0
                Locale = locale
            };

            await TextToSpeech.SpeakAsync(Story.Content!, settings, cancelToken: cts.Token);
        }

        private void OnPauseButtonClicked(object sender, EventArgs e)
        {
            // Pause functionality is not available in Xamarin.Essentials.TextToSpeech
        }

        private void OnStopButtonClicked(object sender, EventArgs e)
        {
            CancelSpeech();
            // Stop functionality is not available in Xamarin.Essentials.TextToSpeech
        }

        private void CancelSpeech()
        {
            if (cts?.IsCancellationRequested ?? true)
                return;

            cts.Cancel();
        }
    }
}