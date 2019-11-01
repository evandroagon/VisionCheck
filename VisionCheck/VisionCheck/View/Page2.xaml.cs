using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml.Internals;
using Xamarin.Forms.Xaml;


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
            InitializeComponent();
            ImageIshihara.Source = Models.imagem.varImagens[i].value;
            NrSlide.Text = "Nr.:" + (Models.imagem.varImagens[i].id).ToString();
    
            Btn1.Text = "12";
            Btn2.Text = "2";
            Btn3.Text = "1";
            Btn4.Text = "Nenhuma";
            //new Models.Respostas();

        }


        public async void ButtonOnClick(Object sender, EventArgs e)
        {
            //var resp = Models.Respostas.varImagens[i];
            BotaoClicado = true;
            Button iBotao = (Button)sender;
            if (i >= 0 && i <= 23)
            {
                if (iBotao.Text == Models.imagem.varImagens[i].normal)
                {
                    await DisplayAlert("Atenção", "Resposta Correta", "OK");

                    //Models.imagem.varImagens[i].resposta = iBotao.Text.ToString();
                    //resp = new Models.Respostas();
                    Models.VetImagens v = Models.imagem.varImagens[i];
                    v.resposta = iBotao.Text.ToString();
                    Models.imagem.varImagens[i] = v;

                    //Models.imagem.varImagens[i].resposta= iBotao.Text.ToString();
                  
                    contCorreta = contCorreta + 1;
                }
                else
                if (iBotao.Text == Models.imagem.varImagens[i].daltonico)
                {
                    // System.Diagnostics.Debugger.Break(); //teste debug

                    await DisplayAlert("Atenção", "Resposta daltonico", "OK");
                    
                    //Models.imagem.varImagens[i].resposta = iBotao.Text.ToString();
                    Models.imagem.varImagens[i].resposta = iBotao.Text.ToString();
                    contDaltonico = contDaltonico + 1;

                }
                else
                 if (iBotao.Text == Models.imagem.varImagens[i].fake)
                {
                    await DisplayAlert("Atenção", "Resposta fake", "OK");
                    //Models.imagem.varImagens[i].resposta = iBotao.Text.ToString();
                    Models.imagem.varImagens[i].resposta = iBotao.Text.ToString();
                    contDaltonico = contDaltonico + 1;
                }
                else
                {
                    await DisplayAlert("Atenção", "Resposta nenhuma", "OK");
                    //Models.imagem.varImagens[i].resposta = iBotao.Text.ToString();
                    Models.imagem.varImagens[i].resposta = iBotao.Text.ToString();
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
                    Btn1.Text = Models.imagem.varImagens[i].normal;
                    Btn2.Text = Models.imagem.varImagens[i].daltonico;
                    Btn3.Text = Models.imagem.varImagens[i].fake;
                    break;
                case 1:
                    Btn1.Text = Models.imagem.varImagens[i].normal;
                    Btn2.Text = Models.imagem.varImagens[i].fake;
                    Btn3.Text = Models.imagem.varImagens[i].daltonico;
                    break;
                case 2:
                    Btn1.Text = Models.imagem.varImagens[i].daltonico;
                    Btn2.Text = Models.imagem.varImagens[i].normal;
                    Btn3.Text = Models.imagem.varImagens[i].fake;
                    break;
                case 3:
                    Btn1.Text = Models.imagem.varImagens[i].daltonico;
                    Btn2.Text = Models.imagem.varImagens[i].fake;
                    Btn3.Text = Models.imagem.varImagens[i].normal;
                    break;
                   
                case 4:
                    Btn1.Text = Models.imagem.varImagens[i].fake;
                    Btn2.Text = Models.imagem.varImagens[i].normal;
                    Btn3.Text = Models.imagem.varImagens[i].daltonico;
                    break;
                case 5:
                    Btn1.Text = Models.imagem.varImagens[i].fake;
                    Btn2.Text = Models.imagem.varImagens[i].daltonico;
                    Btn3.Text = Models.imagem.varImagens[i].normal;
                    break;
            }           
          
        }

        private async void Back()
        {
            if (i > 0 && i <= 23)
            {
                i--;

                ImageIshihara.Source = Models.imagem.varImagens[i].value;
                NrSlide.Text = "Nr.:" + (Models.imagem.varImagens[i].id).ToString();

                await AtualizaProgressBar(progressIshihara,
                    (Convert.ToDouble(i) / 24.0));



            }
            else
            {
                i = 0;
                ImageIshihara.Source = Models.imagem.varImagens[i].value;
                NrSlide.Text = "Nr.:" + (Models.imagem.varImagens[i].id).ToString();

                await AtualizaProgressBar(progressIshihara, .0);

            }
        }

        private async void Play()
        {
            if (i >= 0 && i <=23)
            {
                if (i < 23) { i++;}else { i = 0; }
                
                
                ImageIshihara.Source = Models.imagem.varImagens[i].value;
                NrSlide.Text = "Nr.:" + (Models.imagem.varImagens[i].id).ToString();
                //var vet = Models.imagem.varImagens;             

                if (i < 23) { 
                await AtualizaProgressBar(progressIshihara,
                    (Convert.ToDouble(i) / 24.0));
                }else if (i == 23)
                {
                await AtualizaProgressBar(progressIshihara, 1.0);
                }
                else if (i==0)
                {
                await AtualizaProgressBar(progressIshihara, .0);
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
                    Debug.Write("DEBUG-Evandro ----" + Models.imagem.varImagens[j].resposta);
                }


                
            }

           
        }


    }

}