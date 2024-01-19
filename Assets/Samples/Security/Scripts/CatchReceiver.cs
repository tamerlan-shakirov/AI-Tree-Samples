/* ================================================================
   ----------------------------------------------------------------
   Project   :   AI Tree Samples
   Publisher :   Renowned Games
   Developer :   Vladimir Deryabin
   ----------------------------------------------------------------
   Copyright 2024 Renowned Games All rights reserved.
   ================================================================ */

using UnityEngine;

namespace RenownedGames.AITree.Samples
{
    public class CatchReceiver : MonoBehaviour
    {
        /// <summary>
        /// Called at the moment when the AI catches the player.
        /// </summary>
        private void Catch()
        {
            EndGamePanel.GetRuntimeInstance().Show("You were caught!");
        }
    }
}
