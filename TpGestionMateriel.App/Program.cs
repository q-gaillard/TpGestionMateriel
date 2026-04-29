namespace TpGestionMateriel.App;

class Program
{
    static void Main(string[] args)
    {
        GestionMateriel gestionMateriel = new GestionMateriel();

        // Création de quelques matériels nobles pour notre gestion de matériel ( parce que... bah oui... il faut bien du matériel à gérer !).
        OrdinateurPortable ordinateur1 = new OrdinateurPortable("REF001", "Dell", "XPS 15", "Bon état", 16, true);
        OrdinateurPortable ordinateur2 = new OrdinateurPortable("REF004", "HP", "Spectre x360", "Hors service", 8, false);
        Tablette tablette1 = new Tablette("REF002", "Apple", "iPad Pro", "Bon état", 12.9, true);
        Tablette tablette2 = new Tablette("REF005", "Samsung", "Galaxy Tab S7", "à vérifier", 11.0, false);
        VideoProjecteur videoProjecteur1 = new VideoProjecteur("REF003", "Epson", "PowerLite", "Bon état", 3000, true);
        VideoProjecteur videoProjecteur2 = new VideoProjecteur("REF006", "BenQ", "HT2050A", "Hors service", 2200, false);

        // Ajout des matériels à la gestion de matériel ( parce que... bah oui... il faut bien les ajouter pour pouvoir les gérer !).
        gestionMateriel.AjouterMateriel(ordinateur1);
        gestionMateriel.AjouterMateriel(tablette1);
        gestionMateriel.AjouterMateriel(videoProjecteur1);
        gestionMateriel.AjouterMateriel(ordinateur2);
        gestionMateriel.AjouterMateriel(tablette2);
        gestionMateriel.AjouterMateriel(videoProjecteur2);

        // Affichage des matériels disponibles
        gestionMateriel.AfficherMaterielsDisponibles();

        // Emprunt d'un matériel
        gestionMateriel.EmprunterMateriel("REF001");

        // Affichage des matériels disponibles après emprunt
        gestionMateriel.AfficherMaterielsDisponibles();

        // Retour d'un matériel
        gestionMateriel.RetournerMateriel("REF001");

        // Affichage des matériels disponibles après retour
        gestionMateriel.AfficherMaterielsDisponibles();

        // test des erreurs pontentielles
        gestionMateriel.EmprunterMateriel("REF001"); // emprunt normal
        gestionMateriel.EmprunterMateriel("REF001"); // emprunt d'un matériel déjà emprunté
        gestionMateriel.RetournerMateriel("REF001"); // retour normal
        gestionMateriel.RetournerMateriel("REF001"); // retour d'un matériel qui n'était pas emprunté
        gestionMateriel.EmprunterMateriel("REF999"); // emprunt d'un matériel qui n'existe pas
        gestionMateriel.RetournerMateriel("REF999"); // retour d'un matériel qui n'existe pas
    }
}
