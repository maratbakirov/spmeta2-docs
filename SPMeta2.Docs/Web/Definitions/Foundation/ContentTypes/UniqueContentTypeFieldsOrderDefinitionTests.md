<properties
	  pageTitle="UniqueContentTypeFieldsOrderDefinition"
    pageName="UniqueContentTypeFieldsOrderDefinition"
    parentPageId="spmeta2/definitions/sharepoint-foundation/contenttypes"
/>

###Provision scenario
We should be able to change the order of the fields in a target content type.

###Scope
Should be deployed under the content type.

###Implementation
Fields re-ordering inside a content type is enabled via UniqueContentTypeFieldsOrderDefinition object.

Both CSOM/SSOM object models are supported. 
Provision re-orders field links inside the content type according the Fields property. 
You can deploy either single object or a set of the objects using AddUniqueContentTypeFieldsOrder() extension method as per following examples.

[LIST.SAMPLES]