/* ================================================================
   ----------------------------------------------------------------
   Project   :   AI Tree Samples
   Company   :   Renowned Games
   Developer :   Zinnur Davleev
   ----------------------------------------------------------------
   Copyright 2024 Renowned Games All rights reserved.
   ================================================================ */

using System.Collections.Generic;

namespace RenownedGames.AITree.Samples
{
    public static class MineManager
    {
        private static List<GoldField> Mines;
        private static int current;

        static MineManager()
        {
            Mines = new List<GoldField>();
        }

        public static void AddMine(GoldField mine)
        {
            Mines.Add(mine);
        }

        public static void RemoveMine(GoldField mine)
        {
            Mines.Remove(mine);
        }

        public static GoldField GetNext()
        {
            if (Mines.Count > 0)
            {
                return Mines[(current++) % Mines.Count];
            }
            return null;
        }
    }
}