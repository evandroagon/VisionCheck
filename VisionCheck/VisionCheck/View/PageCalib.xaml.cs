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
    public partial class PageCalib : ContentPage
    {
        public PageCalib()

        {
            double distancia = 1.0;
            double fator = 34.37;
            InitializeComponent();
            slider.Value = 100 + (fator * distancia);


            
        }




    }
}