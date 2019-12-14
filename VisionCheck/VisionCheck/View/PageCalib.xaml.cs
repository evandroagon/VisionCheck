using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
//using LiveSharp;
using Xamarin.Essentials;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace VisionCheck.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageCalib : ContentPage
    {
        public PageCalib()
        {
            Title = "Calibração do Optotipo";
            // testando medir o tamanho da tela

            // Get Metrics
            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;

            // Width (in pixels)
            var width = mainDisplayInfo.Width;

            // Height (in pixels)
            var height = mainDisplayInfo.Height;

            // Screen density
            var density = mainDisplayInfo.Density;

            System.Console.WriteLine("DEBUG - " + "Largura:" + width + "Altura" + height +
                                                                         "Densidade" + density);
            //fim testando medir tela

            double angle;
            double radians;
            double result;
            double alturaReferencia; //altura esperada para a distancia selecionada e optoripo tamanho 20/200
            //recuperar valores passados na classe Session responsável por troca de valores entre as várias telas
            double distancia = Session.Instance.UserDistancia; // distancia do olho até o optotipo informada pelo usuário
            double fator = Session.Instance.UserFator; // fator de correção calculado dividindo o tamanho medido de um optotipo com fonte 100 real na tela pelo valor da altura de referencia.
            double tamanho = Session.Instance.UserTamanho; //tamanho para 20/20
            double tamanhoMedido = Session.Instance.UserTamanhoMedido;  //tamanho informado para uma fonte tamanho 100
            bool mostrarEscala = Session.Instance.UserMostrarEsc;
            bool mostrarDistancia = Session.Instance.UserMostrarDist;
            bool contrate_Alto = Session.Instance.UserContrasteAlto;


            angle = (5.0 / 60.0); //angulo 5' em graus
            radians = angle * (Math.PI / 180); //convertendo em radianos
            result = Math.Tan(radians); //tangente do angulo de 5'
            alturaReferencia = result * distancia;   //calculo da altura do optotipo teorico esperado em centimetros para a distancia informada (*20 para usar a distância do 20/400)

            InitializeComponent();
            Title = "Calibração";
            App.Current.On<Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Resize);
            if (tamanho > 0)
            {

                slider.Value = tamanhoMedido;
                LabelE.FontSize = tamanho;
                SwitchContrasteAlto.On = contrate_Alto; //recuperar configuração antiga
                SwitchDistancia.On = mostrarDistancia;
                SwitchMostrarEscala.On = mostrarEscala;
                if (distancia > 0)
                {
                    ValorDistancia.Text = distancia.ToString();
                }


            }
            else
            {
                slider.Value = tamanhoMedido;
                ValorDistancia.Text = distancia.ToString();
            }

            ValorDistancia.Completed += (sender, args) =>
            {

                distancia = Convert.ToDouble(ValorDistancia.Text);
                alturaReferencia = (result * distancia*20); //aqui altura calculada é 20/400 (multiplicado por 20 para dar tamanho do 20/400)
                tamanhoMedido = slider.Value;
                fator = alturaReferencia / tamanhoMedido; //fator 20 (angulo do 20/400)
                tamanho = 100 * fator;   // 100 é tamanho da fonte do optotipo de referenica para 20/400
                Session.Instance.UserDistancia = distancia;
                Session.Instance.UserFator = fator;
                LabelE.FontSize = tamanho;
                Session.Instance.UserTamanho = tamanho; // fonte a ser usada no 20/400
                Session.Instance.UserTamanhoMedido = tamanhoMedido;

            };



            slider.ValueChanged += (sender, args) =>
            {

                tamanhoMedido = slider.Value;
                alturaReferencia = (result * distancia*20);
                fator = (alturaReferencia) / tamanhoMedido;
                tamanho = 100 * fator;
                
                Session.Instance.UserFator = fator;
                LabelE.FontSize = tamanho;
                Session.Instance.UserTamanho = tamanho;
                Session.Instance.UserTamanhoMedido = tamanhoMedido;

            };

            ;


        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            string my_preferences = "my_preferences";  // nome do repositorio de preferencias personalizado        
  

            double tamanhoMedido = Session.Instance.UserTamanhoMedido;
            Preferences.Set("tamanhoMedido_p", tamanhoMedido, my_preferences);
            double distancia = Session.Instance.UserDistancia;
            Preferences.Set("distancia_p", distancia, my_preferences);
            double fator = Session.Instance.UserFator;
            Preferences.Set("fator_p", fator, my_preferences);
            double tamanho = Session.Instance.UserTamanho;
            Preferences.Set("tamanho_p", tamanho, my_preferences);

        }


        private async void Button_Clicked(object sender, EventArgs e)
        {
            var resultado = await DisplayAlert("Título", "Mensagem do alerta", "Botão OK", "Cancelar");
            Label.Text = resultado ? "Botão OK clicado" : "Botão Cancelar clicado";
            await Task.Delay(10000);
            Label.Text = "";
            if (resultado)

            {
                string valor_distancia = ValorDistancia.Text;
                string my_preferences = "my_preferences";  // nome do repositorio de preferencias personalizado

                Preferences.Set("key_distancia", valor_distancia, my_preferences);
                              

                double tamanhoMedido = Session.Instance.UserTamanhoMedido;
                Preferences.Set("tamanhoMedido_p", tamanhoMedido, my_preferences);
                double distancia = Session.Instance.UserDistancia;
                Preferences.Set("distancia_p", distancia, my_preferences);
                double fator = Session.Instance.UserFator;
                Preferences.Set("fator_p", fator, my_preferences);
                double tamanho = Session.Instance.UserTamanho;
                Preferences.Set("tamanho_p", tamanho, my_preferences);
            }



        }

        private async void Button_Carregar_Clicked(object sender, EventArgs e)
        {

            var resultado = await DisplayAlert("Título", "Mensagem do alerta", "Botão OK", "Cancelar");
            Label.Text = resultado ? "Botão OK clicado" : "Botão Cancelar clicado";
            await Task.Delay(10000);
            Label.Text = "";
            if (resultado)

            {
                string valor_distancia = "";
                ValorDistancia.Text = Preferences.Get("key_distancia", valor_distancia);
                string my_preferences = "my_preferences";  // nome do repositorio de preferencias personalizado
                double tamanhoMedido = Preferences.Get("tamanhoMedido_p", 2.908884, my_preferences);
                double distancia = Preferences.Get("distancia_p", 0.4, my_preferences);
                double fator = Preferences.Get("fator_p", 1.0, my_preferences);
                double tamanho = Preferences.Get("tamanho_p", 100.0, my_preferences);
                Session.Instance.UserDistancia = distancia; //em metros
                Session.Instance.UserFator = fator; //relação entre tamanho medido e tamanho esperado
                Session.Instance.UserTamanho = tamanho;
                Session.Instance.UserTamanhoMedido = tamanhoMedido;



            }
        }

        private void Mudar_Switch_Escala(object sender, ToggledEventArgs e)
        {            
            Session.Instance.UserMostrarEsc =SwitchMostrarEscala.On;
            
        }

        private void Mudar_Switch_ContrateAlto(object sender, ToggledEventArgs e)
        {
            Session.Instance.UserContrasteAlto = SwitchContrasteAlto.On;
            if (SwitchContrasteAlto.On)
            {
                SwitchContrasteAlto.Text = "Contraste Baixo:";
            }
            else
            {
                SwitchContrasteAlto.Text = "Contraste Alto:";
            }
        }

            private void Mudar_SwitchDistancia(object sender, ToggledEventArgs e)
        {
            Session.Instance.UserMostrarDist = SwitchDistancia.On;
        }
    }
}