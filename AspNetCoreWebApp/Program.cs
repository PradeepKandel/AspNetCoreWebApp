using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;

var endpoint = "https://computervision-merocloud.cognitiveservices.azure.com/";
var subscriptionKey = "db355c27a1504e75918e64b30b737471";

var client = new ComputerVisionClient(new ApiKeyServiceClientCredentials(subscriptionKey))
{
    Endpoint = endpoint
};
var builder = WebApplication.CreateBuilder(args);
// Step 9- Use the AnalyzeImageAsync method to analyze an image using the API. For example, the following code analyzes an image stored in a byte array:
var imageBytes = File.ReadAllBytes("path/to/image.jpg");
var features = new List<VisualFeatureTypes>
{
    VisualFeatureTypes.Categories, VisualFeatureTypes.Description, VisualFeatureTypes.Tags
};

var result = await client.AnalyzeImageInStreamAsync(new MemoryStream(imageBytes), features);
// Step 9 ends

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
