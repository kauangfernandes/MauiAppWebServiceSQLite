using System.Diagnostics;

namespace MauiAppWebServiceSQLite
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        /*
           -    Metodo para caputarar campo input cidade.
        */
        private void Button_Clicked(object sender, EventArgs e)
        {
            string cidade = inputCidade.Text;
            lbl_previsao.Text = cidade;
        }
    }

}
