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

namespace RenownedGames.AITree.Samples
{
    [HideMonoScript]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Collider))]
    public sealed class EndGameTrigger : MonoBehaviour
    {
        /// <summary>
        /// Called when an enabled script instance is being loaded.
        /// </summary>
        private void Awake()
        {
            gameObject.SetActive(false);
        }

        private void OnTriggerEnter(Collider other)
        {
            EndGamePanel.GetRuntimeInstance().Show("You Win!");
        }
    }
}
