﻿namespace TunNetCom.SilkRoadErp.Sales.Api.Features.ReceiptNote.CreateReceiptNote;
    public class CreateReceiptNoteEndpoint : ICarterModule
    {
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost(
           "/receiptnotes",
           async Task<Results<Created<CreateReceiptNoteRequest>, ValidationProblem>> (
               IMediator mediator,
               CreateReceiptNoteRequest request,
               CancellationToken cancellationToken) =>
           {
			   //Num: request.Num,
			   var createReceiptNoteCommand = new CreateReceiptNoteCommand
               (
                   NumBonFournisseur: request.NumBonFournisseur,
                   DateLivraison: request.DateLivraison,
                   IdFournisseur:request.IdFournisseur,
                   Date: request.Date,
                   NumFactureFournisseur: request.NumFactureFournisseur,
                   Lignes: request.Lignes
				  );

               var result = await mediator.Send(createReceiptNoteCommand, cancellationToken);

               if (result.IsFailed)
               {
                   return result.ToValidationProblem();
               }

               return TypedResults.Created($"/receiptnotes/{result.Value}", request);
           });
    }
}