using System;
using Sitecore.Diagnostics;
using Sitecore.Rules.Conditions;

namespace Community.Foundation.PlaceholderRules.Rules.Conditions
{
    public class PlaceholderPath<T> : StringOperatorCondition<T> where T : PlaceholderRenderingsRuleContext
    {
        public string Value { get; set; }

        protected override bool Execute(T ruleContext)
        {
            Assert.ArgumentNotNull((object) ruleContext, "ruleContext");
            var path = ruleContext.PlaceholderKey;

            if (String.IsNullOrEmpty(path))
                return false;

            return Compare(path, Value);

        }

    }
}