using System.Text;

namespace NovelEpubMaker{

    /// <summary>
    /// epub 目录
    /// </summary>
    public sealed class EpubNcx
    {
        /// <summary>
        /// epub 目录
        /// </summary>
        public EpubNcx()
        {
        }

        /// <summary>
        /// 是否有封面
        /// </summary>
        public bool HasCover { get; set; } = false;

        /// <summary>
        /// 书籍名称
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// 小说章节信息
        /// </summary>
        public IEnumerable<NovelContent> NovelList { get; set; } = new List<NovelContent>();

        /// <summary>
        /// 生成目录
        /// </summary>
        /// <returns>Manifest</returns>
        public string Generate(){
            var sb = new StringBuilder();
            sb.Append($@"<?xml version=""1.0"" encoding=""utf-8""?>
    <!DOCTYPE ncx PUBLIC ""-//NISO//DTD ncx 2005-1//EN""
            ""http://www.daisy.org/z3986/2005/ncx-2005-1.dtd"">
    <ncx xmlns=""http://www.daisy.org/z3986/2005/ncx/"" version=""2005-1"">
    <head>
        <meta name=""dtb:uid"" content=""{Guid.NewGuid():D}"" />
        <meta name=""dtb:depth"" content=""1"" />
        <meta name=""dtb:totalPageCount"" content=""0"" />
        <meta name=""dtb:maxPageNumber"" content=""0"" />
    </head>
    <docTitle>
        <text>{Title}</text>
    </docTitle>
    <navMap>");
            if(HasCover){
                sb.Append(@"<navPoint id=""cover"" playOrder=""0"">
                    <navLabel>
                        <text>封面</text>
                    </navLabel>
                    <content src=""Text/cover.xhtml"" />
                    </navPoint>");
            }
            var i = 1;
            foreach (var item in NovelList)
            {
                var id = i.ToString().PadLeft(5, '0');
                sb.Append($@"<navPoint id=""{id}"" playOrder=""{i}"">
                    <navLabel>
                        <text>{item.Title}</text>
                    </navLabel>
                    <content src=""Text/{id}.html"" />
                    </navPoint>");
                i++;
            }
            sb.Append("</navMap>\n</ncx>");
            return sb.ToString();
        }

    }

}