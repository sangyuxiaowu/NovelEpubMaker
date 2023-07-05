namespace NovelEpubMaker
{
    /// <summary>
    /// 其他文件
    /// </summary>
    internal static class EpubBase
    {
        internal static string Mimetype = "application/epub+zip";
        internal static string ContainerXml = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<container version=""1.0"" xmlns=""urn:oasis:names:tc:opendocument:xmlns:container"">
    <rootfiles>
        <rootfile full-path=""OEBPS/content.opf"" media-type=""application/oebps-package+xml""/>
    </rootfiles>
</container>";
        internal static string ContentOpf = @"<?xml version=""1.0"" encoding=""utf-8""?>
<package xmlns=""http://www.idpf.org/2007/opf"" version=""2.0"" unique-identifier=""uuid_id"">";

        internal static string CoverHtml = @"<?xml version=""1.0"" encoding=""utf-8""?>
<html xmlns=""http://www.w3.org/1999/xhtml"" xmlns:epub=""http://www.idpf.org/2007/ops"">
    <head>
        <title>Cover</title>
        <link href=""../Styles/stylesheet.css"" rel=""stylesheet"" type=""text/css""/>
    </head>
    <body>
   <div style=""text-align: center; padding: 0pt; margin: 0pt;"">
    <svg xmlns=""http://www.w3.org/2000/svg"" height=""100%"" preserveAspectRatio=""xMidYMid meet"" version=""1.1"" viewBox=""0 0 768 1280"" width=""100%"" xmlns:xlink=""http://www.w3.org/1999/xlink"">
      <image height=""1280"" width=""768"" xlink:href=""../Images/cover.jpg""></image>
    </svg>
  </div>
    </body>
</html>";
        internal static string BaseCss = @"h1{font-size:30px;text-indent:3em;}
p{
    text-indent:2em;
    font-size:24px;
}";

    }
}