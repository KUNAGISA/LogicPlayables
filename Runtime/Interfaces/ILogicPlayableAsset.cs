namespace LogicPlayables
{
    /// <summary>
    /// 逻辑Playable资源接口
    /// </summary>
    public interface ILogicPlayableAsset<in T>
    {
        /// <summary>
        /// 创建逻辑帧
        /// </summary>
        /// <param name="start">开始时间</param>
        /// <param name="end">结束时间</param>
        ILogicFrame<T> CreateLogicFrame(T owner, float start, float end);
    }
}
