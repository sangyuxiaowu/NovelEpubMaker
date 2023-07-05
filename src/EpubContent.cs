using System.Text.RegularExpressions;

namespace NovelEpubMaker
{
    /// <summary>
    /// 生成章节Html
    /// </summary>
    public static class EpubContent
    {
        /// <summary>
        /// 生成章节Html
        /// </summary>
        /// <returns>章节Html</returns>
        public static string Generate(NovelContent NovelInfo)
        {
            // 分割段落
            string[] paragraphs = NovelInfo.Content.Replace("\r","").Split("\n");
            // 去除空行
            paragraphs = Array.FindAll(paragraphs, p => !string.IsNullOrEmpty(p));
            string content = string.Join("", Array.ConvertAll(paragraphs, p => $"<p>{p}</p>"));

            return $@"<!DOCTYPE html>
<html xmlns=""http://www.w3.org/1999/xhtml"" xmlns:epub=""http://www.idpf.org/2007/ops"">
<head>
    <title>{NovelInfo.Title}</title>
    <meta charset=""utf-8"" />
    <link href=""../Styles/stylesheet.css"" rel=""stylesheet"" type=""text/css""/>
</head>
<body>
    <h1>{NovelInfo.Title}</h1>
    {content}
</body>
</html>";
        }

    }
}