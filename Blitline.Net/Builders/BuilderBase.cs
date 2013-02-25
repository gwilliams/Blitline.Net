namespace Blitline.Net.Builders
{
    public abstract class BuilderBase<T>
    {
        protected abstract T BuildImp { get; }
        internal abstract T Build();
    }
}