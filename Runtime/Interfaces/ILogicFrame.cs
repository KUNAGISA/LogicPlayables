namespace LogicPlayables
{
    /// <summary>
    /// 逻辑帧接口
    /// </summary>
    public interface ILogicFrame
    {
        /// <summary>
        /// 逻辑帧开始时间
        /// </summary>
        float start { get; }

        /// <summary>
        /// 逻辑帧结束时间
        /// </summary>
        float end { get; }

        /// <summary>
        /// 设置逻辑帧间隔
        /// </summary>
        /// <param name="start">开始时间</param>
        /// <param name="end">结束时间</param>
        void SetInterval(float start, float end);

        /// <summary>
        /// 所有数据准备好后调用，初始化逻辑帧
        /// </summary>
        void InitFrame();

        /// <summary>
        /// 销毁逻辑帧
        /// </summary>
        void DestroyFrame();

        /// <summary>
        /// 执行逻辑帧
        /// </summary>
        /// <param name="pass">经过的时间</param>
        void ExecuteFrame(float pass);

        /// <summary>
        /// 逻辑帧完成
        /// </summary>
        void FinishFrame();

        public static bool operator < (ILogicFrame frameA, ILogicFrame frameB)
        {
            if (frameA.start != frameB.start)
            {
                return frameA.start < frameB.start;
            }

            if (frameA.end != frameB.end)
            {
                return frameA.end < frameB.end;
            }

            return false;
        }

        public static bool operator > (ILogicFrame frameA, ILogicFrame frameB)
        {
            if (frameA.start != frameB.start)
            {
                return frameA.start > frameB.start;
            }

            if (frameA.end != frameB.end)
            {
                return frameA.end > frameB.end;
            }

            return false;
        }
    }

    /// <summary>
    /// 逻辑帧接口
    /// </summary>
    /// <typeparam name="T">操作对象类型</typeparam>
    public interface ILogicFrame<in T> : ILogicFrame where T : class
    {
        /// <summary>
        /// 设置操作对象
        /// </summary>
        /// <param name="ctrlObj">操作对象</param>
        void SetCtrlObj(T ctrlObj);
    }
}
