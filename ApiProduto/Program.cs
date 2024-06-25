using AutoMapper;
using ApiProduto.Persistence.Context;
using ApiProduto.Persistence.Repositories.Produto;
using ApiProduto.Persistence.Repositories.Produto.Interfaces;
using ApiProduto.Profile;
using ApiProduto.Services.Produto;
using ApiProduto.Services.Produto.Interfaces;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.ResponseCompression;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRouting((Action<RouteOptions>)(options => options.LowercaseUrls = true));
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "CorsPolicy",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod()
            .WithExposedHeaders("accesstoken", "refreshtoken")
            );
});
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<AppDbContext>();
builder.Services.AddControllers();
builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddAutoMapper(typeof(ProdutoProfile));
builder.Services.AddHttpClient();
builder.Services.AddResponseCompression(options =>
{
    options.Providers.Add<GzipCompressionProvider>();
    options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "application/json" });
});
builder.Services.Configure<GzipCompressionProviderOptions>(options => options.Level = System.IO.Compression.CompressionLevel.Optimal);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseRequestLocalization(new RequestLocalizationOptions().SetDefaultCulture("pt-BR"));
    app.UseHttpsRedirection();
    app.UseRouting();
    app.UseCors("CorsPolicy");
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
    app.UseResponseCompression();
    app.UseResponseCaching();

    app.UseSwagger();
    app.UseSwaggerUI(s =>
    {
        s.SwaggerEndpoint("/swagger/v1/swagger.json", "Workshop Management - API V.1.0");
        s.EnableFilter();
        s.RoutePrefix = "";
        s.DocExpansion(DocExpansion.List);
        s.OAuthScopeSeparator(" ");
        s.OAuthUsePkce();
    });

    app.UseForwardedHeaders(new ForwardedHeadersOptions
    {
        ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
    });
}

app.UseHttpsRedirection();

app.Run();