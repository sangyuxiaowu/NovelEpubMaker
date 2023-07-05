using System.Text;

namespace NovelEpubMaker{

    /// <summary>
    /// epub 元数据
    /// </summary>
    public sealed class EpubMetadata
    {
        /// <summary>
        /// epub 元数据
        /// </summary>
        public EpubMetadata()
        {
        }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; } = string.Empty;

        /// <summary>
        /// 语言
        /// </summary>
        public string Language { get; set; } = "zh-CN";

        /// <summary>
        /// 发行者
        /// </summary>
        public string Contributor { get; set; } = "Novel Epub Maker Library";

        /// <summary>
        /// 主题词或关键词
        /// </summary>
        public string Subject { get; set; } = string.Empty;

        /// <summary>
        /// 简介
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// 出版社
        /// </summary>
        public string Publisher { get; set; } = string.Empty;

        /// <summary>
        /// ISBN
        /// </summary>
        public string ISBN { get; set; } = string.Empty;

        /// <summary>
        /// 权限描述
        /// </summary>
        public string Rights { get; set; } = string.Empty;

        /// <summary>
        /// 出版日期
        /// </summary>
        public string PublishDate { get; set; } = string.Empty;

        /// <summary>
        /// 修改日期
        /// </summary>
        public string ModifyDate { get; set; } = string.Empty;

        /// <summary>
        /// 来源信息
        /// </summary>
        public string Source { get; set; } = string.Empty;

        /// <summary>
        /// 唯一标识符
        /// </summary>
        public string Uuid { get; set; } = string.Empty;


        /// <summary>
        /// 生成 metadata
        /// </summary>
        /// <returns>metadata</returns>
        public string Generate(){
            var sb = new StringBuilder();
            sb.AppendLine("<metadata xmlns:dc=\"http://purl.org/dc/elements/1.1/\" xmlns:opf=\"http://www.idpf.org/2007/opf\">");

            if(!string.IsNullOrWhiteSpace(Uuid)){
                sb.AppendLine($"<dc:identifier id=\"uuid_id\" opf:scheme=\"uuid\">{Uuid}</dc:identifier>");
            }else{
                sb.AppendLine($"<dc:identifier id=\"uuid_id\" opf:scheme=\"uuid\">{Guid.NewGuid():D}</dc:identifier>");
            }

            if(!string.IsNullOrWhiteSpace(Title)){
                sb.AppendLine($"<dc:title>{Title}</dc:title>");
            }

            if(!string.IsNullOrWhiteSpace(Author)){
                sb.AppendLine($"<dc:creator>{Author}</dc:creator>");
            }

            if(!string.IsNullOrWhiteSpace(Language)){
                sb.AppendLine($"<dc:language>{Language}</dc:language>");
            }

            if(!string.IsNullOrWhiteSpace(Contributor)){
                sb.AppendLine($"<dc:contributor>{Contributor}</dc:contributor>");
            }

            if(!string.IsNullOrWhiteSpace(Subject)){
                sb.AppendLine($"<dc:subject>{Subject}</dc:subject>");
            }

            if(!string.IsNullOrWhiteSpace(Description)){
                sb.AppendLine($"<dc:description>{Description}</dc:description>");
            }

            if(!string.IsNullOrWhiteSpace(Publisher)){
                sb.AppendLine($"<dc:publisher>{Publisher}</dc:publisher>");
            }

            if(!string.IsNullOrWhiteSpace(ISBN)){
                sb.AppendLine($"<dc:identifier opf:scheme=\"ISBN\">{ISBN}</dc:identifier>");
            }

            if(!string.IsNullOrWhiteSpace(PublishDate)){
                sb.AppendLine($"<dc:date>{PublishDate}</dc:date>");
            }

            if(!string.IsNullOrWhiteSpace(Source)){
                sb.AppendLine($"<dc:source>{Source}</dc:source>");
            }

            if(!string.IsNullOrWhiteSpace(Rights)){
                sb.AppendLine($"<dc:rights>{Rights}</dc:rights>");
            }

            if(!string.IsNullOrWhiteSpace(ModifyDate)){
                sb.AppendLine($"<meta content=\"{ModifyDate}\" name=\"dcterms:modified\" />");
            }else{
                sb.AppendLine($"<meta content=\"{DateTime.Now:yyyy-MM-ddTHH:mm:ss.fff000+00:00}\" name=\"dcterms:modified\" />");
            }
            sb.AppendLine("<meta name=\"cover\" content=\"cover.jpg\"/></metadata>");
            return sb.ToString();
        }

    }

}