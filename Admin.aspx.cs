using BooksApp.DB;
using BooksApp.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace BooksApp
{
    public partial class admin : System.Web.UI.Page
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

        protected void RadGrid1_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            var result = from r in DbContext.Users
                         select r;

            RadGrid1.DataSource = result;
        }

        protected void RadGrid1_UpdateCommand(object source, GridCommandEventArgs e)
        {
            var editableItem = ((GridEditableItem)e.Item);
            var Id = (int)editableItem.GetDataKeyValue("UserId");

            var User = DbContext.Users.Where(n => n.UserId == Id).FirstOrDefault();
            if (User != null)
            {
                editableItem.UpdateValues(User);

                try
                {
                    DbContext.SaveChanges();
                    EndEdit(e);
                }
                catch (System.Exception)
                {
                    ShowErrorMessage();
                }
            }
        }

        /// <summary>
        /// Shows a <see cref="RadWindow"/> alert if an error occurs
        /// </summary>
        private void ShowErrorMessage()
        {
            RadAjaxManager1.ResponseScripts.Add(string.Format("window.radalert(\"Please enter valid data!\")"));
        }

        protected void RadGrid1_ItemCreated(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridEditableItem && (e.Item.IsInEditMode))
            {
                GridEditableItem editableItem = (GridEditableItem)e.Item;
                SetupInputManager(editableItem);
            }
        }

        private void SetupInputManager(GridEditableItem editableItem)
        {
            //var textBox =
            //   ((GridTextBoxColumnEditor)editableItem.EditManager.GetColumnEditor("UserId")).TextBoxControl;


            //InputSetting inputSetting = RadInputManager1.GetSettingByBehaviorID("TextBoxSetting1");
            //inputSetting.TargetControls.Add(new TargetInput(textBox.UniqueID, true));
            //inputSetting.InitializeOnClient = true;
            //inputSetting.Validation.IsRequired = true;

            // textBox =
            //    ((GridTextBoxColumnEditor)editableItem.EditManager.GetColumnEditor("UserName")).TextBoxControl;


            //inputSetting = RadInputManager1.GetSettingByBehaviorID("TextBoxSetting2");
            //inputSetting.TargetControls.Add(new TargetInput(textBox.UniqueID, true));
            //inputSetting.InitializeOnClient = true;
            //inputSetting.Validation.IsRequired = true;

            //textBox =
            //    ((GridTextBoxColumnEditor)editableItem.EditManager.GetColumnEditor("UserPrice")).TextBoxControl;

            //inputSetting = RadInputManager1.GetSettingByBehaviorID("NumericTextBoxSetting3");
            //inputSetting.InitializeOnClient = true;
            //inputSetting.TargetControls.Add(new TargetInput(textBox.UniqueID, true));

            //textBox =
            //    ((GridTextBoxColumnEditor)editableItem.EditManager.GetColumnEditor("UserCount")).TextBoxControl;

            //inputSetting = RadInputManager1.GetSettingByBehaviorID("NumericTextBoxSetting3");
            //(inputSetting as NumericTextBoxSetting).MaxValue = short.MaxValue;
            //inputSetting.InitializeOnClient = true;
            //inputSetting.TargetControls.Add(new TargetInput(textBox.UniqueID, true));
        }

        protected void RadGrid1_InsertCommand(object source, GridCommandEventArgs e)
        {
            var editableItem = ((GridEditableItem)e.Item);
            var User = new User();
            Hashtable values = new Hashtable();
            editableItem.ExtractValues(values);
            User.UserName = (string)values["UserName"];
            if (values["UserName"] != null)
            {
                User.UserName = (values["UserName"].ToString());
            }
            if (values["UserPassword"] != null)
            {
                User.UserPassword = (values["UserPassword"].ToString());
            }
            if (values["UserRole"] != null)
            {
                User.UserRole = (values["UserRole"].ToString());
            }

            DbContext.Users.Add(User);
            try
            {
                DbContext.SaveChanges();
                EndEdit(e);
            }
            catch (System.Exception)
            {
                ShowErrorMessage();
            }
        }
        protected void RadGrid1_ItemCommand(object sender, GridCommandEventArgs e)
        {
            //if (e.CommandName == RadGrid.InitInsertCommandName)
            //{
            //    if (e.Item.ItemIndex > 0)
            //    {
            //        ((GridDataItem)e.Item)["UserId"].Text = (e.Item.ItemIndex + 2).ToString();
            //        ((GridDataItem)e.Item)["UserId"].Enabled = false;
            //    }
            //}
            //if (e.CommandName == RadGrid.UpdateEditedCommandName || e.CommandName == RadGrid.DeleteSelectedCommandName)
            //{
            //    e.Canceled = true;
            //    RadGrid1.Rebind();
            //}
        }
        protected void EndEdit(GridCommandEventArgs e)
        {
            e.Canceled = true;
            RadGrid grid = RadGrid1 as RadGrid;
            grid.MasterTableView.IsItemInserted = false;
            RadGrid1.Rebind();
        }

        protected void RadGrid1_DeleteCommand(object source, GridCommandEventArgs e)
        {
            var id = (int)((GridDataItem)e.Item).GetDataKeyValue("UserId");

            var User = DbContext.Users.Where(n => n.UserId == id).FirstOrDefault();
            if (User != null)
            {
                DbContext.Users.Remove(User);
                try
                {
                    DbContext.SaveChanges();
                    EndEdit(e);


                }
                catch (System.Exception)
                {
                    ShowErrorMessage();
                }
            }
        }
    }
}
