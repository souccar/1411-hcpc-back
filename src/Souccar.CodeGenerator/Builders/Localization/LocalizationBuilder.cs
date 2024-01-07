﻿using System.Reflection;
using System.Xml;

namespace Souccar.CodeGenerator
{
    public class LocalizationBuilder
    {
        public static void Generate(Assembly assembly, string moduleName)
        {
            Console.WriteLine($"Module : {moduleName}");
            var entities = assembly.GetTypes()
               .Where(t => t.Namespace.Contains($"{GeneralSetting.ProjectName}.{moduleName}")
               && t.BaseType != null
               && (t.BaseType != null
               && t.BaseType.FullName.Contains("Entity") || t.BaseType.FullName.Contains("FullAuditedAggregateRoot"))
               && t.Name == "Test"
               && t.IsClass == true).ToList();

            var list = new List<string>();

            if (entities.Any())
            {
                foreach (var entity in entities)
                {
                    GenerateLocalization(entity, list);
                }
            }

            var items = assembly.GetTypes()
                .Where(t => t.Namespace.Contains($"{GeneralSetting.ProjectName}.{moduleName}")
                && t.IsEnum == true).ToList();

            if (items.Any())
            {
                foreach (var item in items)
                {
                    GenerateLocalization(item, list);
                }
            }

            Save(list);
        }

        private static void GenerateLocalization(Type entity, List<string> list)
        {
            //var text = $"<text name=\"{entity.Name}\">{entity.Name}</text>";
            if (!list.Contains(entity.Name))
            {
                list.Add(entity.Name);
                list.Add(entity.Name.Plural());
                list.Add($"CreateNew{entity.Name}");
                list.Add($"Edit{entity.Name}");
                list.Add($"Delete{entity.Name}");
            }

            foreach (var prop in entity.GetProperties())
            {
                //var propText = $"<text name=\"{prop.Name}\">{prop.Name}</text>";
                if (!list.Contains(prop.Name))
                    list.Add(prop.Name);
            }
        }

        private static void Save(List<string> list)
        {
            var document = new XmlDocument();
            document.Load($"{GeneralSetting.ProjectDomainPath}\\Localization\\SourceFiles\\{GeneralSetting.LocalizationFile}");
            var nodes = document.GetElementsByTagName("texts");
            if (nodes != null && nodes.Count > 0)
            {
                var childNodes = nodes[0].ChildNodes;
                foreach (var item in list)
                {
                    var array = item.Split("Id");
                    var str = array[0];

                    if (!string.IsNullOrEmpty(str) && !CheckIfExist(str, childNodes))
                    {
                        Console.WriteLine($" == {str} == ");
                        var ele = document.CreateElement("text");
                        ele.InnerText = str.GetRealText();
                        var attr = document.CreateAttribute("name");
                        attr.Value = str;
                        ele.Attributes.Append(attr);
                        nodes[0].AppendChild(ele);
                    }
                }
            }
            document.Save($"{GeneralSetting.ProjectDomainPath}\\Localization\\SourceFiles\\{GeneralSetting.LocalizationFile}");
        }

        private static bool CheckIfExist(string text, XmlNodeList childNodes)
        {
            
                for (var i = 0; i < childNodes.Count; i++)
                {
                    var value = childNodes[i].Attributes["name"].InnerText;
                    if (value == text)
                    {
                        return true;
                    }
                }
            
            return false;
        }
    }
}
