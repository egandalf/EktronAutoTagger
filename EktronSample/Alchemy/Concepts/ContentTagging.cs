using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using AutoTagger.EktronSample.Alchemy.Models;
using Ektron.Cms;
using HtmlAgilityPack;

namespace AutoTagger.EktronSample.Alchemy.Concepts
{
    public class ContentTagging
    {
        private JavaScriptSerializer _jser = null;
        private JavaScriptSerializer JSer { get { return _jser ?? (_jser = new JavaScriptSerializer()); } }

        public AlchemyResponse GetAlchemyConceptTags(ContentData contentData)
        {
            var html = contentData.Html;

            var response = new AlchemyResponse();
            var alchemyConfiguration = new Alchemy.ConfigValues();

            using (WebClient client = new WebClient())
            {
                client.Headers["Content-Type"] = "application/x-www-form-urlencoded";

                var uploadRequest = "apikey=" + alchemyConfiguration.ApiKey; // configuration values
                uploadRequest += "&text=" + HttpUtility.UrlEncode(StripHtml(html));
                uploadRequest += "&outputMode=json";
                uploadRequest += "&linkedData=0";

                var jsonResponse = client.UploadString(alchemyConfiguration.BaseUrl + alchemyConfiguration.ConceptsPath, uploadRequest);
                response = JSer.Deserialize<AlchemyResponse>(jsonResponse);
            }

            if (!string.IsNullOrEmpty(response.statusInfo))
            {
                // Error
                return null;
            }

            return response;
        }

        private string StripHtml(string html)
        {
            var doc = new HtmlDocument();
            doc.OptionFixNestedTags = true;
            doc.OptionAutoCloseOnEnd = true;
            doc.LoadHtml("<div>" + html + "</div>");

            return doc.DocumentNode.InnerText.Length < 50000 ? doc.DocumentNode.InnerText : doc.DocumentNode.InnerText.Substring(0, 50000);
        }
    }
}
