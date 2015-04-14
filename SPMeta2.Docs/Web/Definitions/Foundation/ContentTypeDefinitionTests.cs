﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.Definitions;
using SPMeta2.Docs.ProvisionSamples.Base;
using SPMeta2.Docs.ProvisionSamples.Consts;
using SPMeta2.Docs.ProvisionSamples.Definitions;
using SPMeta2.Enumerations;
using SPMeta2.Syntax.Default;
using System;
using SPMeta2.Docs.ProvisionSamples.Attributes;

namespace SPMeta2.Docs.ProvisionSamples.Provision.Definitions
{
    [TestClass]
    public class ContentTypeDefinitionTests : ProvisionTestBase
    {
        #region methods

        [SampleMetadata(
            Title = "Adding list item content type",
            Description = "",
            Order = 500,
            CatagoryAlias = SampleCategory.SharePointFoundation,
            GroupAlias = SampleGroups.SiteCollection)]
        [TestMethod]
        [TestCategory("Docs.ContentTypeDefinition")]
        public void CanDeploySimpleListContentType()
        {
            var listContentType = new ContentTypeDefinition
            {
                Name = "Custom list item",
                Id = new Guid("79658c1e-3096-4c44-bd55-4228d01a5b97"),
                ParentContentTypeId = BuiltInContentTypeId.Item,
                Group = "SPMeta2.Samples"
            };

            var model = SPMeta2Model.NewSiteModel(site =>
            {
                site
                   .AddContentType(listContentType);
            });

            DeployModel(model);
        }

        [SampleMetadata(
            Title = "Adding document item content type",
            Description = "",
            Order = 510,
            CatagoryAlias = SampleCategory.SharePointFoundation,
            GroupAlias = SampleGroups.SiteCollection)]
        [TestMethod]
        [TestCategory("Docs.ContentTypeDefinition")]
        public void CanDeploySimpleDocumentContentType()
        {
            var documentContentType = new ContentTypeDefinition
            {
                Name = "Custom document",
                Id = new Guid("008e7c50-a271-4fcd-9f01-f18daad5bd7e"),
                ParentContentTypeId = BuiltInContentTypeId.Document,
                Group = "SPMeta2.Samples"
            };

            var model = SPMeta2Model.NewSiteModel(site =>
            {
                site
                   .AddContentType(documentContentType);
            });

            DeployModel(model);
        }

        [TestMethod]
        [TestCategory("Docs.ContentTypeDefinition")]
        public void CanDeploySimpleContentTypes()
        {
            var model = SPMeta2Model.NewSiteModel(site =>
            {
                site
                   .AddContentType(DocContentTypes.CustomerAccount)
                   .AddContentType(DocContentTypes.CustomerDocument);
            });

            DeployModel(model);
        }

        [SampleMetadata(
            Title = "Adding site fields",
            Description = "",
            Order = 500,
            CatagoryAlias = SampleCategory.SharePointFoundation,
            GroupAlias = SampleGroups.ContentType)]
        [TestMethod]
        [TestCategory("Docs.ContentTypeDefinition")]
        public void CanDeploySimpleContentTypesWithFields()
        {
            var model = SPMeta2Model.NewSiteModel(site =>
            {
                site
                    .AddField(DocFields.Clients.ClientCredit)
                    .AddField(DocFields.Clients.ClientDebit)
                    .AddField(DocFields.Clients.ClientDescription)
                    .AddField(DocFields.Clients.ClientNumber)
                    .AddField(DocFields.Clients.ClientWebSite)

                   .AddContentType(DocContentTypes.CustomerAccount, contentType =>
                   {
                       contentType
                         .AddContentTypeFieldLink(DocFields.Clients.ClientCredit)
                         .AddContentTypeFieldLink(DocFields.Clients.ClientDebit)
                         .AddContentTypeFieldLink(DocFields.Clients.ClientWebSite);
                   })
                   .AddContentType(DocContentTypes.CustomerDocument, contentType =>
                   {
                       contentType
                          .AddContentTypeFieldLink(DocFields.Clients.ClientDescription)
                          .AddContentTypeFieldLink(DocFields.Clients.ClientNumber);
                   });
            });

            DeployModel(model);
        }

        [SampleMetadata(
            Title = "Adding parent-child content types",
            Description = "",
            Order = 500,
            CatagoryAlias = SampleCategory.SharePointFoundation,
            GroupAlias = SampleGroups.SiteCollection)]
        [TestMethod]
        [TestCategory("Docs.ContentTypeDefinition")]
        public void CanDeployHierarhicalContentTypes()
        {
            var rootDocumentContentType = new ContentTypeDefinition
            {
                Name = "A root document",
                Id = new Guid("b0ec3794-8bf3-49ed-b8d1-24a4df5ac75b"),
                ParentContentTypeId = BuiltInContentTypeId.Document,
                Group = "SPMeta2.Samples"
            };

            var childDocumentContentType = new ContentTypeDefinition
            {
                Name = "A child document",
                Id = new Guid("84ab43ee-1f9d-4436-a9de-868bd7a36400"),
                // use GetContentTypeId() to get the content type ID and refer as a parent ID
                ParentContentTypeId = rootDocumentContentType.GetContentTypeId(),
                Group = "SPMeta2.Samples"
            };

            var model = SPMeta2Model.NewSiteModel(site =>
            {
                site
                   .AddContentType(rootDocumentContentType)
                   .AddContentType(childDocumentContentType);
            });

            DeployModel(model);
        }

        #endregion
    }
}
