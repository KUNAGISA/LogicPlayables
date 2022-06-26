using System;

namespace LogicPlayables
{
    /// <summary>
    /// 逻辑帧基类
    /// </summary>
    /// <typeparam name="T">操作对象类型</typeparam>
    public abstract class AbstractLogicFrame<T> : ILogicFrame<T> where T : class
    {
        private uint m_start = 0;
        public uint start => m_start;

        private uint m_end = 0;
        public uint end => m_end;

        private T m_ctrlObj = null;
        protected T ctrlObj => m_ctrlObj;

        void ILogicFrame<T>.SetCtrlObj(T ctrlObj) => m_ctrlObj = ctrlObj;

        void ILogicFrame.SetInterval(uint start, uint end)
        {
            m_start = start; m_end = end;
        }

        void ILogicFrame.InitFrame() => OnInitFrame();

        void ILogicFrame.DestroyFrame() => OnDestroyFrame();

        void ILogicFrame.ExecuteFrame(uint pass) => OnExecuteFrame(pass);

        void ILogicFrame.FinishFrame() => OnFinishFrame();

        int IComparable<ILogicFrame>.CompareTo(ILogicFrame other)
        {
            if (start != other.start)
            {
                return start > other.start ? 1 : -1;
            }

            if (end != other.end)
            {
                return end > other.end ? 1 : -1;
            }

            return 0;
        }

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
        /// <param name="pass">经过时间(毫秒)</param>
        protected virtual void OnExecuteFrame(uint pass) { }

        /// <summary>
        /// 完成逻辑帧回调
        /// </summary>
        protected virtual void OnFinishFrame() { }
    }
}
