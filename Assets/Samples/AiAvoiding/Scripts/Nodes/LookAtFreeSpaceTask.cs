/* ================================================================
   ----------------------------------------------------------------
   Project   :   AI Tree Samples
   Publisher :   Renowned Games
   Developer :   Zinnur Davleev
   ----------------------------------------------------------------
   Copyright 2024 Renowned Games All rights reserved.
   ================================================================ */

using UnityEngine;

namespace RenownedGames.AITree.Samples
{
    [NodeContent("Look At Free Space", "LiveDemo/Deathmatch/Look At Free Space")]
    public class LookAtFreeSpaceTask : TaskNode
    {
        [SerializeField]
        private int rays = 32;

        [SerializeField]
        private float heightOffset = 1.65f;

        [SerializeField]
        private float maxDistance = 10f;

        [SerializeField]
        private LayerMask cullingLayer = ~0;

        [SerializeField]
        private float rotationSpeed = 180f;

        // Stored required components.
        private Transform transform;

        // Stored required properties.
        private Quaternion desiredRotation;

        /// <summary>
        /// Called on behaviour tree is awake.
        /// </summary>
        protected override void OnInitialize()
        {
            base.OnInitialize();
            transform = GetOwner().transform;
        }

        /// <summary>
        /// Called when behaviour tree enter in node.
        /// </summary>
        protected override void OnEntry()
        {
            Vector3 direction = CalculateLookDirection();
            desiredRotation = Quaternion.FromToRotation(Vector3.forward, direction);
        }

        /// <summary>
        /// Called every tick during node execution.
        /// </summary>
        /// <returns>State.</returns>
        protected override State OnUpdate()
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);

            if (transform.rotation == desiredRotation)
            {
                return State.Success;
            }

            return State.Running;
        }

        /// <summary>
        /// Calculate normalized look direction.
        /// </summary>
        private Vector3 CalculateLookDirection()
        {
            Vector3 totalDirection = Vector3.zero;

            for (int i = 0; i < rays; i++)
            {
                float percent = (float)i / rays;
                Quaternion rotation = Quaternion.AngleAxis(360 * percent, Vector3.up);
                Vector3 direction = rotation * transform.forward;

                float distance = maxDistance;
                if (Physics.Raycast(transform.position + Vector3.up * heightOffset, direction, out RaycastHit hitInfo, maxDistance, cullingLayer))
                {
                    distance = Mathf.Min(distance, hitInfo.distance);
                }

                totalDirection += direction * distance;
            }

            return totalDirection.normalized;
        }

        #region [Getter / Setter]
        public int GetRays()
        {
            return rays;
        }

        public void SetRays(int value)
        {
            rays = value;
        }

        public float GetHeightOffset()
        {
            return heightOffset;
        }

        public void SetHeightOffset(float value)
        {
            heightOffset = value;
        }

        public float GetMaxDistance()
        {
            return maxDistance;
        }

        public void SetMaxDistance(float value)
        {
            maxDistance = value;
        }

        public LayerMask GetCullingLayer()
        {
            return cullingLayer;
        }

        public void SetCullingLayer(LayerMask value)
        {
            cullingLayer = value;
        }

        public float GetRotationSpeed()
        {
            return rotationSpeed;
        }

        public void SetRotationSpeed(float value)
        {
            rotationSpeed = value;
        }
        #endregion
    }
}