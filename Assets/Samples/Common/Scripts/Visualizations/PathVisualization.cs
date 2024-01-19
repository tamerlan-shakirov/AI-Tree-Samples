/* ================================================================
   ----------------------------------------------------------------
   Project   :   AI Tree Samples
   Company   :   Renowned Games
   Developer :   Zinnur Davleev
   ----------------------------------------------------------------
   Copyright 2024 Renowned Games All rights reserved.
   ================================================================ */

using UnityEngine;
using UnityEngine.AI;

namespace RenownedGames.AITree.Samples
{
    [RequireComponent(typeof(LineRenderer))]
    public sealed class PathVisualization : MonoBehaviour
    {
        [SerializeField]
        private NavMeshAgent agent;

        [SerializeField]
        private float heightOffset = 0.5f;

        // Stored required components.
        private LineRenderer lineRenderer;

        /// <summary>
        /// Called when an enabled script instance is being loaded.
        /// </summary>
        private void Awake()
        {
            lineRenderer = GetComponent<LineRenderer>();
        }

        /// <summary>
        /// Called every frame, if the Behaviour is enabled.
        /// </summary>
        private void LateUpdate()
        {
            NavMeshPath path = agent.path;
            if (path != null)
            {
                lineRenderer.enabled = true;
                lineRenderer.positionCount = path.corners.Length;
                for (int i = 0; i < path.corners.Length; i++)
                {
                    lineRenderer.SetPosition(i, path.corners[i] + Vector3.up * heightOffset);
                }
            }
            else
            {
                lineRenderer.enabled = false;
            }
        }

        #region [Getter / Setter]
        public NavMeshAgent GetAgent()
        {
            return agent;
        }

        public void SetAgent(NavMeshAgent value)
        {
            agent = value;
        }

        public float GetHeightOffset()
        {
            return heightOffset;
        }

        public void SetHeightOffset(float value)
        {
            heightOffset = value;
        }
        #endregion
    }
}