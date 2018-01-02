using System;
using Sitecore.Diagnostics;
using Sitecore.Rules.Conditions;

namespace Community.Foundation.PlaceholderRules.Rules.Conditions
{
    public class PlaceholderKey<T> : StringOperatorCondition<T> where T : PlaceholderRenderingsRuleContext
    {
        public string Value { get; set; }

        protected override bool Execute(T ruleContext)
        {
            Assert.ArgumentNotNull((object) ruleContext, "ruleContext");
            if (ruleContext.Item == null)
                return false;

            var key = ruleContext.Item["Placeholder Key"];
            if (String.IsNullOrEmpty(key))
                return false;

            return Compare(key, Value);

        }

    }
}