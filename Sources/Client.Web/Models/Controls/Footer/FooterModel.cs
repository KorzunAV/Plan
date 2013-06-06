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
    }
}