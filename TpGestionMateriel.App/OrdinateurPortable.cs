class OrdinateurPortable : Materiel  // Un appareil électronique à clavier azerty ou qwerty portatif.
{
    private int ramGo;
    private bool possedeChargeur;

    public int GetRamGo()
    {
        return ramGo;
    }
    public bool GetPossedeChargeur()
    {
        return possedeChargeur;
    }

    public void SetRamGo(int ramGo)
    {
        this.ramGo = ramGo;
    }
    public void SetPossedeChargeur(bool possedeChargeur)
    {
        this.possedeChargeur = possedeChargeur;
    }

    public OrdinateurPortable(string reference, string marque, string modele, string etat, int ramGo, bool possedeChargeur) : base(reference, marque, modele, etat)
    {
        this.ramGo = ramGo;
        this.possedeChargeur = possedeChargeur;
    }
    public OrdinateurPortable() : base()
    {
        this.ramGo = 0;
        this.possedeChargeur = false;
    }

    public override void AfficherInformation()
    {
        base.AfficherInformation();
        Console.WriteLine("RAM (Go): " + ramGo);
        Console.WriteLine("Possède un chargeur: " + possedeChargeur);
    }

    public override int CalculerDureeMaxEmprunt()
    {
        return 14; // Les ordis ont une durée d'emprunt de 14 jours, ce qui est plutôt bien.
    }
}