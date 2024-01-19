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
using UnityEngine.Events;

namespace RenownedGames.AITree.Samples
{
    [HideMonoScript]
    public class CointSequence : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent collectAllEvent;

        [SerializeField]
        [ReorderableList]
        private List<Coin> coins;

        //Stored required properties.
        private int targetCoin = 0;

        /// <summary>
        /// Called when an enabled script instance is being loaded.
        /// </summary>
        private void Awake()
        {
            if (coins.Count > 0)
            {
                coins[targetCoin].Collect += OnCollect;

                for (int i = 1; i < coins.Count; i++)
                {
                    coins[i].gameObject.SetActive(false);
                }
            }
        }

        /// <summary>
        /// Called at the time of the selection of the active coin.
        /// </summary>
        private void OnCollect()
        {
            Coin coin = coins[targetCoin];
            coin.gameObject.SetActive(false);
            coin.Collect -= OnCollect;

            targetCoin++;
            if (targetCoin < coins.Count)
            {
                coin = coins[targetCoin];
                coin.Collect += OnCollect;
                coin.gameObject.SetActive(true);
            }
            else
            {
                collectAllEvent?.Invoke();
            }
        }

        #region [Getter / Setter]
        public List<Coin> GetCoins()
        {
            return coins;
        }

        public void SetCoins(List<Coin> value)
        {
            coins = value;
        }
        #endregion
    }
}
