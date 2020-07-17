using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using TkMemory.Domain.Items;

namespace TkMemory.Integration.TkClient.Properties.Commands.Peasant
{
    /// <summary>
    /// Commands common to all paths for using items.
    /// </summary>
    public class PeasantItemCommands
    {
        #region Fields

        private readonly Item _ring;
        private readonly TkClient _self;
        private readonly Item _yellowScroll;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Assigns key items from the item user's inventory.
        /// </summary>
        /// <param name="self">The game client data for the item user.</param>
        public PeasantItemCommands(TkClient self)
        {
            _self = self;

            _ring = _self.Inventory.KeyItems.Ring;
            _yellowScroll = _self.Inventory.KeyItems.YellowScroll;
        }

        #endregion Constructors

        #region Public Methods

        /// <summary>
        /// Uses a Love or Blood stone to teleport the item user to his/her spouse or
        /// blood sibling, respectively.
        /// </summary>
        /// <returns>True if an item was used; false otherwise.</returns>
        [SuppressMessage("ReSharper", "UnusedMember.Global")]
        public virtual async Task<bool> UseRing()
        {
            return await ItemCommands.UseItem(_self, _ring);
        }

        /// <summary>
        /// Consumes one Yellow scroll to teleport the item user to his/her home.
        /// </summary>
        /// <returns>True if an item was used; false otherwise.</returns>
        [SuppressMessage("ReSharper", "UnusedMember.Global")]
        public virtual async Task<bool> UseYellowScroll()
        {
            return await ItemCommands.UseItem(_self, _yellowScroll);
        }

        #endregion Public Methods
    }
}
