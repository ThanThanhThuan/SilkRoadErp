using System.Text.Json.Serialization;
using TunNetCom.SilkRoadErp.Sales.Contracts.DeliveryNote;

namespace TunNetCom.SilkRoadErp.Sales.Contracts.ReceiptNotes;

public class CreateReceiptNoteRequest
{
	//[JsonPropertyName("num")]
	//public int Num { get; set; }

	[JsonPropertyName("numBonFournisseur")]
		public long NumBonFournisseur { get; set; }

	[JsonPropertyName("dateLivraison")]
	public DateTime DateLivraison { get; set; }

	[JsonPropertyName("idFournisseur")]
	public int IdFournisseur { get; set; }

	[JsonPropertyName("date")]
	public DateTime Date { get; set; }

	[JsonPropertyName("numFactureFournisseur")]
	public int? NumFactureFournisseur { get; set; }

	[JsonPropertyName("lignes")]
	public List<LigneBRRequest> Lignes { get; set; }
}
