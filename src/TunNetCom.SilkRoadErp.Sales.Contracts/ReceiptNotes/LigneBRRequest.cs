using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TunNetCom.SilkRoadErp.Sales.Contracts.ReceiptNotes
{
    public class LigneBRRequest
    {
	
		//[JsonPropertyName("idLigne")]
		//public int IdLigne { get; set; }

		//[JsonPropertyName("numBonRec")]
		//public int NumBonRec { get; set; }

		[JsonPropertyName("refProduit")]
		public string RefProduit { get; set; } = string.Empty;

		[JsonPropertyName("designationLi")]
		public string DesignationLi { get; set; } = string.Empty;

		[JsonPropertyName("qteLi")]
		public int QteLi { get; set; }

		[JsonPropertyName("prixHt")]
		public decimal PrixHt { get; set; }

		[JsonPropertyName("remise")]
		public double Remise { get; set; }

		[JsonPropertyName("totHt")]
		public decimal TotHt { get; set; }

		[JsonPropertyName("tva")]
		public double Tva { get; set; }

		[JsonPropertyName("totTtc")]
		public decimal TotTtc { get; set; }

		public string? RefAndDisplay { get { return $"{RefProduit} -- {DesignationLi}"; } }
	}
}
