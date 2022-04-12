namespace LogicPlayables
{
    /// <summary>
    /// 逻辑帧基类
    /// </summary>
    public abstract class AbstractLogicFrame<T> : ILogicFrame<T>
    {
        private float m_start = 0.0f;
        private float m_end = 0.0f;

        protected T m_owner;

        public float start => m_start;
        public float end => m_end;
        public T owner => m_owner;

        void ILogicFrame<T>.InitFrame(T owner, float start, float end)
        {
            m_start = start; m_end = end; m_owner = owner;
            OnInitFrame();
        }

        /// <summary>
        /// 初始化逻辑帧
        /// </summary>
        protected abstract void OnInitFrame();

        public abstract void ExcuteFrame(float delta);
    }
}
