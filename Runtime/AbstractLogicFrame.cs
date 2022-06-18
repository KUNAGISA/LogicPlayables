namespace LogicPlayables
{
    /// <summary>
    /// 逻辑帧基类
    /// </summary>
    /// <typeparam name="T">操作对象类型</typeparam>
    public abstract class AbstractLogicFrame<T> : ILogicFrame<T> where T : class
    {
        private float m_start = 0.0f;
        public float start => m_start;

        private float m_end = 0.0f;
        public float end => m_end;

        private T m_ctrlObj = null;
        protected T ctrlObj => m_ctrlObj;

        void ILogicFrame<T>.SetCtrlObj(T ctrlObj) => m_ctrlObj = ctrlObj;

        void ILogicFrame.SetInterval(float start, float end)
        {
            m_start = start; m_end = end;
        }

        void ILogicFrame.InitFrame() => OnInitFrame();

        void ILogicFrame.DestroyFrame() => OnDestroyFrame();

        void ILogicFrame.ExecuteFrame(float pass) => OnExecuteFrame(pass);

        void ILogicFrame.FinishFrame() => OnFinishFrame();

        /// <summary>
        /// 初始化逻辑帧回调
        /// </summary>
        protected virtual void OnInitFrame() { }

        /// <summary>
        /// 销毁逻辑帧回调
        /// </summary>
        protected virtual void OnDestroyFrame() { }

        /// <summary>
        /// 执行逻辑帧回调
        /// </summary>
        /// <param name="pass">经过时间</param>
        protected virtual void OnExecuteFrame(float pass) { }

        /// <summary>
        /// 完成逻辑帧回调
        /// </summary>
        protected virtual void OnFinishFrame() { }
    }
}
