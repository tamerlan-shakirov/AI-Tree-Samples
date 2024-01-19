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
    [AddComponentMenu("Renowned Games/AI Tree Samples/Button SFX")]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Button))]
    public sealed class ButtonSFX : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
    {
        [SerializeField]
        private AudioSource audioSource;

        [SerializeField]
        private AudioClip enterSound;

        [SerializeField]
        private AudioClip clickSound;

        // Stored required components.
        private Button button;

        private void Awake()
        {
            button = GetComponent<Button>();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (button.interactable)
            {
                audioSource.PlayOneShot(enterSound);
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (button.interactable)
            {
                audioSource.PlayOneShot(clickSound);
            }
        }
    }
}