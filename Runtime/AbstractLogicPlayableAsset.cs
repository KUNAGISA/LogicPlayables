using UnityEngine.Playables;

namespace LogicPlayables
{
    /// <summary>
    /// 逻辑帧PlayableAssset基类
    /// </summary>
    /// <typeparam name="TLogicFrame">逻辑帧</typeparam>
    public abstract class AbstractLogicPlayableAsset<TLogicFrame, T> : PlayableAsset, ILogicPlayableAsset<T> where TLogicFrame : ILogicFrame<T>, new()
    {
        ILogicFrame<T> ILogicPlayableAsset<T>.CreateLogicFrame(T owner, float start, float end)
        {
            var logicFrame = new TLogicFrame();
            logicFrame.InitFrame(owner, start, end);
            BuildLogicFrame(logicFrame);
            return logicFrame;
        }

        protected abstract void BuildLogicFrame(TLogicFrame logicFrame);
    }
}
