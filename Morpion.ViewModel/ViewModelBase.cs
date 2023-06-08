using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morpion
{
    // Classe NON-GRAPHIQUE.

    public class ViewModelBase : INotifyPropertyChanged // WPF détecte cette interface
                                                        // et s'abonne à PropertyChanged.
    {
        // Objets PropertyChangedEventArgs déjà créés.
        private static readonly Dictionary<string, PropertyChangedEventArgs> _cache;

        // Constructeur statique : appelée à la 1ère utilisation de la classe
        static ViewModelBase()
        {
            _cache = new Dictionary<string, PropertyChangedEventArgs>();
        }

        private PropertyChangedEventArgs GetPropertyChangedEventArgs(string propertyName)
        {
            // Crée l'objet PropertyChangedEventArgs s'il n'est pas en cache.

            if (!_cache.TryGetValue(propertyName, out PropertyChangedEventArgs? e))
            {
                e = new PropertyChangedEventArgs(propertyName);
                _cache.Add(propertyName, e);
            }

            return e;
        }

        // Evènement déclenché lorsqu'une propriété a été modifiée.
        // (implémentation de INotifyPropertyChanged)
        // ? indique que PropertyChanged peut prendre une valeur null.
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, GetPropertyChangedEventArgs(propertyName));
            }
        }

        // params permet d'écrire OnPropertyChanged(a, b, c...)
        //          à la place de OnPropertyChanged(new string[] { a, b, c... })
        protected void OnPropertyChanged(params string[] propertyNames)
        {
            if (PropertyChanged != null)
            {
                foreach (string p in propertyNames)
                {
                    PropertyChanged(this, GetPropertyChangedEventArgs(p));
                }
            }
        }
    }
}
