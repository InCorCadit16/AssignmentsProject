using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Assignment18
{
    class Connector : IConnector
    {
        string currentConnection;

        public void Connect(string url)
        {
            currentConnection = url;
            Console.WriteLine($"Connecting to {url}");
        }

        public void Reload()
        {
            if (string.IsNullOrEmpty(currentConnection))
                Console.WriteLine($"Reloading {currentConnection}");
        }
    }

    class ConnectorProxy : IConnector
    {
        string[] blockedUrls;
        Connector connector;
        public ConnectorProxy(params string[] blockedUrls)
        {
            connector = new Connector();
            this.blockedUrls = blockedUrls;
        }

        public void Connect(string url)
        {
            try
            {

            
            foreach (var blocked in blockedUrls)
            {
                if (blocked == url) throw new Exception("Required url is blocked");
            }

            if (string.IsNullOrEmpty(url))
                throw new Exception("Required url is a null string or empty string");

            connector.Connect(url);
            } catch (Exception e)
            {
                Debugger.Log(Debug.IndentLevel, Debugger.DefaultCategory, e.Message);
            }
        }

        public void Reload()
        {
            connector.Reload();
        }
    }
}
