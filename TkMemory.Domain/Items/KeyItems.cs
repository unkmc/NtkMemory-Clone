using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using TkMemory.Domain.Infrastructure;

namespace TkMemory.Domain.Items
{
    /// <summary>
    /// A collection of items most likely to be of relevance to a trainer.
    /// </summary>
    public class KeyItems
    {
        #region Fields

        private readonly List<Item> _inventory;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Scans a player's inventory to identify key items.
        /// </summary>
        /// <param name="inventory">A list of items held by the player.</param>
        public KeyItems(List<Item> inventory)
        {
            _inventory = inventory;

            Axe = GetItemByPriority(Priorities.Peasant.Axe);
            MajorManaRestoration = GetRestorationByPriorityAndQuantity(Priorities.Peasant.RestoreManaMajor);
            MiningPick = GetItemByPriority(Priorities.Peasant.MiningPick);
            MinorManaRestoration = GetRestorationByPriorityAndQuantity(Priorities.Peasant.RestoreManaMinor);
            Mount = GetMountByPriority(Priorities.Peasant.Mount);
            Ring = GetItemByPriority(Priorities.Peasant.Rings);
            VitaRestoration = GetRestorationByPriorityAndQuantity(Priorities.Peasant.RestoreVita);
            YellowScroll = GetItemByPriority(Priorities.Peasant.YellowScroll);

            InvokeOrb = GetItemByPriority(Priorities.Mage.Invoke);
            RippleOrb = GetItemByPriority(Priorities.Mage.Ripple);
            ScourgeOrb = GetItemByPriority(Priorities.Mage.Scourge);
            SulSlashOrb = GetItemByPriority(Priorities.Mage.SulSlash);
        }

        #endregion Constructors

        #region Properties

        #region Peasant

        /// <summary>
        /// An axe that can be used for the woodcutting skill.
        /// </summary>
        public Item Axe { get; }

        /// <summary>
        /// The most potent mana restoration item available. If there are multiple matches,
        /// the one with the lowest quantity will be selected.
        /// </summary>
        public Restoration MajorManaRestoration { get; }

        /// <summary>
        /// A mining pick that can be used for the mining skill.
        /// </summary>
        public Item MiningPick { get; }

        /// <summary>
        /// The least potent mana restoration item available. If there are multiple matches,
        /// the one with the lowest quantity will be selected.
        /// </summary>
        public Restoration MinorManaRestoration { get; }

        /// <summary>
        /// A creature that can be summoned and ridden for increased movement speed.
        /// </summary>
        public Item Mount { get; }

        /// <summary>
        /// An item used to transport a player to his/her partner.
        /// </summary>
        public Item Ring { get; }

        /// <summary>
        /// An item that can be consumed to restore vitality.
        /// </summary>
        public Restoration VitaRestoration { get; }

        /// <summary>
        /// An item that can be consumed to return the player to his/her home.
        /// </summary>
        public Item YellowScroll { get; }

        #endregion Peasant

        #region Mage

        /// <summary>
        /// An orb that can be used to cast Invoke.
        /// </summary>
        public Item InvokeOrb { get; }

        /// <summary>
        /// An orb that can be used to cast Ripple.
        /// </summary>
        public Item RippleOrb { get; }

        /// <summary>
        /// An orb that can be used to cast Scourge.
        /// </summary>
        public Item ScourgeOrb { get; }

        /// <summary>
        /// An orb that can be used to cast Sul Slash.
        /// </summary>
        public Item SulSlashOrb { get; }

        #endregion Mage

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Generates a string representation of a player's key item inventory.
        /// </summary>
        /// <returns>A list of key items held by the player.</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var propertyInfo in GetType().GetProperties())
            {
                sb.AppendLine($"{propertyInfo.Name.CamelCaseToString()} => {propertyInfo.GetValue(this)?.ToString() ?? "Empty"}");
            }

            return sb.ToString();
        }

        #endregion Public Methods

        #region Private Methods

        private Item GetMountByPriority(IEnumerable<string> priorityList)
        {
            return (from mount in priorityList
                    from item in _inventory
                    where CultureInfo.InvariantCulture.CompareInfo.IndexOf(item.Name, mount, CompareOptions.OrdinalIgnoreCase) >= 0
                    select item
            ).FirstOrDefault();
        }

        private Item GetItemByPriority(string name)
        {
            var priorityList = new[] { name };
            return GetItemByPriority(priorityList);
        }

        private Item GetItemByPriority(IEnumerable<string> priorityList)
        {
            return (from itemName in priorityList
                    from item in _inventory
                    where CultureInfo.InvariantCulture.CompareInfo.IndexOf(itemName, item.Name, CompareOptions.OrdinalIgnoreCase) >= 0
                    select new Item(Index.Parse(item.Letter), itemName, item.Quantity)
            ).FirstOrDefault();
        }

        private Restoration GetRestorationByPriorityAndQuantity(IEnumerable<Restoration> priorityList)
        {
            var itemsByPriorityThenQuantity = priorityList.Select(restoration =>
                from i in _inventory
                where string.Equals(i.Name, restoration.Name, StringComparison.OrdinalIgnoreCase)
                orderby i.Quantity
                select new Restoration(restoration.Name, restoration.RestoreAmount, Index.Parse(i.Letter), i.Quantity));

            var firstItemInList = itemsByPriorityThenQuantity
                .Select(x => x.FirstOrDefault())
                .FirstOrDefault(y => y != null);

            return firstItemInList;
        }

        #endregion Private Methods
    }
}
