using System;
using System.Collections.Generic;
using System.Linq;
namespace ColdFlame
{
    public class Entity
    {
        public Guid guid { get; private set; }

        public Entity()
        {
            this.guid = EntityManager.generateGUID();
            EntityManager.addEntity(this);
        }

        public Entity(Guid guid)
        {
            this.guid = guid;
        }

        public void AddComponent(Component component)
        {
            EntityManager.addComponent(guid, component);
        }

        public void RemoveComponent(Component component)
        {
            EntityManager.removeComponent(guid, component);
        }

        public T GetComponent<T>() where T:Component
        {
            return (T)EntityManager.getComponent(guid, typeof(T));
        }

        public List<Component> GetComponents(Type comType)
        {
            return EntityManager.getComponents(guid, comType);
        }

        public bool ContainsComponent(Type type)
        {
            return EntityManager.containsComponent(guid, type);
        }

        public override string ToString()
        {
            string str = "Entity#" + guid.ToString() + "<";
            var list = EntityManager.getComponents(guid);
            foreach (Component c in list)
            {
                str += c.GetType().FullName;
                if (!c.Equals(list.Last()))
                {
                    str += ", ";
                }
            }
            return str + ">";
        }

        public override bool Equals(System.Object obj)
        {
            if (obj == null)
                return false;
            if (this.GetType() != obj.GetType()) return false;
            Entity e = (Entity)obj;
            return (this.guid == e.guid);
        }

        public override int GetHashCode()
        {
            return guid.GetHashCode();
        }
    }
}
