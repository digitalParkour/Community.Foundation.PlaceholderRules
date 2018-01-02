using System;
using System.Collections.Generic;
using System.Linq;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Rules.Actions;

namespace Community.Foundation.PlaceholderRules.Rules.Actions
{
    public class AddPlaceHolderRendering<T> : RuleAction<T> where T : PlaceholderRenderingsRuleContext
    {
        public String RenderingId { get; set; }

        public override void Apply(T ruleContext)
        {
            var renderingId = new ID(RenderingId);

            // Create a new list if one hasn't been created yet.
            if (ruleContext.AllowedRenderingItems == null)
                ruleContext.AllowedRenderingItems = new List<Item>();

            // If the sublayout is already in the context, do nothing.
            if (ruleContext.AllowedRenderingItems.Any(i => i.ID == renderingId))
                return;

            // Add the rendering to the context.
            ruleContext.AllowedRenderingItems.Add(ruleContext.Item.Database.GetItem(renderingId));
        }
    }
}

