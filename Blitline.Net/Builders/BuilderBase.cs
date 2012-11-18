namespace Blitline.Net.Builders
{
    public abstract class BuilderBase<T>
    {
        protected abstract T BuildImp();

        public abstract T Build();
    }
}