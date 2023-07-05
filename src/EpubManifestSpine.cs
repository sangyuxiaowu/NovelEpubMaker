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
            sb.AppendLine("<manifest>");
            sb.AppendLine("<item id=\"ncx\" href=\"toc.ncx\" media-type=\"application/x-dtbncx+xml\" />");
            sb.AppendLine("<item id=\"style\" href=\"Text/style.css\" media-type=\"text/css\" />");
            spine.AppendLine("<spine toc=\"ncx\">");

            if (HasCover)
            {
                sb.AppendLine("<item id=\"cover\" href=\"Text/cover.html\" media-type=\"application/xhtml+xml\" />");
                sb.AppendLine("<item id=\"cover-image\" href=\"Images/cover.jpg\" media-type=\"image/jpeg\" />");
                spine.AppendLine("<itemref idref=\"cover\" linear=\"yes\" />");
            }
            for (int i = 1; i <= ChapterCount; i++)
            {
                var id = i.ToString().PadLeft(5, '0');
                sb.AppendLine($"<item id=\"{id}\" href=\"Text/{id}.html\" media-type=\"application/xhtml+xml\" />");
                spine.AppendLine($"<itemref idref=\"{id}\" linear=\"yes\" />");
            }
            sb.AppendLine("</manifest>");
            spine.AppendLine("</spine>");
            return sb.ToString() + spine.ToString();
        }

    }

}