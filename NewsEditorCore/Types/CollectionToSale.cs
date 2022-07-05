using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NewsEditorCore.Types
{
    public class CollectionToSale
    {
        public string Text { get; set; }
        public string FilePath { get; set; }
        public string ImgPath { get; set; }

        public string ToHTML()
        {
            return 
                @"<table style=""display: inline-block; width: 160px;"" border=""0"">" +
                    "<tbody>" +
                        "<tr>" +
                            "<td>" +
                                $@"<a href=""{FilePath}"" target = ""_blank"">" +
                                    $@"<img src=""{ImgPath}""" +
                                        @"border=""0""" +
                                        @"alt=""Обложка""" +
                                        @"width=""150""" +
                                        @"height=""203""" +
                                        @"style=""border: 0;""" +
                                    "/>" +
                                "</a>" +
                            "</td>" +
                        "</tr>" +
                        "<tr>" +
                            "<td>" +
                                $"<p style = \"text-align: center;\" >{Text}</p>" +
                            "</td>" +
                        "</tr>" +
                    "</tbody>" +
                "</table>";
        }

        public static CollectionToSale[] Parse(string src)
        {
            var result = new List<CollectionToSale>();

            var pattern = @"<table .*?>.*?<a href=""(.*?)"".*?<img src=""(.*?)"".*?<p.*?>(.*?)</p>.*?</table>";
            var options = RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.IgnoreCase;
            var matches = Regex.Matches(src, pattern, options);
            foreach (Match match in matches)
            {
                var item = new CollectionToSale
                {
                    FilePath = match.Groups[1].Value,
                    ImgPath = match.Groups[2].Value,
                    Text = match.Groups[3].Value
                };

                result.Add(item);
            }

            return result.ToArray();
        }
    }
}
