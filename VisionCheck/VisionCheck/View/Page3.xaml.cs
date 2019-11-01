using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisionCheck.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VisionCheck.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page3 : ContentPage
    {
        public event EventHandler ModalHandler;
        static List<Respostas> respostas;

        public Page3()
        {
#pragma warning disable CS0219 // A variável "resposta" é atribuída, mas seu valor nunca é usado
            double resposta = 0.0;
#pragma warning restore CS0219 // A variável "resposta" é atribuída, mas seu valor nunca é usado
            InitializeComponent();
            respostas = new List<Respostas>();

        }

        private async void Button0_Clicked(object sender, EventArgs e)

        {
            double angulo_botao = 0.0;
            ModalHandler?.Invoke(angulo_botao, EventArgs.Empty);
            await Navigation.PopModalAsync(true);
        }

        private async void Button90_Clicked(object sender, EventArgs e)
        {
            double angulo_botao = 90.0;
            ModalHandler?.Invoke(angulo_botao, EventArgs.Empty);
            await Navigation.PopModalAsync(true);
        }

        private async void Button180_Clicked(object sender, EventArgs e)
        {
            double angulo_botao = 180.0;
            ModalHandler?.Invoke(angulo_botao, EventArgs.Empty);
            await Navigation.PopModalAsync(true);
        }

        private async void Button270_Clicked(object sender, EventArgs e)
        {
            double angulo_botao = 270.0;
            ModalHandler?.Invoke(angulo_botao, EventArgs.Empty);
            await Navigation.PopModalAsync(true);
        }
    }
}