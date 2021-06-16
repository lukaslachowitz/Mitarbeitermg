using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

namespace Projekt
{
    /// <summary>
    /// Interaktionslogik für Mitarbeiter_erstellen.xaml
    /// </summary>
    public partial class Mitarbeiter_erstellen : Window
    {
        ObservableCollection<Mitarbeiter> mb = new ObservableCollection<Mitarbeiter>();
       
        internal Mitarbeiter_erstellen(Mitarbeiter m = null)
        {
            InitializeComponent();
            
            if (m != null)
            {
                vornametextfeld.Text = m.Vorname;
                nachnametextfeld.Text = m.Nachname;
                anredecombo.SelectedValue = m.Anrede;
                telefonnummertext.Text = m.Telefonnummer;
                orttextfeld.Text = m.Ort;
                geburtsdatumpicker.SelectedDate = m.Geburtsdatum;
                abteiltextfeld.Text = m.Abteilung;
                adressetextfeld.Text = m.Adresse;
                adrresszusatztextfeld.Text = m.Adresszusatz;
                SZtextfeld.Text = Convert.ToString(m.SZ);
                IBANtextfeld.Text = m.IBAN;
                MBerstellen.Content = "Änderung abspeichern";
            }

        }

        private void Mitarbeitererstellen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                mb.Add(new Mitarbeiter(vornametextfeld.Text, nachnametextfeld.Text, anredecombo.Text, telefonnummertext.Text, orttextfeld.Text, (DateTime)geburtsdatumpicker.SelectedDate, abteiltextfeld.Text, adressetextfeld.Text, adrresszusatztextfeld.Text, Convert.ToDouble(SZtextfeld.Text), IBANtextfeld.Text));
                MitarbeiterListen m = new MitarbeiterListen(mb);
                m.Show();
                this.Close();
            }
            catch (Exception)
            {
            }
           
        }

    }
}
