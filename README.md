# Blazor WebAssembly Authentication and Authorization

See [Knowledge Base article](https://www.forestbrook.net/docs/blazor/authorization.html) for detailed description.

This solution:
* Is intended for [Blazor WebAssembly](https://docs.microsoft.com/en-us/aspnet/core/blazor/hosting-models#blazor-webassembly). 
* Shows how to prepare your Blazor WebAssembly client for authentication and authorization.
* Prepares your client to work with a back end with a 3rd party authorization solution like **Azure AD B2C** or any other authorization solution (including your own).
* Includes an example of a **ClientAuthorizationService** and a **SignIn component**.
* Shows how your back end Api can inform you client about the authorization of the user.

User authentication and authorization for Blazor WebAssembly is fully handled by the back end Api, because the Blazor client runs in a browser. So your back end Api must handle the authorization on every Api call. However, your Api can tell the Blazor app whether the user is authenticated and has access to resources, to enable your Blazor app to show the correct content. This example shows you how to do that.

You can implement your own authorization in your Api or use a 3rd party solution like Azure AD B2C (I will soon post an example). The solution you choose does not matter much for your client.
