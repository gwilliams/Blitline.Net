namespace Blitline.Net.Builders
{
    public abstract class BuilderBase<T>
    {
        protected abstract T BuildImp { get; }
        public abstract T Build();
    }
}