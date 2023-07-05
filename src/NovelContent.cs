
namespace NovelEpubMaker{

    /// <summary>
    /// 小说内容
    /// </summary>
    public sealed class NovelContent{

        /// <summary>
        /// 章节名
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// 章节内容
        /// </summary>
        public string Content { get; set; } = string.Empty;
    }
}