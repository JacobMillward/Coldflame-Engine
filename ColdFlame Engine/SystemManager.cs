using System;
using System.Collections.Generic;

namespace ColdFlame
{
    internal static class SystemManager
    {
        private static List<GameSystem> systemList = new List<GameSystem>();
        static SystemManager() { }

        public static void Add(GameSystem system)
        {
            if (system.isUnique)
            {
                foreach (GameSystem s in systemList)
                {
                    if (s.GetType() == system.GetType())
                    {
                        throw new Exception("Cannot add more than one unique System to the SystemManager");
                    }
                }
            }
            foreach(GameSystem s in systemList)
            {
                if (system.priority <= s.priority)
                {
                    systemList.Insert(systemList.IndexOf(s), system);
                    return;
                }
            }
            systemList.Add(system);

        }

        public static void Remove(GameSystem system)
        {
            systemList.Remove(system);
        }

        internal static void doSystemUpdates()
        {
            foreach (GameSystem system in systemList)
            {
                system.Update();
            }
        }
    }
}
