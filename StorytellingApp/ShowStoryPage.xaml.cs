using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

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
    }
}