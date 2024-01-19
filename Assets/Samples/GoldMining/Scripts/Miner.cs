/* ================================================================
   ----------------------------------------------------------------
   Project   :   AI Tree Samples
   Company   :   Renowned Games
   Developer :   Zinnur Davleev
   ----------------------------------------------------------------
   Copyright 2024 Renowned Games All rights reserved.
   ================================================================ */

using RenownedGames.Apex;
using System;
using UnityEngine;

namespace RenownedGames.AITree.Samples
{
    [HideMonoScript]
    public sealed class Miner : MonoBehaviour
    {
        [ReadOnly]
        [SerializeField]
        private int goldCount;

        [SerializeField]
        [NotNull]
        private TextMesh goldTextField;

        /// <summary>
        /// Called every frame, if the MonoBehaviour is enabled.
        /// </summary>
        private void Update()
        {
            goldTextField.text = goldCount == 0 ? "" : goldCount.ToString();
        }

        internal void OnAddGoold(int amount)
        {
            goldCount += Mathf.Abs(amount);
            AddGold?.Invoke(amount);
        }

        internal void OnRemoveGoold(int amount)
        {
            goldCount -= Mathf.Abs(amount);
            RemoveGold?.Invoke(amount);
        }

        #region [Events]
        /// <summary>
        /// Called when gold has been added.
        /// </summary>
        public event Action<int> AddGold;
        
        /// <summary>
        /// Called when gold has been removed.
        /// </summary>
        public event Action<int> RemoveGold;
        #endregion

        #region [Getter / Setter]
        public int GetGoldCount()
        {
            return goldCount;
        }
        #endregion
    }
}