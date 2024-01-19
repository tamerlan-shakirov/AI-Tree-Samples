/* ================================================================
   ----------------------------------------------------------------
   Project   :   AI Tree Samples
   Company   :   Renowned Games
   Developer :   Tamerlan Shakirov
   ----------------------------------------------------------------
   Copyright 2024 Renowned Games All rights reserved.
   ================================================================ */

using UnityEngine;
using UnityEngine.SceneManagement;

namespace RenownedGames.AITree.Samples
{
    [AddComponentMenu("Renowned Games/AI Tree Samples/Scene Loader")]
    [DisallowMultipleComponent]
    public sealed class SceneLoader : MonoBehaviour
    {
        [SerializeField]
        private KeyCode keyCode;

        /// <summary>
        /// Called every frame, if the MonoBehaviour is enabled.
        /// </summary>
        private void Update()
        {
            if (Input.GetKeyDown(keyCode))
            {
                SceneManager.LoadScene("ShowcaseSelector", LoadSceneMode.Single);
            }
        }
    }
}