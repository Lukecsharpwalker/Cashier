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

        private void addCloth_btn_Click(object sender, RoutedEventArgs e)
        {
            //   MessageBox.Show("" + passId);
            try
            {
                Clothes cloth = new Clothes();

                cloth.Agreement_Id = passId;
                cloth.Mark = mark_txt.Text;
                cloth.Size = size_txt.Text;
                cloth.Colour = colour_txt.Text;
                cloth.Type = type_txt.Text;
                cloth.Description = description_txt.Text;
                cloth.Price = Convert.ToInt32(price_txt.Text);
                cloth.Box = box_txt.Text;

                _context.Clothes.Add(cloth);
                _context.SaveChanges();
                clothDataGrid.ItemsSource = _context.Clothes.ToList();
            }
            catch (FormatException fEx)
            {
                MessageBox.Show(fEx.Message + "\nPodaj wszystkie dane lub\nSprawdź poprawność danych");
                //MessageBox.Show("Podaj wszystkie dane");
            }
            catch (Exception)
            {
                MessageBox.Show("Coś poszło nie tak");
            }
        }

        private void load_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Clothes cloth = clothDataGrid.SelectedItem as Clothes;

                mark_txt.Text = cloth.Mark;
                size_txt.Text = cloth.Size;
                colour_txt.Text = cloth.Colour;
                type_txt.Text = cloth.Type;
                description_txt.Text = cloth.Description;
                box_txt.Text = cloth.Box;
                price_txt.Text = Convert.ToString(cloth.Price);
            }
            catch (NullReferenceException nEx)
            {
                MessageBox.Show("Zaznacz Element\n\n" + nEx.Message);
            }
            catch (InvalidCastException iEx)
            {
                MessageBox.Show("Zaznacz Element z wartościami\n\n" + iEx.Message);
            }
            catch (Exception)
            {
                MessageBox.Show("Coś poszło nie tak");
            }
        }
        private void editCloth_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Clothes cloth = clothDataGrid.SelectedItem as Clothes;
                Clothes updateCloth = _context.Clothes.Where(i => i.Id == cloth.Id).FirstOrDefault();



                cloth.Price = Int32.Parse(price_txt.Text);
                cloth.Agreement_Id = passId;
                cloth.Mark = mark_txt.Text;
                cloth.Size = size_txt.Text;
                cloth.Colour = colour_txt.Text;
                cloth.Type = type_txt.Text;
                cloth.Description = description_txt.Text;
                cloth.Box = box_txt.Text;


                _context.SaveChanges();
                clothDataGrid.ItemsSource = _context.Clothes.ToList();
            }
            catch (TargetException tEx)
            {
                MessageBox.Show("\nZaznacz Umowę\n\n" + tEx.Message);
            }
            catch (FormatException fEx)
            {
                MessageBox.Show(fEx.Message + "\nPodaj wszystkie dane lub\nSprawdź poprawność danych");
                //MessageBox.Show("Podaj wszystkie dane");
            }
            catch (Exception)
            {
                MessageBox.Show("Coś poszło nie tak");
            }
            finally
            {
                clothDataGrid.ItemsSource = _context.Clothes.ToList();
            }

        }

        private void deleteCloth_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Clothes deleteCloth;
                Clothes cloth = clothDataGrid.SelectedItem as Clothes;
                deleteCloth = _context.Clothes.Find(cloth.Id);
                _context.Clothes.Attach(deleteCloth);
                _context.Clothes.Remove(deleteCloth);
                _context.SaveChanges();
                clothDataGrid.ItemsSource = _context.Clothes.ToList();
            }
            catch (NullReferenceException nEx)
            {
                MessageBox.Show("Zaznacz Element\n\n" + nEx.Message);
            }
            catch (Exception)
            {
                MessageBox.Show("Coś poszło nie tak");
            }
        }

        
    }
}
