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
    public partial class GestioneCategorie : Window
    {
        public GestioneCategorie()
        {
            InitializeComponent();

            List<Categorium> elenco = CategoriaDAL.getIstanza().GetAll();

            dgCategoria.ItemsSource = elenco;

        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow finestra = new MainWindow();
            finestra.Show();
            this.Close();
        }
        private void btnSalva_Click(object sender, RoutedEventArgs e)
        {
            string? nome = this.tbNome.Text;

            Categorium temp = new Categorium()
            {
                Nome = nome,
            };

            if (CategoriaDAL.getIstanza().Insert(temp))
            {
                List<Categorium> elenco = CategoriaDAL.getIstanza().GetAll();

                dgCategoria.ItemsSource = elenco;

                MessageBox.Show("Inserimento categoria avvenuto!");
            }
            else
            {
                MessageBox.Show("Errore");
            }
            this.tbNome.Text = "";
        }
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(this.tbIDU.Text);
            string? nome = this.tbNomeU.Text;

            Categorium temp = new Categorium()
            {
                CategoriaId = id,
                Nome = nome
            };

            if (CategoriaDAL.getIstanza().Update(temp))
            {
                List<Categorium> elenco = CategoriaDAL.getIstanza().GetAll();

                dgCategoria.ItemsSource = elenco;

                MessageBox.Show("Update categoria avvenuto!");
            }
            else
            {
                MessageBox.Show("Errore");
            }
            this.tbNome.Text = "";
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int nome = Convert.ToInt32(this.tbIDD.Text);

            if (CategoriaDAL.getIstanza().DeleteByID(nome))
            {
                List<Categorium> elenco = CategoriaDAL.getIstanza().GetAll();

                dgCategoria.ItemsSource = elenco;

                MessageBox.Show("Delete categoria avvenuto!");
            }
            else
            {
                MessageBox.Show("Errore");
            }
            this.tbNome.Text = "";
        }
        
    }
}
