﻿using System;
using System.Collections.Generic;
using System.Web;

namespace UrlRewrite.Interfaces
{
    public interface IRequestInfo
    {
        // Initialization
        IRequestInfo Initialize(HttpApplication application, ILog log);

        // Contextual properties
        HttpApplication Application { get; }
        HttpContext Context { get; }
        IRequestLog Log { get; }
        ExecutionMode ExecutionMode { get; set; }
        IList<Action<IRequestInfo>> DeferredActions { get; }

        // Information parsed from the incomming request
        string OriginalUrlString { get; }
        string OriginalPathString { get; }
        IList<string> OriginalPath { get; }
        string OriginalParametersString { get; }
        IDictionary<string, IList<string>> OriginalParameters { get; }

        // Control over the rewritten/redirected URL
        string NewUrlString { get; set; }
        string NewPathString { get; set; }
        string NewParametersString { get; set; }
        IList<string> NewPath { get; set; }
        IDictionary<string, IList<string>> NewParameters { get; set; }

        // Change notification
        void PathChanged();
        void ParametersChanged();
        void ExecuteDeferredActions();

        // Interaction with the request - these are here to enable unit testing
        string GetOriginalServerVariable(string name);
        string GetOriginalHeader(string name);
        string GetServerVariable(string name);
        string GetHeader(string name);
        void SetServerVariable(string name, string value);
        void SetHeader(string name, string value);
    }
}
