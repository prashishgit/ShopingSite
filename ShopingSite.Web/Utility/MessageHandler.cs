using ShoppinSite.Database.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopingSite.Web.Utility
{
    public class MessageHandler
    {
        public static string GetMessage(MessageStatus messageStatus, string title = "", string name = "")
        {
            var message = "";
            switch (messageStatus)
            {
                case MessageStatus.Create:
                    message = " " + title + " <b>'" + name + "'</b> created successfully.";
                    break;
                case MessageStatus.Edit:
                    message = " " + title + " <b>'" + name + "'</b>  updated successfully.";
                    break;
                case MessageStatus.Duplicate:
                    //message = ("This " + duplicateName.ToLower() + " already exists, please try another " + duplicateName.ToLower()).Trim();
                    //message = (" "+ title + " <b>'" + name + "'</b> already exists, please try another " + title.ToLower() + ".");  
                    message = (" " + title + " <b>'" + name + "'</b> already exists" + ".");
                    break;
                case MessageStatus.Delete:
                    message = "Record deleted successfully.";
                    break;
                case MessageStatus.Error:
                    message = "Something went wrong, please try again.";
                    break;
                case MessageStatus.Update:
                    message = "Profile updated successfully.";
                    break;
                case MessageStatus.Warning:
                    message = (" " + title + " <b>'" + name + "'</b> already exists" + ".");
                    break;
                case MessageStatus.PasswordChange:
                    message = "Password changed successfully.";
                    break;
                case MessageStatus.IncorrectPassword:
                    message = "The current password you have entered is incorrect.";
                    break;
                case MessageStatus.Upload:
                    message = "Excel file" + "<b> '" + name + "' </b> successfully uploaded to the Database.";
                    break;
                case MessageStatus.Select:
                    message = "Please select module to upload file.";
                    break;
                case MessageStatus.Choose:
                    message = "Please choose excel file to upload.";
                    break;

            }
            return message;
        }

    }
}