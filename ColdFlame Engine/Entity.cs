using System;
using System.Collections.Generic;
using System.Linq;

namespace ColdFlame
{
    public class Entity
    {
        public Entity()
        {
            Guid = EntityManager.GenerateGuid();
            EntityManager.AddEntity(this);
        }

        public Entity(Guid guid)
        {
            this.Guid = guid;
        }

        public Guid Guid { get; }

        public void AddComponent(Component component)
        {
            EntityManager.AddComponent(Guid, component);
        }

        public void RemoveComponent(Component component)
        {
            EntityManager.RemoveComponent(Guid, component);
        }

        public T GetComponent<T>() where T : Component
        {
            return (T) EntityManager.GetComponent(Guid, typeof (T));
        }

        public List<Component> GetComponents(Type comType)
        {
            return EntityManager.GetComponents(Guid, comType);
        }

        public bool ContainsComponent(Type type)
        {
            return EntityManager.ContainsComponent(Guid, type);
        }

        public override string ToString()
        {
            var str = "Entity#" + Guid + "<";
            var list = EntityManager.GetComponents(Guid);
            foreach (var c in list)
            {
                str += c.GetType().FullName;
                if (!c.Equals(list.Last()))
                {
                    str += ", ";
                }
            }
            return str + ">";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (GetType() != obj.GetType()) return false;
            var e = (Entity) obj;
            return Guid == e.Guid;
        }

        public override int GetHashCode()
        {
            return Guid.GetHashCode();
        }
    }
}