using System;
using System.Collections;
using CsQuery;

namespace Yate.Sheets.Properties
{
    internal class ApplyPatternProperty : IProperty
    {
        private readonly IValue _model;
        private readonly IValue _patternName;

        public ApplyPatternProperty(IValue patternName, IValue model)
        {
            if (patternName == null)
            {
                throw new ArgumentNullException("patternName");
            }
            if (model == null)
            {
                throw new ArgumentNullException("model");
            }

            _patternName = patternName;
            _model = model;
        }

        public void Render(CQ html, string selector, IYateDataContext dataContext)
        {
            var domObjects = html.Select(selector);
            var pattern = dataContext.PatternContainer[_patternName.GetValue(dataContext).ToString()];
            var model = _model.GetValue(dataContext);

            if (model is ICollection)
            {
                var enumModels = model as ICollection;

                foreach (var enumModel in enumModels)
                {
                    RunPattern(dataContext, enumModel, domObjects, pattern);
                }
            }
            else
            {
                RunPattern(dataContext, model, domObjects, pattern);
            }
        }

        private static void RunPattern(IYateDataContext dataContext, object model, CQ domObjects, IPattern pattern)
        {
            //try/finally leaves the data context in the same state as when we started with it hopefully.
            try
            {
                dataContext.PushValue(model);

                foreach (var domObject in domObjects)
                {
                    var htmlFragment = CQ.CreateFragment(pattern.HtmlFragment);

                    foreach (var atRule in pattern.AtRules)
                    {
                        atRule.Render(htmlFragment, dataContext);
                    }

                    foreach (var ruleSet in pattern.RuleSets)
                    {
                        ruleSet.Render(htmlFragment, dataContext);
                    }

                    //append those mama jammas
                    foreach(var frag in htmlFragment)
                    {
                        domObject.AppendChild(frag);
                    }
                }
            }
            finally
            {
                dataContext.PopValue();
            }
        }
    }
}