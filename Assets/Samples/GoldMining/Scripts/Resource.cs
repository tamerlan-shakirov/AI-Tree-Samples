/* ================================================================
   ----------------------------------------------------------------
   Project   :   AI Tree Samples
   Company   :   Renowned Games
   Developer :   Zinnur Davleev
   ----------------------------------------------------------------
   Copyright 2024 Renowned Games All rights reserved.
   ================================================================ */

using RenownedGames.Apex;
using UnityEngine;

namespace RenownedGames.AITree.Samples
{
    [HideMonoScript]
    [DisallowMultipleComponent]
    public class Resource : MonoBehaviour
    {
        [SerializeField]
        private bool occupied;

        #region [Getter / Setter]
        public bool IsOccupied()
        {
            return occupied;
        }

        public void IsOccupied(bool value)
        {
            occupied = value;
        }
        #endregion
    }
}