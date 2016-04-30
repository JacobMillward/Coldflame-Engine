using System;
using System.Collections.Generic;
using System.Linq;
using ColdFlame.GameSystems;

namespace ColdFlame
{
    internal static class SystemManager
    {
        private static readonly List<GameSystem> SystemList = new List<GameSystem>();

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
            foreach (var s in SystemList.Where(s => system.Priority <= s.Priority))
            {
                SystemList.Insert(SystemList.IndexOf(s), system);
                return;
            }
            SystemList.Add(system);
        }

        internal static void Remove(GameSystem system)
        {
            SystemList.Remove(system);
        }

        internal static void DoSystemUpdates()
        {
            foreach (var system in SystemList)
            {
                system.Update(system.TimerClock.Restart().AsSeconds());
            }
        }
    }
}