using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace KönyvekFeladat
{
    public class Konyv
    {
        public string Cim { get; set; } = string.Empty;
        public string Szerzo { get; set; } = string.Empty;
        public int Oldalszam { get; set; }
        public string Mufaj { get; set; } = string.Empty;
        public bool Elerheto { get; set; }
    }

    public partial class MainWindow : Window
    {
        private List<Konyv> konyvekLista = new List<Konyv>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnBetoltes_Click(object sender, RoutedEventArgs e)
        {
            konyvekLista = new List<Konyv>
            {
                new Konyv { Cim = "1984", Szerzo = "George Orwell", Oldalszam = 328, Mufaj = "Sci-fi", Elerheto = true },
                new Konyv { Cim = "A szolgálólány meséje", Szerzo = "Margaret Atwood", Oldalszam = 311, Mufaj = "Disztópia", Elerheto = false },
                new Konyv { Cim = "Az ember tragédiája", Szerzo = "Madách Imre", Oldalszam = 250, Mufaj = "Dráma", Elerheto = true },
                new Konyv { Cim = "Dűne", Szerzo = "Frank Herbert", Oldalszam = 604, Mufaj = "Sci-fi", Elerheto = true },
                new Konyv { Cim = "Egri csillagok", Szerzo = "Gárdonyi Géza", Oldalszam = 552, Mufaj = "Történelmi", Elerheto = false }
            };

            dgKonyvek.ItemsSource = null;
            dgKonyvek.ItemsSource = konyvekLista;
            pbAllapot.Value = 25;
        }

        private bool VanAdat()
        {
            if (konyvekLista.Count == 0)
            {
                MessageBox.Show("Előbb töltsd be a könyveket!", "Figyelmeztetés", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;
        }

        private void btnHanyKonyv_Click(object sender, RoutedEventArgs e)
        {
            if (!VanAdat()) return;
            MessageBox.Show($"Összesen {konyvekLista.Count} könyv van.");
        }

        private void btnLeghosszabb_Click(object sender, RoutedEventArgs e)
        {
            if (!VanAdat()) return;
            var leghosszabb = konyvekLista.OrderByDescending(k => k.Oldalszam).First();
            MessageBox.Show($"A leghosszabb könyv: {leghosszabb.Cim} ({leghosszabb.Oldalszam} oldal)");
        }

        private void btnAtlagOldalszam_Click(object sender, RoutedEventArgs e)
        {
            if (!VanAdat()) return;
            double atlag = konyvekLista.Average(k => k.Oldalszam);
            MessageBox.Show($"Átlagos oldalszám: {atlag:F1} oldal");
        }

        private void btnCsakElerheto_Click(object sender, RoutedEventArgs e)
        {
            if (!VanAdat()) return;
            dgKonyvek.ItemsSource = konyvekLista.Where(k => k.Elerheto).ToList();
        }

        private void btnCsakCimek_Click(object sender, RoutedEventArgs e)
        {
            if (!VanAdat()) return;
            string cimek = string.Join("\n", konyvekLista.Select(k => k.Cim));
            MessageBox.Show(cimek, "Könyvek címei");
        }

        private void btnRendezes_Click(object sender, RoutedEventArgs e)
        {
            if (!VanAdat()) return;
            dgKonyvek.ItemsSource = konyvekLista.OrderBy(k => k.Szerzo).ToList();
        }
    }
}