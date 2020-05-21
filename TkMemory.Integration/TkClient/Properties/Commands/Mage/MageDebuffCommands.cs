// This file is part of TkMemory.

// TkMemory is free software. You can redistribute it and/or modify it
// under the terms of the GNU General Public License as published by the
// Free Software Foundation, either version 3 of the License or (at your
// option) any later version.

// TkMemory is distributed in the hope that it will be useful but WITHOUT
// ANY WARRANTY, without even the implied warranty of MERCHANTABILITY or
// FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License
// for more details.

// You should have received a copy of the GNU General Public License
// along with TkMemory. If not, please refer to:
// https://www.gnu.org/licenses/gpl-3.0.en.html

using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using TkMemory.Domain.Spells;
using TkMemory.Integration.TkClient.Properties.Commands.Caster;
using TkMemory.Integration.TkClient.Properties.Group;
using TkMemory.Integration.TkClient.Properties.Npcs;

// ReSharper disable UnusedMember.Global

namespace TkMemory.Integration.TkClient.Properties.Commands.Mage
{
    /// <summary>
    /// Commands that are used to cast debuffs and debuff cures that are specific to Mages.
    /// </summary>
    public class MageDebuffCommands : CasterDebuffCommands
    {
        #region Fields

        private readonly KeySpell _blindSpell;
        private readonly KeySpell _dozeSpell;
        private readonly KeySpell _paralyzeSpell;
        private readonly KeySpell _sleepSpell;
        private readonly KeySpell _venomSpell;
        private readonly KeySpell _scourgeOrb;
        private readonly MageClient _self;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Assigns debuff spells from the Mage's spell inventory.
        /// </summary>
        /// <param name="self">The game client data for the Mage.</param>
        public MageDebuffCommands(MageClient self) : base(self)
        {
            _self = self;

            _blindSpell = self.Spells.KeySpells.Blind;
            _dozeSpell = self.Spells.KeySpells.Doze;
            _paralyzeSpell = self.Spells.KeySpells.Paralyze;
            _sleepSpell = self.Spells.KeySpells.Sleep;
            _venomSpell = self.Spells.KeySpells.Venom;

            _scourgeOrb = self.Inventory.KeyItems.ScourgeOrb == null
                ? null
                : new KeySpell(self.Inventory.KeyItems.ScourgeOrb);
        }

        #endregion Constructors

        #region Public Methods

        #region Blind

        /// <summary>
        /// Casts the Blindness debuff on a target.
        /// </summary>
        /// <param name="target">The NPC to target for the debuff.</param>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> Blind(Npc target)
        {
            return await StatusCommands.CastStatus(_self, target, target.Activity.Blind, _blindSpell);
        }

        /// <summary>
        /// Iterates through the NPCs in the Mage's vicinity and casts Blind on the first NPC found to be eligible for it.
        /// The method will exit and return true as soon as the spell is cast once. If no eligible NPCs are found,
        /// the method will return false.
        /// </summary>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> BlindNpcs()
        {
            // It may seem like there are more efficient ways to do this loop, but it is imperative to iterate through
            // the list backwards to properly handle removals from the list further downstream.
            for (var i = _self.Npcs.Count - 1; i >= 0; i--)
            {
                if (await Blind(_self.Npcs[i]))
                {
                    return true;
                }
            }

            return false;
        }

        #endregion Blind

        #region Doze

        /// <summary>
        /// Casts the Doze debuff on a target.
        /// </summary>
        /// <param name="target">The NPC to target for the debuff.</param>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> Doze(Npc target)
        {
            return await StatusCommands.CastStatus(_self, target, target.Activity.Doze, _dozeSpell);
        }

        /// <summary>
        /// Iterates through the NPCs in the Mage's vicinity and casts Doze on the first NPC found to be eligible for it.
        /// The method will exit and return true as soon as the spell is cast once. If no eligible NPCs are found,
        /// the method will return false.
        /// </summary>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> DozeNpcs()
        {
            // It may seem like there are more efficient ways to do this loop, but it is imperative to iterate through
            // the list backwards to properly handle removals from the list further downstream.
            for (var i = _self.Npcs.Count - 1; i >= 0; i--)
            {
                if (await Doze(_self.Npcs[i]))
                {
                    return true;
                }
            }

            return false;
        }

        #endregion Doze

        #region Esuna

        /// <summary>
        /// Casts the Mage's full array of debuff cures on a target. Each debuff cure will only be cast if the target
        /// is found to be affected by the debuff. The method will exit and return true as soon as a spell is cast on
        /// on the target. If no spells are cast, the method will return false. The spell priority is Remove Curse,
        /// Cure Paralysis, and then Purge.
        /// </summary>
        /// <param name="target">The caster or a multibox member of the caster's group.</param>
        /// <returns>True if a spell was cast; false otherwise.</returns>
        public async Task<bool> Esuna(TkClient target)
        {
            return await RemoveCurse(target)
                || await CureParalysis(target)
                || await Purge(target);
        }

        /// <summary>
        /// Casts the Mage's full array of debuff cures on a target. Since there is no way to read the active status
        /// effects of an external group member, each debuff cure is cast on its turn but is skipped on the subsequent
        /// iteration of this method (assuming eligibility is not reset by some other process). The method will exit
        /// and return true as soon as a spell is cast on on the target. If no spells are cast, the method will return
        /// false. The spell priority is Remove Curse, Cure Paralysis, and then Purge.
        /// </summary>
        /// <param name="target">An external member of the caster's group.</param>
        /// <returns>True if a spell was cast; false otherwise.</returns>
        public async Task<bool> Esuna(GroupMember target)
        {
            return await RemoveCurse(target)
                || await CureParalysis(target)
                || await Purge(target);
        }

        /// <summary>
        /// Iterates through the Mage's group and casts the Mage's full array of debuff cures on each group member.
        /// The method will exit and return true as soon as a spell is cast on a group member. If no spells are cast,
        /// the method will return false. The group member priority order is the caster, multibox group members, and
        /// then external group members. The spell priority is Remove Curse, Cure Paralysis, and then Purge.
        /// </summary>
        /// <returns>True if a spell was cast; false otherwise.</returns>
        public async Task<bool> EsunaGroup()
        {
            if (await Esuna(_self))
            {
                return true;
            }

            foreach (var multiboxMember in _self.Group.MultiboxMembers)
            {
                if (await Esuna(multiboxMember))
                {
                    return true;
                }
            }

            foreach (var externalMember in _self.Group.ExternalMembers)
            {
                if (await Esuna(externalMember))
                {
                    return true;
                }
            }

            return false;
        }

        #endregion Esuna

        #region Paralyze

        /// <summary>
        /// Casts the Paralyze debuff on a target.
        /// </summary>
        /// <param name="target">The NPC to target for the debuff.</param>
        /// <param name="ignoreEligibility">If true, cast on the target no matter what. If false,
        /// cast only if the duration of the spell has elapsed since the last casting.</param>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> Paralyze(Npc target, bool ignoreEligibility)
        {
            if (ignoreEligibility)
            {
                target.Activity.Paralyze.SetInactive();
            }

            return await StatusCommands.CastStatus(_self, target, target.Activity.Paralyze, _paralyzeSpell);
        }

        /// <summary>
        /// Iterates through the NPCs in the Mage's vicinity and casts Paralyze on the first NPC found to be eligible
        /// for it. The method will exit and return true as soon as the spell is cast once. If no eligible NPCs are
        /// found, the method will return false.
        /// </summary>
        /// <param name="ignoreEligibility">If true, cast repeatedly on targets to compensate for the failure rate.
        /// If false, cast on a particular target only as often as the duration of the spell.</param>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        [SuppressMessage("ReSharper", "InvertIf")]
        public async Task<bool> ParalyzeNpcs(bool ignoreEligibility = false)
        {
            // It may seem like there are more efficient ways to do this loop, but it is imperative to iterate through
            // the list backwards to properly handle removals from the list further downstream.
            for (var i = _self.Npcs.Count - 1; i >= 0; i--)
            {
                if (ignoreEligibility && i == 0)
                {
                    // We have iterated through the entire list of NPCs, so mark each as eligible for Paralyze again and start over.
                    foreach (var npc in _self.Npcs)
                    {
                        npc.Activity.Paralyze.SetInactive();
                    }
                }

                if (await Paralyze(_self.Npcs[i], false)) // Never ignore eligibility here. It would cause an infinite loop of paralyzing a single target.
                {
                    return true;
                }
            }

            return false;
        }

        #endregion Paralyze

        #region Sleep

        /// <summary>
        /// Casts the Sleep debuff on a target.
        /// </summary>
        /// <param name="target">The NPC to target for the debuff.</param>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> Sleep(Npc target)
        {
            return await StatusCommands.CastStatus(_self, target, target.Activity.Sleep, _sleepSpell);
        }

        /// <summary>
        /// Iterates through the NPCs in the Mage's vicinity and casts Sleep on the first NPC found to be eligible for it.
        /// The method will exit and return true as soon as the spell is cast once. If no eligible NPCs are found,
        /// the method will return false.
        /// </summary>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> SleepNpcs()
        {
            // It may seem like there are more efficient ways to do this loop, but it is imperative to iterate through
            // the list backwards to properly handle removals from the list further downstream.
            for (var i = _self.Npcs.Count - 1; i >= 0; i--)
            {
                if (await Sleep(_self.Npcs[i]))
                {
                    return true;
                }
            }

            return false;
        }

        #endregion Sleep

        #region Venom

        /// <summary>
        /// Casts the Venom debuff on a target.
        /// </summary>
        /// <param name="target">The NPC to target for the debuff.</param>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> Venom(Npc target)
        {
            return await StatusCommands.CastStatus(_self, target, target.Activity.Venom, _venomSpell);
        }

        /// <summary>
        /// Iterates through the NPCs in the Mage's vicinity and casts Venom on the first NPC found to be eligible for it.
        /// The method will exit and return true as soon as the spell is cast once. If no eligible NPCs are found,
        /// the method will return false.
        /// </summary>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> VenomNpcs()
        {
            // It may seem like there are more efficient ways to do this loop, but it is imperative to iterate through
            // the list backwards to properly handle removals from the list further downstream.
            for (var i = _self.Npcs.Count - 1; i >= 0; i--)
            {
                if (await Venom(_self.Npcs[i]))
                {
                    return true;
                }
            }

            return false;
        }

        #endregion Venom

        #region Scourge Orb

        /// <summary>
        /// Casts a curse (i.e. Vex or Scourge) on a target.
        /// </summary>
        /// <param name="target">The NPC to target for the debuff.</param>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public override async Task<bool> Curse(Npc target)
        {
            if (_scourgeOrb == null)
            {
                return await base.Curse(target);
            }

            return await StatusCommands.CastStatus(_self, target, target.Activity.Curse, _scourgeOrb);
        }

        #endregion Scourge Orb

        #endregion Public Methods
    }
}
