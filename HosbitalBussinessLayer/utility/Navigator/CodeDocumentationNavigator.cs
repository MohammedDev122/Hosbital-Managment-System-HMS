using System;
using Documentationattribute;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text;
namespace HosbitalBussinessLayer.utility.Navigator
{
    static public class CodeDocumentationNavigator
    {
        static string _FilePath = "C:\\Users\\Win -11\\source\\repos\\HosbitalBussinessLayer\\Documentation\\Doc.txt";
        static string GetParameterList(ParameterInfo[] parameters)
        {
            return string.Join(", ", parameters.Select(parameter => $"{parameter.ParameterType.Name} {parameter.Name}"));
        }
        static string IdentifyModifier(MethodInfo Method)
        {
            if (Method.IsStatic)
            {
                if (Method.IsPublic)
                {

                    return "Static Public";
                }
                else if (Method.IsFamily)
                {
                    if (Method.IsVirtual)
                    {
                        return "Static virtual Protected";

                    }

                    return "Static Protected";
                }
                else
                {

                    return "Static Private";

                }
            }
            else
            {
                if (Method.IsPublic)
                {

                    return "Public";
                }
                else if (Method.IsFamily)
                {
                    if (Method.IsVirtual)
                    {
                        return "virtual Protected";

                    }
                    return "Protected";
                }
                else
                {

                    return "Private";

                }





            }
        }
        static string IdentifyModifier(FieldInfo Field)
        {
            if (Field.IsStatic)
            {
                if (Field.IsPublic)
                {

                    return "Static Public";
                }
                else if (Field.IsFamily)
                {


                    return "Static Protected";
                }
                else
                {

                    return "Static Private";

                }
            }
            else
            {
                if (Field.IsPublic)
                {

                    return "Public";
                }
                else if (Field.IsFamily)
                {

                    return "Protected";
                }
                else
                {

                    return "Private";

                }





            }
        }
        static string IdentifyModifier(ConstructorInfo Constructor)
        {

            if (Constructor.IsPublic)
            {

                return "Public";
            }
            else if (Constructor.IsFamily)
            {

                return "Protected";
            }
            else
            {

                return "Private";

            }






        }
        static StringBuilder GetBaseConstructor(Type ClassType)
        {
            StringBuilder BaseConstructor= new StringBuilder();

            if (ClassType.BaseType != null)
            {

                var Base = ClassType.BaseType.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);

                if (Base.Length != 0)
                    BaseConstructor.Append($"\t :{ClassType.BaseType.Name}({GetParameterList(Base[0].GetParameters())})\n");


            }
            return BaseConstructor;
        }
        static StringBuilder GetConstructors(Type ClassType)
        {
            StringBuilder BaseConstructor = new StringBuilder();
            BaseConstructor = GetBaseConstructor(ClassType);

            StringBuilder AllConstructors = new StringBuilder();


            var ClassConstructors = ClassType.GetConstructors(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);


            foreach (var Constructor in ClassConstructors)
            {

                AllConstructors.Append($"\t{IdentifyModifier(Constructor)}  {ClassType.Name}({GetParameterList(Constructor.GetParameters())})");
                if (!string.IsNullOrWhiteSpace(Convert.ToString(BaseConstructor)))
                {
                    if (Constructor.IsPublic)
                    {
                        AllConstructors.Append(":Base()\n");
                    }
                    else
                    {
                        AllConstructors.Append(BaseConstructor);
                    }

                }
                else
                {
                    AllConstructors.Append("\n");
                }
     

                    object[] Attr = Constructor.GetCustomAttributes(typeof(DocumentationAttribute),false);
                   foreach(DocumentationAttribute attribute in Attr)
                    {
                        AllConstructors.Append(attribute.Description+"\n");
                    }




                

            }







            return AllConstructors;
        }
        static StringBuilder GetMethods(Type ClassType)
        {
            var ClassMethods = ClassType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static).Where(m => !m.IsSpecialName && m.DeclaringType == ClassType);

            StringBuilder AllMethods = new StringBuilder();
            foreach (var method in ClassMethods)
            {
                AllMethods.Append($"\t{IdentifyModifier(method)} {method.ReturnType.Name} {method.Name}({GetParameterList(method.GetParameters())})\n");
                object[] Attr = method.GetCustomAttributes(typeof(DocumentationAttribute), false);
                foreach(DocumentationAttribute attribute in Attr)
                {
                    AllMethods.Append(attribute.Description + "\n");
                }
            }

            return AllMethods;

        }
        static StringBuilder GetProps(Type ClassType)
        {
            var classProps = ClassType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static).Where(m => m.IsSpecialName && m.DeclaringType == ClassType);
            StringBuilder AllProps = new StringBuilder();

            foreach (var Prop in classProps)
            {
                AllProps.Append($"\t{IdentifyModifier(Prop)}  {Prop.ReturnType.Name} {Prop.Name}\n");
                object[] Attr = Prop.GetCustomAttributes(typeof(DocumentationAttribute), false);
                foreach (DocumentationAttribute attribute in Attr)
                {
                    AllProps.Append(attribute.Description + "\n");
                }
            }
            return AllProps;

        }
        static StringBuilder GetFields(Type ClassType)
        {
            var classFileds = ClassType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).Where(m => !m.IsDefined(typeof(CompilerGeneratedAttribute), true));
            StringBuilder AllFields = new StringBuilder();
            foreach (var field in classFileds)
            {
                AllFields.Append($"\t{IdentifyModifier(field)}  {field.FieldType.Name} {field.Name}\n");
                object[] Attr = field.GetCustomAttributes(typeof(DocumentationAttribute), false);
                foreach (DocumentationAttribute attribute in Attr)
                {
                    AllFields.Append(attribute.Description + "\n");
                }
            }

            return AllFields;
        }
        static StringBuilder DoccumentClass(Type Class)
        {
            StringBuilder ClassInfo = new StringBuilder();

            ClassInfo.Append($"\n*******************************************************\n");


            Type ClassType = Class;
            ClassInfo.Append($"                                  {ClassType.Name}                    \n\n");
           
            if (ClassType != null)
            {
                object[] Attr = ClassType.GetCustomAttributes(typeof(DocumentationAttribute), false);
                foreach (DocumentationAttribute attribute in Attr)
                {
                    ClassInfo.Append(attribute.Description + "\n");
                }
                ClassInfo.Append($"\n\nConstructors of the {ClassType.Name} class:\n");
                ClassInfo.Append($"____________\n\n");

                ClassInfo.Append(GetConstructors(ClassType));
                ClassInfo.Append($"\n\nMethods of the {ClassType.Name} class:\n");
                ClassInfo.Append($"____________\n\n");




                ClassInfo.Append(GetMethods(ClassType));
                // Get all public methods of the System.String class

                ClassInfo.Append($"\n\nProps & Fileds of the {ClassType.Name} class:\n");
                ClassInfo.Append($"____________\n\n");

                ClassInfo.Append(GetProps(ClassType));

                ClassInfo.Append(GetFields(ClassType));


            }
            else
            {
                Console.WriteLine($" {ClassType.Name}  type not found.\n");
            }

            return ClassInfo;


        }
        static IEnumerable<Type> _GetAllProjectClasses()
        {




            Assembly asm = Assembly.GetExecutingAssembly();
            var customTypes = asm.GetTypes().Where(t => t.IsClass && !t.Namespace.StartsWith("System"));


            return customTypes;





        }
        private static void _UploadDocomentationDataToFile(string Data, string filename)
        {


            using (File.Create(filename))
            {



            }
            File.WriteAllText(filename, Data);

        }


        static public void DoccumentProject()
        {


            var CustomClasses = _GetAllProjectClasses();
            StringBuilder AllProject =new StringBuilder();
            foreach (var CustomClass in CustomClasses)
            {


                AllProject.Append(DoccumentClass(CustomClass));






            }

            _UploadDocomentationDataToFile(Convert.ToString(AllProject), _FilePath);





        }
    }

    static public class ClassDocumentationNavigator
    {
        static string _FilePath = "C:\\Users\\Win -11\\source\\repos\\HosbitalBussinessLayer\\Documentation\\ClassDoc.txt";
       
    
        static string GetBaseClass(Type ClassType)
        {
            string BaseClass = "";

            if (ClassType.BaseType != null)
            {

                BaseClass = ClassType.BaseType.Name;

             


            }
            return BaseClass;
        }
     
        static string DoccumentClass(Type Class)
        {
            string ClassInfo = "";

            ClassInfo += $"\n*******************************************************\n";


            Type ClassType = Class;
          
          
            if (ClassType != null)
            {
                if (ClassType.BaseType != null&&ClassType.BaseType!=typeof(object))
                {
                    ClassInfo += $"                                  {ClassType.Name}:{GetBaseClass(ClassType)}                    \n\n";

                }
                else
                {
                    ClassInfo += $"                                  {ClassType.Name}                    \n\n";

                }
                object[] Attr = ClassType.GetCustomAttributes(typeof(DocumentationAttribute), false);
                foreach (DocumentationAttribute attribute in Attr)
                {
                    ClassInfo += attribute.Description + "\n";
                }
              

            }
            else
            {
                Console.WriteLine($" {ClassType.Name}  type not found.\n");
            }

            return ClassInfo;


        }
        static IEnumerable<Type> _GetAllProjectClasses()
        {




            Assembly asm = Assembly.GetExecutingAssembly();
            var customTypes = asm.GetTypes().Where(t => t.IsClass && !t.Namespace.StartsWith("System"));


            return customTypes;





        }
        private static void _UploadDocomentationDataToFile(string Data, string filename)
        {


            using (File.Create(filename))
            {



            }
            File.WriteAllText(filename, Data);

        }


        static public void DoccumentProject()
        {


            var CustomClasses = _GetAllProjectClasses();
            string AllProject = "";
            foreach (var CustomClass in CustomClasses)
            {


                AllProject += DoccumentClass(CustomClass);






            }

            _UploadDocomentationDataToFile(AllProject, _FilePath);





        }
    }

}
