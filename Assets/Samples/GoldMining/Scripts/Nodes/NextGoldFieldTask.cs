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
    [NodeContent("Next Gold Field", "Tasks/Demo/Gold Mining/Next Gold Field")]
    public class NextGoldFieldTask : TaskNode
    {
        [Title("Blackboard")]
        [SerializeField]
        [NonLocal]
        private Key<Transform> key;

        protected override State OnUpdate()
        {
            if (key == null) return State.Failure;

            GoldField mine = MineManager.GetNext();
            key.SetValue(mine.transform);

            return State.Success;
        }
    }
}