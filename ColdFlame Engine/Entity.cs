using System;
using System.Linq;
namespace ColdFlame
{
    public class Entity
    {
        public int uuid { get; private set; }

        public Entity()
        {
            this.uuid = EntityManager.generateUUID();
            EntityManager.addEntity(this);
        }

        public Entity(int uuid)
        {
            this.uuid = uuid;
        }

        public void AddComponent(Component component)
        {
            EntityManager.addComponent(uuid, component);
        }

        public T GetComponent<T>() where T:Component
        {
            return (T)EntityManager.getComponent(uuid, typeof(T));
        }

        public bool ContainsComponent(Type type)
        {
            return EntityManager.containsComponent(uuid, type);
        }

        public override string ToString()
        {
            string str = "Entity#" + uuid + "<";
            var list = EntityManager.getComponents(uuid);
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
    }
}
