using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.Docs.ProvisionSamples.Base;
using SPMeta2.Docs.ProvisionSamples.Definitions;
using SPMeta2.Syntax.Default;
using SubPointSolutions.Docs.Code.Enumerations;
using SubPointSolutions.Docs.Code.Metadata;

namespace SPMeta2.Docs.ProvisionSamples.Provision.Definitions
{
    [TestClass]
    [SampleMetadataTag(Name = BuiltInTagNames.SPRuntime, Value = BuiltInSPRuntimeTagValues.Foundation)]

    [SampleMetadataTag(Name = BuiltInTagNames.SampleCategory, Value = BuiltInSampleCategoryTagValues.ContentTypes)]
    [SampleMetadataTag(Name = BuiltInTagNames.SampleM2Model, Value = BuiltInM2ModelTagValues.WebModel)]

    [SampleMetadataTag(Name = BuiltInTagNames.SampleHidden)]
    public class ContentTypeFieldLinkDefinitionTests : ProvisionTestBase
    {
        #region methods

        [TestMethod]
        [TestCategory("Docs.ContentTypeFieldLinkDefinition")]
        public void CanDeploySimpleContentTypeFieldLinkDefinition()
        {
            var model = SPMeta2Model.NewSiteModel(site =>
            {
         
            });

            DeployModel(model);
        }

        #endregion
    }
}