/* ================================================================
   ----------------------------------------------------------------
   Project   :   AI Tree Samples
   Company   :   Renowned Games
   Developer :   Tamerlan Shakirov
   ----------------------------------------------------------------
   Copyright 2024 Renowned Games All rights reserved.
   ================================================================ */

using UnityEngine;

namespace RenownedGames.AITree.Samples
{
    [System.Serializable]
    public struct Showcase
    {
        [SerializeField]
        private string name;

        [SerializeField]
        private string sceneName;

        [SerializeField]
        private string description;

        [SerializeField]
        private Sprite preview;

        #region [Getter / Setter]
        public string GetName()
        {
            return name;
        }

        public void SetName(string value)
        {
            name = value;
        }

        public string GetSceneName()
        {
            return sceneName;
        }

        public void SetSceneName(string value)
        {
            sceneName = value;
        }

        public string GetDescription()
        {
            return description;
        }

        public void SetDescription(string value)
        {
            description = value;
        }

        public Sprite GetPreview()
        {
            return preview;
        }

        public void SetPreview(Sprite value)
        {
            preview = value;
        }
        #endregion
    }
}