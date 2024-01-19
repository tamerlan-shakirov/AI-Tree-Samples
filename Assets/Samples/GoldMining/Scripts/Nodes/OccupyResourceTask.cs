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
    [NodeContent("Occupy Resource", "Tasks/Demo/Gold Mining/Occupy Resource")]
    public class OccupyResourceTask : TaskNode
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

            resource.IsOccupied(true);
            return State.Success;
        }
    }
}