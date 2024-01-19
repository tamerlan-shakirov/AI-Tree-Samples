/* ================================================================
   ----------------------------------------------------------------
   Project   :   AI Tree Samples
   Company   :   Renowned Games
   Developer :   Tamerlan Shakirov
   ----------------------------------------------------------------
   Copyright 2024 Renowned Games All rights reserved.
   ================================================================ */

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using RenownedGames.Apex;

namespace RenownedGames.AITree.Samples
{
    [AddComponentMenu("Renowned Games/AI Tree Samples/Template SFX")]
    [DisallowMultipleComponent]
    public sealed class TemplateSFX : MonoBehaviour, IPointerEnterHandler, ISelectHandler
    {
        [SerializeField]
        private AudioSource audioSource;

        [SerializeField]
        private AudioClip hoverSound;

        [SerializeField]
        private AudioClip clickSound;

        [SerializeField]
        [Slider(0, 1)]
        private float rate = 0.25f;

        // Stored required properties.
        private float lastTime;

        private void Start()
        {
            lastTime = Time.time;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if(Time.time - lastTime >= rate)
            {
                audioSource.PlayOneShot(hoverSound);
                lastTime = Time.time;
            }
        }

        public void OnSelect(BaseEventData eventData)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }
}