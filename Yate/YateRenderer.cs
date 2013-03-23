using System;
using System.IO;
using Common.Logging;
using Yate.Parsing;

namespace Yate
{
    public class YateRenderer
    {
        private readonly ILog _log = LogManager.GetCurrentClassLogger();
        private readonly IViewBuilder _viewBuilder;

        public YateRenderer()
            : this(new ViewBuilder(new FileFetcher()))
        {
        }

        public YateRenderer(IViewBuilder viewBuilder)
        {
            if (viewBuilder == null)
            {
                throw new ArgumentNullException("viewBuilder");
            }

            _log.Debug("Building YateRenderer");

            _viewBuilder = viewBuilder;
        }

        public string Render(string filepath, object model)
        {
            using (var stringWriter = new StringWriter())
            {
                WriteToTextWriter(filepath, stringWriter, model);
                return stringWriter.ToString();
            }
        }

        public void WriteToTextWriter(string filepath, TextWriter textWriter, object model)
        {
            //todo: some crazy cacheing layer.
            var view = _viewBuilder.Build(filepath);
            view.WriteToTextWriter(textWriter, new YateDataContext(model));
        }
    }
}
