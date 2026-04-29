using System.IO.Pipelines;

class GestionMateriel
{
    private List<Materiel> materiels;

    public List<Materiel> GetMateriels()
    {
        return materiels;
    }

    public void SetMateriels(List<Materiel> materiels)
    {
        this.materiels = materiels;
    }

    public GestionMateriel(List<Materiel> materiels)
    {
        this.materiels = materiels;
    }
    public GestionMateriel()
    {
        this.materiels = new List<Materiel>();
    }

    // pour ajouter un jolie petit matériel à notre spendide liste.
    public void AjouterMateriel(Materiel materiel)
    {
        materiels.Add(materiel);
    }
    public Materiel RechercherMaterielParReference(string reference)
    {
        foreach (Materiel materiel in materiels)
        {
            if (materiel.GetReference() == reference)
            {
                return materiel;
            }
        }
        return null;
    }
    // pour emprunter un matériel, adieu mon petit.
    public void EmprunterMateriel(string reference)
    {
        foreach (Materiel materiel in materiels)
        {
            if (materiel.GetReference() == reference)
            {
                if (materiel.GetDisponible())
                {
                    materiel.SetDisponible(false);
                    Console.WriteLine($"Matériel {reference} emprunté avec succès ");
                }
                else
                {
                    Console.WriteLine($"Le matériel {reference} n'est pas disponible pour l'emprunt ");
                }
                return;
            }
        }
        Console.WriteLine($"Materiel {reference} non trouvé");
    }
    // pour retourner un matériel, bon retour parmi nous mon petit.
    public void RetournerMateriel(string reference)
    {
        foreach (Materiel materiel in materiels)
        {
            if (materiel.GetReference() == reference)
            {
                if (!materiel.GetDisponible())
                {
                    materiel.SetDisponible(true);
                    Console.WriteLine($"Matériel {reference} retourné avec succès ");
                }
                else
                {
                    Console.WriteLine($"Le matériel {reference} n'était pas emprunté ");
                }
                return;
            }
        }
        Console.WriteLine($"Materiel {reference} non trouvé");
    }
    // pour afficher les matériels disponibles, parce que c'est toujours mieux de savoir ce qu'on peut emprunter avant de l'emprunter (bah oui... logique !).
    public void AfficherMaterielsDisponibles()
    {
        Console.WriteLine("Matériels disponibles :");
        foreach (Materiel materiel in materiels)
        {
            if (materiel.GetDisponible())
            {
                materiel.AfficherInformation();
                Console.WriteLine("--------------------");
            }
        }
    }
    // pour afficher tous les matériels, même ceux qui sont empruntés, parce que c'est important de savoir ce qu'on a dans notre inventaire (même si c'est pas dispo...).
    public void AfficherToutLesMateriels()
    {
        Console.WriteLine("Tous les matériels :");
        foreach (Materiel materiel in materiels)
        {
            materiel.AfficherInformation();
            Console.WriteLine("--------------------");
        }
    }
    // pour calculer la durée maximale d'emprunt d'un matériel, parce que c'est important de savoir combien de temps on peut garder notre précieux matériel avant de devoir le rendre (et éviter les amendes...).
    public int CalculerDureeMaxEmprunt()
    {
        int result = 0;
        foreach (Materiel materiel in materiels)
        {
            result = result + materiel.CalculerDureeMaxEmprunt();
        }
        return result;
    }
}