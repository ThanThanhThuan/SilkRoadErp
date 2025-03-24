using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TunNetCom.SilkRoadErp.Sales.Contracts.ReceiptNotes;

namespace TunNetCom.SilkRoadErp.Sales.HttpClients.Services.ReceiptNote
{
	public interface IReceiptNoteApiClient
    {
		Task<PagedList<ReceiptNoteResponse>> GetReceiptNotes(
	   int pageNumber,
	   int pageSize,
	   int? customerId,
	   string? searchKeyword,
	   bool? isFactured);

		Task<int> CreateReceiptNote(
			CreateReceiptNoteRequest createReceiptNoteRequest);

		Task<List<ReceiptNoteResponse>> GetReceiptNotesByClientId(
			int clientId);
	}
}
