﻿
namespace Catalog.API.Products.CreateProduct
{

    public record CreateProductRequest(string Name, List<string> Category, string Description, string ImageFile, decimal Price);

    public record CreateProductResponse(Guid Id);

    public class CreateProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products", async (CreateProductResult request, ISender sender) =>
            {
                var command = request.Adapt<CreateProductCommand>(); //Mapster - Map the incoming command object

                var result = await sender.Send(command); //MediatR - will trigger handler class

                var response = result.Adapt<CreateProductResponse>();

                return Results.Created($"/products/{response.Id}", response);
            }).WithName("")
                .Produces<CreateProductResponse>(StatusCodes.Status201Created)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Create Product")
                .WithDescription("Create Product");

        }
    }
}