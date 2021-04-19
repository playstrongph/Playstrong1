﻿using System;
using UnityEngine;

namespace Assets.Scripts.Utilities
{
    [System.AttributeUsage(System.AttributeTargets.Field, AllowMultiple = false)]
    public class SubclassSelectorAttribute : PropertyAttribute
    {

        Type m_type;

        public SubclassSelectorAttribute(System.Type type)

        {

            m_type = type;

        }



        public Type GetFieldType()

        {

            return m_type;

        }
    }
}