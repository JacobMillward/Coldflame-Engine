namespace ColdFlame
{
    public class GameBase
    {
        public static bool Running { private get; set; }

        protected virtual void Initialise()
        {
        }

        protected virtual void Update()
        {
        }

        public void Start()
        {
            Initialise();
            Running = true;
            while (Running)
            {
                SystemManager.DoSystemUpdates();
                Update();
            }
        }
    }
}