using System.Text.Json.Serialization;
using TunNetCom.SilkRoadErp.Sales.Contracts.DeliveryNote;

namespace TunNetCom.SilkRoadErp.Sales.Contracts.ReceiptNotes;

public class ReceiptNoteResponse
{
    [JsonPropertyName("num")]
    public int Num { get; set; }

    [JsonPropertyName("NumBonFournisseur")]
    public long NumBonFournisseur { get; set; }

    [JsonPropertyName("DateLivraison")]
    public DateTime DateLivraison { get; set; }

    [JsonPropertyName("IdFournisseur")]
    public int IdFournisseur { get; set; }

    [JsonPropertyName("Date")]
    public DateTime Date { get; set; }

    [JsonPropertyName("NumFactureFournisseur")]
    public int? NumFactureFournisseur { get; set; }

	//[JsonPropertyName("lignes")]
	//public List<LigneBRRequest> Lignes { get; set; }

}