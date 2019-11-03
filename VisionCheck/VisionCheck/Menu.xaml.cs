using Xamarin.Forms;
using VisionCheck.View;
using Xamarin.Forms.Xaml;

namespace VisionCheck
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : MasterDetailPage
    {
        public Menu()
        {
            InitializeComponent();
            Detail = new NavigationPage(new MenuDetail());
         
        }

        private void GoPage1(object sender, System.EventArgs e)
        {
            Detail.Navigation.PopToRootAsync();  // elimina a pilha de paginas
            Detail.Navigation.PushAsync(new Page1());
            IsPresented = false; // faz menu se esconder apos selecionar uma pagina
        }
        private void GoPage2(object sender, System.EventArgs e)
        {
            Detail.Navigation.PopToRootAsync();
            Detail.Navigation.PushAsync(new Page2());
            IsPresented = false;
        }
        private void GoPage3(object sender, System.EventArgs e)
        {
            Detail.Navigation.PopToRootAsync();
            Detail.Navigation.PushAsync(new Page3());
            IsPresented = false;
        }

        private void GoPageCalib(object sender, System.EventArgs e)
        {
            Detail.Navigation.PopToRootAsync();
            Detail.Navigation.PushAsync(new PageCalib());
            IsPresented = false;
        }

        private void GoListView(object sender, System.EventArgs e)
        {
            Detail.Navigation.PopToRootAsync();
            Detail.Navigation.PushAsync(new ListViewPage1(Models.imagem.varImagem));
            IsPresented = false;
        }


    }
}