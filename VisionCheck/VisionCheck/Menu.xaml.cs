﻿using Xamarin.Forms;
using VisionCheck.View;
using Xamarin.Forms.Xaml;

namespace VisionCheck
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Menu : MasterDetailPage
	{
		public Menu ()
		{
			InitializeComponent ();
            Detail = new NavigationPage(new MenuDetail());
		}

        private void GoPage1(object sender, System.EventArgs e)
        {
            Detail.Navigation.PushAsync(new Page1());
            IsPresented = false;
        }
        private void GoPage2(object sender, System.EventArgs e)
        {
            Detail.Navigation.PushAsync(new Page2());
            IsPresented = false;
        }
        private void GoPage3(object sender, System.EventArgs e)
        {
            Detail.Navigation.PushAsync(new Page3());
            IsPresented = false;
        }

        private void GoPageCalib(object sender, System.EventArgs e)
        {
            Detail.Navigation.PushAsync(new PageCalib());
            IsPresented = false;
        }
    }
}