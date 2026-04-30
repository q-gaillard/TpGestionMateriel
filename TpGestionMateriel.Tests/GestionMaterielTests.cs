using Microsoft.VisualStudio.TestTools.UnitTesting;
using TpGestionMateriel.App;

namespace TpGestionMateriel.Tests
{
    [TestClass]
    public class GestionMaterielTests
    {
        [TestMethod]

        // test pour vérifié que l'ajout d'un matériel est possible si il est valide ( trop bien pour être vrai ?! )
        public void AjouterMateriel_RetourneTrue_QuandMaterielValide()
        {
            // arrange
            GestionMateriel gestionMateriel = new GestionMateriel();
            OrdinateurPortable ordinateur = new OrdinateurPortable("REF001", "Dell", "XPS 15", "Bon état", 16, true);
            // act
            bool result = gestionMateriel.AjouterMateriel(ordinateur);
            // assert
            Assert.IsTrue(result);
        }

        // test pour vérifié qui qu'il n'est pas possible d'ajouté des doublons ( we have a impostor AMOUG US !!! )
        public void AjouterMateriel_RetourneFalse_QuandMaterielExisteDeja()
        {
            // arrange
            GestionMateriel gestionMateriel = new GestionMateriel();
            OrdinateurPortable ordinateur = new OrdinateurPortable("REF001", "Dell", "XPS 15", "Bon état", 16, true);
            gestionMateriel.AjouterMateriel(ordinateur);
            // act
            bool result = gestionMateriel.AjouterMateriel(ordinateur);
            // assert
            Assert.IsFalse(result);
        }

        // test pour vérifié que l'ajout d'un matériel null n'est pas possible ( c'est pas trop trop possible de gérer un truc qui existe pas !).
        public void AjouterMateriel_RetourneFalse_QuandMaterielNull()
        {
            // arrange
            GestionMateriel gestionMateriel = new GestionMateriel();
            // act
            bool result = gestionMateriel.AjouterMateriel(null);
            // assert
            Assert.IsFalse(result);
        }

        // test pour vérifié que l'on ne peut pas chercher un matériel qui n'existe pas ( sinon l'on chercher longtemps...).
        public void RechercherMaterielParReference_RetourneNull_QuandMaterielNonExistant()
        {
            // arrange
            GestionMateriel gestionMateriel = new GestionMateriel();
            // act
            Materiel result = gestionMateriel.RechercherMaterielParReference("REF999");
            // assert
            Assert.IsNull(result);
        }

        // test pour vérifié que l'on peut chercher un matériel qui existe ( c'est justement tout le but de la recherche !).
        public void RechercherMaterielParReference_RetourneMateriel_QuandMaterielExistant()
        {
            // arrange
            GestionMateriel gestionMateriel = new GestionMateriel();
            OrdinateurPortable ordinateur = new OrdinateurPortable("REF001", "Dell", "XPS 15", "Bon état", 16, true);
            gestionMateriel.AjouterMateriel(ordinateur);
            // act
            Materiel result = gestionMateriel.RechercherMaterielParReference("REF001");
            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual("REF001", result.GetReference());
        }

        // test pour vérifié que l'on peut emprunter un matériel disponible ( à par si vous voulez emprunt du rien du tout).
        public void EmprunterMateriel_RetourneTrue_QuandMaterielDisponible()
        {
            // arrange
            GestionMateriel gestionMateriel = new GestionMateriel();
            OrdinateurPortable ordinateur = new OrdinateurPortable("REF001", "Dell", "XPS 15", "Bon état", 16, true);
            gestionMateriel.AjouterMateriel(ordinateur);
            // act
            bool result = gestionMateriel.EmprunterMateriel("REF001");
            // assert
            Assert.IsTrue(result);
        }

        // test pour vérifié que l'on ne peut pas emprunter un matériel qui n'est pas disponible ( vu que c'est pas dispo...).
        public void EmprunterMateriel_RetourneFalse_QuandMaterielNonDisponible()
        {
            // arrange
            GestionMateriel gestionMateriel = new GestionMateriel();
            OrdinateurPortable ordinateur = new OrdinateurPortable("REF001", "Dell", "XPS 15", "Bon état", 16, true);
            gestionMateriel.AjouterMateriel(ordinateur);
            gestionMateriel.EmprunterMateriel("REF001"); // Emprunter le matériel
            // act
            bool result = gestionMateriel.EmprunterMateriel("REF001"); // Tentative d'emprunt du même matériel
            // assert
            Assert.IsFalse(result);
        }

        // test pour vérifié que l'on ne peut pas emprunter un ordinateur sans chargeur ( c'est pas très malin de vouloir emprunter un truc qui ne peut pas être utilisé !).
        public void EmprunterMateriel_RetourneFalse_QuandOrdinateurSansChargeur()
        {
            // arrange
            GestionMateriel gestionMateriel = new GestionMateriel();
            OrdinateurPortable ordinateur = new OrdinateurPortable("REF001", "Dell", "XPS 15", "Bon état", 16, false);
            gestionMateriel.AjouterMateriel(ordinateur);
            // act
            bool result = gestionMateriel.EmprunterMateriel("REF001");
            // assert
            Assert.IsFalse(result);
        }

        // test pour vérifié que l'on ne peut pas emprunter une tablette sans stylet ( à par si vous préférez utiliser vos gros doigts sale ).
        public void EmprunterMateriel_RetourneFalse_QuandTabletteSansStylet()
        {
            // arrange
            GestionMateriel gestionMateriel = new GestionMateriel();
            Tablette tablette = new Tablette("REF002", "Apple", "iPad Pro", "Bon état", 12.9, false);
            gestionMateriel.AjouterMateriel(tablette);
            // act
            bool result = gestionMateriel.EmprunterMateriel("REF002");
            // assert
            Assert.IsFalse(result);
        }
    }
}