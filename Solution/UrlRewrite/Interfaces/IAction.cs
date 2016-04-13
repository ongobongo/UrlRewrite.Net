﻿using System.Web;
using System.Xml.Linq;

namespace UrlRewrite.Interfaces
{
    public interface IAction: IRuleElement
    {
        IAction Initialize(XElement configuration);

        /// <summary>
        /// Performs the redirection, rewrite or whatever action is required
        /// when the rule matches the incomming request
        /// </summary>
        void PerformAction(
            IRequestInfo request, 
            IRuleResult ruleResult, 
            out bool stopProcessing, 
            out bool endRequest);
    }
}
