using System.Text;

namespace NovelEpubMaker{

    /// <summary>
    /// epub 文件列表
    /// </summary>
    public sealed class EpubManifestSpine
    {
        /// <summary>
        /// epub 文件列表
        /// </summary>
        public EpubManifestSpine()
        {
        }

        /// <summary>
        /// 章节数
        /// </summary>
        public int ChapterCount { get; set; } = 0;

        /// <summary>
        /// 是否有封面
        /// </summary>
        public bool HasCover { get; set; } = false;

        /// <summary>
        /// 生成文件列表 Manifest 和 Spine
        /// </summary>
        /// <returns>Manifest</returns>
        public string Generate(){
            var sb = new StringBuilder();
            var spine = new StringBuilder();
            sb.Append(@"<manifest>
    <item href=""toc.ncx"" id=""ncx"" media-type=""application/x-dtbncx+xml"" />
    <item href=""Styles/stylesheet.css"" id=""stylesheet"" media-type=""text/css"" />");
            spine.AppendLine("<spine toc=\"ncx\">");

            if (HasCover)
            {
                sb.Append(@"<item href=""Text/cover.xhtml"" id=""cover.xhtml"" media-type=""application/xhtml+xml"" />
    <item href=""Images/cover.jpg"" id=""cover.jpg"" media-type=""image/jpeg"" />");
                spine.AppendLine("<itemref idref=\"cover.xhtml\" linear=\"yes\" />");
            }
            for (int i = 1; i <= ChapterCount; i++)
            {
                var id = i.ToString().PadLeft(5, '0');
                sb.AppendLine($"<item href=\"Text/{id}.html\" id=\"{id}\" media-type=\"application/xhtml+xml\" />");
                spine.AppendLine($"<itemref idref=\"{id}\" linear=\"yes\" />");
            }
            sb.AppendLine("</manifest>");
            spine.AppendLine("</spine>");
            if (HasCover)
            {
                spine.Append(@"<guide>
                <reference type=""cover"" title=""封面"" href=""Text/cover.xhtml"" />
                </guide>");
            }
            return sb.ToString() + spine.ToString();
        }

    }

}