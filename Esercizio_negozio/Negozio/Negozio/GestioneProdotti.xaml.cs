using PURIFICAMI_SIGNORE.DAL;
using PURIFICAMI_SIGNORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PURIFICAMI_SIGNORE
{
    /// <summary>
    /// Logica di interazione per GestioneProdotti.xaml
    /// </summary>
    public partial class GestioneProdotti : Window
    {
        public GestioneProdotti()
        {
            InitializeComponent();

            List<Prodotto> elenco = ProdottoDAL.getIstanza().GetAll();

            dgProdotto.ItemsSource = elenco;
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow finestra = new MainWindow();
            finestra.Show();
            this.Close();
        }
        private void btnSalvaP_Click(object sender, RoutedEventArgs e)
        {
            string? nome = this.tbNomeP.Text;
            string? descrizione = this.tbDescrizione.Text;
            int categoria = Convert.ToInt32(this.tbCategoriaP.Text);
            Prodotto temp = new Prodotto()
            {
                Nome = nome,
                Descrizione = descrizione,
                CategoriaRif = categoria
            };

            if (ProdottoDAL.getIstanza().Insert(temp))
            {
                List<Prodotto> elenco = ProdottoDAL.getIstanza().GetAll();

                dgProdotto.ItemsSource = elenco;

                MessageBox.Show("Inserimento prodotto avvenuto!");
            }
            else
            {
                MessageBox.Show("Errore");
            }
            this.tbNomeP.Text = "";
            this.tbDescrizione.Text = "";
            this.tbCategoriaP.Text = "";
        }
        private void btnUpdateP_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(this.tbIDPU.Text);
            string? nome = this.tbNomePU.Text;
            string? descrizione = this.tbDescrizioneU.Text;
            int categoria = Convert.ToInt32(this.tbCategoriaPU.Text);

            Prodotto temp = new Prodotto()
            {
                ProdottoId = id,
                Nome = nome,
                Descrizione = descrizione,
                CategoriaRif = categoria
            };

            if (ProdottoDAL.getIstanza().Update(temp))
            {
                List<Prodotto> elenco = ProdottoDAL.getIstanza().GetAll();

                dgProdotto.ItemsSource = elenco;

                MessageBox.Show("Update prodotto avvenuto!");
            }
            else
            {
                MessageBox.Show("Errore");
            }
            this.tbIDPU.Text = "";
            this.tbNomePU.Text = "";
            this.tbDescrizioneU.Text = "";
            this.tbCategoriaPU.Text = "";
        }
        private void btnDeleteP_Click(object sender, RoutedEventArgs e)
        {
            int nome = Convert.ToInt32(this.tbIDPD.Text);

            if (ProdottoDAL.getIstanza().DeleteByID(nome))
            {
                List<Prodotto> elenco = ProdottoDAL.getIstanza().GetAll();

                dgProdotto.ItemsSource = elenco;

                MessageBox.Show("Delete prodotto avvenuto!");
            }
            else
            {
                MessageBox.Show("Errore");
            }
            this.tbIDPD.Text = "";
        }
    }
}
