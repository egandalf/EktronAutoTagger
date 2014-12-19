using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace AutoTagger.EktronSample.Alchemy
{
    public class ConfigValues
    {
        public string ApiKey { get; set; }
        public string BaseUrl { get; set; }
        public string ConceptsPath { get; set; }
        public ConfigValues()
        {
            var config = (AlchemyConfig)ConfigurationManager.GetSection("AlchemyConfig");
            this.ApiKey = config.Api_Key;
            this.BaseUrl = config.Base_Url;
            this.ConceptsPath = config.Concepts_Path;
        }
    }
}
