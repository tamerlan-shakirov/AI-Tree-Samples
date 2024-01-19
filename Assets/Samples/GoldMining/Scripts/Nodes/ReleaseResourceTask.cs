/* ================================================================
   ----------------------------------------------------------------
   Project   :   AI Tree Samples
   Company   :   Renowned Games
   Developer :   Zinnur Davleev
   ----------------------------------------------------------------
   Copyright 2024 Renowned Games All rights reserved.
   ================================================================ */

using RenownedGames.Apex;
using UnityEngine;

namespace RenownedGames.AITree.Samples
{
    [NodeContent("Release Resource", "Tasks/Demo/Gold Mining/Release Resource")]
    public class ReleaseResourceTask : TaskNode
    {
        [Title("Blackboard")]
        [SerializeField]
        private Key<Transform> key;

        /// <summary>
        /// Called every tick during node execution.
        /// </summary>
        /// <returns>State.</returns>
        protected override State OnUpdate()
        {
            if (key == null)
            {
                return State.Failure;
            }

            Transform transform = key.GetValue();
            if (transform == null)
            {
                return State.Failure;
            }

            Resource resource = transform.GetComponent<Resource>();
            if (resource == null)
            {
                return State.Failure;
            }

            resource.IsOccupied(false);
            return State.Success;
        }
    }
}