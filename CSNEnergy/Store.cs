using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System.IO;
using System.Linq;

namespace CSNEnergy
{
    public class Store : IStore
    {
        JObject jobLibrairie;

        /// <summary>
        /// Importe une collection JSon dans une variable globale.
        /// On vérifie que la chaine passée en paramètre est valide suivant le 
        /// schéma, et si c'est le cas, on met à jour la variable globale qui stockera
        /// les informations.
        /// </summary>
        /// <param name="catalogAsJson"></param>
        public void Import(string catalogAsJson)
        {
            JSchema JSLib = JSchema.Parse(File.ReadAllText(@"Schemas\librairie_schema.json"));

            JObject job = JObject.Parse(catalogAsJson);

            if (job.IsValid(JSLib))
                jobLibrairie = job;
        }

        /// <summary>
        /// Récupère la quantité d'un produit au travers de son nom.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>le nombre de livres, 0, si le livre n'existe pas.</returns>
        public int Quantity(string name)
        {
            if (jobLibrairie == null || !jobLibrairie.ContainsKey("Catalog"))
                return 0;

            int results = jobLibrairie["Catalog"].Children().Where(book => book.Value<string>("Name") == name).Select(book => book.Value<int>("Quantity")).SingleOrDefault();

            return results;
        }

        /// <summary>
        /// Permet de constituer un panier au travers
        /// de noms d'éléments passés en paramètres.
        /// </summary>
        /// <param name="basketByNames"></param>
        /// <returns></returns>
        public double Buy(params string[] basketByNames)
        {
            double prixPanier = 0D;

            if (jobLibrairie == null)
                return prixPanier;

            /** la liste des livres qu'on souhaite acheter et leur nombre */
            var lstLivresDemandes = basketByNames.GroupBy(Name => Name).Select(NmGrp => new NameQuantity { Name = NmGrp.Key, Quantity = NmGrp.Count()});

            /** les livres dont on n'a pas assez d'exemplaire pour le client. */
            var InmQteErr = lstLivresDemandes.Where(bk => Quantity(bk.Name) < bk.Quantity);

            /** On retourne un message d'erreur pour les articles avec pas assez d'exemplaires. */
            if (InmQteErr.Count() > 0)
                throw new NotEnoughInventoryException(InmQteErr);

            /** liaison interne avec les livres du catalogue */
            var jb = jobLibrairie["Catalog"].Children().Join(
                lstLivresDemandes, cat => cat.Value<string>("Name"), lst => lst.Name, 
                (cat, lst) => new { lst.Name, lst.Quantity, Category = cat.Value<string>("Category"), Price = cat.Value<double>("Price") });

            /** les categories de livres que l'on recherche. */
            var jbCategories = jobLibrairie["Category"].Children().Where(catg => jb.Select(cat => cat.Category).Contains(catg.Value<string>("Name")));

            /** On boucle sur tous les produits pour en récupérer le prix.
             *  On regarde si on a prix des livres dans la même catégorie 
             *  et, si c'est le cas, on applique une réduction, sur le premier de chaque livre de la catégorie.
             *  Si le livre est pris plusieurs fois, on applique la réduction sur le premier livre également.
             *  Sinon, on applique le prix normal. */
            foreach(var livre in jb.ToList()) {
                double discount = jbCategories.Where(bk => bk.Value<string>("Name") == livre.Category).Select(bk => bk.Value<double>("Discount")).Single();

                if ((jb.Where(bk => bk.Category == livre.Category).Count() > 1) || livre.Quantity > 1) {
                    prixPanier += (livre.Price * (1 - discount)) + (livre.Quantity - 1) * livre.Price;
                }
                else {
                    prixPanier += livre.Quantity * livre.Price;
                }
            }

            return prixPanier;
        }

    }
}
