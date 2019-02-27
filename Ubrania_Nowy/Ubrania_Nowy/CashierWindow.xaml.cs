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
    /// Logika interakcji dla klasy CashierWindow.xaml
    /// </summary>
    public partial class CashierWindow : Window
    {
        int temp2 = 0;
        private ERPDbContext _context = new ERPDbContext();
        public CashierWindow()
        {
            InitializeComponent();
            Scaner_txt.Focus();
          //  var cloth = _context.Clothes.ToList().Where(i => i.Agreement_Id == passId);


        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            

            if (e.Key == Key.Return)
            {
                int temp = Convert.ToInt32(Scaner_txt.Text);
                Cloth cloth = _context.Clothes.Where(i => i.Id == temp).FirstOrDefault();

                if (cloth.Sold == false)
                { cloth.Sold = true; }
                temp2 = temp2 + cloth.Price;
                price_txt.Text = temp2.ToString();

                _context.SaveChanges();

                // MessageBox.Show("dziala");
            }
        }
    }
}
