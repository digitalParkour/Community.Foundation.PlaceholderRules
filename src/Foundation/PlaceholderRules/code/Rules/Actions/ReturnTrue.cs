namespace SiteDeck.Essentials.InsertRules.Rules.Actions
{
    public class ReturnTrue<T> : Sitecore.Rules.Actions.RuleAction<T>
      where T : Sitecore.ContentSearch.Boosting.RuleBoostingContext
    { 
        
        public override void Apply(
          T ruleContext)
        {
            ruleContext.Parameters.Add("result", true);
            // After running check for..
            // var result = ruleContext.Parameters.ContainsKey("result") && (Boolean)ruleContext.Parameters["result"];
        }
    }
}

