﻿using System;
using System.Collections.Generic;
using System.Linq;
using Composite.Data;
using Composite.Core.Types;
using Composite.Core.Xml;


namespace Composite.Core.WebClient.Renderings.Data
{
    /// <summary>    
    /// </summary>
    /// <exclude />
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)] 
	public static class DataXhtmlRenderingServices
	{
        /// <exclude />
        public static bool CanRender(Type dataTypeToRender, XhtmlRenderingType renderingType)
        {
            IEnumerable<XhtmlRendererProviderAttribute> rendererAttributes = dataTypeToRender.GetCustomInterfaceAttributes<XhtmlRendererProviderAttribute>();
            return rendererAttributes.Any(f => f.SupportedRenderingType == renderingType);
        }


        /// <exclude />
        public static XhtmlDocument Render(IDataReference dataToRender, XhtmlRenderingType renderingType)
        {
            Type dataTypeToRender = dataToRender.ReferencedType;
            IEnumerable<XhtmlRendererProviderAttribute> rendererAttributes = dataTypeToRender.GetCustomInterfaceAttributes<XhtmlRendererProviderAttribute>();

            XhtmlRendererProviderAttribute rendererAttribute = rendererAttributes.FirstOrDefault(f => f.SupportedRenderingType == renderingType);

            if (rendererAttribute == null) throw new NotImplementedException(string.Format("No '{0}' xhtml renderer found for type '{1}'",renderingType, dataTypeToRender.FullName));

            IDataXhtmlRenderer renderer = rendererAttribute.BuildRenderer();

            return renderer.Render(dataToRender);
        }
	}
}
