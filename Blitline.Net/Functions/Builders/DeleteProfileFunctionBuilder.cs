namespace Blitline.Net.Functions.Builders
{
    public class DeleteProfileFunctionBuilder : FunctionBuilder<DeleteProfileFunction>
    {
        public DeleteProfileFunctionBuilder WithProfileName(string name)
        {
            BuildImp.ProfileName = name;
            return this;
        }
    }
}