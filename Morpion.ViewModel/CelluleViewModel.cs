using System.Windows.Input;

namespace Morpion
{
    public class CelluleViewModel : ViewModelBase
    {
        private readonly MainViewModel _jeu;
        private CelluleEtat _etat;
        private bool _canDrop;

        public CelluleViewModel(MainViewModel jeu)
        {
            _jeu = jeu;
            _canDrop = true;
        }

        public CelluleEtat Etat
        {
            get { return _etat; }
        }

        public ICommand CocheCommand
        {
            get { return new RelayCommand(Coche); }
        }

        public void Coche()
        {
            if (_etat == CelluleEtat.Rien)
            {
                int columnIndex = -1;

                for (int i = 0; i < _jeu.Grille.Length; i++)
                {
                    if (_jeu.Grille[i] == this)
                    {
                        columnIndex = i % 7; // Assuming 7 columns
                        break;
                    }
                }

                for (int row = 5; row >= 0; row--) // Iterate from bottom to top
                {
                    CelluleViewModel cell = _jeu.Grille[row * 7 + columnIndex]; // Assuming 7 columns
                    if (cell.Etat == CelluleEtat.Rien) // Found an empty cell
                    {
                        if (_jeu.ProchainJoueur())
                        {
                            cell._etat = CelluleEtat.Rouge;
                        }
                        else
                        {
                            cell._etat = CelluleEtat.Jaune;
                        }

                        cell.OnPropertyChanged(nameof(cell.Etat));
                        _jeu.VerifieGagnant();
                        break;
                    }
                }
            }
        }

        public bool CanCoche()
        {
            return _canDrop;
        }
    }

    public enum CelluleEtat
    {
        Rien,
        Rouge,
        Jaune
    }
}
