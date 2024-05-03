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
    /// Logica di interazione per GestioneUtente.xaml
    /// </summary>
    public partial class GestioneUtente : Window
    {
        public GestioneUtente()
        {
            InitializeComponent();

            List<Utente> elenco = UtenteDAL.getIstanza().GetAll();

            dgUtente.ItemsSource = elenco;
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow finestra = new MainWindow();
            finestra.Show();
            this.Close();
        }
        private void btnSalvaU_Click(object sender, RoutedEventArgs e)
        {
            string? nome = this.tbNomeU.Text;
            string? indirizzo = this.tbIndirizzo.Text;
            string? email = this.tbEmail.Text;
            Utente temp = new Utente()
            {
                Nominativo = nome,
                Indirizzo = indirizzo,
                Email = email
            };

            if (UtenteDAL.getIstanza().Insert(temp))
            {
                List<Utente> elenco = UtenteDAL.getIstanza().GetAll();

                dgUtente.ItemsSource = elenco;

                MessageBox.Show("Inserimento utente avvenuto!");
            }
            else
            {
                MessageBox.Show("Errore");
            }
            this.tbNomeU.Text = "";
            this.tbIndirizzo.Text = "";
            this.tbEmail.Text = "";
        }
        private void btnUpdateU_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(this.tbIDUU.Text);
            string? nome = this.tbNomeUU.Text;
            string? indirizzo = this.tbIndirizzoU.Text;
            string? email = this.tbEmailU.Text;

            Utente temp = new Utente()
            {
                UtenteId = id,
                Nominativo = nome,
                Indirizzo = indirizzo,
                Email = email
            };

            if (UtenteDAL.getIstanza().Update(temp))
            {
                List<Utente> elenco = UtenteDAL.getIstanza().GetAll();

                dgUtente.ItemsSource = elenco;

                MessageBox.Show("Update utente avvenuto!");
            }
            else
            {
                MessageBox.Show("Errore");
            }
            this.tbIDUU.Text = "";
            this.tbNomeU.Text = "";
            this.tbIndirizzo.Text = "";
            this.tbEmail.Text = "";
        }
        private void btnDeleteU_Click(object sender, RoutedEventArgs e)
        {
            int nome = Convert.ToInt32(this.tbIDUD.Text);

            if (UtenteDAL.getIstanza().DeleteByID(nome))
            {
                List<Utente> elenco = UtenteDAL.getIstanza().GetAll();

                dgUtente.ItemsSource = elenco;

                MessageBox.Show("Delete utente avvenuto!");
            }
            else
            {
                MessageBox.Show("Errore");
            }
            this.tbIDUD.Text = "";
        }
    }
}
