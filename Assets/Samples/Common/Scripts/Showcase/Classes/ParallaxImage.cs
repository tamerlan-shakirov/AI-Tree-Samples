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
    [RequireComponent(typeof(RectTransform))]
    public sealed class ParallaxImage : MonoBehaviour
    {
        [SerializeField]
        private float waveAmplitude = 5.0f;

        [SerializeField]
        private float waveSpeed = 0.5f;

        [SerializeField]
        private bool sizeMove = true;

        [SerializeField]
        private float sizeAmplitude = 0.25f;

        [SerializeField]
        private float sizeSpeed = 0.15f;

        // Stored required properties.
        private Vector3 startScale;
        private Vector2Int waveFactor;

        // Stored required components.
        private new RectTransform transform;

        private void Awake()
        {
            transform = GetComponent<RectTransform>();

            startScale = transform.localScale;
            waveFactor = new Vector2Int(RandomSign(), RandomSign());

            int RandomSign()
            {
                return Random.value < 0.5f ? 1 : -1;
            }
        }

        private void Update()
        {
            Vector3 newPos = new Vector3(Mathf.Sin(Time.time * waveSpeed) * waveAmplitude, Mathf.Cos(Time.time * waveSpeed) * waveAmplitude, 0);
            newPos.x *= waveFactor.x;
            newPos.y *= waveFactor.y;
            transform.localPosition = Vector3.Lerp(transform.localPosition, newPos, waveSpeed * Time.deltaTime);

            if (sizeMove)
            {
                float amplitude = (Mathf.Sin(Time.time * sizeSpeed) + startScale.x) * sizeAmplitude;
                transform.localScale = new Vector3(startScale.x + amplitude, startScale.y + amplitude, startScale.z);
            }
        }
    }
}