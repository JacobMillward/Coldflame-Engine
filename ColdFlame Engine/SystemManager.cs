using System;
using System.Collections.Generic;
using System.Linq;
using ColdFlame.GameSystems;
using SFML.System;

namespace ColdFlame
{
    internal static class SystemManager
    {
        // Will not use this many lists, only temp. Could use: array of lists, struct, map...
        private static readonly List<GameSystem> SystemList = new List<GameSystem>();
        private static readonly List<GameSystem> SystemList_EXACT= new List<GameSystem>();
        private static readonly List<GameSystem> SystemList_HIGH = new List<GameSystem>();
        private static readonly List<GameSystem> SystemList_MEDIUM = new List<GameSystem>();
        private static readonly List<GameSystem> SystemList_LOW = new List<GameSystem>();

        static SystemManager()
        {
        }

        internal static void Add(GameSystem system)
        {
            if (system.IsUnique)
            {
                if (SystemList.Any(s => s.GetType() == system.GetType()))
                {
                    throw new Exception("Cannot add more than one unique System to the SystemManager");
                }
            }

            switch(system.Priority)
            {
                case SystemPriority.LOW:
                    SystemList_LOW.Add(system);
                    break;
                case SystemPriority.MEDIUM:
                    SystemList_MEDIUM.Add(system);
                    break;
                case SystemPriority.HIGH:
                    SystemList_HIGH.Add(system);
                    break;
                case SystemPriority.EXACT:
                    SystemList_EXACT.Add(system);
                    break;
            }
            SystemList.Add(system);
        }

        internal static void Remove(GameSystem system)
        {
            SystemList.Remove(system);
            switch (system.Priority)
            {
                case SystemPriority.LOW:
                    SystemList_LOW.Remove(system);
                    break;
                case SystemPriority.MEDIUM:
                    SystemList_MEDIUM.Remove(system);
                    break;
                case SystemPriority.HIGH:
                    SystemList_HIGH.Remove(system);
                    break;
                case SystemPriority.EXACT:
                    SystemList_EXACT.Remove(system);
                    break;
            }
        }

        internal static void DoCriticalSystemUpdates()
        {
            foreach (var system in SystemList_EXACT)
            {
                system.Update();
            }
        }

        internal static void DoOtherSystemUpdates(int TimeBudget)
        {
            // I should build a queue of tasks and some kind of table where I can see what the typical time budget needed for a task is.
            
        }
    }
}