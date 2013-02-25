using System;
using Blitline.Net.Builders;
using Blitline.Net.Request.Builders;

namespace Blitline.Net.Functions.Builders
{
    public abstract class FunctionBuilder<T> : Builder<T>
        where T : BlitlineFunction, new()
    {
        protected T Function;

        protected FunctionBuilder()
        {
            Function = new T();
        }

	    public FunctionBuilder<T> SaveAs(Action<SaveBuilder> build)
        {
		    var saveBuilder = new SaveBuilder();
		    build(saveBuilder);
		    Function.Save = saveBuilder.Build();
			return this;
        }

        internal override T Build()
        {
			BuildImp.Validate();
            return BuildImp;
        }

        protected sealed override T BuildImp
        {
            get { return Function; }
        }
    }
}