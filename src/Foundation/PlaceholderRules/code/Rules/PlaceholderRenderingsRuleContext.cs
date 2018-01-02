using System.Collections.Generic;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Rules;

namespace Community.Foundation.PlaceholderRules.Rules
{
    public class PlaceholderRenderingsRuleContext : RuleContext
    {
        public List<Item> AllowedRenderingItems { get; set; }
        public ID DeviceId { get; set; }
        public string PlaceholderKey { get; set; }
        public Database ContentDatabase { get; set; }
        public string LayoutDefinition { get; set; }
    }
}