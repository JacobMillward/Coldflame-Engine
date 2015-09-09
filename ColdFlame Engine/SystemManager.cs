﻿using System;
using System.Collections.Generic;

namespace ColdFlame
{
    static class SystemManager
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
            systemList.Insert(system.priority, system);
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