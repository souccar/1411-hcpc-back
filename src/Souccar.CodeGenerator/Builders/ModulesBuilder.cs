using System.Reflection;

namespace Souccar.CodeGenerator
{
    internal class ModulesBuilder
    {

        public static void Generate(Assembly assembly, string moduleName)
        {
            Console.WriteLine($"Module : {moduleName}");

            var entities = assembly.GetTypes()
                .Where(t => t.Namespace.Contains($"{GeneralSetting.ProjectName}.{moduleName}")
                && t.BaseType != null
                && ( t.BaseType !=null
                && t.BaseType.FullName.Contains("Entity") || t.BaseType.FullName.Contains("FullAuditedAggregateRoot"))
                && t.Name =="Test"
                && t.IsClass == true).ToList();


            if (entities.Any())
            {
                foreach (var entity in entities)
                {
                    ApplicationBuilder.Generate(entity);
                    DomainBuilder.Generate(entity);
                    LocalizationBuilder.Generate(assembly, moduleName);
                }
            }

            //var entity = typeof(Unit);
            //DomainBuilder.Genetate(entity);
            //ApplicationBuilder.Genetate(entity);
        }
    }
}
