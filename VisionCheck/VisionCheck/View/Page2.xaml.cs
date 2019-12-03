using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml.Internals;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;

namespace VisionCheck.View
{
    // [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage

    {
        int i = 0;
        private bool BotaoClicado = false;
        private int contCorreta = 0;
        private int contDaltonico = 0;
        // O campo "Page2.contFake" é atribuído, mas seu valor nunca é usado
        private int contFake = 0;
        // O campo "Page2.contFake" é atribuído, mas seu valor nunca é usado
        private int contNenhum = 0;
        // O campo "Page2.contTotal" é atribuído, mas seu valor nunca é usado
        private int contTotal = 0;
        // O campo "Page2.contTotal" é atribuído, mas seu valor nunca é usado


        //ProgressBar progress = new ProgressBar();

        public Page2()
        {
            // double v = Convert.ToDouble(i) / 24.0;
            Button button = new Button();
            InitializeComponent();
            Title = "Ishihara - Teste de Cores";
            ImageIshihara.Source = Models.imagem.varImagem[i].value;
            NrSlide.Text = "Nr.:" + (Models.imagem.varImagem[i].id).ToString();

            Btn1.Text = "12";
            Btn2.Text = "2";
            Btn3.Text = "1";
            Btn4.Text = "Nenhuma";
            //new Models.Respostas();

        }


        public async void ButtonOnClick(Object sender, EventArgs e)
        {
            //var resp = Models.Respostas.varImagem[i];
            BotaoClicado = true;
            Button iBotao = (Button)sender;
            if (i >= 0 && i <= 23)
            {
                if (iBotao.Text == Models.imagem.varImagem[i].normal)
                {
                    await DisplayAlert("Atenção", "Resposta Correta", "OK");
                    Models.imagem.Instance.atualizarVet(i, iBotao.Text.ToString());

                    //Models.imagem.varImagem[i].;

                    //Models.imagem.varImagem[] v = Models.imagem.varImagem[i];
                    //v.resposta = iBotao.Text.ToString();
                    //Models.imagem.varImagem[i] = v;



                    contCorreta = contCorreta + 1;
                }
                else
                if (iBotao.Text == Models.imagem.varImagem[i].daltonico)
                {
                    // System.Diagnostics.Debugger.Break(); //teste debug

                    await DisplayAlert("Atenção", "Resposta daltonico", "OK");

                    //Models.imagem.Instance.atualizarVet(i, iBotao.Text.ToString());
                    Models.imagem.Instance.atualizarVet(i, iBotao.Text.ToString());
                    contDaltonico = contDaltonico + 1;

                }
                else
                 if (iBotao.Text == Models.imagem.varImagem[i].fake)
                {
                    await DisplayAlert("Atenção", "Resposta fake", "OK");
                    //Models.imagem.Instance.atualizarVet(i, iBotao.Text.ToString());
                    Models.imagem.Instance.atualizarVet(i, iBotao.Text.ToString());
                    contDaltonico = contDaltonico + 1;
                }
                else
                {
                    await DisplayAlert("Atenção", "Resposta nenhuma", "OK");
                    //Models.imagem.Instance.atualizarVet(i, iBotao.Text.ToString());
                    Models.imagem.Instance.atualizarVet(i, iBotao.Text.ToString());
                    contNenhum = contNenhum + 1;
                }
                Play();
                SorteiaBotoes();
            }
        }

        private void SorteiaBotoes()
        {
            int n = 0;
            Random ordenBotoes = new Random();
            n = ordenBotoes.Next(0, 5);

            switch (n)
            {
                case 0:
                    Btn1.Text = Models.imagem.varImagem[i].normal;
                    Btn2.Text = Models.imagem.varImagem[i].daltonico;
                    Btn3.Text = Models.imagem.varImagem[i].fake;
                    break;
                case 1:
                    Btn1.Text = Models.imagem.varImagem[i].normal;
                    Btn2.Text = Models.imagem.varImagem[i].fake;
                    Btn3.Text = Models.imagem.varImagem[i].daltonico;
                    break;
                case 2:
                    Btn1.Text = Models.imagem.varImagem[i].daltonico;
                    Btn2.Text = Models.imagem.varImagem[i].normal;
                    Btn3.Text = Models.imagem.varImagem[i].fake;
                    break;
                case 3:
                    Btn1.Text = Models.imagem.varImagem[i].daltonico;
                    Btn2.Text = Models.imagem.varImagem[i].fake;
                    Btn3.Text = Models.imagem.varImagem[i].normal;
                    break;

                case 4:
                    Btn1.Text = Models.imagem.varImagem[i].fake;
                    Btn2.Text = Models.imagem.varImagem[i].normal;
                    Btn3.Text = Models.imagem.varImagem[i].daltonico;
                    break;
                case 5:
                    Btn1.Text = Models.imagem.varImagem[i].fake;
                    Btn2.Text = Models.imagem.varImagem[i].daltonico;
                    Btn3.Text = Models.imagem.varImagem[i].normal;
                    break;
            }

        }

        private async void Back()
        {
            if (i > 0 && i <= 23)
            {
                i--;

                ImageIshihara.Source = Models.imagem.varImagem[i].value;
                NrSlide.Text = "Nr.:" + (Models.imagem.varImagem[i].id).ToString();

                await AtualizaProgressBar(progressIshihara,
                    (Convert.ToDouble(i) / 24.0));



            }
            else
            {
                i = 0;
                ImageIshihara.Source = Models.imagem.varImagem[i].value;
                NrSlide.Text = "Nr.:" + (Models.imagem.varImagem[i].id).ToString();

                await AtualizaProgressBar(progressIshihara, .0);

            }
        }

        private async void Play()
        {
            if (i >= 0 && i <= 23)
            {
                if (i <23) { i++; } else { i = 0; }


                ImageIshihara.Source = Models.imagem.varImagem[i].value;
                NrSlide.Text = "Nr.:" + (Models.imagem.varImagem[i].id).ToString();
                //var vet = Models.imagem.varImagem;             

                if (i <23) {
                    await AtualizaProgressBar(progressIshihara,
                        (Convert.ToDouble(i) / 24.0));
                } else if (i == 23)
                {
                    await AtualizaProgressBar(progressIshihara, 1.0);
                }
                else if (i == 0)
                {
                    await AtualizaProgressBar(progressIshihara, .0);
                }


                if (i == 0)
                {
                    ObservableCollection<Models.VetImagens> list = new ObservableCollection<Models.VetImagens>();
                    list = Models.imagem.varImagem;
                        

                    await Navigation.PushAsync(new ListViewPage1(list));
                }

            }




        }



        public async Task AtualizaProgressBar(ProgressBar progress, double V)
        {
            await progress.ProgressTo(V, 200, Easing.Linear);
            LblPorcent.Text = (int)((i + 1) * 100 / 24) + "%";

            if (i == 0)
            {
                await DisplayAlert("Parabéns!", "Fim do teste", "OK");


                for (int j = 0; j <= 23; j++)

                {

                    // Debug.Write("DEBUG-Evandro ----" + Models.imagem.CriarVetImages()[j].resposta);
                    Debug.Write("DEBUG-Evandro ----" + Models.imagem.varImagem[j].resposta);
                }
            }
        }
    }
}