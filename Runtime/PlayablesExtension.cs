using System.Collections.Generic;
using UnityEngine.Timeline;

namespace LogicPlayables
{
    public static class LogicPlayablesExtension
    {
        /// <summary>
        /// 创建逻辑帧列表
        /// </summary>
        /// <param name="trackAsset">轨道资源</param>
        /// <param name="outputFrames">输出逻辑帧</param>
        public static void CreateLogicFrames<T>(this TrackAsset trackAsset, T ctrlObj, List<ILogicFrame> outputFrames) where T : class
        {
            float start = (float)trackAsset.start, end = (float)trackAsset.end;
            foreach (var clip in trackAsset.GetClips())
            {
                var playableAsset = clip.asset as ILogicPlayableAsset<T>;
                if (playableAsset != null)
                {
                    var logicFrame = playableAsset.CreateLogicFrame(ctrlObj);
                    logicFrame.SetInterval(start, end);
                    outputFrames.Add(logicFrame);
                }
            }

            foreach(var child in trackAsset.GetChildTracks())
            {
                child.CreateLogicFrames<T>(ctrlObj, outputFrames);
            }
        }
    }
}
