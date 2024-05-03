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
    /// Logica di interazione per GestioneVariazione.xaml
    /// </summary>
    public partial class GestioneVariazione : Window
    {
        public GestioneVariazione()
        {
            InitializeComponent();

            List<Variazione> elenco = VariazioneDAL.getIstanza().GetAll();

            dgVariazione.ItemsSource = elenco;
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow finestra = new MainWindow();
            finestra.Show();
            this.Close();
        }
        private void btnSalvaV_Click(object sender, RoutedEventArgs e)
        {
            int codice = Convert.ToInt32(this.tbCodice.Text);
            decimal prezzo = Convert.ToDecimal(this.tbPrezzo.Text);
            decimal prezzoOfferrta = Convert.ToDecimal(this.tbPrezzoOfferta.Text);
            //DateOnly dataInizio = Convert.ToDateTime(this.tbDataInizio.Text);
            //DateOnly dataFine = Convert.ToDateTime(this.tbDataFine.Text);
            string? colore = this.tbColore.Text;
            string? taglia = this.tbTaglia.Text;
            int quantita = Convert.ToInt32(this.tbQuantita.Text);
            string? link = this.tbLink.Text;
            int prodottoRif = Convert.ToInt32(this.tbProdottoRIF.Text);
            Variazione temp = new Variazione()
            {
                Codice = codice,
                Prezzo = prezzo,
                PrezzoOfferta = prezzoOfferrta,
                //DataInizioOfferta = dataInizio,
                //DataFineOfferta = dataFine,
                Colore = colore,
                Taglia = taglia,
                Quantita = quantita,
                ImmagineLink = link,
                ProdottoRif =prodottoRif
            };

            if (VariazioneDAL.getIstanza().Insert(temp))
            {
                List<Utente> elenco = UtenteDAL.getIstanza().GetAll();

                dgVariazione.ItemsSource = elenco;

                MessageBox.Show("Inserimento variazione avvenuto!");
            }
            else
            {
                MessageBox.Show("Errore");
            }
            this.tbCodice.Text = "";
            this.tbPrezzo.Text = "";
            this.tbPrezzoOfferta.Text = "";
            this.tbDataInizio.Text = "";
            this.tbDataFine.Text = "";
            this.tbColore.Text = "";
            this.tbTaglia.Text = "";
            this.tbQuantita.Text = "";
            this.tbLink.Text = "";
            this.tbProdottoRIF.Text = "";
        }
        private void btnUpdateV_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(this.tbIDVU.Text);
            int codice = Convert.ToInt32(this.tbCodice.Text);
            decimal prezzo = Convert.ToDecimal(this.tbPrezzo.Text);
            decimal prezzoOfferrta = Convert.ToDecimal(this.tbPrezzoOfferta.Text);
            //DateOnly dataInizio = Convert.ToDateTime(this.tbDataInizio.Text);
            //DateOnly dataFine = Convert.ToDateTime(this.tbDataFine.Text);
            string? colore = this.tbColore.Text;
            string? taglia = this.tbTaglia.Text;
            int quantita = Convert.ToInt32(this.tbQuantita.Text);
            string? link = this.tbLink.Text;
            int prodottoRif = Convert.ToInt32(this.tbProdottoRIF.Text);

            Variazione temp = new Variazione()
            {
                VariazioneId = id,
                Codice = codice,
                Prezzo = prezzo,
                PrezzoOfferta = prezzoOfferrta,
                //DataInizioOfferta = dataInizio,
                //DataFineOfferta = dataFine,
                Colore = colore,
                Taglia = taglia,
                Quantita = quantita,
                ImmagineLink = link,
                ProdottoRif = prodottoRif
            };

            if (VariazioneDAL.getIstanza().Update(temp))
            {
                List<Variazione> elenco = VariazioneDAL.getIstanza().GetAll();

                dgVariazione.ItemsSource = elenco;

                MessageBox.Show("Update variazione avvenuto!");
            }
            else
            {
                MessageBox.Show("Errore");
            }
            this.tbIDVU.Text = "";
            this.tbCodice.Text = "";
            this.tbPrezzo.Text = "";
            this.tbPrezzoOfferta.Text = "";
            this.tbDataInizio.Text = "";
            this.tbDataFine.Text = "";
            this.tbColore.Text = "";
            this.tbTaglia.Text = "";
            this.tbQuantita.Text = "";
            this.tbLink.Text = "";
            this.tbProdottoRIF.Text = "";
        }
        private void btnDeleteV_Click(object sender, RoutedEventArgs e)
        {
            int nome = Convert.ToInt32(this.tbIDVD.Text);

            if (VariazioneDAL.getIstanza().DeleteByID(nome))
            {
                List<Variazione> elenco = VariazioneDAL.getIstanza().GetAll();

                dgVariazione.ItemsSource = elenco;

                MessageBox.Show("Delete utente avvenuto!");
            }
            else
            {
                MessageBox.Show("Errore");
            }
            this.tbIDVD.Text = "";
        }
    }
}
