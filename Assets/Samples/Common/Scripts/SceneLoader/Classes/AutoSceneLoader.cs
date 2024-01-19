/* ================================================================
   ----------------------------------------------------------------
   Project   :   AI Tree Samples
   Company   :   Renowned Games
   Developer :   Tamerlan Shakirov
   ----------------------------------------------------------------
   Copyright 2024 Renowned Games All rights reserved.
   ================================================================ */

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RenownedGames.AITree.Samples
{
    [AddComponentMenu("Renowned Games/AI Tree Samples/Auto Scene Loader")]
    [DisallowMultipleComponent]
    public sealed class AutoSceneLoader : MonoBehaviour
    {
        [SerializeField]
        private string sceneName;

        [SerializeField]
        [Min(0)]
        private float delay;

        [SerializeField]
        private ScreenFadeEffect fadeEffect;

        /// <summary>
        /// called on the frame when a script is enabled
        /// just before any of the Update methods are called the first time.
        /// </summary>
        private IEnumerator Start()
        {
            yield return new WaitForSeconds(delay);
            if(fadeEffect != null)
            {
                fadeEffect.OnFadeComplete += (mode) => SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
                fadeEffect.FadeIn();
            }
            else
            {
                SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
            }
        }
    }
}