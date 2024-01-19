/* ================================================================
   ----------------------------------------------------------------
   Project   :   AI Tree Samples
   Company   :   Renowned Games
   Developer :   Zinnur Davleev
   ----------------------------------------------------------------
   Copyright 2024 Renowned Games All rights reserved.
   ================================================================ */

namespace RenownedGames.AITree.Samples
{
    public sealed class GoldField : Resource
    {
        /// <summary>
        /// Called when an enabled script instance is being loaded.
        /// </summary>
        private void Awake()
        {
            MineManager.AddMine(this);
        }

        /// <summary>
        /// Called when the MonoBehaviour will be destroyed.
        /// </summary>
        private void OnDestroy()
        {
            MineManager.RemoveMine(this);
        }
    }
}