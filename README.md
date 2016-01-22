# PexelsNet
PexelsNet is a .NET class library that provides an easy-to-use interface for the https://www.pexels.com/ web api

##Initializing

```csharp

PexelsClient client = new PexelsClient("<Your Api key>");

```

Than to search pictures

```csharp

var page = client.Search("business"); 

foreach (var photo in page.Photos)
{
    Console.WriteLine(photo.Src.Medium);
}

```

Paginate

```csharp

var page = client.Search("business", 2, 20); 

```
