﻿using System;

namespace Natasha.Template
{

    public class NamespaceTemplate<T> : OopBodyTemplate<T> where T : NamespaceTemplate<T>, new()
    {

        public string NamespaceScript;
        private bool _hiddenNamesapce;


        public NamespaceTemplate()
        {

            _hiddenNamesapce = false;
            NamespaceScript = "NatashaDynimacSpace";

        }




        public T HiddenNamespace(bool shut = true)
        {

            _hiddenNamesapce = shut;
            return Link;

        }




        /// <summary>
        /// 设置命名空间
        /// </summary>
        /// <param name="namespace">命名空间</param>
        /// <returns></returns>
        public T Namespace(string @namespace)
        {

            NamespaceScript = @namespace;
            return Link;

        }




        public T Namespace<S>()
        {

            return Namespace(typeof(S));

        }




        public T Namespace(Type type)
        {

            NamespaceScript = type.Namespace;
            return Link;

        }




        public override T BuilderScript()
        {

            // [{this}]
            //  [Attribute]
            //  [access] [modifier] [Name] [:Interface] 
            //  [body]
            base.BuilderScript();
            if (!_hiddenNamesapce)
            {
                _script.Insert(0,$"namespace {NamespaceScript}{{");
                _script.Append('}');
            }
            return Link;

        }


    }

}
