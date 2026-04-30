public class Tablette : Materiel  // smartphone de grande taille tactile pouvais accueillir beaucoup de doigts en même temps !
{
    private double tailleEcranPouces;
    private bool styletInclut;

    public double GetTailleEcranPouces()
    {
        return tailleEcranPouces;
    }
    public bool GetStyletInclut()
    {
        return styletInclut;
    }

    public void SetTailleEcranPouces(double tailleEcranPouces)
    {
        this.tailleEcranPouces = tailleEcranPouces;
    }
    public void SetStyletInclut(bool styletInclut)
    {
        this.styletInclut = styletInclut;
    }

    public Tablette(string reference, string marque, string modele, string etat, double tailleEcranPouces, bool styletInclut) : base(reference, marque, modele, etat)
    {
        this.tailleEcranPouces = tailleEcranPouces;
        this.styletInclut = styletInclut;
    }
    public Tablette() : base()
    {
        this.tailleEcranPouces = 0.0;
        this.styletInclut = false;
    }

    public override void AfficherInformation()
    {
        base.AfficherInformation();
        Console.WriteLine("Taille de l'écran (pouces): " + tailleEcranPouces);
        Console.WriteLine("Stylet inclus: " + styletInclut);
    }

    public override int CalculerDureeMaxEmprunt()
    {
        return 7; // Les tablettes ont une durée d'emprunt de 7 jours... c'est peu... mais bon c'est déjà ça...
    }
}