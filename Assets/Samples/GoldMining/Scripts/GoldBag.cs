/* ================================================================
   ----------------------------------------------------------------
   Project   :   AI Tree Samples
   Publisher :   Renowned Games
   Developer :   Vladimir Deryabin
   ----------------------------------------------------------------
   Copyright 2024 Renowned Games All rights reserved.
   ================================================================ */

using RenownedGames.Apex;
using System.Collections.Generic;
using UnityEngine;

namespace RenownedGames.AITree.Samples
{
    [HideMonoScript]
    [AddComponentMenu("Renowned Games/AI Tree Samples/Common/Gold Bag")]
    [DisallowMultipleComponent]
    public sealed class GoldBag : MonoBehaviour
    {
        [SerializeField]
        [Array]
        private List<Miner> miners;

        [SerializeField]
        [NotNull]
        private TextMesh textField;

        [SerializeField]
        [Indent]
        private string format = "Golds: {0}";

        //Stored required properties.
        private int goldAmount;

        /// <summary>
        /// Called when the object becomes enabled and active.
        /// </summary>
        private void OnEnable()
        {
            for (int i = 0; i < miners.Count; i++)
            {
                miners[i].RemoveGold += OnRemoveGoold;
            }
        }

        /// <summary>
        /// Called when the behaviour becomes disabled.
        /// </summary>
        private void OnDisable()
        {
            for (int i = 0; i < miners.Count; i++)
            {
                miners[i].RemoveGold -= OnRemoveGoold;
            }
        }

        /// <summary>
        /// It is called at the time of the gold reset by the miner.
        /// </summary>
        /// <param name="amount"></param>
        private void OnRemoveGoold(int amount)
        {
            goldAmount += amount;
            textField.text = string.Format(format, goldAmount);
        }

        #region [Getter / Setter]
        public List<Miner> GetMiners()
        {
            return miners;
        }

        public void SetMiners(List<Miner> value)
        {
            miners = value;
        }

        public TextMesh GetTextField()
        {
            return textField;
        }

        public void SetTextField(TextMesh value)
        {
            textField = value;
        }

        public string GetFormat()
        {
            return format;
        }

        public void SetFormat(string value)
        {
            format = value;
        }
        #endregion
    }
}
