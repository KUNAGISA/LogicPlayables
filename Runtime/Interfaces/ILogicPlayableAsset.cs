namespace LogicPlayables
{
    /// <summary>
    /// 逻辑Playable资源接口
    /// </summary>
    public interface ILogicPlayableAsset<in T>
    {
        /// <summary>
        /// 创建逻辑帧，建议在初次创建后一直使用同一个对象
        /// </summary>
        ILogicFrame<T> CreateLogicFrame();
    }
}
