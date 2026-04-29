public abstract class Materiel
{
    protected string reference;
    protected string marque;
    protected string modele;
    protected string etat; // un état peut être : "Bon", "à vérifier" et "Hors service".
    protected bool disponible;

    public string GetReference()
    {
        return reference;
    }
    public string GetMarque()
    {
        return marque;
    }
    public string GetModele()
    {
        return modele;
    }
    public string GetEtat()
    {
        return etat;
    }
    public bool GetDisponible()
    {
        return disponible;
    }

    public void SetReference(string reference)
    {
        this.reference = reference;
    }
    public void SetMarque(string marque)
    {
        this.marque = marque;
    }
    public void SetModele(string modele)
    {
        this.modele = modele;
    }
    public void SetEtat(string etat)
    {
        this.etat = etat;
    }
    public void SetDisponible(bool disponible)
    {
        this.disponible = disponible;
    }

    public Materiel(string reference, string marque, string modele, string etat)
    {
        this.reference = reference;
        this.marque = marque;
        this.modele = modele;
        this.etat = etat;
        this.disponible = true;
    }
    public Materiel()
    {
        this.reference = "unknown";
        this.marque = "unknown";
        this.modele = "unknown";
        this.etat = "unknown";
        this.disponible = true;
    }

    public virtual void AfficherInformation()
    {
        Console.WriteLine("Reference: " + reference);
        Console.WriteLine("Marque: " + marque);
        Console.WriteLine("Modele: " + modele);
        Console.WriteLine("Etat: " + etat);
        Console.WriteLine("Disponible: " + disponible);
    }

    public virtual int CalculerDureeMaxEmprunt()
    {
        return 0; // Par défaut, la durée d'emprunt est de 0 jours car il n'existe pas de matériel générique à emprunter
    }
}