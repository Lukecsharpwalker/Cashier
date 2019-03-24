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
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Reflection;
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
            try
            {
                Agreement agreement = new Agreement();

                agreement.Name = name_txt.Text;
                agreement.Surname = surname_txt.Text;
                agreement.Pesel = Convert.ToDouble(pesel_txt.Text);
                agreement.Tel = Convert.ToDouble(tel_txt.Text);
                agreement.Begin = DateTime.Now.Date;
                agreement.End = DateTime.Now.Date;
                _context.Agreements.Add(agreement);
                _context.SaveChanges();
                agreementDataGrid.ItemsSource = _context.Agreements.ToList();
            }
            catch (FormatException fEx)
            {
                MessageBox.Show(fEx.Message + "\nPodaj wszystkie dane lub\nSprawdź poprawność danych");
                //MessageBox.Show("Podaj wszystkie dane");
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Coś poszło nie tak");
            }
        }

        private void edit_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Agreement agreement = (Agreement)agreementDataGrid.SelectedItem;
                // Agreement updateAgreement = _context.Agreements.Where(i => i.Id == agreement.Id).FirstOrDefault();
                // updateAgreement.Name = name_txt.Text;
                
                agreement.Pesel = Convert.ToDouble(pesel_txt.Text);
                agreement.Tel = Convert.ToDouble(tel_txt.Text);
                agreement.End = DateTime.Now.Date;
                agreement.Name = name_txt.Text;
                agreement.Surname = surname_txt.Text;
                _context.SaveChanges();
                agreementDataGrid.ItemsSource = _context.Agreements.ToList();
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
            catch (Exception Ex)
            {
                MessageBox.Show("Coś poszło nie tak");
            }
            finally
            {
               agreementDataGrid.ItemsSource = _context.Agreements.ToList();
            }
        }

        private void remove_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Agreement deleteAgreement;
                Agreement agreement = agreementDataGrid.SelectedItem as Agreement;
                deleteAgreement = _context.Agreements.Find(agreement.Id);
                _context.Agreements.Attach(deleteAgreement);
                _context.Agreements.Remove(deleteAgreement);
                _context.SaveChanges();
                agreementDataGrid.ItemsSource = _context.Agreements.ToList();
            }
            catch (NullReferenceException nEx)
            {
                MessageBox.Show("Zaznacz Element\n\n" + nEx.Message);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Coś poszło nie tak");
            }

        }

        private void load_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Agreement agreement = (Agreement)agreementDataGrid.SelectedItem;
                //Agreement updateAgreement = _context.Agreements.Where(i => i.Id == agreement.Id).FirstOrDefault();

                //name_txt.Text = updateAgreement.Name;
                //surname_txt.Text = updateAgreement.Surname;
                //pesel_txt.Text = Convert.ToString(updateAgreement.Pesel);
                //tel_txt.Text = Convert.ToString(updateAgreement.Tel);
                //id_temp = updateAgreement.Id;
                
                name_txt.Text = agreement.Name;
                surname_txt.Text = agreement.Surname;
                pesel_txt.Text = Convert.ToString(agreement.Pesel);
                tel_txt.Text = Convert.ToString(agreement.Tel);
                id_temp = agreement.Id;
            }

            catch (NullReferenceException nEx)
            {
                MessageBox.Show("Zaznacz Element\n\n"+nEx.Message);
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

        private void addClothes_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Agreement agreement = (Agreement)agreementDataGrid.SelectedItem;
                int passId = agreement.Id;
                addClothesWindow addclotheswindow = new addClothesWindow(passId);
                addclotheswindow.Show();
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

        private void CheckAgreement_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int passId;
                passId = Convert.ToInt32(CheckAgreementId_txt.Text);
                var CheckAgreementWindow = new CheckAgreementWindow(passId);
                CheckAgreementWindow.Show();
            }
            catch (FormatException fEx)
            {
                MessageBox.Show(fEx.Message + "\nPodaj Numer Umowy");
                //MessageBox.Show("Podaj wszystkie dane");
            }
            catch(OverflowException oEx)
            {
                MessageBox.Show("Zbyt duży Numer\n\n" + oEx.Message);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Coś poszło nie tak");
            }

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

        private void Return_btn_Click(object sender, RoutedEventArgs e)
        {
            ReturnsWindow returnsWindow = new ReturnsWindow();
            returnsWindow.Show();
        }

        private void Print_Btn_Click(object sender, RoutedEventArgs e)
        {


            Agreement agreement = (Agreement)agreementDataGrid.SelectedItem;
           // Agreement updateAgreement = _context.Agreements.Where(i => i.Id == agreement.Id).FirstOrDefault();
            Cloth cloth = new Cloth();

            try
            {
                Document pdfDoc = new Document(PageSize.A4, 20, 20, 42, 35);
                PdfWriter pdfWri = PdfWriter.GetInstance(pdfDoc, new FileStream(agreement.Name + "_" + agreement.Surname + "_" + agreement.Id, FileMode.Create));
                pdfDoc.Open();

                iTextSharp.text.Paragraph p1 = new iTextSharp.text.Paragraph("Poznan dnia " + DateTime.Now.Date.ToShortDateString());
                p1.Alignment = Element.ALIGN_RIGHT;

                iTextSharp.text.Paragraph p2 = new iTextSharp.text.Paragraph("UMOWA KOMISU NR: " + agreement.Id);
                p2.Alignment = iTextSharp.text.Element.ALIGN_CENTER;

                iTextSharp.text.Paragraph p3 = new iTextSharp.text.Paragraph("Zawarta w dniu " + DateTime.Now.Date.ToShortDateString() +
                    " pomiędzy SZAFARI z siedzibą w Poznaniu, przy ul.Ratajczaka 28, w imieniu którego działa ; Iga Staniul zwana w treści umowy 'Komisantem' a, " +
                   agreement.Name + " " + agreement.Surname + " zwanym w treści umowy 'Komitentem', o następującej treści: ");

                iTextSharp.text.Paragraph p4 = new iTextSharp.text.Paragraph("§1.");
                p4.Alignment = iTextSharp.text.Element.ALIGN_CENTER;


                iTextSharp.text.Paragraph p5 = new iTextSharp.text.Paragraph("Komisant zobowiązuje się do sprzedaży komisowej we własnym imieniu otrzymanych od " +
                    "Komitenta następujących rzeczy: (*wymienione na drugiej stronie)");


                iTextSharp.text.Paragraph p6 = new iTextSharp.text.Paragraph("§2.");
                p6.Alignment = iTextSharp.text.Element.ALIGN_CENTER;

                iTextSharp.text.Paragraph p7 = new iTextSharp.text.Paragraph("Komitent oświadcza, że przekazane rzeczy stanowią jego własność i nie są obciążone prawami osób trzecich.");

                iTextSharp.text.Paragraph p8 = new iTextSharp.text.Paragraph("§3.");
                p8.Alignment = iTextSharp.text.Element.ALIGN_CENTER;

                iTextSharp.text.Paragraph p9 = new iTextSharp.text.Paragraph("Komisant zobowiązany jest na własny koszt ubezpieczyć oddane do sprzedaży komisowej " +
                    "rzeczy od ryzyka kradzieży z włamaniem, ognia i innych zdarzeń losowych, natomiast nie " +
                    "ponosi odpowiedzialności za uszkodzenia powstałe podczas normalnej eksplatacji tzn " +
                    "przymierzania przez klientów.");

                iTextSharp.text.Paragraph p10 = new iTextSharp.text.Paragraph("§4.");
                p10.Alignment = iTextSharp.text.Element.ALIGN_CENTER;

                iTextSharp.text.Paragraph p11 = new iTextSharp.text.Paragraph("Wysokość należnej Komitentowi kwoty za każdą rzeczy, ustalana jest indywidualnie" +
                    " (*kwoty zapisane na drugiej stronie).Komisant narzuca swoją marże.");

                iTextSharp.text.Paragraph p12 = new iTextSharp.text.Paragraph("§5.");
                p12.Alignment = iTextSharp.text.Element.ALIGN_CENTER;

                iTextSharp.text.Paragraph p13 = new iTextSharp.text.Paragraph("W przypadku, gdy powierzone do sprzedania rzeczy określone wg umowy, pomimo dołożenia " +
                    "przez Komisanta należytej staranności, nie zostaną sprzedane do dnia " + DateTime.Now.Date.AddDays(90).ToShortDateString() + ", Komitent " +
                    "jest zobowiązany do odebrania rzeczy i gotówki w ciągu 1 miesiąca od daty zakończenia " +
                    "umowy, w przeciwnym razie rzeczy zostają przekazane na rzecz Komisanta oraz dodatkowo naliczana jest codzinnie kara umowna o wyskości 5% wartości umowy");

                iTextSharp.text.Paragraph p14 = new iTextSharp.text.Paragraph("§6.");
                p14.Alignment = iTextSharp.text.Element.ALIGN_CENTER;

                iTextSharp.text.Paragraph p15 = new iTextSharp.text.Paragraph("Przyjmowanie oraz rozliczanie rzeczy wyłącznie w czwartki i piątki w godzinach między " +
                    "12.00 a 18.00 lub po ówczesnym umówienie się poprzez www.facebook.com/szafarisklep.");

                iTextSharp.text.Paragraph p16 = new iTextSharp.text.Paragraph("§7.");
                p16.Alignment = iTextSharp.text.Element.ALIGN_CENTER;

                iTextSharp.text.Paragraph p17 = new iTextSharp.text.Paragraph("Ewentualne spory mogące wyniknąć na tle stosowania niniejszej umowy strony poddają " +
                    "rozstrzygnięciu sądu właściwego dla siedziby Komisanta.");

                iTextSharp.text.Paragraph p18 = new iTextSharp.text.Paragraph("            " +
                    "Komisant" +
                    "                                                                                                                 " +
                    "Komitient");
                p18.Alignment = iTextSharp.text.Element.ALIGN_LEFT;

                //  iTextSharp.text.Paragraph p19 = new iTextSharp.text.Paragraph("Komitient");
                //  p19.Alignment = iTextSharp.text.Element.ALIGN_RIGHT;


                pdfDoc.AddAuthor("Szafari");
                pdfDoc.AddCreator("Szafari");
                pdfDoc.AddSubject("Umowa Komisu");
                pdfDoc.AddTitle("Umowa komisu nr:" + agreement.Id);


                pdfDoc.Add(p1);
                pdfDoc.Add(p2);
                pdfDoc.Add(p3);
                pdfDoc.Add(p4);
                pdfDoc.Add(p5);
                pdfDoc.Add(p6);
                pdfDoc.Add(p7);
                pdfDoc.Add(p8);
                pdfDoc.Add(p9);
                pdfDoc.Add(p10);
                pdfDoc.Add(p11);
                pdfDoc.Add(p12);
                pdfDoc.Add(p13);
                pdfDoc.Add(p14);
                pdfDoc.Add(p15);
                pdfDoc.Add(p16);
                pdfDoc.Add(p17);
                pdfDoc.Add(p18);
                // pdfDoc.Add(p19);

                pdfDoc.Close();


            }
            catch (NullReferenceException nEx)
            {
                MessageBox.Show("Zaznacz Element\n\n" + nEx.Message);
            }



        }
    }
}
