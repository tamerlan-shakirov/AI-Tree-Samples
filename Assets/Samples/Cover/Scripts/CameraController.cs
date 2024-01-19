/* ================================================================
   ----------------------------------------------------------------
   Project   :   AI Tree Samples
   Publisher :   Renowned Games
   Developer :   Vladimir Deryabin
   ----------------------------------------------------------------
   Copyright 2024 Renowned Games All rights reserved.
   ================================================================ */

using RenownedGames.Apex;
using UnityEngine;

namespace RenownedGames.AITree.Samples
{
    [HideMonoScript]
    [DisallowMultipleComponent]
    public sealed class CameraController : MonoBehaviour
    {
        [SerializeField]
        [NotNull]
        private Transform target;

        [SerializeField]
        [MinValue(0.1f)]
        private float smoothSpeed = 5f;

        /// <summary>
        /// Called every frame, if the MonoBehaviour is enabled.
        /// </summary>
        private void Update()
        {
            Vector3 position = Vector3.Lerp(transform.position, target.position, smoothSpeed * Time.deltaTime);
            transform.position = new Vector3(position.x, transform.position.y, position.z);
        }

        #region [Getter / Setter]
        public Transform GetTarget()
        {
            return target;
        }

        public void SetTarget(Transform value)
        {
            target = value;
        }

        public float GetSmoothSpeed()
        {
            return smoothSpeed;
        }

        public void SetSmoothSpeed(float value)
        {
            smoothSpeed = value;
        }
        #endregion
    }
}
