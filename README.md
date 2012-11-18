Blitline.Net
============

A simple .net wrapper for the [Blitline API](http://www.blitline.com)

New Usage
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
            var response = BuilA.Request()
                .WithApplicationId("API_KEY")
                .WithSourceImageUri(new Uri("http://IMAGE_URL"))
                .WithResizeToFitFunction(f => f.WithWidth(100).WithHeight(100)
                    .SaveAs(s => s.WithImageIdentifier("image_identifier").Build())
                .Build())
                .Build().Send();
        }
    }
}
```

Old Simple Usage
------------

```
using Blitline.Net;
using Blitline.Net.Functions;
using Blitline.Net.Request;
using Blitline.Net.Response;

namespace Blitline.Net.Test
{
    public class Test
    {
        public void BuildRequest()
        {
        	var client = new BlitlineApi();
        	var request = new BlitlineRequest("API_KEY", "IMAGE_URL");

        	var resizeFunction = new ResizeToFitFunction(100, 100)
        	{
        		Save = new Save
        		{
        			ImageIdentifier = "test_image"
        		}
        	};

        	request.AddFunction(resizeFunction);

        	var response = client.ProcessImages(request);
        }
    }
}
```

Extending
---------
You can add any missing functions by simply inheriting from BlitlineFunction - This will not work with the new usage

```
public abstract class BlitlineFunction
{
    [JsonProperty("name")]
    public abstract string Name { get; }
    [JsonProperty("params")]
    public abstract object @Params { get; protected set; }
    [JsonProperty("save")]
    public Save Save { get; set; }
    [JsonProperty("functions")]
    public ICollection<BlitlineFunction> Functions { get; set; }

    protected BlitlineFunction()
    {
        Functions = new Collection<BlitlineFunction>();
    }

    public void AddFunction(BlitlineFunction function)
    {
        Functions.Add(function);
    }
}

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