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

            if (fatorAtual == 0)
            {
                index = 14;
                fatorAtual = Session.Instance.CriarVetTamanhos()[index].value;
               
            }
            if (index < Session.Instance.CriarVetTamanhos().Count)
            {
                fatorAtual = Session.Instance.CriarVetTamanhos()[index].value;
                lblTamanho.Text = Session.Instance.CriarVetTamanhos()[index].name;
            
            }
            else
            {
                index = 0;
                fatorAtual = Session.Instance.CriarVetTamanhos()[index].value;
                lblTamanho.Text = Session.Instance.CriarVetTamanhos()[index].name;
                UpdateTela(index);
            }

            angulo = GirarObjeto(label: labelOptotipoE);
            UpdateTela(index);

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
            lblTamanho.Text = "Snellen: " + Session.Instance.CriarVetTamanhos()[i].name;
            lblTamanhoDec.Text = "Dec.: " + Math.Round(Session.Instance.CriarVetTamanhos()[i].value, 3)+
                                             "\r\n"+ Math.Round(Session.Instance.CriarVetTamanhos()[i].value, 3)*100 +"%";
            labelNrOptotipo.Text = "Nr.: " + Convert.ToString(i + 1);            

        }

        private void BackButtonClicked(object sender, EventArgs e)
        {
            angulo = GirarObjeto(labelOptotipoE);  //variavel angulo recebe o valor do 
                                                   //angulo de giro que será utilizada para verificar se o usuario acertou a resposta
            index++;
            if (fatorAtual == 0)
            {
                index = 1;
                fatorAtual = Session.Instance.CriarVetTamanhos()[index].value;
            }
            if (index < Session.Instance.CriarVetTamanhos().Count)
            {
                fatorAtual = Session.Instance.CriarVetTamanhos()[index].value;
                lblTamanho.Text = Session.Instance.CriarVetTamanhos()[index].name;

            }
            else
            {
                index = 0;
                fatorAtual = Session.Instance.CriarVetTamanhos()[index].value;
                lblTamanho.Text = Session.Instance.CriarVetTamanhos()[index].name;
            }
            Session.Instance.CriarVetTamanhos()[index].angulo = angulo;
            labelOptotipoE.FontSize =  Tamanho_base / (fatorAtual * 20);  //* 20 porque a referencia é o tamamho 20/400
            labelOptotipoE.HorizontalTextAlignment = TextAlignment.Center;
            labelOptotipoE.Text = $"E";
            UpdateTela(index);
            //return angulo; // retorna o angulo sorteado para comparar com a resposta do usuário

        }

        private void NextButtonClicked(object sender, EventArgs e)
        {

            abrePaginaRespostas(angulo_retorno, EventArgs.Empty);

        }

        private async void abrePaginaRespostas(object sender, EventArgs e)
        {

            // criando a pagina de respostas como modalPage e amarrando um método ao ModalHandler
            var paginaRespostas = new Page3();
            //double angulo_retorno = 0;
            paginaRespostas.ModalHandler += (o, args) =>
            { // aqui tarefas realizadas após o retorno da pagina modal
                angulo_retorno = (double)o;
                if (angulo == angulo_retorno)
                {
                    //debugando repostas Ok funcioando beleza
                    //System.Console.WriteLine("DEBUG - " + "angulo:" + angulo + "angulo retorno" + angulo_retorno);
                    labelTipoExame.Text = ("angulo: " + angulo + "angulo retorno" + angulo_retorno + "Resp. Correta");
                    labelTipoExame.TextColor = Color.Green;
                }
                else
                {
                    labelTipoExame.Text = ("Resposta Incorreta");

                }

                if (index >= 1) { index--; }
                if (fatorAtual == 0)
                {
                    index = 1;
                    fatorAtual = Session.Instance.CriarVetTamanhos()[index].value;
                }
                if (index < Session.Instance.CriarVetTamanhos().Count)
                {
                    fatorAtual = Session.Instance.CriarVetTamanhos()[index].value;
                    lblTamanho.Text = Session.Instance.CriarVetTamanhos()[index].name;

                }
                else
                {
                    index = 0;
                    fatorAtual = Session.Instance.CriarVetTamanhos()[index].value;
                    lblTamanho.Text = Session.Instance.CriarVetTamanhos()[index].name;
                }
                fatorAtual = Session.Instance.CriarVetTamanhos()[index].value;
                labelOptotipoE.FontSize = Tamanho_base / (fatorAtual * 20);
                labelOptotipoE.Text = $"E";
                angulo = GirarObjeto(labelOptotipoE); // gira o optotipo
                UpdateTela(index);
            };


            await Navigation.PushModalAsync(paginaRespostas, true);




        }
    }

}


