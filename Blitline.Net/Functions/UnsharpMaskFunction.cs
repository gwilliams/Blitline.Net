using System;

namespace Blitline.Net.Functions
{
    /// <summary>
    /// Sharpens an image
    /// </summary>
    public class UnsharpMaskFunction : BlitlineFunction
    {
        public override string Name
        {
            get { return "unsharp_mask"; }
        }

        public override object Params
        {
            get
            {
                return new
                {
                    sigma = Sigma,
                    radius = Radius,
                    amount = Amount,
                    threshold = Threshold
                };
            }
        }

        /// <summary>
        /// Gaussian operator (defaults to 1.0)
        /// </summary>
        public decimal Sigma { get; set; }

        /// <summary>
        /// Gaussian operator (defaults to 0.0)
        /// </summary>
        public decimal Radius { get; set; }

        /// <summary>
        /// The percentage of the blurred image to be added to the receiver, specified as a fraction between 0 and 1.0 (defaults to 1.0)
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// The threshold needed to apply the amount, specified as a fraction between 0 and 1.0 (defaults to 0.05)
        /// </summary>
        public decimal Threshold { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sigma">Gaussian operator (defaults to 1.0)</param>
        /// <param name="radius">Gaussian operator (defaults to 0.0)</param>
        /// <param name="amount">The percentage of the blurred image to be added to the receiver, specified as a fraction between 0 and 1.0 (defaults to 1.0)</param>
        /// <param name="threshold">The threshold needed to apply the amount, specified as a fraction between 0 and 1.0 (defaults to 0.05)</param>
        public UnsharpMaskFunction(decimal sigma = 1.0m, decimal radius = 0.0m, decimal amount = 1.0m, decimal threshold = 0.05m)
        {
            if(amount < 0 || amount > 1.0m) throw new ArgumentException("amount cannot be less than 0 and greater than 1.0", "amount");
            if (threshold < 0 || threshold > 1.0m) throw new ArgumentException("threshold cannot be less than 0 and greater than 1.0", "threshold");

            Sigma = sigma;
            Radius = radius;
            Amount = amount;
            Threshold = threshold;
        }

        protected internal UnsharpMaskFunction()
        {
            Sigma = 1.0m;
            Amount = 1.0m;
            Threshold = 0.05m;
        }
    }
}
