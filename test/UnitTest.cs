public class UnitTest
{
    private readonly ITestOutputHelper output;

    public UnitTest(ITestOutputHelper output)
    {
        this.output = output;
    }


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

    private string coverImage = "/9j/4QAYRXhpZgAASUkqAAgAAAAAAAAAAAAAAP/sABFEdWNreQABAAQAAAAAAAD/7gAhQWRvYmUAZMAAAAABAwAQAwIDBgAACAcAAAztAAAOcf/bAIQAGxoaKR0pQSYmQUIvLy9CRz8+Pj9HR0dHR0dHR0dHR0dHR0dHR0dHR0dHR0dHR0dHR0dHR0dHR0dHR0dHR0dHRwEdKSk0JjQ/KCg/Rz81P0dHR0dHR0dHR0dHR0dHR0dHR0dHR0dHR0dHR0dHR0dHR0dHR0dHR0dHR0dHR0dHR0dH/8IAEQgCvAIYAwEiAAIRAQMRAf/EAIwAAQACAwEBAAAAAAAAAAAAAAAFBgEDBAIHAQEBAQAAAAAAAAAAAAAAAAAAAQIQAAIBBAAGAQMEAwEAAAAAAAECAwARBAVQITESExUQQCIUIGCAQaAyI5ARAAICAgICAgMBAAAAAAAAAAABETEQUCESIIFgApCgQSISAQAAAAAAAAAAAAAAAAAAAKD/2gAMAwEAAhEDEQAAALMAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABjzXSyKrZDeAYCFjC2o2SMgAAAAAAAAAAAAAAAAAAAAAAAAAANcWSVFsNYl93uiWbUnUZJRnGfJUYWTjS4zEbJICgAAAAAAAAAAAAAAAAAAAAAAAAAcVH+gcBScWesmPUjYiDtUBCl68UcbObxgvUhTLinsKAAAAAAAAAAAAAAAAAAAAAAAAAMBEch0U+XiFsFqpMpc9cFYpGWma7vHFI9+ZAkrL59mQAAAAAAAAAAAAAAAAAAAAAAAAAPPrBTIy+eCirhqKpm67Cu799XLzo5vRVJiGsFlqzjMoAAAAAAAAAAAAAAAAAAAAAAAAAA8mccOog4rp4y7SUF21rpd4pGbPe+dZB2ir2+ybySgAAAAAAAAAAAAAAAAAAAAAAAAANO7wUPluXMVRs2Gnvnek90i+VY9eJKHOG60y82d4lAAAAAAAAAAAAAAAAAAAAAAAAAAAxxdsbFL7eCQq7eoDBYMMmmjXaiSr3Sb1rO4SgAAAAAAAAAAAAAAAAAAAAAAAAANfutEzBwWsw295Gds5JkZmH4C60mUiCQvFUttmRKAAAAAAAAAAAAAAAAAAAAAAAAABiImMFRkZ0cfV7GGRD1T6FyFC327pOeSDIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAMedVRLmowvKjC8qMLyowvKjC8+qTbTqAAAAAAAAAAAAAAAAAAAAAAAAAABy1S6YKSuwpOi+VmK7t1WOo7N1yUldhT7XtyZAAAAAAAAAAAAAAAAAAAAAAAAAABjj6KRFsUbNXOpaPJ7tlQ9F5UcXjo+f95eM6dwAAAAAAAAAAAAAAAAAAAAAAAAAABz0S7UWX1OxNuspGzx3ElXrzRz3OxtqKNs8by7dGvYZAAAAAAAAAAAAAAAAAAAAAAAAAABG0i4U6WSssDM2U+QjclqqudZNz0RIlPkI6Yq3+/PqAAAAAAAAAAAAAAAAAAAAAAAAAABggKpZK3LYO3V5srNhr1urlrdmrWbZ/ezksrc/AWeyx5xmUAAAAAAAAAAAAAAAAAAAAAAAAABjPkqUHKxa22PloNIecg+o6I70LlDT1aIq31G62SolAAAAAAAAAAAAAAAAAAAAAAAAAAa9mkpPHv1lzq9qqBputOu1U7m2ouVRt9LNF5pN7s6hKAAAAAAAAAAAAAAAAAAAAAAAAABjl6uKKR52a6moUPcxCB78Cbg8jfeqbdbPYlAAAAAAAAAAAAAAAAAAAAAAAAAAePY43YON2Djdg43YON2Dl6cgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAD//2gAIAQIAAQUA/iIP3Kfrx8n9gj+O4+DQ+uPyaH1oo/J+uFH5P1wr+/6Ff3/Mr//aAAgBAwABBQD+Ih/co4EP2Cf47n5P1w+RR+uHyPrjQ+R9caHwf5mf/9oACAEBAAEFAP8ABNvV/wBd+NObDK2bRtHtmZoHLr+jPzjAfcNWBkmYcYmNlzTeTFF3xhZPk9Nu13XrqlsnFpH7A+1RTNtUZZn72xnCNHtUUQbBZSOfw/TaNeSMXbXLaPi2abRy9xbn8C9WatWe1xOlvOlSZCduc/dJD/thSKE4tJGJAdZGazsFIkbrrscTMNXHWdAMYHLevy5KOW5pmLUDatdMzOnTi+3ayHrpl5itjjtMPVSV6qSpNc8YIsYozIdfgtGwFhxQ1lbEQn3IrNz/ADisHMEFe5FYmYMirCu0VsbCN+utW8iKAOKt02Ssz+Nq8TV4mrxNXjasPI/HV9wb4OSZl2rWRuuoW7jpxUi9PiI5/BjqWOCM3x6jxYpB+DHWzx1RD1078tw32nrpl5jjDdNrKe9JGJ1oPjrZreNuR07c9w3xpl5cWY2D7BELbKO2dMJHjNjiZ6RomwRzn/dFJ/tqDZtu12HXULZOLTmyZbMXu1H4BasDuMmUP+Mv+2qNm2jXdOZ1i2j4s69wfVoxn1iIsq9rY0fkdNUhEOuWI5UZZG1sjNiYLQ1sDd4hdsBbR8YzjaOU3bWreROQvVr12CpuS5hvJji74gsnGNm1o3Nzr5FjabbBRh7IysDcVlmyZBu+ELyQCy8WaQLUmaiVsM9ZAeZBIrmaxFdGO1EYg2vkbNk/5Sm7a5byRiw4qa2kzxlpmauZpIGaodY71BqAKXDRF2MJR4n7Gm2HfGTc6iK7DkOLbHEMwj1DGodQq1HhIlKgX52OH5RLjtGe01DjNIcDF8K8XIvVh+oi9S4aSV6yOosRI6At/wCbHeK8i15FryLXkWvIteRa8i15FryLXkWvIKBvxbIftSbYOG9jJXsZK9jJXsZK9jJXsZK9jJXsZK9jJXsZKiz5GbFYsnFcpC6Sa2Rm9ZJXrJK9ZJU2E0QqKEyn1kleskr1kleskqDWurQJ2LxW1dorsFdgoqBW2mFda1GNeggrsFdgrsFdo4uTanzUQ+wjr2EdTbFO3Km8rR27sPJjiT2Edewjr2EdR5CycYlNlzZT5PI1eRqLk/HMV5GryNXe1eRqwspkeF+5eLZJsmUbvBH5GOrASZOxsaLys+qVUmXtbGi8rPqlVJl7Wxhd8YWTi2abRzG7YAvJOe2Kc3fWLeTJPbFObtrFvJlHtimN2wReSEWXi2ya0bm51i3kzj2xSG7a6VY2y85Gjc3OoW77BrRyG7a1byILDi22ayN11C3fZtaNuqg03cPjTLz2rWjbrqVu69OLbhvtNaZee3aynrq8ZZBs8dI1/vTLy3Dfaa0y8xxfct8aZeW5ah11C2TctQ66hbJuW+NMvLixrcNdh11K2TcN9w64mxEK5uX5yvM61bR7hrsOuoWy8WbptWu69dato9s13AvS4jkOhQxC7YQtFtGu6jnq1tHxaQ2XYNeSIXbDHbFsmvJji7wxKIthbyY4u8I7Ytg15IhdsBbR8WnNkzDeTHF3i+2HNN5MMXkH2xZpvJhi8h+2LLN3xxd8QWTi2WbJkG7xP2N7X7JX72x5fGzba6yv3tjy+Nn2t0kfvOGLyQCy8Wzr+OSJi3havC1eFq8LV4WrwtXhavC1eFq18LeSMWHFnQODhRmvwo6/Cjr8KOvwo6/Cjr8KOvwo6/Cjr8KOkxUQj/Ij/9oACAECAgY/ADsf/9oACAEDAgY/ADsf/9oACAEBAQY/AP0j5IRAm/GFiXuWMQt9LIGkNibIIXgxC27H4yyyx8jEJTt4ZRKxDKJ+pZZZLwlO7nELMsghHZ7eMR5sYtw4KKKKKJZwS93LRRDP4SkUf5xGZ3XBYpw8xidvJDZZKwkyExse7Y/FHofgtvBI2NCRJKGkUSxiFuWMXixiFuXiWR9SHljELb8lkLw7JEOyCRiFt+Dl44RyifsQkMk64nccHJyUcZlWQ1iI+A8oo4X42bLLLLLLLLLLL27Y0mWWWWWWWWWWJSJvbNIbgoool4hFFFFCbQlu+qx2e9hssscMbORKSyyzh7hj5L8rxYlInt2MSOw0Qdhog7DQhbdjEehiwxYYhbd4WGSyEycsW94OcTu4xJGJZxiSMTuIxJGYzGJ3UkYj4HKRDF4LbsYsMRX8HAj0MQtuxiPQxHoYj0MQtuxknUkk6kknUkQtu4HwUUUUUUUUUKULbwyiiiiiiiiiiUv2JP/Z";

    [Fact]
    public async Task TestBook()
    {
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
        var btyes = await epub.SaveBytesAsync();
        await File.WriteAllBytesAsync("test.epub", btyes);
    }

    [Fact]
    public void TestEpubMetadata()
    {
        var epub = new EpubMetadata(){

        };
        var metadata = epub.Generate();
        File.WriteAllText("metadata.xml", metadata);
        output.WriteLine(metadata);
    }

    [Fact]
    public void TestEpubManifestSpine()
    {
        var epub = new EpubManifestSpine{
            ChapterCount = 10,
            HasCover = true
        };
        var manifest = epub.Generate();
        File.WriteAllText("manifest.xml", manifest);
        output.WriteLine(manifest);
    }

    [Fact]
    public void TestEpubNcx()
    {
        var epub = new EpubNcx{
            Title = "测试小说",
            HasCover = true,
            NovelList = new List<NovelContent>{
                new NovelContent{
                    Title = "第一章 测试",
                    Content = "\r\n    开天辟地   \r\n  ABSCCCC \n  RRRRRR \n"
                },
                new NovelContent{
                    Title = "第二章 测试二",
                    Content = "\r\n    霹雳玄晶   \r\n  ABSCCCC \n  FFFFFF \n"
                }
            }
        };
        var ncx = epub.Generate();
        File.WriteAllText("ncx.xml", ncx);
        output.WriteLine(ncx);
    }
}