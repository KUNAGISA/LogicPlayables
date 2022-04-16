namespace LogicPlayables
{
    /// <summary>
    /// 帧时间间隔
    /// </summary>
    public readonly struct FrameInterval
    {
        public readonly float start;
        public readonly float end;

        public FrameInterval(float start, float end)
        {
            this.start = start;
            this.end = end;
        }
    }
}
