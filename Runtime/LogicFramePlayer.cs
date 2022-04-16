namespace LogicPlayables
{
    /// <summary>
    /// 逻辑帧Player
    /// </summary>
    public struct LogicFramePlayer<T>
    {
        private T m_owner;
        private float m_runtime;
        private FrameData<T>[] m_frames;

        public LogicFramePlayer(T owner)
        {
            m_owner = owner;
            m_runtime = 0.0f;
            m_frames = null;
        }

        /// <summary>
        /// 运行新的逻辑帧
        /// </summary>
        /// <param name="frames">逻辑帧列表</param>
        public void Play(FrameData<T>[] frames)
        {
            Clear();
            m_frames = frames;

            for (var index = 0; index < frames.Length; ++index)
            {
                frames[index].logic.InitFrame(m_owner);
            }
        }

        /// <summary>
        /// 清空运行的内容
        /// </summary>
        public void Clear()
        {
            if (m_frames != null)
            {
                for (var index = 0; index < m_frames.Length; ++index)
                {
                    m_frames[index].logic.DestroyFrame(m_owner);
                }
                m_frames = null;
            }
            m_runtime = 0.0f;
        }

        /// <summary>
        /// 逻辑帧更新
        /// </summary>
        /// <param name="delta">时间差</param>
        public void Update(float delta)
        {
            if (m_frames == null)
            {
                return;
            }

            var lasttime = m_runtime;
            m_runtime = m_runtime + delta;

            for(var index = 0; index < m_frames.Length; ++index)
            {
                ref var frame = ref m_frames[index];
                ref readonly var interval = ref frame.interval;
                if (interval.start <= m_runtime && interval.end > m_runtime)
                {
                    frame.logic.ExcuteFrame(m_owner, m_runtime - interval.start, in interval);
                }
                else if (interval.start <= lasttime && interval.end > lasttime && interval.end <= m_runtime)
                {
                    frame.logic.FinishFrame(m_owner, in interval);
                }
            }
        }
    }
}
