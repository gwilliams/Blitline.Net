Blitline.Net
============

A simple .net wrapper for the [Blitline API](http://www.blitline.com)

Usage - Simple
------------

```
using Blitline.Net.Builders;
using Blitline.Net.Request;

namespace Blitline.Net.Test
{
    public class Test
    {
        public void BuildRequest()
        {
            var response = BuildA.Request(r => r
                .WithApplicationId("123")
                .WithSourceImageUri(new Uri("http://foo.bar.gif"))
                .Crop(f => 
					f.WithDimensions(1,2,3,4)
					.WithGravity(Gravity.NorthEastGravity)
					.PreserveAspectIfSmaller()
				))
                .Send();
        }
        
        public async void BuildRequestAsync()
        {
            var response = BuildA.Request(r => r
                .WithApplicationId("123")
                .WithSourceImageUri(new Uri("http://foo.bar.gif"))
                .Crop(f => 
					f.WithDimensions(1,2,3,4)
					.WithGravity(Gravity.NorthEastGravity)
					.PreserveAspectIfSmaller()
				))
                .SendAsync();
        }
    }
}
```

Usage - Multiple Functions
-------------
```
using Blitline.Net.Builders;
using Blitline.Net.Request;

namespace Blitline.Net.Test
{
    public class Test
    {
        public void BuildRequest()
        {
            var response = BuildA.Request(r => 
				r.WithApplicationId("123")
				.WithSourceImageUri(new Uri("http://foo.bar.gif"))
				.Crop(c => 
				    c.WithDimensions(1, 2, 3, 4)
				    .WithGravity(Gravity.NorthEastGravity))
				.Watermark(w => 
				    w.WithText("Watermarked")))
				.Send ();
        }
        
        public aysnc void BuildRequestAsync()
        {
            var response = BuildA.Request(r => 
				r.WithApplicationId("123")
				.WithSourceImageUri(new Uri("http://foo.bar.gif"))
				.Crop(c => 
				    c.WithDimensions(1, 2, 3, 4)
				    .WithGravity(Gravity.NorthEastGravity))
				.Watermark(w => 
				    w.WithText("Watermarked")))
				.SendAsync();
        }
    }
}
```

Custom Functions
------------
If a function that you require isn't available, you can now add your own and use the AddFunction<TBuilder,TFunction> method

```
public class MyFunction : BlitlineFunction
{
	public int Age { get; private set; }
	public override string Name { get { return "My Function"; }
	public override dynamic Params 
	{
		get 
		{
			return new {
				age = Age
			};
		}
	}
}

public class MyFunctionBuilder : FunctionBuilder<MyFunction>
{
	public MyFunctionBuilder WithAge(int age)
	{
		BuildImp.Age = age;
		return this;
	}
}

public class BlitlineTest
{
	public static void Main (string [] args)
	{
		var request = BuildA.Request (r => r
						  .WithApplicationId ("appId")
						  .WithSourceImageUri (new Uri ("imageUrl"))
		                              .AddFunction<MyFunctionBuilder, MyFunction> (x => x.WithAge (123)
		                              .SaveAs (s => s.WithImageIdentifier (imageIdentifier)
		                              .ToS3 (s3 => s3.ToBucket (bucketName)
		                              .WithKey ("annotate-default.png")))));

		var response = request.Send();
		Console.Read();
	}
}
```

Released under the Simple Public License (SimPL 2.0): http://opensource.org/licenses/SimPL-2.0
