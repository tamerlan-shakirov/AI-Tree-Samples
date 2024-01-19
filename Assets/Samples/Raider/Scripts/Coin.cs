/* ================================================================
   ----------------------------------------------------------------
   Project   :   AI Tree Samples
   Publisher :   Renowned Games
   Developer :   Tamerlan Shakirov
   ----------------------------------------------------------------
   Copyright 2024 Renowned Games All rights reserved.
   ================================================================ */

using System;

namespace RenownedGames.AITree.Samples
{
    public class Coin : PickupObject
    {
        /// <summary>
        /// Pickup this object.
        /// </summary>
        public override void Pickup()
        {
            Collect?.Invoke();
            Destroy(gameObject);
        }

        #region [Events]
        /// <summary>
        /// Called when coin has been picked up.
        /// </summary>
        public event Action Collect;
        #endregion
    }
}