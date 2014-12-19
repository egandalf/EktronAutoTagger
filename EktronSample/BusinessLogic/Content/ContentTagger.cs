using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutoTagger.EktronSample.Alchemy.Models;
using Ektron.Cms;
using Ektron.Cms.Framework.Community;

namespace AutoTagger.EktronSample.BusinessLogic.Content
{
    public class ContentTagger
    {
        private TagManager _tagCRUD = null;
        private TagManager TagCRUD { get { return _tagCRUD ?? (_tagCRUD = new TagManager()); } }

        public void TagContent(long ContentID, AlchemyResponse Tags)
        {
            TagData cmsTag = null;
            foreach (var tag in Tags.concepts)
            {
                cmsTag = new TagData();
                cmsTag.LanguageId = TagCRUD.ContentLanguage;
                cmsTag.Text = CleanTag(tag.text);
                cmsTag.Type = TagTypes.All;

                TagCRUD.Add(cmsTag);
                TagCRUD.Tag(cmsTag.Text, ContentID, Ektron.Cms.Common.EkEnumeration.CMSObjectTypes.Content);
            }
        }

        public bool HasTags(long contentId)
        {
            var returnValue = true;

            try
            {
                var appliedTags = TagCRUD.GetTags(contentId, Ektron.Cms.Common.EkEnumeration.CMSObjectTypes.Content);
                return appliedTags.Any();
            }
            catch (Exception ex)
            {
                EkException.LogException(ex);
            }

            return returnValue;
        }

        private string CleanTag(string tagText)
        {
            var result = tagText.Replace(' ', '-').ToLower();
            var re = new Regex("[^a-zA-Z0-9-_]");
            result = re.Replace(result, string.Empty);
            return result;
        }
    }
}
