using System;
using Blitline.Net.ParamOptions;

namespace Blitline.Net.Functions
{
    public class CaptionFunction : BlitlineFunction
    {
        public override string Name
        {
            get { return "caption"; }
        }

        public override dynamic Params
        {
            get { throw new System.NotImplementedException(); }
        }

        public string Text { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public string Colour { get; set; }
        public string FontFamily { get; set; }
        public int PointSize { get; set; }
        public Gravity Gravity { get; set; }

        public CaptionFunction()
        {
            X = 0;
            Y = 0;
            Width = "90%";
            Height = "90%";
            Colour = "#ffffff";
            FontFamily = "Helvetica";
            PointSize = 12;
            Gravity = Gravity.CenterGrativty;
        }

        public override void Validate()
        {
            if(string.IsNullOrEmpty(Text)) throw new ArgumentException("Text cannot be empty");
        }
    }
}