namespace Blitline.Net.Functions.Builders
{
    public class EllipseFunctionBuilder : FunctionBuilder<EllipseFunction>
    {
        public EllipseFunctionBuilder WithDimensions(int x, int y, int width, int height)
        {
            BuildImp.OriginX = x;
            BuildImp.OriginY = y;
            BuildImp.EllipseWidth = width;
            BuildImp.EllipseHeight = height;

            return this;
        }

        public EllipseFunctionBuilder WithStrokeColor(string color)
        {
            BuildImp.Color = color;
            return this;
        }

        public EllipseFunctionBuilder WithFillColor(string color)
        {
            BuildImp.FillColor = color;
            return this;
        }

        public EllipseFunctionBuilder WithStrokeOpacity(decimal opacity)
        {
            BuildImp.StrokeOpacity = opacity;
            return this;
        }

        public EllipseFunctionBuilder WithFillOpacity(decimal opacity)
        {
            BuildImp.FillOpacity = opacity;
            return this;
        }
    }
}