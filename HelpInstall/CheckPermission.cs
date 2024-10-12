using System;
using NetFwTypeLib;
using System;

namespace HelpInstall
{
    internal class CheckPermission
    {
        public static void checkAndSetPermission(string _path)
        {
            string path = _path + "\\FerumClient.exe";
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

        public static void DeleteFirewallRule()
        {
            try
            {
                INetFwPolicy2 firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(
                    Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));

                firewallPolicy.Rules.Remove("Access to FerumAgent");
                Console.WriteLine("правило в Firewall удален!");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка: " + ex.Message);
            }
        }
    }
}
