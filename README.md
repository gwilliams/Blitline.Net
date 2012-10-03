Blitline.Net
============

A simple .net wrapper for the [Blitline API](http://www.blitline.com)

Simple Usage
------------

```
using Blitline.Net;
using Blitline.Net.Functions;
using Blitline.Net.Request;
using Blitline.Net.Response;

namespace Blitline.Net.Test
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
```

Extending
---------
You can add any missing functions by simply inheriting from BlitlineFunction

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

    public NoOpFunction()
    {
        @Params = new { foo = 1, bar = 2 };
    }
}
```
