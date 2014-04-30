namespace Gallery.Interface
{
    /// <summary>
    /// 支持深度克隆
    /// </summary>
    public interface IDeepCloneable<in T>
        where T : class
    {
        /// <summary>
        /// 创建作为当前实例副本的深度副本。
        /// </summary>
        void DeepCloneTo(T clone);
    }
}
