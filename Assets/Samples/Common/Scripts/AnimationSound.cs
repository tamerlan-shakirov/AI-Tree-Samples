/* ================================================================
   ----------------------------------------------------------------
   Project   :   AI Tree Samples
   Company   :   Renowned Games
   Developer :   Tamerlan Shakirov
   ----------------------------------------------------------------
   Copyright 2024 Renowned Games All rights reserved.
   ================================================================ */

using RenownedGames.Apex;
using UnityEngine;

namespace RenownedGames.AITree.Samples
{
    [HideMonoScript]
    [AddComponentMenu("Renowned Games/AI Tree Samples/Animation/Animation Sound")]
    [DisallowMultipleComponent]
    public sealed class AnimationSound : MonoBehaviour
    {
        [SerializeField]
        [Slider(0, 1)]
        private float volume = 0.5f;

        /// <summary>
        /// Called in Animation event similar SendMessage().
        /// </summary>
        private void Play(AnimationEvent evt)
        {
            AudioClip clip = evt.objectReferenceParameter as AudioClip;
            if (evt.animatorClipInfo.weight > 0.5f && clip != null)
            {
                AudioSource.PlayClipAtPoint(clip, transform.position, volume);
            }
        }

        #region [Getter / Setter]
        public float GetVolume()
        {
            return volume;
        }

        public void SetVolume(float value)
        {
            volume = value;
        }
        #endregion
    }
}