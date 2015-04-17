using System;
using System.Collections.Generic;
using System.Linq;

namespace ColdFlame
{

    public class EntityManager
    {

        public delegate void EntityEventHandler(int entity);
        public EntityEventHandler EntityEvent;
        private Dictionary<int, List<Component>> _entityList;
        private int lowestEID { get; set; }

        public EntityManager()
        {
            _entityList = new Dictionary<int, List<Component>>();
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
            EntityEvent(entity);
        }

        public void addComponent(int entity, List<Component> componentList)
        {
            EntityEvent(entity);
            throw new NotImplementedException();
        }

        public int createEntity(List<Component> componentList)
        {
            int genID = generateNewEID();
            _entityList.Add(genID, componentList);
            EntityEvent(genID);
            return genID;
        }

        public int createEntity()
        {
            int genID = generateNewEID();
            _entityList.Add(genID, new List<Component>());
            EntityEvent(genID);
            return genID;
        }

        public List<Component> getComponents(int entity)
        {
            List<Component> components;
            _entityList.TryGetValue(entity, out components);
            return components;
        }

        public Component getComponent(int entity, Type comType)
        {
            List<Component> components;
            _entityList.TryGetValue(entity, out components);
            return components[0];
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
            }
            return false;
        }

    }
}