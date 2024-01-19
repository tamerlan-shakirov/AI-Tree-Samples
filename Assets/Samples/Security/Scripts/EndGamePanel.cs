/* ================================================================
   ----------------------------------------------------------------
   Project   :   AI Tree Samples
   Publisher :   Renowned Games
   Developer :   Vladimir Deryabin
   ----------------------------------------------------------------
   Copyright 2024 Renowned Games All rights reserved.
   ================================================================ */

using RenownedGames.Apex;
using RenownedGames.ExLib.Patterns;
using UnityEngine;
using UnityEngine.UI;

namespace RenownedGames.AITree.Samples
{
    [HideMonoScript]
    [DisallowMultipleComponent]
    public sealed class EndGamePanel : Singleton<EndGamePanel>
    {
        [SerializeField]
        [NotNull]
        private Text textField;

        [SerializeField]
        [NotNull]
        private Transform container;

        /// <summary>
        /// Called when an enabled script instance is being loaded.
        /// </summary>
        private void Awake()
        {
            Time.timeScale = 1f;
        }

        /// <summary>
        /// Called when the behaviour becomes disabled.
        /// </summary>
        private void OnDisable()
        {
            Time.timeScale = 1f;
        }


        /// <summary>
        /// Shows the end game panel.
        /// </summary>
        /// <param name="text">Panel text.</param>
        public void Show(string text)
        {
            Time.timeScale = 0f;
            textField.text = $"{text}";
            container.gameObject.SetActive(true);
        }

        /// <summary>
        /// Hides the end of game panel.
        /// </summary>
        public void Hide()
        {
            Time.timeScale = 1f;
            container.gameObject.SetActive(false);
        }

        #region [Getter / Setter]
        public Text GetTextField()
        {
            return textField;
        }

        public void SetTextField(Text value)
        {
            textField = value;
        }

        public Transform GetContainer()
        {
            return container;
        }

        public void SetContainer(Transform value)
        {
            container = value;
        }
        #endregion
    }
}
