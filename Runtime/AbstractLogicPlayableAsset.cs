using UnityEngine;
using UnityEngine.Playables;

namespace LogicPlayables
{
    /// <summary>
    /// 逻辑帧PlayableAsset基类
    /// </summary>
    /// <typeparam name="T">操作对象基类</typeparam>
    public abstract class AbstractLogicPlayableAsset<T> : PlayableAsset, ILogicPlayableAsset<T> where T : class
    {
        /// <summary>
        /// 创建演出Playable
        /// **如果需要顺带创建演出的直接重写这个接口**
        /// </summary>
        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner) => Playable.Null;

        ILogicFrame ILogicPlayableAsset<T>.CreateLogicFrame(T ctrlObj)
        {
            var logicFrame = CreateLogicFrame(ctrlObj);
            logicFrame.SetCtrlObj(ctrlObj);
            return logicFrame;
        }

        /// <summary>
        /// 创建逻辑帧回调
        /// **如果比较频繁可以考虑接入对象池**
        /// </summary>
        /// <returns>逻辑帧</returns>
        protected abstract ILogicFrame<T> CreateLogicFrame(T ctrlObj);
    }
}
