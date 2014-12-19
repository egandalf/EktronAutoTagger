using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ektron.Cms.Extensibility;
using Ektron.Cms.Extensibility.Content;

namespace AutoTagger.EktronSample.Strategies.Content
{
    public class TagOnUpdate : ContentStrategy
    {
        public override void OnBeforeUpdateContent(Ektron.Cms.ContentData contentData, CmsEventArgs eventArgs)
        {
            var tagger = new BusinessLogic.Content.ContentTagger();
            if (!tagger.HasTags(contentData.Id))
            {
                var alchemyManager = new Alchemy.Concepts.ContentTagging();
                var tagResults = alchemyManager.GetAlchemyConceptTags(contentData);
                tagger.TagContent(contentData.Id, tagResults);
            }
        }
    }
}
