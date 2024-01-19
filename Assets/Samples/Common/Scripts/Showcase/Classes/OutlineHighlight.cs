/* ================================================================
   ----------------------------------------------------------------
   Project   :   AI Tree Samples
   Company   :   Renowned Games
   Developer :   Tamerlan Shakirov
   ----------------------------------------------------------------
   Copyright 2024 Renowned Games All rights reserved.
   ================================================================ */

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace RenownedGames.AITree.Samples
{
    [AddComponentMenu("Renowned Games/AI Tree Samples/Outline Highlight")]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Outline))]
    public class OutlineHighlight : MonoBehaviour, ISelectHandler, IDeselectHandler
    {
        [SerializeField]
        private Color selectedColor;

        // Stored required properties.
        private Color baseColor;

        // Stored required components.
        private Outline outline;

        private void Awake()
        {
            outline = GetComponent<Outline>();
            baseColor = outline.effectColor;
        }

        public void OnSelect(BaseEventData eventData)
        {
            outline.effectColor = selectedColor;
        }

        public void OnDeselect(BaseEventData eventData)
        {
            outline.effectColor = baseColor;
        }
    }
}