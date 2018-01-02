using System;
using System.Linq;
using Sitecore.Data;
using Sitecore.Rules.Actions;

namespace Community.Foundation.PlaceholderRules.Rules.Actions
{
    public class RemovePlaceHolderRendering<T> : RuleAction<T> where T : PlaceholderRenderingsRuleContext
    {
        public String RenderingId { get; set; }

        public override void Apply(T ruleContext)
        {
            var renderingId = new ID(RenderingId);

            // If there are no renderings, do nothing.
            if (ruleContext.AllowedRenderingItems == null) return;

            // If the rendering already isn't in the context, do nothing.
            var item = ruleContext.AllowedRenderingItems.FirstOrDefault(i => i.ID == renderingId);
            if (item == null) return;

            // Remove the sublayout from the context.
            ruleContext.AllowedRenderingItems.Remove(item);
        }
    }
}

