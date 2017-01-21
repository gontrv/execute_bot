using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChangerProxy;
using System.IO;
using System.Xml.Linq;
using System.Diagnostics;
using System.Net;
using ExplorerByChrome;

namespace ExecuteBot
{
    class BotExecuter
    {
        const string PATH_TO_RAW_PROXY = @".\raw_proxy.txt";
        List<string> _rawProxyList = null;
        ChangerProxy.ChangerProxy changerProxy = new ChangerProxy.ChangerProxy();
        int _executeNumber;
        string _currentProxy = "";
        Process _chrome = null;

        public BotExecuter(int countOfProxyToExecute)
        {
            _executeNumber = countOfProxyToExecute;
        }

        public void ExecuteBot()
        {
            if (FillRawProxyList())
            {
                for (int i = 0; i < _executeNumber; i++)
                {
                    _currentProxy = _rawProxyList[i];
                    if (changerProxy.IsProxyValid(_currentProxy))
                    {
                        changerProxy.ChangeProxySettings(_currentProxy);
                        _chrome = Process.Start("Chrome.exe");
                        _chrome.WaitForExit();
                        DeleteChromeData();
                    }
                }
            }
        }

        public bool FillRawProxyList()
        {
            if (File.Exists(PATH_TO_RAW_PROXY))
            {
                _rawProxyList = new List<string>(File.ReadAllLines(PATH_TO_RAW_PROXY));
                return true;
            }
            return false;
        }

        private void DeleteChromeData()
        {

        }
    }
}
