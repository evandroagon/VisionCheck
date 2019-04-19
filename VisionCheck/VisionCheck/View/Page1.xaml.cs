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


        

        public Page1()
        {
            InitializeComponent();
            labelContaCliques.FontSize = 100;

        }

        void GirarObjeto(Label label)
        {

            int numLados = 0;
            Double angulo = 0;
            Random randNum = new Random();

            numLados = randNum.Next(0, 4);

            switch (numLados)

            {


                case 0:

                    //angulo = (labelContaCliques.Rotation);
                    angulo = 0;
                    label.Rotation = angulo;

                    break;
                case 1:
                    //angulo = ((360 - labelContaCliques.Rotation)+90);
                    //if (angulo >=360) {
                    //angulo = angulo - 360;
                    //    .Rotation = angulo;
                    //}       
                    angulo = 90;
                    label.Rotation = angulo;
                    break;
                case 2:
                    //angulo = ((360 - labelContaCliques.Rotation) + 180);
                    //if (angulo >= 360)
                    //{
                    //   angulo = angulo - 360;
                    //    labelContaCliques.Rotation = angulo;
                    //}
                    angulo = 180;
                    label.Rotation = angulo;
                    break;
                case 3:
                    //angulo = ((360 - labelContaCliques.Rotation) + 270);
                    //if (angulo >= 360)
                    //{
                    //    angulo = angulo - 360;
                    //   labelContaCliques.Rotation = angulo;
                    // }
                    angulo = 270;
                    label.Rotation = angulo;
                    break;
            }



            //label.Text = $"E";

        }

        void ImageButton_Clicked(object sender, EventArgs e)
        {
            GirarObjeto(labelContaCliques);
            labelContaCliques.FontSize = (labelContaCliques.FontSize - labelContaCliques.FontSize * 1.1); ; ;
            labelContaCliques.Text = $"E";

            //labelContaCliques.Text = $"{randNum} ImageButton click{(randNum.Next(1, 4))? "" : "s")}";

        }



        void OnImageButtonClicked(object sender, EventArgs e)
        {

            GirarObjeto(labelContaCliques);
            labelContaCliques.FontSize = (labelContaCliques.FontSize + labelContaCliques.FontSize * 1.1); ; ;
            labelContaCliques.Text = $"E";

        }

        void CalularFonteInicial(Label label, int FatorCalibracao)

        {
             // cria função para ler o valor de um arquivo
                                  // valor deve ser calibrado em uma atela com auxilido de uma regua            label.FontSize = 100 * FatorCalibracao;
        
        }
    }

}