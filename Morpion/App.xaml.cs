using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Morpion
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application, IMainView
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Remplace StartupUri="MainWindow.xaml" dans le source XAML :
            //
            MainWindow w = new();
            w.DataContext = new MainViewModel(this); // Impossible à écrire en XAML.
            w.Show();
        }

        // Implémentation de IMainView
        public void PartieTerminee(bool joueur)
        {
            MessageBox.Show($"Le joueur {(joueur ? "Rouge" : "Jaune")} a gagné.", "Partie terminée");
        }
    }
}
