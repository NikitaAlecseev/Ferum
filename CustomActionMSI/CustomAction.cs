using Microsoft.Deployment.WindowsInstaller;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CustomActionMSI
{
    public class CustomActions
    {
        [CustomAction]
        public static ActionResult AddStartUp(Session session)
        {
            try
            {
                string filePath = Path.Combine("C:\\Debug\\", "Result.txt");
                string res = session.CustomActionData["TARGETDIR"];

                // Создание файла в папке установки 
                File.WriteAllText(filePath, $"Список ключей CustomActionData:\n{res}");

                return ActionResult.Success;
            }
            catch (Exception ex)
            {
                session.Log($"Ошибка: {ex.Message}");
                string filePath = Path.Combine("C:\\Debug\\", "ErrorInstall.txt");
                File.WriteAllText(filePath, $"Ошибка (v1.6): {ex.Message}");
                return ActionResult.Failure;
            }
        }
    }
}
