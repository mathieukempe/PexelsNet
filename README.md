# PexelsNet
PexelsNet is a .NET class library that provides an easy-to-use interface for the [Pexels API](https://www.pexels.com/api/)

## Nuget

https://www.nuget.org/packages/PexelsNet/

## Initializing

```csharp
var client = new PexelsClient("<Your Api key>");
```

## Methods

### Search

The following example will grab all images for the term `business` using the default pagination (15 images).

```csharp
var results = client.SearchAsync("business").Result; 

foreach (var image in results.Photos)
{
    Console.WriteLine(image.Src.Medium);
}
```

### Popular

The following example will grab all popular images using the default pagination (15 images).

```csharp
var results = client.PopularAsync().Result; 

foreach (var image in results.Photos)
{
    Console.WriteLine(image.Src.Medium);
}
```

## Pagination

By default, pexels will return 15 images but you can specify your own pagination. 

The following example will grab 20 images from the 2nd page for the term `business`.

```csharp
var page = client.SearchAsync("business", 2, 20).Result; 
```

The following example will grab 20 popular images from the 2nd page.

```csharp
var page = client.PopularAsync(2, 20).Result; 
```
