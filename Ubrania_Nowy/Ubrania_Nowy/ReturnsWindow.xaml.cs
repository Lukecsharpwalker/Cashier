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
using System.Reflection;

namespace Ubrania_Nowy
{
    /// <summary>
    /// Logika interakcji dla klasy ReturnsWindow.xaml
    /// </summary>
    public partial class ReturnsWindow : Window
    {
        private ERPDbContext _context = new ERPDbContext();
        public ReturnsWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource clothViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("clothViewSource")));
            clothDataGrid.ItemsSource = _context.Clothes.ToList();
            // Załaduj dane poprzez ustawienie właściwości CollectionViewSource.Source:
            // clothViewSource.Źródło = [ogólne źródło danych]
        }

        private void Load_Btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Cloth cloth = clothDataGrid.SelectedItem as Cloth;
                Sold_box.IsChecked = Convert.ToBoolean(cloth.Sold);
                clothDataGrid.ItemsSource = _context.Clothes.ToList();
            }
            catch (NullReferenceException nEx)
            {
                MessageBox.Show("Zaznacz Element\n\n" + nEx.Message);
            }
            catch (InvalidCastException iEx)
            {
                MessageBox.Show("Zaznacz Element z wartościami\n\n" + iEx.Message);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Coś poszło nie tak");
            }
        }

        private void Return_Btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                Cloth cloth = (Cloth)clothDataGrid.SelectedItem; //agreementDataGrid.SelectedItem as Agreement;
               // Cloth updateCloth = _context.Clothes.FirstOrDefault(i => i.Id == cloth.Id);
                if (cloth.Sold == true)
                {
                    cloth.Sold = (bool)Sold_box.IsChecked;
                    _context.SaveChanges();
                    clothDataGrid.ItemsSource = _context.Clothes.ToList();
                }
            }
            catch (TargetException tEx)
            {
                MessageBox.Show("\nZaznacz Umowę\n\n" + tEx.Message);
            }

        }
    }
}
