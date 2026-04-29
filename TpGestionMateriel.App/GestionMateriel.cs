using System.IO.Pipelines;
using System.Security;

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
    public bool AjouterMateriel(Materiel materiel)
    {
        if (materiel == null)
        {
            Console.WriteLine("Le matériel ne peut pas être 'null'.");  // pour éviter les erreurs nulles ( vous avez le jeu de mot ), parce que c'est pas cool de faire planter le programme.
            return false;
        }
        else
        {
            bool verif = true;
            foreach (Materiel elt in materiels)
            {
                if (elt.GetReference() == materiel.GetReference())
                {
                    verif = false;
                }
            }
            if (!verif)
            {
                Console.WriteLine("Un matériel avec cette référence existe déjà.");  // pour ne pas avoir deux fois le même truc ( ici on est tous différents ).
                return false;
            }
            else
            {
                materiels.Add(materiel);
                Console.WriteLine("Matériel ajouté avec succès.");
                return true;
            }
        }
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
        Console.WriteLine($"Matériel avec la référence {reference} non trouvé.");  // pour éviter de chercher un truc qui existe pas ( puisque... bah il existe pas...).
        return null;
    }
    // pour emprunter un matériel, adieu mon petit.
    public bool EmprunterMateriel(string reference)
    {
        foreach (Materiel materiel in materiels)
        {
            if (materiel.GetReference() == reference)
            {
                if (materiel.GetDisponible())
                {
                    if (materiel.GetEtat() != "Hors service")
                    {
                        if (materiel is OrdinateurPortable ordinateurPortable)
                        {
                            if (ordinateurPortable.GetPossedeChargeur())
                            {
                                materiel.SetDisponible(false);
                                Console.WriteLine($"Matériel {reference} emprunté avec succès ");
                                return true;
                            }
                            else
                            {
                                Console.WriteLine($"Le matériel {reference} ne peut pas être emprunté car il n'inclut pas de chargeur ");  // c'est pas cool d'emprunter un ordi sans chargeur... c'est comme voler une voiture sans essence... ça sert à rien...
                                return false;
                            }
                        }
                        else if (materiel is Tablette tablette)
                        {
                            if (tablette.GetStyletInclut())
                            {
                                materiel.SetDisponible(false);
                                Console.WriteLine($"Matériel {reference} emprunté avec succès ");
                                return true;
                            }
                            else
                            {
                                Console.WriteLine($"Le matériel {reference} ne peut pas être emprunté car il n'inclut pas de stylet ");  // c'est pas cool d'emprunter une tablette sans stylet... c'est comme voler une voiture sans volant... c'est débile...
                                return false;
                            }
                        }
                        else if (materiel is VideoProjecteur videoProjecteur)
                        {
                            if (videoProjecteur.GetCableHDMIInclut())
                            {
                                materiel.SetDisponible(false);
                                Console.WriteLine($"Matériel {reference} emprunté avec succès ");
                                return true;
                            }
                            else
                            {
                                Console.WriteLine($"Le matériel {reference} ne peut pas être emprunté car il n'inclut pas de câble HDMI ");  // c'est pas cool d'emprunter un vidéoprojecteur sans câble HDMI... c'est comme voler une voiture sans... bah... c'est pas vraiment comparable... mais c'est quand même pas cool...
                                return false;
                            }
                        }
                        else
                        {
                            materiel.SetDisponible(false);
                            Console.WriteLine($"Matériel {reference} emprunté avec succès ");
                            return true;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Le matériel {reference} est en panne et ne peut pas être emprunté ");  // IL EST CASSÉ !!! IL NE FONCTIONNE PAS !!! IL NE PEUT PAS ÊTRE EMPUNTÉ !!! 
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine($"Le matériel {reference} n'est pas disponible pour l'emprunt ");  // pour éviter d'emprunter un truc qui est déjà emprunté ( parce que c'est pas cool de voler le matériel de quelqu'un d'autre... même si c'est pas vraiment du vol... enfin bref...).
                    return false;
                }
            }
        }
        Console.WriteLine($"Materiel {reference} non trouvé");  // pour éviter de chercher un truc qui existe pas ( puisque... bah il existe pas...).
        return false;
    }
    // pour retourner un matériel, bon retour parmi nous mon petit.
    public bool RetournerMateriel(string reference)
    {
        foreach (Materiel materiel in materiels)
        {
            if (materiel.GetReference() == reference)
            {
                if (!materiel.GetDisponible())
                {
                    materiel.SetDisponible(true);
                    Console.WriteLine($"Matériel {reference} retourné avec succès ");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Le matériel {reference} n'était pas emprunté ");  // pour éviter de retourner un truc que tu n'a même pas emprunté ( ai-je vraiment besoin de préciser ça ?... apparemment oui...).
                    return false;
                }
            }
        }
        Console.WriteLine($"Materiel {reference} non trouvé");  // pour éviter de chercher un truc qui existe pas ( puisque... bah il existe pas...).
        return false;
    }
    // pour afficher les matériels disponibles, parce que c'est toujours mieux de savoir ce qu'on peut emprunter avant de l'emprunter (bah oui... logique !).
    public void AfficherMaterielsDisponibles()
    {
        Console.WriteLine("Matériels disponibles :");
        foreach (Materiel materiel in materiels)
        {
            if (materiel.GetDisponible() && materiel.GetEtat() != "Hors service")
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