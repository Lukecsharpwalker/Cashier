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

namespace Ubrania_Nowy
{
    /// <summary>
    /// Logika interakcji dla klasy CheckAgreementWindow.xaml
    /// </summary>
    public partial class CheckAgreementWindow : Window
    {
        private ERPDbContext _context = new ERPDbContext();
        int passId;
        public CheckAgreementWindow(int id)
        {
            InitializeComponent();
            passId = id;
            //MessageBox.Show("" + id);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource clothViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("clothViewSource")));          
            clothDataGrid.ItemsSource = _context.Clothes.ToList().Where(i => i.Agreement_Id == passId);
            // Załaduj dane poprzez ustawienie właściwości CollectionViewSource.Source:
            // clothViewSource.Źródło = [ogólne źródło danych]
        }

        private void CloseAgreement_btn_Click(object sender, RoutedEventArgs e)
        {
            int temp=0;
            var cloth = _context.Clothes.ToList().Where(i => i.Agreement_Id == passId);
            foreach (var price in cloth)
                temp += price.Price;
            MessageBox.Show("" + temp);
        }
    }
}
