using TunNetCom.SilkRoadErp.Sales.Contracts.ReceiptNotes;

namespace TunNetCom.SilkRoadErp.Sales.WebApp.Components.Pages
{
	public class ValueService
	{
		private string _value = "333";
		private CreateReceiptNoteRequest? receiptNote = null;

		public void SetReceiptNote(CreateReceiptNoteRequest? val)
		{
			receiptNote = val;
		}

		public CreateReceiptNoteRequest? GetReceiptNote()
		{
			return receiptNote;
		}	

		public void SetValue(string val)
		{
			_value= val;
		}
		public string GetValue()
		{
			return _value;
		}
		
	}
}
