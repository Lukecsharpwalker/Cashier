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
        // nazywaj zmienne tak żeby było wiadomo co one robią albo do czego służą
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
            
// staraj się unikać tak dużych przerw w tekscie 1 linijka jest wystczająca
// if można odwróćić np:
// if(e.Key != Key.Return)
// return
// i dalej resztę kodu
// staraj unikać się zagnieżdżania jeśli się da
            if (e.Key == Key.Return)
            {
                // nazywaj zmienne tak żeby było wiadomo co one robią albo do czego służą
                int temp = Convert.ToInt32(Scaner_txt.Text);
                // zamiast Where możesz użyć FirstOrDefault od razu
                Cloth cloth = _context.Clothes.Where(i => i.Id == temp).FirstOrDefault();
                // używając FirstOrDefault sprwawdz w ifie czy nie zwróciło defaulta
                // if (cloth == default(cloth))
                // obsuga zdazenia

                // troche bez sensu nie prawdaż? możesz ustawiać od razu na true to nie zmienia nic w tym wyrażeniu a masz 1 operacje mniej
                // co w przypadku jak jest sprzedane? może warto to obsłużyć
                // btw jak masz tylko jedną linię po if czy for itp nie musisz używać klamerek
                if (cloth.Sold == false)
                { cloth.Sold = true; }
                // temp += cloth.Price ;)
                temp2 = temp2 + cloth.Price;
                price_txt.Text = temp2.ToString();

                _context.SaveChanges();

                // MessageBox.Show("dziala");
            }
        }
    }
}
