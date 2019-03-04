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
    /// Logika interakcji dla klasy Warehouse.xaml
    /// </summary>
    public partial class Warehouse : Window
    {
        private ERPDbContext _context = new ERPDbContext();
        public Warehouse()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
// juz wczedniej o tym pisalem
            System.Windows.Data.CollectionViewSource clothViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("clothViewSource")));
           // clothDataGrid.ItemsSource = _context.Clothes.ToList();
            // Załaduj dane poprzez ustawienie właściwości CollectionViewSource.Source:
            // clothViewSource.Źródło = [ogólne źródło danych]
        }

        private void Search_btn_Click(object sender, RoutedEventArgs e)
        {
// juz wczedniej o tym pisalem

            string type_temp, size_temp;
            type_temp = Type_txt.Text;
            size_temp = Size_txt.Text;
            //   var select = _context.Clothes.Where(c => c.Size == size_temp && c.Type == type_temp).ToList();
            if (string.IsNullOrEmpty(Size_txt.Text))
                clothDataGrid.ItemsSource = _context.Clothes.Where(c => c.Type == type_temp).ToList();
            else if (string.IsNullOrEmpty(Type_txt.Text))
                clothDataGrid.ItemsSource = _context.Clothes.Where(c => c.Size == size_temp).ToList();           
            else
            clothDataGrid.ItemsSource = _context.Clothes.Where(c => c.Size == size_temp && c.Type == type_temp).ToList();

        }
    }
}
