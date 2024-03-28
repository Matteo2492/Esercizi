using PURIFICAMI_SIGNORE.DAL;
using PURIFICAMI_SIGNORE.Models;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PURIFICAMI_SIGNORE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void btnCategorie_Click(object sender, RoutedEventArgs e)
        {
            GestioneCategorie finestra = new GestioneCategorie();
            finestra.Show();
            this.Close();
        }
        private void btnProdotti_Click(object sender, RoutedEventArgs e)
        {
            GestioneProdotti finestra = new GestioneProdotti();
            finestra.Show();
            this.Close();
        }
        private void btnVariazioni_Click(object sender, RoutedEventArgs e)
        {
            GestioneVariazione finestra = new GestioneVariazione();
            finestra.Show();
            this.Close();
        }
        private void btnUtenti_Click(object sender, RoutedEventArgs e)
        {
            GestioneUtente finestra = new GestioneUtente();
            finestra.Show();
            this.Close();
        }
    }
}