using AngleSharp.Html.Dom;
using System.Xml.Linq;

namespace Dhb.L5r.ShortCodes
{
    public class TableOfContentsShortCode : Shortcode
    {
        private const string Toggler = nameof(Toggler);
        public override async Task<ShortcodeResult> ExecuteAsync(KeyValuePair<string, string>[] args, string content, IDocument document, IExecutionContext context)
        {
            IMetadataDictionary dictionary = args.ToDictionary(
                Toggler);

            IHtmlDocument htmlDocument = await document.ParseHtmlAsync(false);
            if (htmlDocument is object)
            {
                var pageContent = htmlDocument.QuerySelector("#content");
                var headings = pageContent.QuerySelectorAll("h2,h3,h4");

                var hasToC = headings.Count() > 0;
                var isToggler = dictionary.GetBool(Toggler, false);

                if (isToggler)
                {
                    if (hasToC)
                    {
                        return new XElement("button",
                            new XAttribute("style", "width: 60px; border: none;"),
                            new XAttribute("class", "navbar-toggler"),
                            new XAttribute("type", "button"),
                            new XAttribute("data-bs-toggle", "offcanvas"),
                            new XAttribute("data-bs-target", "#tableOfContents"),
                            new XAttribute("aria-controls", "tableOfContents"),
                            new XElement("span", ". . .")
                        ).ToString();
                    } else
                    {
                        return new XElement("div",
                            new XAttribute("style", "width: 60px;"),
                            new XAttribute("class", "d-block")
                        ).ToString();
                    }
                }
                else
                {
                    if (!hasToC) return null;

                    return BuildToC(headings);
                }
            }

            return null;
        }

        string BuildToC(AngleSharp.Dom.IHtmlCollection<AngleSharp.Dom.IElement> headings)
        {
            var toc = new XElement("div",
                    new XAttribute("class", "d-grid"),
                    new XElement("h4",
                        new XAttribute("class", "brushtip d-none d-lg-block"), 
                        "Table of Contents")
                );

            foreach (var heading in headings)
            {
                var id = heading.Id;
                if (!string.IsNullOrWhiteSpace(id))
                {
                    var classes = "btn btn-toc";
                    if (heading.TagName.ToUpper() == "H3")
                    {
                        classes += " ms-3";
                    }
                    else if (heading.TagName.ToUpper() == "H4")
                    {
                        classes += " ms-5";
                    }

                    var tocEntry = new XElement("button",
                        new XAttribute("class", classes),
                        new XAttribute("onclick", $"l5r.tocOnClick('#{id}')"),
                        heading.TextContent.Replace("&amp;", "&")
                    );

                    toc.Add(tocEntry);
                }
            }

            return toc.ToString();
        }
    }
}
