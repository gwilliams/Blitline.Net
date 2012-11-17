namespace Blitline.Net.Builders
{
    public abstract class UberBuilder<T>
    {
        protected abstract T BuildImp();

        public abstract T Build();
    }
}