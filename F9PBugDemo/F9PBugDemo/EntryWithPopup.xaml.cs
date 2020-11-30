using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BubblePopup = Forms9Patch.BubblePopup;

namespace F9PBugDemo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EntryWithPopup : ContentView
    {
        BubblePopup popup;
        public EntryWithPopup()
        {
            InitializeComponent();
            var content = new Frame
            {
                Padding = 0,
                Margin = 0,
                Content = new Label { Text = "Popup!" }
            };
            popup = new BubblePopup(MainEntry)
            {
                PointerLength = 0,
                TargetBias = 0,
                PageOverlayColor = Color.Transparent,
                Content = content,
                CloseWhenBackgroundIsClicked = false,
                BackgroundInputTransparent = false // this doesn't work regardless of whether true or false
            };
        }

        void OnTextChanged(object sender, TextChangedEventArgs args)
        {
            var entry = sender as Entry;
            popup.IsVisible = entry.Text.Length > 0;
        }
    }
}