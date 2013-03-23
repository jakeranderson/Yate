using System;
using System.IO;
using System.Web.Mvc;
using Yate.Parsing;

namespace Yate.Mvc4
{
    public class YateView : IView
    {
        private readonly IParsedView _parsedView;

        public YateView(IParsedView parsedView)
        {
            if (parsedView == null)
            {
                throw new ArgumentNullException("parsedView");
            }

            _parsedView = parsedView;
        }

        public void Render(ViewContext viewContext, TextWriter writer)
        {
            if (viewContext == null)
            {
                throw new ArgumentNullException("viewContext");
            }
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }

            _parsedView.WriteToTextWriter(writer, new YateDataContext(viewContext.ViewData.Model));
        }
    }
}