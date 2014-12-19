using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace AutoTagger
{
    public class AlchemyConfig : ConfigurationSection
    {
        private const string APIKey = "APIKey";
        private const string BaseURL = "BaseURL";
        private const string ConceptsPath = "ConceptsPath";

        [ConfigurationProperty(APIKey, IsRequired = true)]
        public string Api_Key
        {
            get
            {
                return (string)this[APIKey];
            }
            set
            {
                this[APIKey] = value;
            }
        }

        [ConfigurationProperty(BaseURL, IsRequired = true)]
        public string Base_Url
        {
            get
            {
                return (string)this[BaseURL];
            }
            set
            {
                this[BaseURL] = value;
            }
        }

        [ConfigurationProperty(ConceptsPath, IsRequired = false)]
        public string Concepts_Path
        {
            get
            {
                return (string)this[ConceptsPath];
            }
            set
            {
                this[ConceptsPath] = value;
            }
        }
    }
}
