using TunNetCom.SilkRoadErp.Sales.Api.Features.DeliveryNote.CreateDeliveryNote;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TunNetCom.SilkRoadErp.Sales.Api.Features.ReceiptNote.CreateReceiptNote;

public class CreateReceiptNoteCommandHandler(
    SalesContext _context,
    ILogger<CreateReceiptNoteCommandHandler> _logger)
    : IRequestHandler<CreateReceiptNoteCommand, Result<int>>
{
    public async Task<Result<int>> Handle(CreateReceiptNoteCommand createReceiptNoteCommand, CancellationToken cancellationToken)
    {
        _logger.LogEntityCreated(nameof(BonDeReception), createReceiptNoteCommand);

        var providerExists = await _context.Fournisseur.AnyAsync(p => p.Id == createReceiptNoteCommand.IdFournisseur, cancellationToken);
        if (!providerExists)
        {
            return Result.Fail("provider_not_found");
        }


        //var isReceiptNoteExist = await _context.BonDeReception.AnyAsync(
        //    Rec => Rec.Num == createReceiptNoteCommand.Num,
        //    cancellationToken);

        //if (isReceiptNoteExist)
        //{
        //    return Result.Fail("receiptnote_number_exists");
        //}

        var receiptNote = BonDeReception.CreateReceiptNote(
            //createReceiptNoteCommand.Num,
            createReceiptNoteCommand.NumBonFournisseur,
            createReceiptNoteCommand.DateLivraison,
            createReceiptNoteCommand.IdFournisseur,
            createReceiptNoteCommand.Date,
            createReceiptNoteCommand.NumFactureFournisseur
);

		foreach (var ligne in createReceiptNoteCommand.Lignes)
		{
			var lignesBR = new LigneBonReception
			{
				//NumBonRec = ligne.NumBonRec,
				RefProduit = ligne.RefProduit,
				DesignationLi = ligne.DesignationLi,
				QteLi = ligne.QteLi,
				PrixHt = ligne.PrixHt,
				Remise = ligne.Remise,
				TotHt = ligne.TotHt,
				Tva = ligne.Tva,
				TotTtc = ligne.TotTtc,
				NumBonRecNavigation = receiptNote
			};
			//TODO make method to add lignesBl
			receiptNote.LigneBonReception.Add(lignesBR);
			//zz
			//_context.LigneBl.Add(lignesBl);

		}
		_context.BonDeReception.Add(receiptNote);
        await _context.SaveChangesAsync(cancellationToken);

        _logger.LogEntityCreatedSuccessfully(nameof(BonDeReception), receiptNote.Num);

        return receiptNote.Num;
    }
}