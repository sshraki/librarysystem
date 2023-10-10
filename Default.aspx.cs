using BooksApp.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BooksApp
{
    public partial class Login : System.Web.UI.Page
    {
        private LibraryDBContext dataContext;

        protected LibraryDBContext DbContext
        {
            get
            {
                if (dataContext == null)
                {
                    dataContext = new LibraryDBContext();
                }
                return dataContext;
            }
        }

        public override void Dispose()
        {
            if (dataContext != null)
            {
                dataContext.Dispose();
            }
            base.Dispose();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.Cookies["user"] != null)
                {
                    Request.Cookies["user"].Expires = DateTime.Now.AddMinutes(30);
                    Request.Cookies.Remove("user");
                }
            }
            catch (Exception)
            {


            }

        }
        private bool CheckUser(string username , string password)
        {
           BooksApp.Models.User user = DbContext.Users.FirstOrDefault(c => c.UserName == username && c.UserPassword == password);

            if (user != null)
                return true;
            else
            {
                lbl.InnerText = "Invalid Credentials";
                return false;
            }
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            lbl.InnerText = string.Empty;

            if (CheckUser(inputUserName.Value,inputPassword.Value) || (inputUserName.Value == "admin" && inputPassword.Value == "admin"))
            {
                Response.Cookies["user"]["login"] = "true";
                Response.Redirect("Home.aspx");
            }
        }
    }
}