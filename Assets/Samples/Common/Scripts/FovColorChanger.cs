/* ================================================================
   ----------------------------------------------------------------
   Project   :   AI Tree Samples
   Publisher :   Renowned Games
   Developer :   Tamerlan Shakirov
   ----------------------------------------------------------------
   Copyright 2024 Renowned Games All rights reserved.
   ================================================================ */

using UnityEngine;

namespace RenownedGames.AITree.Samples
{
    public sealed class FovColorChanger : MonoBehaviour
    {
        [SerializeField]
        private new Renderer renderer;

        [SerializeField]
        private Color[] colors;

        // Stored required properties.
        private MaterialPropertyBlock block;

        /// <summary>
        /// Called when an enabled script instance is being loaded.
        /// </summary>
        private void Awake()
        {
            block = new MaterialPropertyBlock();
        }

        /// <summary>
        /// Change field of view color animation event.
        /// </summary>
        private void ChangeFovColor(int index)
        {
            if (0 <= index && index < colors.Length)
            {
                renderer.GetPropertyBlock(block);
                block.SetColor("_BaseColor", colors[index]);
                renderer.SetPropertyBlock(block);
            }
        }

        #region [Getter / Setter]
        public Renderer GetRenderer()
        {
            return renderer;
        }

        public void SetRenderer(Renderer value)
        {
            renderer = value;
        }

        public Color[] GetColors()
        {
            return colors;
        }

        public void SetColors(Color[] value)
        {
            colors = value;
        }
        #endregion
    }
}