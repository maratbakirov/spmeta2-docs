using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.Definitions;
using SPMeta2.Definitions.ContentTypes;
using SPMeta2.Definitions.Fields;
using SPMeta2.Docs.ProvisionSamples.Attributes;
using SPMeta2.Docs.ProvisionSamples.Base;
using SPMeta2.Docs.ProvisionSamples.Consts;
using SPMeta2.Docs.ProvisionSamples.Definitions;
using SPMeta2.Enumerations;
using SPMeta2.Syntax.Default;

namespace SPMeta2.Docs.ProvisionSamples.Provision.Definitions
{
    [TestClass]
    public class UniqueContentTypeOrderDefinitionTests : ProvisionTestBase
    {
        #region methods

        [SampleMetadata(
         Title = "Reordering content types in list",
         Description = "",
         Order = 1500,
         CatagoryAlias = SampleCategory.SharePointFoundation,
         GroupAlias = SampleGroups.ContentType)]

        [TestMethod]
        [TestCategory("Docs.UniqueContentTypeOrderDefinition")]
        public void CanReorderContentTypesInList()
        {
            var creditContentType = new ContentTypeDefinition
            {
                Name = "M2 Credit",
                Id = new Guid("5D8346E4-A7AB-40AE-9AE9-22CF18170029"),
                ParentContentTypeId = BuiltInContentTypeId.Item,
                Group = "SPMeta2.Samples"
            };

            var debitContentType = new ContentTypeDefinition
            {
                Name = "M2 Debit",
                Id = new Guid("0C8D0474-384B-4765-8F84-993124447516"),
                ParentContentTypeId = BuiltInContentTypeId.Item,
                Group = "SPMeta2.Samples"
            };

            var totalContentType = new ContentTypeDefinition
            {
                Name = "M2 Total",
                Id = new Guid("110E6911-4611-4905-9E2F-46FEA608B418"),
                ParentContentTypeId = BuiltInContentTypeId.Item,
                Group = "SPMeta2.Samples"
            };

            var annualRevenueList = new ListDefinition
            {
                Title = "M2 Annual Revenue",
                Description = "A generic list.",
                TemplateType = BuiltInListTemplateTypeId.GenericList,
                ContentTypesEnabled = true,
                CustomUrl = "M2AnnualRevenue"
            };

            var siteModel = SPMeta2Model.NewSiteModel(site =>
            {
                site
                    .AddContentType(creditContentType)
                    .AddContentType(debitContentType)
                    .AddContentType(totalContentType);
            });

            var webModel = SPMeta2Model.NewWebModel(web =>
            {
                web.AddList(annualRevenueList, list =>
                {
                    list
                        .AddContentTypeLink(totalContentType)
                        .AddContentTypeLink(creditContentType)
                        .AddContentTypeLink(debitContentType)
                        .AddUniqueContentTypeOrder(new UniqueContentTypeOrderDefinition
                        {
                            ContentTypes = new List<ContentTypeLinkValue>
                            {
                                new ContentTypeLinkValue{ ContentTypeName = creditContentType.Name },
                                new ContentTypeLinkValue{ ContentTypeName = debitContentType.Name },
                                new ContentTypeLinkValue{ ContentTypeName = totalContentType.Name }
                            }
                        });
                });
            });

            DeployModel(siteModel);
            DeployModel(webModel);
        }

        #endregion
    }
}