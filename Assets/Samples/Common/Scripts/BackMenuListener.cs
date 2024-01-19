/* ================================================================
   ----------------------------------------------------------------
   Project   :   AI Tree Samples
   Publisher :   Renowned Games
   Developer :   Tamerlan Shakirov
   ----------------------------------------------------------------
   Copyright 2024 Renowned Games All rights reserved.
   ================================================================ */

using RenownedGames.Apex;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RenownedGames.AITree.Samples
{
    [HideMonoScript]
    [AddComponentMenu("Renowned Games/AI Tree Samples/UI/Back Menu Listener")]
    [DisallowMultipleComponent]
    public sealed class BackMenuListener : MonoBehaviour
    {
        [SerializeField]
        [SceneSelecter]
        private int menuScene = 1;

        [SerializeField]
        private ScreenFadeEffect fadeEffect;

        // Stored required properties.
        private bool hasPressed;

        /// <summary>
        /// Called after all Update functions have been called.
        /// </summary>
        private void LateUpdate()
        {
            if (!hasPressed && Input.GetKeyDown(KeyCode.Q))
            {
                if(fadeEffect != null)
                {
                    fadeEffect.OnFadeComplete += (mode) => SceneManager.LoadScene(menuScene, LoadSceneMode.Single);
                    fadeEffect.FadeIn();
                }
                else
                {
                    SceneManager.LoadScene(menuScene, LoadSceneMode.Single);
                }
                hasPressed = true;
            }
        }
    }
}