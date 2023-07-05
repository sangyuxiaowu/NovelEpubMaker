# NovelEpubMaker

Novel epub production tool library.

小说 epub 电子书制作工具类库

## Instructions 介绍

Novel Epub Maker is a .NET library for creating novel epub e-books. It does not depend on any third-party libraries, is lightweight and easy to use, and can be quickly adapted to scenarios such as novel production ebup and txt to epub.

Novel Epub Maker 是一个用于制作小说 epub 电子书的 .NET 类库。它不依赖任何第三方库，轻巧使用方便，可以快速适用于小说制作 ebup 和 txt 转 epub 等场景。

## Usage 使用方法

First, create a `List<NovelContent>` object to store the content of the novel's chapters:

首先创建一个 `List<NovelContent>` 对象，用于存放小说的章节内容：

```cs
private List<NovelContent> novellist = new List<NovelContent>{
    new NovelContent{
        Title = "第一章 测试",
        Content = "\r\n    开天辟地   \r\n  ABSCCCC \n  RRRRRR \n"
    },
    new NovelContent{
        Title = "第二章 测试二",
        Content = "\r\n    霹雳玄晶   \r\n  ABSCCCC \n  FFFFFF \n"
    }
};
```

Then create a `NovelEpub` object and set the related metadata, cover image, and novel content:

然后创建一个 `NovelEpub` 对象，并设置相关的元数据、封面图片和小说内容：

```cs
private string coverImage = "/9j/4QAYRX..........";
var epub = new NovelEpub(){
    Metadata = new EpubMetadata{
        Title = "测试小说",
        Author = "测试作者",
        Language = "zh-CN",
        Publisher = "测试出版社",
        Description = "测试描述",
        Subject = "测试主题,测试,主题",
        PublishDate = DateTime.Now.ToString("yyyy-MM-dd")
    },
    CoverBase64 = coverImage,
    NovelList = novellist
};
```

Finally, call the `SaveBytesAsync` method to save the generated epub e-book to a file:

最后调用 `SaveBytesAsync` 方法将生成的 epub 电子书保存到文件：

```cs
var btyes = await epub.SaveBytesAsync();
await File.WriteAllBytesAsync("test.epub", btyes);
```