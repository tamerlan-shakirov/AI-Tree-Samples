/* ================================================================
   ----------------------------------------------------------------
   Project   :   AI Tree Samples
   Publisher :   Renowned Games
   Developer :   Vladimir Deryabin
   ----------------------------------------------------------------
   Copyright 2024 Renowned Games All rights reserved.
   ================================================================ */

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace RenownedGames.AITree.Samples
{
    [RequireComponent(typeof(Button))]
    public sealed class RestartButton : MonoBehaviour
    {
        [SerializeField]
        private ScreenFadeEffect fadeEffect;

        /// <summary>
        /// Called when an enabled script instance is being loaded.
        /// </summary>
        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(OnClick);
        }

        /// <summary>
        /// Called when the button is pressed.
        /// </summary>
        private void OnClick()
        {
            if(fadeEffect != null)
            {
                fadeEffect.OnFadeComplete += (mode) =>
                {
                    EndGamePanel.GetRuntimeInstance().Hide();
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
                };
                fadeEffect.FadeIn();
            }
            else
            {
                EndGamePanel.GetRuntimeInstance().Hide();
                SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
            }
        }

        #region [Getter / Setter]
        public ScreenFadeEffect GetFadeEffect()
        {
            return fadeEffect;
        }

        public void SetFadeEffect(ScreenFadeEffect value)
        {
            fadeEffect = value;
        }
        #endregion
    }
}
