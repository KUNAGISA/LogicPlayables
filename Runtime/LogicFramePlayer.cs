namespace LogicPlayables
{
    /// <summary>
    /// 逻辑帧Player
    /// </summary>
    public class LogicFramePlayer
    {
        private float m_runtime = 0.0f;
        private ILogicFrame[] m_frames = null;

        public float Runtime => m_runtime;

        /// <summary>
        /// 运行新的逻辑帧
        /// </summary>
        /// <param name="frames">逻辑帧列表</param>
        public void Play(ILogicFrame[] frames)
        {
            Clear();
            m_frames = frames;

            for (var index = 0; index < frames.Length; ++index)
            {
                frames[index].InitFrame();
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
                    m_frames[index].DestroyFrame();
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
                var frame = m_frames[index];
                if (frame.start <= m_runtime && frame.end > m_runtime)
                {
                    frame.ExecuteFrame(m_runtime - frame.start);
                }
                else if (frame.start <= lasttime && frame.end > lasttime && frame.end <= m_runtime)
                {
                    frame.FinishFrame();
                }
            }
        }
    }
}
