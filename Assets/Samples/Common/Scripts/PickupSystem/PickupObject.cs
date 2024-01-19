/* ================================================================
   ----------------------------------------------------------------
   Project   :   AI Tree Samples
   Publisher :   Renowned Games
   Developer :   Tamerlan Shakirov
   ----------------------------------------------------------------
   Copyright 2024 Renowned Games All rights reserved.
   ================================================================ */

using UnityEngine;

namespace RenownedGames.AITree.Samples
{
    [RequireComponent(typeof(Collider))]
    public abstract class PickupObject : MonoBehaviour
    {
        /// <summary>
        /// Pickup this object.
        /// </summary>
        public abstract void Pickup();
    }
}