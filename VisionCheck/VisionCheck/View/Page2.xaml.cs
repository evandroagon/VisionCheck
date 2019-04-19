using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VisionCheck.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page2 : ContentPage
        
    {
        Label label;
        int clickTotal = 0;
        public Page2 ()
		{
            //InitializeComponent ();
            Label header = new Label
            {
                Text = "ImageButton",
                FontSize = 50,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) => {
                // handle the tap
            };

           

            Image imageButton = new Image
            {
                Source = "XamarinLogo.png",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            imageButton.GestureRecognizers.Add(tapGestureRecognizer);


            label = new Label
            {
                Text = "0 ImageButton clicks",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            // Build the page.
            Title = "ImageButton Demo";
            Content = new StackLayout
            {
                Children =
            {
                header,
                imageButton,
                label
            }
            };
        }

        void OnTapGestureRecognizerTapped(object sender, EventArgs args)
        {
            clickTotal += 1;
            label.Text = $"{clickTotal} ImageButton click{(clickTotal == 1 ? "" : "s")}";
        }
    }
}