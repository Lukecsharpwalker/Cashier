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
            // var agrements = _context.Agreements.ToList();
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


    }
}
