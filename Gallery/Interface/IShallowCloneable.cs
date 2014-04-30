namespace Gallery.Interface
{
    /// <summary>
    /// 支持浅表克隆
    /// </summary>
    public interface IShallowCloneable<in T>
        where T : class
    {
        /// <summary>
        /// 创建作为当前实例副本的浅表副本。
        /// </summary>
        /// <returns>作为此实例副本的浅表副本。</returns>
        void ShallowCloneTo(T clone);
    }
}
