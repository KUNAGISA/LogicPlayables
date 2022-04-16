namespace LogicPlayables
{
    /// <summary>
    /// 逻辑帧接口
    /// 建议本对象内部不要维护数据，把数据都丢到操作对象上
    /// </summary>
    public interface ILogicFrame<in T>
    {
        /// <summary>
        /// 初始化逻辑帧
        /// </summary>
        /// <param name="owner">操作对象</param>
        void InitFrame(T owner);

        /// <summary>
        /// 销毁逻辑帧
        /// </summary>
        /// <param name="owner">操作对象</param>
        void DestroyFrame(T owner);

        /// <summary>
        /// 执行逻辑帧回调
        /// </summary>
        /// <param name="owner">操作对象</param>
        /// <param name="pass">经过时间</param>
        /// <param name="interval">时间区间</param>
        void ExcuteFrame(T owner, float pass, in FrameInterval interval);

        /// <summary>
        /// 结束逻辑帧回调
        /// </summary>
        /// <param name="owner">操作对象</param>
        /// <param name="interval">时间区间</param>
        void FinishFrame(T owner, in FrameInterval interval);
    }
}
