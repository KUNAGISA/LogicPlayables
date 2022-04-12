namespace LogicPlayables
{
    /// <summary>
    /// 逻辑帧接口
    /// </summary>
    public interface ILogicFrame<in T>
    {
        /// <summary>
        /// 开始时间
        /// </summary>
        float start { get; }

        /// <summary>
        /// 结束时间
        /// </summary>
        float end { get; }

        /// <summary>
        /// 初始化逻辑帧
        /// </summary>
        void InitFrame(T owner, float start, float end);

        /// <summary>
        /// 执行逻辑帧
        /// </summary>
        void ExcuteFrame(float delta);
    }
}
