﻿using System;
using System.Collections.Generic;
using System.Reflection;
using MbUnit.Framework;

namespace LightBDD
{
    internal class MbUnitTestMetadataProvider : TestMetadataProvider
    {
        public static readonly TestMetadataProvider Instance = new MbUnitTestMetadataProvider();

        /// <summary>
        /// Returns implementation specific feature description or null if such is not provided.
        /// If test class is annotated with [Description] attribute, it's content is used as feature description.
        /// </summary>
        /// <param name="testClass">Class to analyze.</param>
        /// <returns>Feature description or null.</returns>
        protected override string GetImplementationSpecificFeatureDescription(Type testClass)
        {
            return ExtractAttributePropertyValue<DescriptionAttribute>(testClass, a => a.Description);
        }

        /// <summary>
        /// Returns implementation specific scenario categories or empty collection if no categories are provided.
        /// If test class is annotated with [Category] attribute, it's content is used as scenario category.
        /// </summary>
        /// <param name="scenarioMethod">Scenario method to analyze.</param>
        /// <returns>Scenario categories or empty collection.</returns>
        protected override IEnumerable<string> GetImplementationSpecificScenarioCategories(MethodBase scenarioMethod)
        {
            return ExtractAttributePropertyValues<CategoryAttribute>(scenarioMethod, a => a.Category);
        }
    }
}