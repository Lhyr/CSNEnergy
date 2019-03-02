using System;
using System.Collections.Generic;

namespace CSNEnergy
{
    /// <summary>
    /// Si un panier n’est pas valide car le catalogue ne contient pas assez d’ouvrage.
    /// </summary>
    public class NotEnoughInventoryException : Exception
    {
        public IEnumerable<INameQuantity> Missing { get; }

        /// <summary>
        /// Initialisation du message d'erreur, avec la liste des livres manquants.
        /// </summary>
        /// <param name="missing"></param>
        public NotEnoughInventoryException(IEnumerable<INameQuantity> missing) {
            Missing = missing;
        }
    }
}
