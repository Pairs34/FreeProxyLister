using System;
using System.Collections.Generic;
using System.IO;
using HtmlAgilityPack;

namespace ProxyFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "https://free-proxy-list.net/";
            var web = new HtmlWeb();
            var doc = web.Load(url);
            var table = doc.DocumentNode.SelectSingleNode("//table[@id='proxylisttable']");
            var allIp = table.SelectNodes("tbody/tr/td[1]");
            var allPorts = table.SelectNodes("tbody/tr/td[2]");

            List<string> proxies = new List<string>();

            for(int i = 0;i <= allIp.Count -1;i++)
            {
                proxies.Add(allIp[i].InnerText + ":" + allPorts[i].InnerText);
            }

            File.WriteAllLines($"{AppDomain.CurrentDomain.BaseDirectory}/proxies.txt",proxies.ToArray());
        }
    }
}
