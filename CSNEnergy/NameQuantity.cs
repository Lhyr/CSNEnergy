namespace CSNEnergy
{
    class NameQuantity : INameQuantity
    {
        /// <summary>
        /// Le nom du livre dont on souhaite la quantité
        /// </summary>
        public string Name {get; set;}
        /// <summary>
        /// La quantité de livres en stock
        /// </summary>
        public int Quantity {get; set;}
    }
}
