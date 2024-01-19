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
    [NodeContent("Unload Gold", "Tasks/Demo/GoldMining/Unload Gold")]
    [RequireComponent(typeof(Miner))]
    public class UnloadGoldTask : TaskNode
    {
        // Stored required components.
        private Miner miner;

        protected override void OnInitialize()
        {
            base.OnInitialize();
            miner = GetOwner().GetComponent<Miner>();
        }

        protected override State OnUpdate()
        {
            if (miner.GetGoldCount() > 0)
            {
                miner.OnRemoveGoold(1);
                return State.Success;
            }
            return State.Failure;
        }
    }
}