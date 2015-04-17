using System;
using System.Collections.Generic;
using System.Linq;

namespace ColdFlame
{

    public class EntityManager
    {

        private Dictionary<int, List<Component>> _entityList;
        private List<GameSystem> _gameSystems;
        private int lowestEID { get; set; }

        public EntityManager()
        {
            _entityList = new Dictionary<int, List<Component>>();
            _gameSystems = new List<GameSystem>();
        }

        private int generateNewEID()
        {
            if (lowestEID < int.MaxValue)
            {
                return lowestEID++;
            }
            for (int i = 0; i < int.MaxValue; i++)
            {
                List<Component> value;
                if (!_entityList.TryGetValue(i, out value))
                {
                    return i;
                }
            }
            throw new Exception("Cannot create new EID");
        }

        public void addComponent(int entity, Component component)
        {
            List<Component> value;
            _entityList.TryGetValue(entity, out value);
            value.Add(component);
        }

        public void addComponent(int entity, List<Component> componentList)
        {
            //TODO: Implement this
        }

        public int createEntity(List<Component> componentList)
        {
            int genID = generateNewEID();
            _entityList.Add(genID, componentList);
            return genID;
        }

        public int createEntity()
        {
            int genID = generateNewEID();
            _entityList.Add(genID, new List<Component>());
            return genID;
        }

        public List<Component> getEntity(int eID)
        {
            List<Component> value;
            _entityList.TryGetValue(eID, out value);
            return value;
        }

        public List<int> getEntityList()
        {
            return _entityList.Keys.ToList<int>();
        }

        public bool containsComponent(int entity, Type comType)
        {
            List<Component> componentList;
            if (_entityList.TryGetValue(entity, out componentList))
            {
                foreach (Component c in componentList)
                {
                    if (comType.Equals(c.GetType()))
                    {
                        return true;
                    }
                }
                return false;
            }
            else return false;
        }
    }
}