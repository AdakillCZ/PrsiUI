using Prší;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PršiUI
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// 
    /// Pro karty list box s obrazky?
    /// 
    /// </summary>
    public partial class MainWindow : Window
    {

        public Hra hra;
        bool inicializace;

        public MainWindow()
        {
            InitializeComponent();
            inicializace = false;

            hra = new Hra(3);

            hra.inicializujHru();

            InicializujUI();


            // hra.zacniHrat();
        }

        /// <summary>
        /// Odehrani tahu
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int indexKarty = lbKartyHrace.SelectedIndex;

        }

        /// <summary>
        /// liznuti karty
        /// </summary>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void lbKartyHrace_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public void InicializujUI()
        {
            for (int i = 0; i < hra.hraci.Count; i++)
            {
                lbSeznamHracu.Items.Add(i);
            }

            lbSeznamHracu.SelectedIndex = 0;

            inicializace = true;

            foreach (Karta karta in hra.hraci[0].hracovyKarty)
            {
                lbKartyHrace.Items.Add(karta);
            }
            
        }

        /// <summary>
        /// Test vyberu hrace
        /// </summary>
        private void lbSeznamHracu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!inicializace) return;

            int indexHrace = lbSeznamHracu.SelectedIndex;

            lbKartyHrace.Items.Clear();

            for (int i = 0; i < hra.hraci[indexHrace].hracovyKarty.Count; i++)
            {
                lbKartyHrace.Items.Add(hra.hraci[indexHrace].hracovyKarty[i]);
            }
        }
    }
}
