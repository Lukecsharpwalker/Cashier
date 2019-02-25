using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity;

namespace Ubrania_Nowy
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ERPDbContext _context = new ERPDbContext();
        int id_temp;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource agreementViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("agreementViewSource")));
            agreementDataGrid.ItemsSource = _context.Agreements.ToList();
            // Załaduj dane poprzez ustawienie właściwości CollectionViewSource.Source:
            // agreementViewSource.Źródło = [ogólne źródło danych]
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            _context.Dispose();
        }

        private void add_btn_Click(object sender, RoutedEventArgs e)
        {           
            Agreement agreement = new Agreement();

            agreement.Name = name_txt.Text;
            agreement.Surname = surname_txt.Text;
            agreement.Pesel = Convert.ToInt32(pesel_txt.Text);
            agreement.Tel = Convert.ToInt32(tel_txt.Text);
            agreement.Begin = DateTime.Now.Date;
            agreement.End = DateTime.Now.Date;
            _context.Agreements.Add(agreement);
            _context.SaveChanges();
            agreementDataGrid.ItemsSource = _context.Agreements.ToList();
        }

        private void edit_btn_Click(object sender, RoutedEventArgs e)
        {
         
            Agreement agreement = agreementDataGrid.SelectedItem as Agreement;
            Agreement updateAgreement = _context.Agreements.Where(i => i.Id == agreement.Id).FirstOrDefault();
            updateAgreement.Name = name_txt.Text;
            agreement.Surname = surname_txt.Text;
            agreement.Pesel = Convert.ToInt32(pesel_txt.Text);
            agreement.Tel = Convert.ToInt32(tel_txt.Text);
            agreement.End = DateTime.Now.Date;
            _context.SaveChanges();
            agreementDataGrid.ItemsSource = _context.Agreements.ToList();
        }

        private void remove_btn_Click(object sender, RoutedEventArgs e)
        {
          
            Agreement deleteAgreement;
            Agreement agreement = agreementDataGrid.SelectedItem as Agreement;
            deleteAgreement = _context.Agreements.Find(agreement.Id);
            _context.Agreements.Attach(deleteAgreement);
            _context.Agreements.Remove(deleteAgreement);
            _context.SaveChanges();
            agreementDataGrid.ItemsSource = _context.Agreements.ToList();

        }

        private void load_btn_Click(object sender, RoutedEventArgs e)
        {
            
            Agreement agreement = agreementDataGrid.SelectedItem as Agreement;

            name_txt.Text = agreement.Name;
            surname_txt.Text = agreement.Surname;
            pesel_txt.Text = Convert.ToString(agreement.Pesel);
            tel_txt.Text = Convert.ToString(agreement.Tel);
            id_temp = agreement.Id;

        }

        private void addClothes_btn_Click(object sender, RoutedEventArgs e)
        {
            Agreement agreement = agreementDataGrid.SelectedItem as Agreement;
            int passId = agreement.Id;

            var addclotheswindow = new addClothesWindow(passId);
            addclotheswindow.Show();
        }
    }
}
