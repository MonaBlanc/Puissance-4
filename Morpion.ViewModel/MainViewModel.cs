namespace Morpion
{
    public interface IMainView
    {
        void PartieTerminee(bool joueur);
    }

    public class MainViewModel : ViewModelBase
    {
        private readonly IMainView _view;

        private CelluleViewModel[] _grille;
        private               bool _joueur;

        public MainViewModel(IMainView view)
        {
            _view   = view;
            _grille = GrilleVide();
        }

        private CelluleViewModel[] GrilleVide()
        {
            return Enumerable.Range(0, 42)
                .Select(_ => new CelluleViewModel(this))
                .ToArray();
        }

        public bool ProchainJoueur()
        {
            bool j = _joueur;
            _joueur = !_joueur;
            return j;
        }

        public void VerifieGagnant()
        {
            if (Gagnant(out bool joueur))
            {
                _view.PartieTerminee(joueur);

                _grille = GrilleVide();
                OnPropertyChanged(nameof(Grille));
            }
        }

        private bool Gagnant(out bool joueur)
        {
            CelluleEtat c;

            // Parcours des lignes.
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    c = _grille[7 * i + j].Etat;
                    if (c != CelluleEtat.Rien && c == _grille[7 * i + j + 1].Etat && c == _grille[7 * i + j + 2].Etat && c == _grille[7 * i + j + 3].Etat)
                    {
                        joueur = (c == CelluleEtat.Rouge);
                        return true;
                    }
                }
            }

            // Parcours des colonnes.
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    c = _grille[7 * j + i].Etat;
                    if (c != CelluleEtat.Rien && c == _grille[7 * (j + 1) + i].Etat && c == _grille[7 * (j + 2) + i].Etat && c == _grille[7 * (j + 3) + i].Etat)
                    {
                        joueur = (c == CelluleEtat.Rouge);
                        return true;
                    }
                }
            }

            // Parcours des diagonales descendantes.
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    c = _grille[7 * i + j].Etat;
                    if (c != CelluleEtat.Rien && c == _grille[7 * (i + 1) + (j + 1)].Etat && c == _grille[7 * (i + 2) + (j + 2)].Etat && c == _grille[7 * (i + 3) + (j + 3)].Etat)
                    {
                        joueur = (c == CelluleEtat.Rouge);
                        return true;
                    }
                }
            }

            // Parcours des diagonales montantes.
            for (int i = 0; i < 3; i++)
            {
                for (int j = 3; j < 7; j++)
                {
                    c = _grille[7 * i + j].Etat;
                    if (c != CelluleEtat.Rien && c == _grille[7 * (i + 1) + (j - 1)].Etat && c == _grille[7 * (i + 2) + (j - 2)].Etat && c == _grille[7 * (i + 3) + (j - 3)].Etat)
                    {
                        joueur = (c == CelluleEtat.Rouge);
                        return true;
                    }
                }
            }

            joueur = false; // Valeur arbitraire.
            return false;
        }


        public CelluleViewModel[] Grille
        {
            get { return _grille; }
        }
    }
}