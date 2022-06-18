namespace LogicPlayables
{
    /// <summary>
    /// 逻辑Playable资源接口
    /// </summary>
    public interface ILogicPlayableAsset<in T> where T : class
    {
        /// <summary>
        /// 创建逻辑帧
        /// </summary>
        /// <param name="ctrlObj">操作对象</param>
        /// <returns>逻辑帧</returns>
        ILogicFrame CreateLogicFrame(T ctrlObj);
    }
}
