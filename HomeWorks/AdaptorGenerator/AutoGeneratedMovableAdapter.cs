﻿using HomeWorks.IocContainer;

using System.Numerics;
using System.Reflection;
using System.Reflection.Emit;

using UserObjects.Objects;

namespace HomeWorks.AdaptorGenerator
{
    public class AutoGeneratedMovableAdapter
    {
        public static object Main()
        {
            var aName = new AssemblyName("DynamicAssemblyExample");
            AssemblyBuilder ab =
                AssemblyBuilder.DefineDynamicAssembly(
                    aName,
                    AssemblyBuilderAccess.Run);

            // Имя модуля обычно совпадает с именем сборки.
            ModuleBuilder mb = ab.DefineDynamicModule(aName.Name ?? "DynamicAssemblyExample");

            TypeBuilder tb = mb.DefineType(
                "MovableAdapter",
                 TypeAttributes.Public);

            // Добавляем частное поле типа int.
            FieldBuilder fbObj = tb.DefineField(
                "obj",
                typeof(UserObject),
                FieldAttributes.Private);

            // Определяем конструктор, который принимает целочисленный аргумент и
            // сохраняет его в приватном поле.
            Type[] parameterTypes = { typeof(UserObject) };
            ConstructorBuilder ctor1 = tb.DefineConstructor(
                attributes: MethodAttributes.Public,
                callingConvention: CallingConventions.Standard,
                parameterTypes: parameterTypes);

            ILGenerator ctor1IL = ctor1.GetILGenerator();

            ctor1IL.Emit(OpCodes.Ldarg_0);
            ConstructorInfo? ci = typeof(object).GetConstructor(Type.EmptyTypes);
            ctor1IL.Emit(OpCodes.Call, ci!);

            // Помещаем экземпляр в стек перед помещением аргумента,
            // который должен быть назначен частному полю number1.
            ctor1IL.Emit(OpCodes.Ldarg_0);
            ctor1IL.Emit(OpCodes.Ldarg_1);
            ctor1IL.Emit(OpCodes.Stfld, fbObj);
            ctor1IL.Emit(OpCodes.Ret);

            // Определяем метод, который принимает целочисленный аргумент и возвращает
            // произведение этого целого числа и частного поля number1.
            MethodBuilder methGetPosition = tb.DefineMethod(
                "getPosition",
                MethodAttributes.Public,
                typeof(Vector2),
                Array.Empty<Type>());

            ILGenerator methIL = methGetPosition.GetILGenerator();

            MethodInfo mi = typeof(IoC).GetMethod("Resolve");
            MethodInfo miGeneric = mi.MakeGenericMethod(typeof(Vector2));

            methIL.Emit(OpCodes.Ldstr, "Spaceship.Operations.IMovable:position.get");
            methIL.Emit(OpCodes.Ldc_I4_1);
            methIL.Emit(OpCodes.Newarr, typeof(object));
            methIL.Emit(OpCodes.Dup);
            methIL.Emit(OpCodes.Ldc_I4_0);
            methIL.Emit(OpCodes.Ldarg_0);
            methIL.Emit(OpCodes.Ldfld, fbObj);
            methIL.Emit(OpCodes.Stelem_Ref);
            methIL.Emit(OpCodes.Call, miGeneric);
            methIL.Emit(OpCodes.Ldloc_0);
            methIL.Emit(OpCodes.Ret);

            Type? t = tb.CreateType();

            // Создаем экземпляр DynamicType, используя значение конструктора по умолчанию.
            object? obj = null;
            if (t is not null)
            {
                obj = Activator.CreateInstance(t, [new UserObject()]);
            }

            return obj;

        }
    }
}