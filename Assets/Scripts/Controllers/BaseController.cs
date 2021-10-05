namespace Snake
{
    public abstract class BaseController
    {
        protected MainUI UiInterface;
        protected BaseController()
        {
            UiInterface = new MainUI();
        }
    
        public bool IsActive { get; private set; }

        public virtual void On()
        {
            On(null);
        }

        public virtual void On(params BaseSceneObject[] obj)
        {
            IsActive = true;
        }

        public virtual void Off()
        {
            IsActive = false;
        }

        public void Switch(params BaseSceneObject[] obj)
        {
            if (!IsActive)
            {
                On(obj);
            }
            else
            {
                Off();
            }
        }
    }
}