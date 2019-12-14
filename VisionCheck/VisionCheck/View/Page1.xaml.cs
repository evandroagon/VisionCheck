using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Random = System.Random;


namespace VisionCheck.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        //private string tamanhoAtual = "20/20";
        public double fatorAtual = 0;
        public double Tamanho_base = Session.Instance.UserTamanho;
        public int index = 14; //indice 9 representa o tamanho 20/400 este é o tamnho inicial para o primeiro optotipo apresentado.
        private double angulo_retorno;
        private double angulo = 1.0;
        private string CorFundo = "#fefefe";
        private string CorE = "#010101";
        private string CorEscala = "#010101";
        public int cert = 0, err = 0;
        public bool fimExame = false;
        public int ultimaRespostaCorreta = 0;


        public Page1()

        {
            InitializeComponent();

            Title = "Teste de Snellen";
            //var vetTamanhos = CriarVetTamanhos();



            labelOptotipoE.FontSize = Session.Instance.UserTamanho;
            labelTipoExame.Text = "Distância: " + Convert.ToString(Session.Instance.UserDistancia) + " cm";
            labelOptotipoE.Text = "E";
            if (Session.Instance.UserContrasteAlto) //Define preferencias do usuário 
            {
                labelOptotipoE.TextColor = Color.FromHex(CorE);
                labelOptotipoE.BackgroundColor = Color.FromHex(CorFundo);
                labelTipoExame.TextColor = Color.FromHex(CorEscala);
                labelTipoExame.BackgroundColor = Color.FromHex(CorFundo);
                lblTamanho.TextColor = Color.FromHex(CorEscala);
                lblTamanho.BackgroundColor = Color.FromHex(CorFundo);
                lblTamanhoDec.TextColor = Color.FromHex(CorEscala);
                lblTamanhoDec.BackgroundColor = Color.FromHex(CorFundo);
                GridExame.BackgroundColor = Color.FromHex(CorFundo);
                NextButton.BorderColor = Color.FromHex(CorFundo);
            }
            else
            {
                labelOptotipoE.TextColor = Color.FromHex(CorFundo);
                labelOptotipoE.BackgroundColor = Color.FromHex(CorEscala);
                labelTipoExame.TextColor = Color.FromHex(CorFundo);
                labelTipoExame.BackgroundColor = Color.FromHex(CorEscala);
                lblTamanho.TextColor = Color.FromHex(CorFundo);
                lblTamanho.BackgroundColor = Color.FromHex(CorEscala);
                lblTamanhoDec.TextColor = Color.FromHex(CorFundo);
                lblTamanhoDec.BackgroundColor = Color.FromHex(CorEscala);
                GridExame.BackgroundColor = Color.FromHex(CorEscala);
                NextButton.BorderColor = Color.FromHex(CorFundo);

            }

            //labelOptotipoE.VerticalTextAlignment = TextAlignment.End;

            fimExame = false;

            if (fimExame)
            {
                index = 14;
                fatorAtual = Session.varTamanhos[index].value;

                if (fimExame)
                {
                    MostrarResultado();
                }


            }


            


        

            if (fatorAtual == 0)
            {
                index = 14;
                fatorAtual = Session.varTamanhos[index].value;
               
            } 

            angulo = GirarObjeto(label: labelOptotipoE);
            UpdateTela(index);

        }


        private async void MostrarResultado()
        {
           var i = 14;
            while (Session.varTamanhos[i].resposta == "correta")
            {
                ultimaRespostaCorreta = i;
                    i--;
                
            }

           // var complemento = "";
           // if(Session.varTamanhos[14].resposta != "correta"){
         //       complemento = " < ";
                
          //  }
          

            
            // mostar as respostas corretas e ver a accuidade visual do usuário.
            string resposta = "";                

                var resultado = await DisplayAlert("Resultados", "Final do Teste" + "\r\nRespostas Corretas = " + cert +
                "\r\nRespostas Incorretas = " + err +
                "\r\nAcuidade Visual:" +
                "\r\nSnellen:" + Session.varTamanhos[ultimaRespostaCorreta].name +
                "\r\nDec.:" + Session.varTamanhos[ultimaRespostaCorreta].value.ToString() +
                " ou " + (Session.varTamanhos[ultimaRespostaCorreta].value * 100).ToString() + "%", "Sair", "Repetir o teste");
                resposta = resultado ? "s" : "r";
                if (resposta == "s")
                {
                    await Navigation.PopToRootAsync();
                }
                else
                {
                    await Navigation.PopAsync(); //voltar para pagina anterior

                }
            
        }
    
            

        private double GirarObjeto(Label label)
        {

            int numLados = 0;
            //Double angulo = 0;
            Random randNum = new Random();

            numLados = randNum.Next(0, 4);

            switch (numLados)

            {
                case 0:
                    angulo = 0.0f;
                    label.Rotation = angulo;
                    break;
                case 1:
                    angulo = 90.0f;
                    label.Rotation = angulo;
                    break;
                case 2:
                    angulo = 180.0f;
                    label.Rotation = angulo;
                    break;
                case 3:
                    angulo = 270.0f;
                    label.Rotation = angulo;
                    break;
            }

            return (angulo);
        }

        private void UpdateTela(int i)
        {
            
            lblTamanho.Text = "Snellen: " + Session.varTamanhos[i].name;
            lblTamanhoDec.Text = "Dec.: " + Math.Round(Session.varTamanhos[i].value, 3)+
                                             "\r\n"+ Math.Round(Session.varTamanhos[i].value, 3)*100 +"%";
            labelNrOptotipo.Text = "Nr.: " + Convert.ToString(i + 1);  
            
        }

        private void BackButtonClicked(object sender, EventArgs e)
        {
            angulo = GirarObjeto(labelOptotipoE);  //variavel angulo recebe o valor do 
                                                   //angulo de giro que será utilizada para verificar se o usuario acertou a resposta
            index++;
            if (fatorAtual == 0)
            {
                index = 14;
                fatorAtual = Session.varTamanhos[index].value;
            }
            if (index < Session.varTamanhos.Count)
            {
                fatorAtual = Session.varTamanhos[index].value;
                lblTamanho.Text = Session.varTamanhos[index].name;
            }
            else
            {
                index = 0;
                fatorAtual = Session.varTamanhos[index].value;
                lblTamanho.Text = Session.varTamanhos[index].name;
            }
            Session.varTamanhos[index].angulo = angulo;
            labelOptotipoE.FontSize =  Tamanho_base / (fatorAtual * 20);  //* 20 porque a referencia é o tamamho 20/400
            labelOptotipoE.HorizontalTextAlignment = TextAlignment.Center;
            labelOptotipoE.Text = $"E";
            UpdateTela(index);
            //return angulo; // retorna o angulo sorteado para comparar com a resposta do usuário

        }

        private async void NextButtonClicked(object sender, EventArgs e)
        {
           
            if (index >= 0 && !fimExame)
            {
               await abrePaginaRespostas(angulo_retorno, EventArgs.Empty);
                
            }
           
                                          
            if (fimExame)
            {
                MostrarResultado();
                
            }
        }




        private async Task abrePaginaRespostas(object sender, EventArgs e)
        {

            // criando a pagina de respostas como modalPage e amarrando um método ao ModalHandler
            var paginaRespostas = new Page3();
            //double angulo_retorno = 0;
            paginaRespostas.ModalHandler += (o, args) =>
            { // aqui tarefas realizadas após o retorno da pagina modal
                angulo_retorno = (double)o;
                if (angulo == angulo_retorno)
                {
                    
                    Session.Instance.AtualizarTamanhos(index, "correta");
                }
                else
                {
          
                    Session.Instance.AtualizarTamanhos(index, "incorreta");

                }

                if (index >= 0) { index--; }
          
                if (index >= 0)
                {
                    fatorAtual = Session.varTamanhos[index].value;
                    lblTamanho.Text = Session.varTamanhos[index].name;

                }
                else
                {
                    index = 0; //troquei o zero por 14 testando
                    fatorAtual = Session.varTamanhos[index].value;
                    lblTamanho.Text = Session.varTamanhos[index].name;
                    fimExame = true;
                    cert = 0; err = 0;
                    //ultimaRespostaCorreta = 0;
                    for (int i = 14; i >= 0; i--)
                    {
                        if (Session.varTamanhos[i].resposta == "correta")
                        {
                            cert = cert + 1;
                            //ultimaRespostaCorreta = i;
                        }
                        else
                        {
                            err = err + 1;
                        }

                        System.Console.WriteLine("DEBUG - " + "resposta:" + Session.varTamanhos[i].resposta);
                        // fimExame = true;
                    }


                }
                fatorAtual = Session.varTamanhos[index].value;
                labelOptotipoE.FontSize = Tamanho_base / (fatorAtual * 20);
                labelOptotipoE.Text = $"E";
                angulo = GirarObjeto(labelOptotipoE); // gira o optotipo
                UpdateTela(index);
            };

            if (!fimExame)
            {
                await Navigation.PushModalAsync(paginaRespostas, false);
            }
            else
            {
                
            }
                          


        }
    }

}


