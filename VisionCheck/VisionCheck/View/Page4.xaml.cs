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
	public partial class Page4 : ContentPage
	{
		public Page4 ()
		{
			InitializeComponent ();
		}

        private async void GoTumblingClicked(object sender, EventArgs e)
        {
           //await  Navigation.PopToRootAsync();  // elimina a pilha de paginas
           await  Navigation.PushAsync(new Page1());
           // IsPresented = false; // faz menu se esconder apos selecionar uma pagina
        }

       
    }
}