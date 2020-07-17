namespace TkMemory.Domain.Items
{
    /// <summary>
    /// An item that can be consumed to restore vitality or mana.
    /// </summary>
    public class Restoration : Item
    {
        #region Constructors

        /// <summary>
        /// Initializes a restoration item with its key properties.
        /// </summary>
        /// <param name="name">The name of the amount.</param>
        /// <param name="restoreAmount">The amount of vitality/mana that the item restores with each usage.</param>
        /// <param name="index">The numeric index of the position of the item within a player's inventory.</param>
        /// <param name="quantity">The current quantity of the item.</param>
        public Restoration(string name, int restoreAmount, int index = 0, int quantity = 0) : base(index, name, quantity)
        {
            RestoreAmount = restoreAmount;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// The amount of vitality/mana that the item restores with each usage.
        /// </summary>
        public int RestoreAmount { get; }

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Outputs all item properties in a more consistent approximation of the format used in-game.
        /// Also outputs the restoration potency of the item.
        /// </summary>
        /// <returns>A string representation of all key properties of the item.</returns>
        public override string ToString()
        {
            return $"{base.ToString()} (Restores: {RestoreAmount:N0})";
        }

        #endregion Public Methods
    }
}
