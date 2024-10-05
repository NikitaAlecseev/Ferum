using Microsoft.Win32;
using NetFwTypeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerumClient.Core
{
    public class CheckPermission
    {
        public static void checkAndSetPermission()
        {
            string path = Environment.CurrentDirectory + "\\FerumClient.exe";
            AddFirewallRule(path);
        }

        static void AddFirewallRule(string applicationPath)
        {
            try
            {
                INetFwRule firewallRule = (INetFwRule)Activator.CreateInstance(
        Type.GetTypeFromProgID("HNetCfg.FWRule"));

                INetFwPolicy2 firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(
                    Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));

                firewallRule.ApplicationName = applicationPath;

                firewallRule.Action = NET_FW_ACTION_.NET_FW_ACTION_ALLOW;
                firewallRule.Description = " My Windows Firewall Rule";
                firewallRule.Enabled = true;
                firewallRule.InterfaceTypes = "All";
                firewallRule.Name = "Access to FerumAgent";

                // Проверка на существование правила
                foreach (INetFwRule rule in firewallPolicy.Rules)
                {
                    if (rule.Name == firewallRule.Name)
                    {
                        return; // Правило уже существует
                    }
                }

                // Should really check that rule is not already present before add in
                firewallPolicy.Rules.Add(firewallRule);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка: " + ex.Message);
            }
        }
    }
}
