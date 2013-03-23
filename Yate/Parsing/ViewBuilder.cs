using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BoneSoft.CSS;
using Common.Logging;
using CsQuery;
using Yate.Sheets;
using Yate.Sheets.AtRules;
using Yate.Sheets.Properties;
using Yate.Sheets.Values;
using RuleSet = Yate.Sheets.RuleSet;

namespace Yate.Parsing
{
    public class ViewBuilder : IViewBuilder
    {
        private readonly IFileFetcher _fileFetcher;
        private readonly ILog _log = LogManager.GetCurrentClassLogger();
        //todo: This seems like it should be interfaced out 
        private readonly CSSParser _cssParser = new CSSParser();
        private readonly IDictionary<string, IPropertyBuilder<IProperty>> _propertyBuilderTable;
        private readonly IDictionary<string, IFunctionValueBuilder<IFunctionValue>> _valueBuilderTable;
        private readonly IDictionary<string, IAtRuleBuilder<IAtRule>> _atRuleBuilders;

        public ViewBuilder(IFileFetcher fileFetcher)
        {
            if (fileFetcher == null)
            {
                _log.Error("No fileFetcher given to ParsedView.");
                throw new ArgumentNullException("fileFetcher");
            }

            _fileFetcher = fileFetcher;

            _propertyBuilderTable = new Dictionary<string, IPropertyBuilder<IProperty>>();
            _valueBuilderTable = new Dictionary<string, IFunctionValueBuilder<IFunctionValue>>();
            _atRuleBuilders = new Dictionary<string, IAtRuleBuilder<IAtRule>>();

            AddPropertyBuilder("apply-pattern",new ApplyPatternPropertyBuilder());
            AddPropertyBuilder("text", new TextPropertyBuilder());
            AddPropertyBuilder("format-text", new FormatTextPropertyBuilder());
            AddPropertyBuilder("attr", new AttributePropertyBuilder());
            AddPropertyBuilder("html", new HtmlPropertyBuilder());

            AddValueBuilder("if", new IfFunctionValueBuilder());
            AddValueBuilder("concat", new ConcatFunctionValueBuilder());
            AddValueBuilder("true", new TrueFunctionValueBuilder());
            AddValueBuilder("false", new FalseFunctionValueBuilder());
            AddValueBuilder("model", new ModelFunctionValueBuilder());

            AddAtRuleBuilder("@pattern", new PatternAtRuleBuilder());
            AddAtRuleBuilder("@if", new IfAtRuleBuilder());
        }

        public void AddAtRuleBuilder(string keyword, IAtRuleBuilder<IAtRule> atRuleBuilder)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                throw new ArgumentNullException("keyword");
            }
            if (atRuleBuilder == null)
            {
                throw new ArgumentNullException("atRuleBuilder");
            }

            _atRuleBuilders.Add(keyword, atRuleBuilder);
        }

        public void AddValueBuilder(string keyword, IFunctionValueBuilder<IFunctionValue> value)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                throw new ArgumentNullException("keyword");
            }
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            _valueBuilderTable.Add(keyword, value);
        }

        public void AddPropertyBuilder(string keyword, IPropertyBuilder<IProperty> propertyBuilder)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                throw new ArgumentNullException("keyword");
            }
            if (propertyBuilder == null)
            {
                throw new ArgumentNullException("propertyBuilder");
            }

            _propertyBuilderTable.Add(keyword, propertyBuilder);
        }

        public IParsedView Build(string filepath)
        {
            if (string.IsNullOrWhiteSpace(filepath))
            {
                _log.Error("filepath was not given.");
                throw new ArgumentNullException("filepath");
            }

            var dom = CQ.Create(_fileFetcher.GetText(filepath));

            //get all YateScripts out and combine
            var combinedScripts = new StringBuilder();

            var scriptTags = dom.Select("script[type='text/yate']");

            foreach (var scriptTag in scriptTags)
            {
                var srcAttributeValue = scriptTag.GetAttribute("src");
                if (!string.IsNullOrWhiteSpace(srcAttributeValue))
                {
                    combinedScripts.Append(_fileFetcher.GetText(srcAttributeValue));
                }
                else
                {
                    combinedScripts.Append(scriptTag.InnerHTML);
                }
            }

            dom.Select("script[type='text/yate']").Remove();

            //todo: we would have to sort the css to be more css like.
            var css = _cssParser.ParseText(combinedScripts.ToString());

            var view = new ParsedView(dom);

            BuildBlock(view, css.Directives, css.RuleSets);

            return view;
        }

        private void BuildBlock(
            IBlockStructure block,
            IEnumerable<Directive> directives,
            IEnumerable<BoneSoft.CSS.RuleSet> ruleSets)
        {
            foreach (var directive in directives)
            {
                var atRule = _atRuleBuilders[directive.Name].Build(directive.Expression.Terms.Select(HandleValue).ToList());

                BuildBlock(atRule, directive.Directives, directive.RuleSets);

                block.AtRules.Add(atRule);
            }

            foreach (var sheetRuleSet in ruleSets)
            {
                var ruleSet = new RuleSet(sheetRuleSet.Selectors.Select(s => s.ToString()).ToList());

                foreach (var sheetDeclaration in sheetRuleSet.Declarations)
                {
                    var declaration = BuildProperties(sheetDeclaration);

                    if (declaration != null)
                    {
                        ruleSet.Properties.Add(declaration);
                    }
                }

                if (ruleSet.Properties.Count() != 0 && ruleSet.Selectors.Count != 0)
                {
                    block.RuleSets.Add(ruleSet);
                }
            }
        }

        private IProperty BuildProperties(Declaration sheetDeclaration)
        {
            IProperty retVal = null;

            var builder = _propertyBuilderTable[sheetDeclaration.Name];

            if (builder != null)
            {
                retVal = builder.Build(sheetDeclaration.Expression.Terms.Select(HandleValue).ToList());
            }

            return retVal;
        }


        private IValue HandleValue(Term term)
        {
            return term.Function != null ? HandleFunctionValue(term.Function) : new StringValue(term.Value);
        }

        private IValue HandleFunctionValue(Function function)
        {
            IValue retVal = null;

            var builder = _valueBuilderTable[function.Name];

            if (builder != null)
            {
                retVal = builder.Build(function.Expression.Terms.Select(HandleValue).ToList());
            }

            return retVal;
        }
    }
}