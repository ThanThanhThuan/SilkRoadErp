using Newtonsoft.Json;
using System.Net.Http.Json;
using TunNetCom.SilkRoadErp.Sales.Contracts.ReceiptNotes;

namespace TunNetCom.SilkRoadErp.Sales.HttpClients.Services.ReceiptNote;

public class ReceiptNoteApiClient(HttpClient _httpClient) : IReceiptNoteApiClient
{
	public async Task<PagedList<ReceiptNoteResponse>> GetReceiptNotes(int pageNumber, int pageSize, int? customerId, string? searchKeyword, bool? isFactured)
	{
		var queryString = $"/ReceiptNote?pageNumber={pageNumber}&pageSize={pageSize}";

		if (customerId.HasValue)
		{
			queryString += $"&customerId={customerId.Value}";
		}

		if (!string.IsNullOrEmpty(searchKeyword))
		{
			queryString += $"&searchKeyword={Uri.EscapeDataString(searchKeyword)}";
		}

		if (isFactured.HasValue)
		{
			queryString += $"&isFactured={isFactured.Value}";
		}

		var response = await _httpClient.GetAsync(queryString);
		response.EnsureSuccessStatusCode();
		var content = await response.Content.ReadFromJsonAsync<PagedList<ReceiptNoteResponse>>();
		return content!;
	}




	public async Task<int> CreateReceiptNote(CreateReceiptNoteRequest createReceiptNoteRequest)
	{
		var response = await _httpClient.PostAsJsonAsync("/ReceiptNote", createReceiptNoteRequest);
		response.EnsureSuccessStatusCode();

		var responseJson = await response.Content.ReadAsStringAsync();
		Console.WriteLine("Response JSON: " + responseJson);


		var ReceiptNoteResponse = JsonConvert.DeserializeObject<ReceiptNoteResponse>(responseJson);
		return ReceiptNoteResponse==null?-1: ReceiptNoteResponse.Num ;
	}

	public async Task<List<ReceiptNoteResponse>> GetReceiptNotesByClientId(int clientId)
	{
		var response = await _httpClient.GetAsync($"/ReceiptNote/client/{clientId}");
		response.EnsureSuccessStatusCode();
		var content = await response.Content.ReadAsStringAsync();
		return System.Text.Json.JsonSerializer.Deserialize<List<ReceiptNoteResponse>>(content) ?? new List<ReceiptNoteResponse>();
	}



}
