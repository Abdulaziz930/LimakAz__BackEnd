using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Utils
{
    public static class ViewConstant
    {   
        /// <summary>
        /// Reades html file and create email html view
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="link"></param>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="buttonName"></param>
        /// <returns>string</returns>
        public static string GetEmailView(string filePath, string link, string title, string description
            , string buttonName)
        {
            StreamReader streamReader = new StreamReader(filePath);
            string mailText = streamReader.ReadToEnd();
            streamReader.Close();

            mailText = mailText.Replace("[Title]", title).Replace("[Description]",description).Replace("[Button]",buttonName).Replace("[link]", link);

            return mailText;
        }
    }
}
