using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSNEnergy;

namespace CSNEnergy_TestsUnitaires
{
    [TestClass]
    public class StoreTest
    {

        /// <summary>
        /// Ici on teste si la fonction quantité remplit bien sa fonction, 
        /// avec le test de l'exemple.
        /// Exemple d’appel :
        /// Store.Quantity("Ayn Rand - FountainHead");
        /// Résultat :
        /// 10
        /// </summary>
        [TestMethod]
        public void Quantity_AynRand_10() {
            Store store = new Store();
            store.Import(@"{ ""Category"":[ { ""Name"": ""Science Fiction"", ""Discount"": 0.05 }, { ""Name"": ""Fantastique"", ""Discount"": 0.1 }, { ""Name"": ""Philosophy"", ""Discount"": 0.15 }, ], ""Catalog"": [ { ""Name"": ""J.K Rowling - Goblet Of fire"", ""Category"": ""Fantastique"", ""Price"": 8, ""Quantity"": 2 }, { ""Name"": ""Ayn Rand - FountainHead"", ""Category"": ""Philosophy"", ""Price"": 12, ""Quantity"": 10 }, { ""Name"": ""Isaac Asimov - Foundation"", ""Category"": ""Science Fiction"", ""Price"": 16, ""Quantity"": 1 }, { ""Name"": ""Isaac Asimov - Robot series"", ""Category"": ""Science Fiction"", ""Price"": 5, ""Quantity"": 1 }, { ""Name"": ""Robin Hobb - Assassin Apprentice"", ""Category"": ""Fantastique"", ""Price"": 12, ""Quantity"": 8 } ], }");

            Assert.AreEqual(10, store.Quantity("Ayn Rand - FountainHead"));
        }

        /// <summary>
        /// Ici on teste si la fonction quantité remplit bien sa fonction, 
        /// avec un test tiré directement du JSON.
        /// J.K Rowling - Goblet Of fire : 2
        /// </summary>
        [TestMethod]
        public void Quantity_Rowling_2()
        {
            Store store = new Store();
            store.Import(@"{ ""Category"":[ { ""Name"": ""Science Fiction"", ""Discount"": 0.05 }, { ""Name"": ""Fantastique"", ""Discount"": 0.1 }, { ""Name"": ""Philosophy"", ""Discount"": 0.15 }, ], ""Catalog"": [ { ""Name"": ""J.K Rowling - Goblet Of fire"", ""Category"": ""Fantastique"", ""Price"": 8, ""Quantity"": 2 }, { ""Name"": ""Ayn Rand - FountainHead"", ""Category"": ""Philosophy"", ""Price"": 12, ""Quantity"": 10 }, { ""Name"": ""Isaac Asimov - Foundation"", ""Category"": ""Science Fiction"", ""Price"": 16, ""Quantity"": 1 }, { ""Name"": ""Isaac Asimov - Robot series"", ""Category"": ""Science Fiction"", ""Price"": 5, ""Quantity"": 1 }, { ""Name"": ""Robin Hobb - Assassin Apprentice"", ""Category"": ""Fantastique"", ""Price"": 12, ""Quantity"": 8 } ], }");

            Assert.AreEqual(2, store.Quantity("J.K Rowling - Goblet Of fire"));
        }

        /// <summary>
        /// Ici on teste si la fonction quantité remplit bien sa fonction, 
        /// avec un test tiré directement du JSON.
        /// Isaac Asimov - Foundation : 1
        /// </summary>
        [TestMethod]
        public void Quantity_Asimov_Foundation_16()
        {
            Store store = new Store();
            store.Import(@"{ ""Category"":[ { ""Name"": ""Science Fiction"", ""Discount"": 0.05 }, { ""Name"": ""Fantastique"", ""Discount"": 0.1 }, { ""Name"": ""Philosophy"", ""Discount"": 0.15 }, ], ""Catalog"": [ { ""Name"": ""J.K Rowling - Goblet Of fire"", ""Category"": ""Fantastique"", ""Price"": 8, ""Quantity"": 2 }, { ""Name"": ""Ayn Rand - FountainHead"", ""Category"": ""Philosophy"", ""Price"": 12, ""Quantity"": 10 }, { ""Name"": ""Isaac Asimov - Foundation"", ""Category"": ""Science Fiction"", ""Price"": 16, ""Quantity"": 1 }, { ""Name"": ""Isaac Asimov - Robot series"", ""Category"": ""Science Fiction"", ""Price"": 5, ""Quantity"": 1 }, { ""Name"": ""Robin Hobb - Assassin Apprentice"", ""Category"": ""Fantastique"", ""Price"": 12, ""Quantity"": 8 } ], }");

            Assert.AreEqual(1, store.Quantity("Isaac Asimov - Foundation"));
        }

        /// <summary>
        /// Ici on teste si la fonction quantité remplit bien sa fonction, 
        /// avec un test tiré directement du JSON.
        /// Isaac Asimov - Robot series : 1
        /// </summary>
        [TestMethod]
        public void Quantity_Asimov_Robot_1()
        {
            Store store = new Store();
            store.Import(@"{ ""Category"":[ { ""Name"": ""Science Fiction"", ""Discount"": 0.05 }, { ""Name"": ""Fantastique"", ""Discount"": 0.1 }, { ""Name"": ""Philosophy"", ""Discount"": 0.15 }, ], ""Catalog"": [ { ""Name"": ""J.K Rowling - Goblet Of fire"", ""Category"": ""Fantastique"", ""Price"": 8, ""Quantity"": 2 }, { ""Name"": ""Ayn Rand - FountainHead"", ""Category"": ""Philosophy"", ""Price"": 12, ""Quantity"": 10 }, { ""Name"": ""Isaac Asimov - Foundation"", ""Category"": ""Science Fiction"", ""Price"": 16, ""Quantity"": 1 }, { ""Name"": ""Isaac Asimov - Robot series"", ""Category"": ""Science Fiction"", ""Price"": 5, ""Quantity"": 1 }, { ""Name"": ""Robin Hobb - Assassin Apprentice"", ""Category"": ""Fantastique"", ""Price"": 12, ""Quantity"": 8 } ], }");

            Assert.AreEqual(1, store.Quantity("Isaac Asimov - Robot series"));
        }

        /// <summary>
        /// Ici on teste si la fonction quantité remplit bien sa fonction, 
        /// avec un exemple qui n'existe pas.
        /// Il retourne 0.
        /// </summary>
        [TestMethod]
        public void Quantity_Inconnu_0()
        {
            Store store = new Store();
            store.Import(@"{ ""Category"":[ { ""Name"": ""Science Fiction"", ""Discount"": 0.05 }, { ""Name"": ""Fantastique"", ""Discount"": 0.1 }, { ""Name"": ""Philosophy"", ""Discount"": 0.15 }, ], ""Catalog"": [ { ""Name"": ""J.K Rowling - Goblet Of fire"", ""Category"": ""Fantastique"", ""Price"": 8, ""Quantity"": 2 }, { ""Name"": ""Ayn Rand - FountainHead"", ""Category"": ""Philosophy"", ""Price"": 12, ""Quantity"": 10 }, { ""Name"": ""Isaac Asimov - Foundation"", ""Category"": ""Science Fiction"", ""Price"": 16, ""Quantity"": 1 }, { ""Name"": ""Isaac Asimov - Robot series"", ""Category"": ""Science Fiction"", ""Price"": 5, ""Quantity"": 1 }, { ""Name"": ""Robin Hobb - Assassin Apprentice"", ""Category"": ""Fantastique"", ""Price"": 12, ""Quantity"": 8 } ], }");

            Assert.AreEqual(0, store.Quantity("Anne McCaffrey - Le Vol du dragon"));
        }

        /// <summary>
        /// Ici on teste si la fonction Buy remplit bien sa fonction, 
        /// avec le test de l'exemple.
        /// Exemple d’appel :
        /// Store.Buy("J.K Rowling - Goblet Of fire", "Isaac Asimov - Foundation");
        /// Résultat :
        /// 24.00
        /// </summary>
        [TestMethod]
        public void Buy_RowlingAsimov_24()
        {
            Store store = new Store();
            store.Import(@"{ ""Category"":[ { ""Name"": ""Science Fiction"", ""Discount"": 0.05 }, { ""Name"": ""Fantastique"", ""Discount"": 0.1 }, { ""Name"": ""Philosophy"", ""Discount"": 0.15 }, ], ""Catalog"": [ { ""Name"": ""J.K Rowling - Goblet Of fire"", ""Category"": ""Fantastique"", ""Price"": 8, ""Quantity"": 2 }, { ""Name"": ""Ayn Rand - FountainHead"", ""Category"": ""Philosophy"", ""Price"": 12, ""Quantity"": 10 }, { ""Name"": ""Isaac Asimov - Foundation"", ""Category"": ""Science Fiction"", ""Price"": 16, ""Quantity"": 1 }, { ""Name"": ""Isaac Asimov - Robot series"", ""Category"": ""Science Fiction"", ""Price"": 5, ""Quantity"": 1 }, { ""Name"": ""Robin Hobb - Assassin Apprentice"", ""Category"": ""Fantastique"", ""Price"": 12, ""Quantity"": 8 } ], }");

            Assert.AreEqual(24, store.Buy("J.K Rowling - Goblet Of fire", "Isaac Asimov - Foundation"));
        }

        /// <summary>
        /// Ici on teste si la fonction Buy remplit bien sa fonction, 
        /// avec le test de l'annexe.
        /// Exemple 1 : si un client achète un exemplaire de J.K Rowling - Goblet Of fire et deux de Robin Hobb - Assassin Apprentice,
        /// seuls Goblet of fire et un des deux exemplaires de Robin Hobb aura le droit à la réduction 
        /// (ce qui donnerait un prix de 30 = 8 * 0.9 + 12 * 0.9 + 12).
        /// </summary>
        [TestMethod]
        public void Buy_1Rowling_2Hobb_30()
        {
            Store store = new Store();
            store.Import(@"{ ""Category"":[ { ""Name"": ""Science Fiction"", ""Discount"": 0.05 }, { ""Name"": ""Fantastique"", ""Discount"": 0.1 }, { ""Name"": ""Philosophy"", ""Discount"": 0.15 }, ], ""Catalog"": [ { ""Name"": ""J.K Rowling - Goblet Of fire"", ""Category"": ""Fantastique"", ""Price"": 8, ""Quantity"": 2 }, { ""Name"": ""Ayn Rand - FountainHead"", ""Category"": ""Philosophy"", ""Price"": 12, ""Quantity"": 10 }, { ""Name"": ""Isaac Asimov - Foundation"", ""Category"": ""Science Fiction"", ""Price"": 16, ""Quantity"": 1 }, { ""Name"": ""Isaac Asimov - Robot series"", ""Category"": ""Science Fiction"", ""Price"": 5, ""Quantity"": 1 }, { ""Name"": ""Robin Hobb - Assassin Apprentice"", ""Category"": ""Fantastique"", ""Price"": 12, ""Quantity"": 8 } ], }");

            Assert.AreEqual(30, store.Buy("J.K Rowling - Goblet Of fire", "Robin Hobb - Assassin Apprentice", "Robin Hobb - Assassin Apprentice"));
        }

        /// <summary>
        /// Ici on teste si la fonction Buy remplit bien sa fonction, 
        /// avec le test de l'annexe.
        /// Exemple 2 : si un client achète un exemplaire de Rand, les deux ouvrages d’Asimov 
        /// (un exemplaire de Isaac Asimov - Robot series et un de Isaac Asimov – Foundation),
        /// l’ouvrage de Rowling en deux exemplaire et celui de Hobb en deux exemplaires,
        /// il doit payer 69.95 € = 12 + 5 * 0.95 + 16 * 0.95 + 8 *0.9 + 8 + 12 * 0.9 + 12
        /// </summary>
        [TestMethod]
        public void Buy_1Rand_2Asimov_2Rowling_Hobb_6995()
        {
            Store store = new Store();
            store.Import(@"{ ""Category"":[ { ""Name"": ""Science Fiction"", ""Discount"": 0.05 }, { ""Name"": ""Fantastique"", ""Discount"": 0.1 }, { ""Name"": ""Philosophy"", ""Discount"": 0.15 }, ], ""Catalog"": [ { ""Name"": ""J.K Rowling - Goblet Of fire"", ""Category"": ""Fantastique"", ""Price"": 8, ""Quantity"": 2 }, { ""Name"": ""Ayn Rand - FountainHead"", ""Category"": ""Philosophy"", ""Price"": 12, ""Quantity"": 10 }, { ""Name"": ""Isaac Asimov - Foundation"", ""Category"": ""Science Fiction"", ""Price"": 16, ""Quantity"": 1 }, { ""Name"": ""Isaac Asimov - Robot series"", ""Category"": ""Science Fiction"", ""Price"": 5, ""Quantity"": 1 }, { ""Name"": ""Robin Hobb - Assassin Apprentice"", ""Category"": ""Fantastique"", ""Price"": 12, ""Quantity"": 8 } ], }");

            Assert.AreEqual(69.95, store.Buy("Ayn Rand - FountainHead", "Isaac Asimov - Foundation", "Isaac Asimov - Robot series", "J.K Rowling - Goblet Of fire", "J.K Rowling - Goblet Of fire", "Robin Hobb - Assassin Apprentice", "Robin Hobb - Assassin Apprentice"));
        }

        /// <summary>
        /// Ici on teste si la fonction Buy remplit bien sa fonction, 
        /// Si le client achète plusieurs fois le même livre, réduction sur le premier.
        /// "J.K Rowling - Goblet Of fire", "J.K Rowling - Goblet Of fire"
        /// Résultat :
        /// 15.20
        /// </summary>
        [TestMethod]
        public void Buy_2Rowling_1520()
        {
            Store store = new Store();
            store.Import(@"{ ""Category"":[ { ""Name"": ""Science Fiction"", ""Discount"": 0.05 }, { ""Name"": ""Fantastique"", ""Discount"": 0.1 }, { ""Name"": ""Philosophy"", ""Discount"": 0.15 }, ], ""Catalog"": [ { ""Name"": ""J.K Rowling - Goblet Of fire"", ""Category"": ""Fantastique"", ""Price"": 8, ""Quantity"": 2 }, { ""Name"": ""Ayn Rand - FountainHead"", ""Category"": ""Philosophy"", ""Price"": 12, ""Quantity"": 10 }, { ""Name"": ""Isaac Asimov - Foundation"", ""Category"": ""Science Fiction"", ""Price"": 16, ""Quantity"": 1 }, { ""Name"": ""Isaac Asimov - Robot series"", ""Category"": ""Science Fiction"", ""Price"": 5, ""Quantity"": 1 }, { ""Name"": ""Robin Hobb - Assassin Apprentice"", ""Category"": ""Fantastique"", ""Price"": 12, ""Quantity"": 8 } ], }");

            Assert.AreEqual(15.20, store.Buy("J.K Rowling - Goblet Of fire", "J.K Rowling - Goblet Of fire"));
        }

        /// <summary>
        /// Ici on teste si la fonction Buy remplit bien sa fonction, 
        /// avec le test de l'annexe.
        /// Si un panier n’est pas valide car le catalogue ne contient pas assez d’ouvrage
        /// (par exemple si le client veut acheter deux exemplaires de Isaac Asimov Foundation),
        /// le propriétaire s’attend à recevoir une exception de type NotEnoughInventoryException contenant la liste des ouvrages introuvables.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NotEnoughInventoryException))]
        public void Buy_1Rand_2Asimov_Error()
        {
            Store store = new Store();
            store.Import(@"{ ""Category"":[ { ""Name"": ""Science Fiction"", ""Discount"": 0.05 }, { ""Name"": ""Fantastique"", ""Discount"": 0.1 }, { ""Name"": ""Philosophy"", ""Discount"": 0.15 }, ], ""Catalog"": [ { ""Name"": ""J.K Rowling - Goblet Of fire"", ""Category"": ""Fantastique"", ""Price"": 8, ""Quantity"": 2 }, { ""Name"": ""Ayn Rand - FountainHead"", ""Category"": ""Philosophy"", ""Price"": 12, ""Quantity"": 10 }, { ""Name"": ""Isaac Asimov - Foundation"", ""Category"": ""Science Fiction"", ""Price"": 16, ""Quantity"": 1 }, { ""Name"": ""Isaac Asimov - Robot series"", ""Category"": ""Science Fiction"", ""Price"": 5, ""Quantity"": 1 }, { ""Name"": ""Robin Hobb - Assassin Apprentice"", ""Category"": ""Fantastique"", ""Price"": 12, ""Quantity"": 8 } ], }");

            store.Buy("Isaac Asimov - Foundation", "Isaac Asimov - Foundation");
        }

    }
}
