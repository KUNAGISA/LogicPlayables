namespace LogicPlayables
{
    /// <summary>
    /// 逻辑帧数据
    /// </summary>
    public readonly struct FrameData<T>
    {
        public readonly FrameInterval interval;
        public readonly ILogicFrame<T> logic;

        public FrameData(FrameInterval interval, ILogicFrame<T> logic)
        {
            this.interval = interval;
            this.logic = logic;
        }
    }
}
