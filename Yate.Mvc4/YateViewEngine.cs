using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Yate.Parsing;

namespace Yate.Mvc4
{
    public class YateViewEngine : VirtualPathProviderViewEngine
    {
        private readonly IViewBuilder _viewBuilder;

        public YateViewEngine()
            : this(new ViewBuilder(new FileFetcher()))
        {
        }

        public YateViewEngine(IViewBuilder viewBuilder)
        {
            if (viewBuilder == null)
            {
                throw new ArgumentNullException("viewBuilder");
            }

            _viewBuilder = viewBuilder;

            FileExtensions = new[] { "html", "htm" };

            MasterLocationFormats = BuildFileLocations(new[]
                {
                    "~/Views/{1}/{0}.",
                    "~/Views/Shared/{0}."
                }, FileExtensions);
            ViewLocationFormats = BuildFileLocations(new[]
                {                    
                    "~/Views/{1}/{0}.",
                    "~/Views/Shared/{0}."
                }, FileExtensions);
            PartialViewLocationFormats = BuildFileLocations(new[]
                {
                    "~/Views/{1}/{0}.",
                    "~/Views/Shared/{0}."
                }, FileExtensions);
            AreaMasterLocationFormats = BuildFileLocations(new[]
                {
                    "~/Areas/{2}/Views/{1}/{0}.",
                    "~/Areas/{2}/Views/Shared/{0}."
                }, FileExtensions);
            AreaViewLocationFormats = BuildFileLocations(new[]
                {
                    "~/Areas/{2}/Views/{1}/{0}.",
                    "~/Areas/{2}/Views/Shared/{0}." 
                }, FileExtensions);
            AreaPartialViewLocationFormats = BuildFileLocations(new[]
                {
                    "~/Areas/{2}/Views/{1}/{0}.",
                    "~/Areas/{2}/Views/Shared/{0}." 
                }, FileExtensions);
        }

        private static string[] BuildFileLocations(string[] formats, string[] extensions)
        {
            var retVal = new List<string>();

            foreach (var format in formats)
            {
                foreach (var extension in extensions)
                {
                    retVal.Add(format + extension);
                }
            }

            return retVal.ToArray();
        }

        protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)
        {
            return GetView(controllerContext, viewPath, masterPath);
        }

        protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath)
        {
            return GetView(controllerContext, partialPath, null);
        }

        private IView GetView(ControllerContext controllerContext, string viewPath, string masterPath)
        {
            return new YateView(_viewBuilder.Build(viewPath));//this, controllerContext, viewPath, masterPath);
        }
    }
}
