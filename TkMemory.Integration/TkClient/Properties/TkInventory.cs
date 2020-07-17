using AutoHotkey.Interop.ClassMemory;
using System;
using System.Collections.Generic;
using System.Text;
using TkMemory.Domain.Items;
using TkMemory.Integration.TkClient.Infrastructure;

namespace TkMemory.Integration.TkClient.Properties
{
    /// <summary>
    /// Provides information about the items currently possessed by a player. Item inventory data
    /// is cached for performance reasons, so it is not updated automatically in real time.
    /// </summary>
    public class TkInventory
    {
        #region Fields

        private const string LeftBracket = "[";
        private const int MaxNumberOfItems = 27;

        private readonly ClassMemory _classMemory;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a player's item data.
        /// </summary>
        /// <param name="classMemory">The application memory for the player's game client.</param>
        public TkInventory(ClassMemory classMemory)
        {
            _classMemory = classMemory;
            Update();
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the current item inventory of the player.
        /// </summary>
        public List<Item> Items { get; private set; }

        /// <summary>
        /// Gets the key items currently possessed by the player.
        /// </summary>
        public KeyItems KeyItems { get; private set; }

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Gets the name and quantity of the item at the specified position within a player's item inventory.
        /// The format used is a more consistent approximation of the format used in-game for a player's item
        /// inventory.
        /// </summary>
        /// <param name="inventoryPosition">The zero-indexed position of the item within the player's item inventory.</param>
        /// <returns>The name and quantity of the item in a more consistent approximation of the format used in-game for a
        /// player's item inventory.</returns>
        public string GetDisplayName(int inventoryPosition)
        {
            var address = TkAddresses.Self.Inventory.DisplayName;
            var offsets = address.Offsets.AddPositionOffset(inventoryPosition, TkAddresses.Self.Inventory.PositionOffset);
            return _classMemory.ReadString(address.BaseAddress, offsets, Constants.DefaultEncoding);
        }

        /// <summary>
        /// Gets the name of the item at the specified position within a player's item inventory.
        /// </summary>
        /// <param name="inventoryPosition">The zero-indexed position of the item within the player's item inventory.</param>
        /// <returns>The name of the item.</returns>
        public string GetName(int inventoryPosition)
        {
            var address = TkAddresses.Self.Inventory.ItemName;
            var offsets = address.Offsets.AddPositionOffset(inventoryPosition, TkAddresses.Self.Inventory.PositionOffset);
            return _classMemory.ReadString(address.BaseAddress, offsets, Constants.DefaultEncoding);
        }

        /// <summary>
        /// Gets the current quantity of the item at the specified position within a player's item inventory.
        /// </summary>
        /// <param name="inventoryPosition">The zero-indexed position of the item within the player's item inventory.</param>
        /// <returns>The current quantity of the item.</returns>

        public int GetQuantity(int inventoryPosition)
        {
            var address = TkAddresses.Self.Inventory.Quantity;
            var offsets = address.Offsets.AddPositionOffset(inventoryPosition, TkAddresses.Self.Inventory.PositionOffset);
            return _classMemory.Read<int>(address.BaseAddress, offsets);
        }

        /// <summary>
        /// Discards any cached item data and replaces it with the current state.
        /// </summary>
        public void Update()
        {
            Items = new List<Item>();

            for (var i = 0; i < MaxNumberOfItems; i++)
            {
                var displayName = GetDisplayName(i);

                if (string.IsNullOrWhiteSpace(displayName))
                {
                    continue;
                }

                var quantity = displayName.Contains(LeftBracket) && !displayName.Contains("(")
                    ? ParseQuantityFromDisplayName(displayName)
                    : GetQuantity(i);

                Items.Add(new Item(i, GetName(i), quantity));
            }

            KeyItems = new KeyItems(Items);
        }

        /// <summary>
        /// Outputs all items currently possessed by the player in a more consistent approximation of the format
        /// used in-game for a player's item inventory.
        /// </summary>
        /// <returns>A string representation of all key items currently possessed by the player.</returns>

        public override string ToString()
        {
            if (Items == null || Items.Count == 0)
            {
                return "No inventory is cached. Call Update() and try again.";
            }

            var sb = new StringBuilder();

            foreach (var item in Items)
            {
                sb.AppendLine(item.ToString());
            }

            sb.AppendLine(System.Environment.NewLine + KeyItems);

            return sb.ToString();
        }

        #endregion Public Methods

        #region Private Methods

        private static int ParseQuantityFromDisplayName(string displayName)
        {
            var startIndex = displayName.IndexOf(LeftBracket, StringComparison.Ordinal) + 1;
            var length = displayName.Substring(startIndex).IndexOf(" ", StringComparison.Ordinal);
            var quantity = displayName.Substring(startIndex, length);

            if (!int.TryParse(quantity, out var result))
            {
                throw new Exception($"Failed to parse item quantity from item display name '{displayName}'");
            }

            return result;
        }

        #endregion Private Methods
    }
}
