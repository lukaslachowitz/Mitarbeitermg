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
    /// Interaktionslogik für MitarbeiterListen.xaml
    /// </summary>
    public partial class MitarbeiterListen : Window
    {
        ObservableCollection<Mitarbeiter> mitarbeitergelistet;
        public MitarbeiterListen()
        {
            InitializeComponent();
            try
            {
                mitarbeitergelistet = DeserelizeDataToJson(mitarbeitergelistet);
                mitarblisten.ItemsSource = mitarbeitergelistet;
            }
            catch (Exception)
            {

            }
            
        }
        internal MitarbeiterListen(ObservableCollection<Mitarbeiter> m)
        {
            InitializeComponent();
            try
            {
                mitarbeitergelistet = DeserelizeDataToJson(mitarbeitergelistet);
                mitarbeitergelistet.Add(m[0]);
                SerelizeDataToJson(mitarbeitergelistet);
                mitarbeitergelistet = DeserelizeDataToJson(mitarbeitergelistet);

                mitarblisten.ItemsSource = mitarbeitergelistet;
            }
            catch (Exception)
            {

            }
        }
        private static ObservableCollection<Mitarbeiter> DeserelizeDataToJson(ObservableCollection<Mitarbeiter> m)
        {
            string json = File.ReadAllText("Daten.json");
            m = JsonConvert.DeserializeObject<ObservableCollection<Mitarbeiter>>(json);
            return m;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Mitarbeiter_erstellen m = new Mitarbeiter_erstellen();
            m.Show();
            this.Close();
        }
        private static void SerelizeDataToJson(ObservableCollection<Mitarbeiter> m)
        {
            string json = JsonConvert.SerializeObject(m, Formatting.Indented);
            File.WriteAllText("Daten.json", json);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Mitarbeiter_erstellen mit = new Mitarbeiter_erstellen((Mitarbeiter)mitarblisten.SelectedItem);
            mitarbeitergelistet.Remove((Mitarbeiter)mitarblisten.SelectedItem);
            SerelizeDataToJson(mitarbeitergelistet);
            mit.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            mitarbeitergelistet.Remove((Mitarbeiter)mitarblisten.SelectedItem);
            SerelizeDataToJson(mitarbeitergelistet);
            mitarblisten.ItemsSource = DeserelizeDataToJson(mitarbeitergelistet);
        }
    }
}
