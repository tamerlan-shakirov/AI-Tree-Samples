/* ================================================================
   ----------------------------------------------------------------
   Project   :   AI Tree Samples
   Publisher :   Renowned Games
   Developer :   Vladimir Deryabin
   ----------------------------------------------------------------
   Copyright 2024 Renowned Games All rights reserved.
   ================================================================ */

using RenownedGames.Apex;
using UnityEngine;
using UnityEngine.UI;

namespace RenownedGames.AITree.Samples
{
    [HideMonoScript]
    [AddComponentMenu("Renowned Games/AI Tree Samples/UI/Coin Counter")]
    [DisallowMultipleComponent]
    public sealed class CoinCounter : MonoBehaviour
    {
        [SerializeField]
        [NotNull]
        private Text text;

        [SerializeField]
        [Indent]
        private string format = "COINS: {0}";

        [SerializeField]
        [NotNull]
        private CoinSpawner coinSpawner;

        /// <summary>
        /// Called when an enabled script instance is being loaded.
        /// </summary>
        private void Awake()
        {
            coinSpawner.Collect += OnCollect;
        }

        /// <summary>
        /// Called after the coin is picked up.
        /// </summary>
        private void OnCollect(int collected)
        {
            text.text = string.Format(format, collected);
        }

        #region [Getter / Setter]
        public Text GetText()
        {
            return text;
        }

        public void SetText(Text value)
        {
            text = value;
        }

        public string GetFormat()
        {
            return format;
        }

        public void SetFormat(string value)
        {
            format = value;
        }

        public CoinSpawner GetCoinSpawner()
        {
            return coinSpawner;
        }

        public void SetCoinSpawner(CoinSpawner value)
        {
            coinSpawner = value;
        }
        #endregion
    }
}