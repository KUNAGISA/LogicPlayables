using System.Collections.Generic;
using UnityEngine.Timeline;

namespace LogicPlayables
{
    public static class LogicPlayablesExtension
    {
        /// <summary>
        /// 逻辑帧根据时间排序排序
        /// </summary>
        public static void SortByTime<T>(this List<FrameData<T>> logicFrames)
        {
            logicFrames.Sort((frameA, frameB) =>
            {
                ref readonly var intervalA = ref frameA.interval;
                ref readonly var intervalB = ref frameB.interval;

                if (intervalA.start != intervalB.start)
                {
                    return intervalA.start < intervalB.start ? -1 : 1;
                }

                if (intervalA.end != intervalB.end)
                {
                    return intervalA.end < intervalB.end ? -1 : 1;
                }

                return -1;
            });
        }

        /// <summary>
        /// 创建逻辑帧列表
        /// </summary>
        /// <param name="asset">轨道资源</param>
        /// <param name="outputFrames">输出逻辑帧</param>
        public static void CreateLogicFrames<T>(this TrackAsset asset, in List<FrameData<T>> outputFrames)
        {
            var interval = new FrameInterval((float)asset.start, (float)asset.end);
            foreach (var clip in asset.GetClips())
            {
                if (clip.asset is ILogicPlayableAsset<T>)
                {
                    var logicFrame = (clip.asset as ILogicPlayableAsset<T>)?.CreateLogicFrame();
                    outputFrames.Add(new FrameData<T>(interval, logicFrame));
                }
            }

            foreach(var child in asset.GetChildTracks())
            {
                child.CreateLogicFrames<T>(outputFrames);
            }
        }

        /// <summary>
        /// 创建逻辑帧列表
        /// </summary>
        /// <param name="asset">Timeline资源</param>
        /// <param name="owner">持有者</param>
        /// <param name="outputFrames">输出的逻辑帧列表（没有排序）</param>
        public static void CreateLogicFrames<T>(this TimelineAsset asset, in List<FrameData<T>> outputFrames)
        {
            for (var index = 0; index < asset.outputTrackCount; ++index)
            {
                asset.GetRootTrack(index).CreateLogicFrames(outputFrames);
            }
        }
    }
}
