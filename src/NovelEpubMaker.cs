
using System.IO;
using System.IO.Compression;
using System.Text;

namespace NovelEpubMaker
{
    /// <summary>
    /// NovelEpub
    /// </summary>
    public sealed class NovelEpub
    {
        /// <summary>
        /// NovelEpub
        /// </summary>
        public NovelEpub()
        {
        }

        /// <summary>
        /// 书籍元数据
        /// </summary>
        public EpubMetadata Metadata { get; set; } = new EpubMetadata();

        /// <summary>
        /// 封面 base64
        /// </summary>
        public string CoverBase64 { get; set; } = string.Empty;

        /// <summary>
        /// 样式信息
        /// </summary>
        public string StyleSheet { get; set; } = EpubBase.BaseCss;

        /// <summary>
        /// 小说章节信息
        /// </summary>
        public IEnumerable<NovelContent> NovelList { get; set; } = new List<NovelContent>();

        /// <summary>
        /// 添加章节
        /// </summary>
        /// <param name="title">title</param>
        /// <param name="content">content</param>
        public void AddChapter(string title, string content)
        {
            _ = NovelList.Append(new NovelContent
            {
                Title = title,
                Content = content
            });
        }

        /// <summary>
        /// 保存为 Bytes
        /// </summary>
        /// <returns>epub 电子书</returns>
        public async Task<byte[]> SaveBytesAsync()
        {
            // 是否有封面
            var hasCover = !string.IsNullOrEmpty(CoverBase64);

            using var zipStream = new MemoryStream();

            using (var zip = new ZipArchive(zipStream, ZipArchiveMode.Create, true))
            {
                // 添加mimetype文件
                var mimetypeEntry = zip.CreateEntry("mimetype", CompressionLevel.NoCompression);
                using (var writer = new StreamWriter(mimetypeEntry.Open()))
                {
                    writer.Write(EpubBase.Mimetype);
                }
                var meta = zip.CreateEntry("META-INF/container.xml");

                // 添加container.xml文件
                using (var metaStream = meta.Open())
                {
                    await metaStream.WriteAsync(Encoding.UTF8.GetBytes(EpubBase.ContainerXml));
                }

                // 添加核心内容文件夹
                var content = zip.CreateEntry("OEBPS/content.opf");
                using (var contentStream = content.Open())
                {
                    var contentsb = new StringBuilder();
                    contentsb.Append(EpubBase.ContentOpf);
                    contentsb.Append(Metadata.Generate());
                    contentsb.Append(new EpubManifestSpine{
                        ChapterCount = NovelList.Count(),
                        HasCover = hasCover
                    }.Generate());
                    contentsb.Append("</package>");
                    await contentStream.WriteAsync(Encoding.UTF8.GetBytes(contentsb.ToString()));
                }

                // 添加目录文件夹
                var toc = zip.CreateEntry("OEBPS/toc.ncx");
                using (var tocStream = toc.Open())
                {
                    await tocStream.WriteAsync(Encoding.UTF8.GetBytes(new EpubNcx
                    {
                        Title = Metadata.Title,
                        HasCover = hasCover,
                        NovelList = NovelList
                    }.Generate()));
                }

                // 封面处理
                if(hasCover){
                    var coverImage = zip.CreateEntry("OEBPS/Images/cover.jpg");
                    using(var coverImageStream = coverImage.Open()){
                        await coverImageStream.WriteAsync(Convert.FromBase64String(CoverBase64));
                    }

                    var coverHtml = zip.CreateEntry("OEBPS/Text/cover.html");
                    using(var coverHtmlStream = coverHtml.Open()){
                        await coverHtmlStream.WriteAsync(Encoding.UTF8.GetBytes(EpubBase.CoverHtml));
                    }
                }

                // 添加样式文件
                var style = zip.CreateEntry("OEBPS/Styles/stylesheet.css");
                using (var styleStream = style.Open())
                {
                    await styleStream.WriteAsync(Encoding.UTF8.GetBytes(StyleSheet));
                }

                // 添加章节文件
                var i = 1;
                foreach (var item in NovelList)
                {
                    var id = i.ToString().PadLeft(5, '0');
                    var chapter = zip.CreateEntry($"OEBPS/Text/{id}.html");
                    using (var chapterStream = chapter.Open())
                    {
                        await chapterStream.WriteAsync(Encoding.UTF8.GetBytes(EpubContent.Generate(item)));
                    }
                    i++;
                }
            }
            return zipStream.ToArray();
        }

    }
}