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
        // konwencja nazewnictwa mowi aby nazywac zmienne prywatne z '_' przed
        // staraj sie wypisywac modyfikatory dostepu
        int id_temp;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


//find resources do try catcha
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
// powinno sie najpierw sprawdzac czy jest tam jakis tekst
            agreement.Name = name_txt.Text;
            agreement.Surname = surname_txt.Text;
            // staraj sie uzywac tryparse i obsluge zdarzenia jesli sie nie uda sparsowac
            // if (!int.TryParse()) return
            agreement.Pesel = Convert.ToInt32(pesel_txt.Text);
            agreement.Tel = Convert.ToInt32(tel_txt.Text);
            agreement.Begin = DateTime.Now.Date;
            agreement.End = DateTime.Now.Date;
            // ogolnie fajnie by było połączenie z bazą danych otwierać wtedy kiedy jest opotrzebne i zamykać zaraz potem 
            // blok using(context = new ERPDbContext()){tutaj kod}
            _context.Agreements.Add(agreement);
            _context.SaveChanges();
            // moglbys stworzyc metode w contexcie ktora zwraca ReadOnlyCollection i ją przypisywać do sourca
            agreementDataGrid.ItemsSource = _context.Agreements.ToList();
        }

        private void edit_btn_Click(object sender, RoutedEventArgs e)
        {
         
         // staraj sie kastowac w tradycyjny sposob najlepiej w bloku try catch
            Agreement agreement = agreementDataGrid.SelectedItem as Agreement;
            // juz pisalem wczesniej o FirstOrDefault
            Agreement updateAgreement = _context.Agreements.Where(i => i.Id == agreement.Id).FirstOrDefault();
            // sprawdzaj wczesniej czy masz tam tekst
            updateAgreement.Name = name_txt.Text;
            agreement.Surname = surname_txt.Text;
            // uzywaj tryparse i obslughuj sytuacje kiedy nie uda sie sparsowac
            agreement.Pesel = Convert.ToInt32(pesel_txt.Text);
            agreement.Tel = Convert.ToInt32(tel_txt.Text);
            agreement.End = DateTime.Now.Date;
            _context.SaveChanges();
            // moglbys stworzyc metode w contexcie ktora zwraca ReadOnlyCollection i ją przypisywać do sourca
            agreementDataGrid.ItemsSource = _context.Agreements.ToList();
        }

        private void remove_btn_Click(object sender, RoutedEventArgs e)
        {
          // to samo co wyzej
            Agreement deleteAgreement;
            Agreement agreement = agreementDataGrid.SelectedItem as Agreement;
            // do takiego wyszukiwania lepiej uzywac FirstoOrDefault
            deleteAgreement = _context.Agreements.Find(agreement.Id);
            // czemu najpierw dolaczasz a potem usuwasz? troche nie rozumiem
            _context.Agreements.Attach(deleteAgreement);
            _context.Agreements.Remove(deleteAgreement);
            _context.SaveChanges();
            agreementDataGrid.ItemsSource = _context.Agreements.ToList();

        }

        private void load_btn_Click(object sender, RoutedEventArgs e)
        {
// jak wyzej            
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
// juz wczesniej o tym pytalem
// moze moglbys rozwazyc uzycie ShowDialog() aby zablokowac mozliwosc wyjscia z tamtego okna dopoki sie go nie zamknie?
            var addclotheswindow = new addClothesWindow(passId);
            addclotheswindow.Show();
        }

        private void CheckAgreement_btn_Click(object sender, RoutedEventArgs e)
        {
            int passId;
            // same as before
            passId = Convert.ToInt32(CheckAgreementId_txt.Text);
            var CheckAgreementWindow = new CheckAgreementWindow(passId);
            CheckAgreementWindow.Show();
        }

        private void Cashier_btn_Click(object sender, RoutedEventArgs e)
        {
            CashierWindow cashierWindow = new CashierWindow();
            cashierWindow.Show();
        }

        private void Warehouse_btn_Click(object sender, RoutedEventArgs e)
        {
            Warehouse warehouse = new Warehouse();
            warehouse.Show();
        }
    }
}
