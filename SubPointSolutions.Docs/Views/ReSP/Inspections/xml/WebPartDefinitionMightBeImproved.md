﻿---
Title: Improve web part definition
FileName: resp516401.html
---
### Description
Adding icons enhance look and feel of the Web Parts with which Web Parts will be more identifiable. It also make Web Parts more professional.

### Resolution

#### Icons

The two default properties to specify icons for Web Part are:

- TitleIconImageUrl. This can be used to show an icon in the Web Part’s title bar. The icon will be displayed to the left of the Title
- CatalogIconImageUrl. This will be used in the Web Part gallery to identify the Web Part.

The icon should be 16x16 pixel image of png, gif or jpeg format. We can set these default properties either in the code or directly modify the xml. Following is the xml that shows the properties of icon

<a href="_samples/WebPartDefinitionMightBeImproved-IncorrectWebPartDefinitionSample.sample-ref"></a>

#### Description
Web part should not have autogenerated description property like "My WebPart" or "My Visual WebPart".

### Links
- [Creating Web Parts for SharePoint](https://msdn.microsoft.com/en-us/library/ee231579(v=vs.100).aspx)
- [WebPart.CatalogIconImageUrl Property](https://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.webparts.webpart.catalogiconimageurl.aspx)
- [WebPart.TitleIconImageUrl Property](https://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.webparts.webpart.titleiconimageurl.aspx)
- [WebPart.ChromeType Property](https://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.webparts.webpart.chrometype.aspx)