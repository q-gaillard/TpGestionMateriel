using System.ComponentModel;

public class VideoProjecteur : Materiel  // un appareil à tire lumière capable de faire apparaître des éléments visuels sans écran, c'est DE LA SORCELLERIE !
{
    private int luminositeLumens;
    private bool cableHDMIInclut;

    public int GetLuminositeLumens()
    {
        return luminositeLumens;
    }
    public bool GetCableHDMIInclut()
    {
        return cableHDMIInclut;
    }

    public void SetLuminositeLumens(int luminositeLumens)
    {
        this.luminositeLumens = luminositeLumens;
    }
    public void SetCableHDMIInclut(bool cableHDMIInclut)
    {
        this.cableHDMIInclut = cableHDMIInclut;
    }

    public VideoProjecteur(string reference, string marque, string modele, string etat, int luminositeLumens, bool cableHDMIInclut) : base(reference, marque, modele, etat)
    {
        this.luminositeLumens = luminositeLumens;
        this.cableHDMIInclut = cableHDMIInclut;
    }
    public VideoProjecteur() : base()
    {
        this.luminositeLumens = 0;
        this.cableHDMIInclut = false;
    }

    public override void AfficherInformation()
    {
        base.AfficherInformation();
        Console.WriteLine("Luminosité (lumens): " + luminositeLumens);
        Console.WriteLine("Câble HDMI inclus: " + cableHDMIInclut);
    }

    public override int CalculerDureeMaxEmprunt()
    {
        return 3; //euh... C'EST TOUT ?!! C'EST TOUT !!!!
    }
}