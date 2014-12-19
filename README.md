Ektron Auto Tagger
================

Uses an integration with Alchemy API to automatically tag CMS content as it's created or updated.

Sign up for your own account at: http://www.alchemyapi.com/

This is a sample containing two content strategies. The first strategy is a hook into the *OnAfterContentCreated* event and the second is a hook into *OnBeforeContentUpdated* event.

When either of these events fires, it checks the content for any Tags that may already be applied. If tags are already applied, then the content is not processed.

If no Tags are applied to the content, then the content HTML or XML value is stripped of markup and the first 50,000 characters (limitation set by Alchemy API) are sent via a POST web request to the Alchemy Concepts API to retrieve the top 8 concepts extracted from the content.

The returned concepts are not in a format that is friendly for Ektron Tags, which disallows spaces and other special characters. Each tag is cleaned using a whitelist regular expression and then added to the Ektron CMS before applying each added tag to the content being edited.

This code is intended as a sample and starting point for additional natural language processing strategies.

Feedback and revisions are welcome!
