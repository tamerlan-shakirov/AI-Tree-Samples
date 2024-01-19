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
    [NodeContent("Available Resource", "Demo/Gold Mining/Available Resource")]
    public class AvailableResourceDecorator : ConditionDecorator
    {
        [Title("Blackboard")]
        [SerializeField]
        private Key<Transform> key;

        /// <summary>
        /// Calculates the result of the condition.
        /// </summary>
        protected override bool CalculateResult()
        {
            if (key == null)
            {
                return false;
            }

            Transform transform = key.GetValue();
            if (transform == null)
            {
                return false;
            }

            Resource resource = transform.GetComponent<Resource>();
            if (resource == null)
            {
                return false;
            }

            return !resource.IsOccupied();
        }
    }
}