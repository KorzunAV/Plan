namespace Client.Web.Models.Controls.Footer
{
	public class FooterModel
	{
		#region Public pages
		public string HomeUrl { get; set; }
		#endregion Public pages

		#region MyAccount

		public bool IsMyAccountEnabled { get; set; }
		public string MyAccountUrl { get; set; }

		#endregion


		#region CurrencyType

		public bool IsCurrencyTypeEnabled { get; set; }
		public string CurrencyTypeUrl { get; set; }

		#endregion


        #region Transaction

        public bool IsTransactionEnabled { get; set; }
        public string TransactionUrl { get; set; }

		#endregion
	}
}