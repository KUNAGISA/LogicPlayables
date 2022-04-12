using System.Collections.Generic;
using UnityEngine.Timeline;

namespace LogicPlayables
{
    public static class LogicPlayablesExtension
    {
        /// <summary>
        /// 逻辑帧根据时间排序排序
        /// </summary>
        public static void SortByTime<T>(this List<ILogicFrame<T>> logicFrames)
        {
            logicFrames.Sort((frameA, frameB) =>
            {
                if (frameA.start != frameB.start)
                {
                    return frameA.start < frameB.start ? -1 : 1;
                }

                if (frameA.end != frameB.end)
                {
                    return frameA.end < frameB.end ? -1 : 1;
                }

                return -1;
            });
        }

        /// <summary>
        /// 创建逻辑帧列表
        /// </summary>
        /// <param name="asset">轨道资源</param>
        /// <param name="owner">逻辑持有者</param>
        /// <param name="logicFrames">输出逻辑帧</param>
        public static void CreateLogicFrames<T>(this TrackAsset asset, T owner, in List<ILogicFrame<T>> logicFrames)
        {
            float start = (float)asset.start, end = (float)asset.end;
            foreach (var clip in asset.GetClips())
            {
                var logicFrame = (clip.asset as ILogicPlayableAsset<T>)?.CreateLogicFrame(owner, start, end);
                if (logicFrame != null)
                {
                    logicFrames.Add(logicFrame);
                }
            }

            foreach(var child in asset.GetChildTracks())
            {
                child.CreateLogicFrames<T>(owner, logicFrames);
            }
        }

        /// <summary>
        /// 创建逻辑帧列表
        /// </summary>
        /// <param name="asset">Timeline资源</param>
        /// <param name="owner">持有者</param>
        /// <param name="logicFrames">输出的逻辑帧列表（没有排序）</param>
        public static void CreateLogicFrames<T>(this TimelineAsset asset, T owner, in List<ILogicFrame<T>> logicFrames)
        {
            foreach (var track in asset.GetRootTracks())
            {
                track.CreateLogicFrames(owner, logicFrames);
            }
        }

        /// <summary>
        /// 创建逻辑帧列表
        /// </summary>
        /// <param name="asset">Timeline资源</param>
        /// <param name="owner">逻辑持有者</param>
        /// <returns>逻辑帧列表</returns>
        public static List<ILogicFrame<T>> CreateLogicFrames<T>(this TimelineAsset asset, T owner)
        {
            var logicFrames = new List<ILogicFrame<T>>();
            asset.CreateLogicFrames(owner, logicFrames);
            logicFrames.SortByTime();
            return logicFrames;
        }
    }
}
