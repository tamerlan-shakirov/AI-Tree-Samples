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
    [RequireComponent(typeof(Coin))]
    public class CoinAnimation : MonoBehaviour
    {
        [SerializeField]
        private Transform visual;

        [SerializeField]
        private float speed = 1f;

        [SerializeField]
        private float amplitude = 1f;

        [SerializeField]
        private float rotationSpeed = 90f;

        private void FixedUpdate()
        {
            // Position
            Vector3 localPosition = visual.localPosition;
            localPosition.y = Mathf.Sin(Time.time * speed) * amplitude;
            visual.localPosition = localPosition;

            // Rotation
            visual.Rotate(Vector3.up, rotationSpeed * Time.fixedDeltaTime, Space.World);
        }
    }
}