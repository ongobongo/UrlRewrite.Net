﻿using System.IO;
using System.Xml.Linq;
using UrlRewrite.Interfaces;

namespace UrlRewrite.Actions
{
    internal abstract class Action: IAction
    {
        protected bool _stopProcessing;
        protected bool _endRequest;

        public abstract void PerformAction(
            IRequestInfo request, 
            IRuleResult ruleResult, 
            out bool stopProcessing,
            out bool endRequest);

        public abstract string ToString(IRequestInfo requestInfo);

        public virtual IAction Initialize(XElement configuration)
        {
            return this;
        }

        public virtual void Describe(TextWriter writer, string indent, string indentText)
        {
            writer.WriteLine(indent + ToString());
        }
    }
}
