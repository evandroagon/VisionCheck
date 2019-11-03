using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace VisionCheck.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewPage1 : ContentPage
    {
        //public ObservableCollection<Models.VetImagens> Items; // { get; set; }



        public ListViewPage1(ObservableCollection<Models.VetImagens> list)
        {
            InitializeComponent();
            Title = "Resultado";

            ObservableCollection<Models.VetImagens>
                items = new ObservableCollection<Models.VetImagens>();
                for (int v = 0; v <= 23; v++)
            {
                items.Add(new Models.VetImagens
                {
                    id = "Nr.:" + Models.imagem.varImagem[v].id,
                    value =Models.imagem.varImagem[v].value,
                    normal ="Normal:" + Models.imagem.varImagem[v].normal +
                    "\r\nDaltonico:" + Models.imagem.varImagem[v].daltonico +
                    "\r\nTotal:" + Models.imagem.varImagem[v].total,
                    resposta =" | Resposta:" + Models.imagem.varImagem[v].resposta
                    
                });

            }




        MyListView.ItemsSource = items;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
