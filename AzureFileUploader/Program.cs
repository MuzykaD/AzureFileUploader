
using Azure.Storage.Blobs;
using AzureFileUploader.BL.Services;
using AzureFileUploader.BL.Services.Interfaces;

namespace AzureFileUploader
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddScoped(_ =>
            {
                return new BlobServiceClient(builder.Configuration.GetConnectionString("AzureFileStorage"));
            });
            builder.Services.AddTransient<IFileUploaderService, FileUploaderService>();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}