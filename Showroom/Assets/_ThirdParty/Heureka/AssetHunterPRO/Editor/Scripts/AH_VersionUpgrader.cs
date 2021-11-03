/*using System;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEditor.PackageManager;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.Assertions;

namespace HeurekaGames.AssetHunterPRO
{
 #if UNITY_2018_1_OR_NEWER  
    [InitializeOnLoad]
    public static class AH_VersionUpgrader
    {
        public static ListRequest Request { get; }

        static AH_VersionUpgrader()
        {
            Request = Client.List();    // List packages installed for the Project
            EditorApplication.update += verifyPackages;
            //https://docs.unity3d.com/Manual/upm-api.html
        }

        [UnityEditor.Callbacks.DidReloadScripts]
        private static void OnScriptsReloaded()
        {
            Debug.LogWarning("OnScriptsReloaded");
            //Request = Client.List();    // List packages installed for the Project
            //EditorApplication.update += verifyPackages;
        }

        //See if we have addressables package installed and set DefineSymbol accordingly
        private static void verifyPackages()
        {
            if (Request.IsCompleted)
            {
                bool foundAddressables = false;
                if (Request.Status == StatusCode.Success)
                    foreach (var package in Request.Result)
                {
                        if (package.name == "com.unity.addressables")
                        {
                            Version version = new Version(package.version);
                            if (version >= new Version("1.2.0"))
                            {
                                foundAddressables = true;
                                AddAddressables(true);
                            }
                        }
                }
                else if (Request.Status >= StatusCode.Failure)
                    Debug.Log(Request.Error.message);

                if(!foundAddressables)
                    AddAddressables(false);

                EditorApplication.update -= verifyPackages;
            }
        }

        private static void AddAddressables(bool useAddressables)
        {
            Debug.LogWarning("AddAddressables " + useAddressables);

            UnityEditor.Compilation.Assembly[] editorAssemblies =
                UnityEditor.Compilation.CompilationPipeline.GetAssemblies(UnityEditor.Compilation.AssembliesType.Editor);

            var AddressablesAssembly = editorAssemblies.SingleOrDefault(a => a.name.Equals("Unity.Addressables.Editor"));
            var AH_Assembly = editorAssemblies.SingleOrDefault(a => a.name.Equals("AH_AssemblyDefinition"));
            Assert.IsNotNull(AH_Assembly, "No AHP Assembly Definition Present in project");

            bool hasRefToAddressables = AH_Assembly.assemblyReferences.Any(a => a.name.Equals("Unity.Addressables.Editor"));

            var newAssemblyRefList = AH_Assembly.assemblyReferences.ToList();
            //If we have reference to addressables assembly but dont want it
            if (!useAddressables && hasRefToAddressables)
                newAssemblyRefList.Remove(AddressablesAssembly);
            else if (useAddressables && !hasRefToAddressables)
                newAssemblyRefList.Add(AddressablesAssembly);

            //Get the readonly field for adding assembly references
            FieldInfo field = typeof(UnityEditor.Compilation.Assembly).GetField($"<{nameof(UnityEditor.Compilation.Assembly.assemblyReferences)}>k__BackingField", BindingFlags.Instance | BindingFlags.NonPublic);
            var value = field.GetValue(AH_Assembly);
            field.SetValue(AH_Assembly, newAssemblyRefList.ToArray());

            var pipe = UnityEditor.Compilation.CompilationPipeline.GetAssemblyDefinitionFilePathFromAssemblyName("AH_AssemblyDefinition");

            //CompilationPipeline 
            //var builder = new UnityEditor.Compilation.AssemblyBuilder(AddressablesAssembly.
            //var stronglyTypedField = value as UnityEditor.Compilation.Assembly[];
            //stronglyTypedField = newAssemblyRefList.ToArray();

            //UnityEditor.Compilation.CompilationPipeline.
            //AH_PreProcessor.AddDefineSymbols("ADRESSABLES_1_2_0_OR_NEWER", useAddressables);
        }
    }
#endif
}
*/