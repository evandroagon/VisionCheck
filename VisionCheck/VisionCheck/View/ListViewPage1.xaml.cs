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



        public ListViewPage1()
        {
            InitializeComponent();
                      


            ObservableCollection<Models.VetImagens>
                items = new ObservableCollection<Models.VetImagens>();
            
                for (int v = 0; v <= 23-1; v++)
            {
                items.Add(new Models.VetImagens()
                {
                    id = Models.imagem.varImagens[v].id,
                    normal = Models.imagem.varImagens[v].normal,
                    resposta = Models.imagem.varImagens[v].resposta,
                    value = Models.imagem.varImagens[v].value});
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
