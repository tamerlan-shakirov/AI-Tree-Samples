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
    [NodeContent("Harvest Gold", "Tasks/Demo/Gold Mining/Harvest Gold")]
    [RequireComponent(typeof(Miner))]
    public class HarvestGoldTask : TaskNode
    {
        [Title("Node")]
        [SerializeField]
        private Key<Transform> mine;

        // Stored required components.
        private Miner miner;

        protected override void OnInitialize()
        {
            base.OnInitialize();
            miner = GetOwner().GetComponent<Miner>();
        }

        protected override State OnUpdate()
        {
            miner.OnAddGoold(1);
            return State.Success;
        }
    }
}