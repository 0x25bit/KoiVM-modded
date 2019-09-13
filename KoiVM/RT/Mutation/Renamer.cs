#region

using System;
using System.Collections.Generic;
using System.IO;
using dnlib.DotNet;
using Microsoft.VisualBasic;

#endregion

namespace KoiVM.RT.Mutation
{
    public class Renamer
    {
        private readonly Dictionary<string, string> nameMap = new Dictionary<string, string>();
        private int next;

        public Renamer(int seed)
        {
            next = seed;
        }

        private string ToString(int id)
        {
            return id.ToString("x");
        }

        private string NewName(string name)
        {
            string newName;
            if(!nameMap.TryGetValue(name, out newName))
            {
                nameMap[name] = newName = ToString(next);
				next = next * 0x15660D + 0x3D6EF85F;
            }
            return newName;
        }

        public void Process(ModuleDef module)
        {
            foreach(var type in module.GetTypes())
            {
                if(!type.IsPublic)
                {
                    type.Namespace = NewName(type.Namespace);
                    type.Name = NewName(type.Name);
                }
                foreach(var genParam in type.GenericParameters)
                    genParam.Name = "";

                var isDelegate = type.BaseType != null &&
                                 (type.BaseType.FullName == "System.Delegate" ||
                                  type.BaseType.FullName == "System.MulticastDelegate");

                foreach(var method in type.Methods)
                {
                    if(method.HasBody)
                        foreach(var instr in method.Body.Instructions)
                        {
                            var memberRef = instr.Operand as MemberRef;
                            if(memberRef != null)
                            {
                                var typeDef = memberRef.DeclaringType.ResolveTypeDef();

                                if(memberRef.IsMethodRef && typeDef != null)
                                {
                                    var target = typeDef.ResolveMethod(memberRef);
                                    if(target != null && target.IsRuntimeSpecialName)
                                        typeDef = null;
                                }

                                if (typeDef != null && typeDef.Module == module)
                                    memberRef.Name = NewName(memberRef.Name);
                            }
                        }

                    foreach(var arg in method.Parameters)
                        arg.Name = "";
                    if(method.IsRuntimeSpecialName || isDelegate || type.IsPublic)
                        continue;
                    method.Name = NewName(method.Name);
                    method.CustomAttributes.Clear();
                }
                for(var i = 0; i < type.Fields.Count; i++)
                {
                    var field = type.Fields[i];
                    if(field.IsLiteral)
                    {
                        type.Fields.RemoveAt(i--);
                        continue;
                    }
                    if(field.IsRuntimeSpecialName)
                        continue;
                    field.Name = NewName(field.Name);
                }
                type.Properties.Clear();
                type.Events.Clear();
                type.CustomAttributes.Clear();
            }
        }
    }
}