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
    /// Logika interakcji dla klasy addClothesWindow.xaml
    /// </summary>
    public partial class addClothesWindow : Window
    {
        
        private ERPDbContext _context = new ERPDbContext();
        int passId;
        public addClothesWindow(int id)
        {
            InitializeComponent();
            passId = id;
           // MessageBox.Show("" + id);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource clothViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("clothViewSource")));
            clothDataGrid.ItemsSource = _context.Clothes.ToList();
            // Załaduj dane poprzez ustawienie właściwości CollectionViewSource.Source:
            // clothViewSource.Źródło = [ogólne źródło danych]
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
         //   MessageBox.Show("" + passId);

            Cloth cloth = new Cloth();
            cloth.Agreement_Id = passId;
            cloth.Mark = mark_txt.Text;
            cloth.Size = size_txt.Text;
            cloth.Colour = colour_txt.Text;
            cloth.Type = type_txt.Text;
            cloth.Description = description_txt.Text;
            cloth.Price = Convert.ToInt32(price_txt.Text);
            _context.Clothes.Add(cloth);
            _context.SaveChanges();
            clothDataGrid.ItemsSource = _context.Clothes.ToList();
        }
    }
}
