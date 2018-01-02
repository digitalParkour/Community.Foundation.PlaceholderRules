using System;
using System.Linq;
using Community.Foundation.PlaceholderRules.Rules;
using Sitecore;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Pipelines.GetPlaceholderRenderings;
using Sitecore.Rules;
using Sitecore.SecurityModel;

namespace Community.Foundation.PlaceholderRules.Pipelines.GetPlaceholderRenderings
{
    /// <summary>
    /// Upload has finished.
    /// </summary>
    public class RunRules
    {
        private const String PlaceholderRulesRootId = "{D50A3251-93D3-4FD2-958D-E12F4BE682CF}";
        /// <summary>
        /// Runs the processor.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public void Process(GetPlaceholderRenderingsArgs args)
        {
            Assert.ArgumentNotNull(args, "args");
            Item root;
            Item placeholderItem = null;

            // Set root
            using (new SecurityDisabler())
            {
                root = args.ContentDatabase.GetItem(PlaceholderRulesRootId);
                if (root == null)
                    return; // no root, exit
            }

            // Set placeholder item
            if (ID.IsNullOrEmpty(args.DeviceId))
            {
                placeholderItem = Client.Page.GetPlaceholderItem(args.PlaceholderKey, args.ContentDatabase, args.LayoutDefinition);
            }
            else
            {
                using (new DeviceSwitcher(args.DeviceId, args.ContentDatabase))
                    placeholderItem = Client.Page.GetPlaceholderItem(args.PlaceholderKey, args.ContentDatabase, args.LayoutDefinition);
            }

            // Define context
            var ruleContext = new PlaceholderRenderingsRuleContext()
            {
                Item = placeholderItem,
                AllowedRenderingItems = args.PlaceholderRenderings,
                DeviceId = args.DeviceId,
                PlaceholderKey = args.PlaceholderKey,
                ContentDatabase = args.ContentDatabase,
                LayoutDefinition = args.LayoutDefinition
            };
            
            // Run rules
            RuleList<PlaceholderRenderingsRuleContext> rules = RuleFactory.GetRules<PlaceholderRenderingsRuleContext>(root, "Rule");
            if (rules != null)
            {
                rules.Run(ruleContext);
            }

            if (ruleContext.AllowedRenderingItems != null)
                args.PlaceholderRenderings = ruleContext.AllowedRenderingItems.ToList();
        }
    }
}