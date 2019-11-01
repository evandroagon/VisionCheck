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
        public int index = 9; //indice 9 representa o tamanho 20/200 este é o tamnho inicial para o primeiro optotipo apresentado.
//#pragma warning disable CS0414 // O campo "Page1.i" é atribuído, mas seu valor nunca é usado
  //      private int i = 0;
//#pragma warning restore CS0414 // O campo "Page1.i" é atribuído, mas seu valor nunca é usado
        private double angulo_retorno;
        private double angulo = 1.0;




        public Page1()

        {
            InitializeComponent();

            Title = "Teste de Snnellen";
            //var vetTamanhos = CriarVetTamanhos();



            labelOptotipoE.FontSize = Session.Instance.UserTamanho;
            labelOptotipoE.Text = "E";
            labelOptotipoE.VerticalTextAlignment = TextAlignment.End;


            if (fatorAtual == 0)
            {
                index = 9;
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

            angulo = GirarObjeto(label: labelOptotipoE);


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
            labelOptotipoE.FontSize = (Session.Instance.UserTamanho / 10 * fatorAtual);
            labelOptotipoE.HorizontalTextAlignment = TextAlignment.Center;
            labelOptotipoE.Text = $"E";
            //return angulo; // retorna o angulo rosteado para comparar com a resposta do usuário

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
                labelOptotipoE.FontSize = (Session.Instance.UserTamanho / 10 * fatorAtual);

                labelOptotipoE.Text = $"E";


                angulo = GirarObjeto(labelOptotipoE); // gira o optotipo
            };


            await Navigation.PushModalAsync(paginaRespostas, true);




        }
    }

}


