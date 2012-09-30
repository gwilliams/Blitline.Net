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