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

Extending
---------
You can add any missing functions by simply inheriting from BlitlineFunction - This will not work with the new usage

```
public class MyTestFunction : BlitlineFunction
{
    public override string Name
    {
        get { return "my_test_function"; }
    }

    public override object Params { get; protected set; }

    public MyTestFunction()
    {
        @Params = new { foo = 1, bar = 2 };
    }
}
```
Released under the Simple Public License (SimPL 2.0): http://opensource.org/licenses/SimPL-2.0
