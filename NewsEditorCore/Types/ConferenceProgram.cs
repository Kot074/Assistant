using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NewsEditorCore.Types
{
    public class ConferenceProgram
    {
        public string Title { get; set; }
        public string DocumentUrl { get; set; }

        public string ToHTML()
        {
            return $"<p style=\"text-align: justify; text-indent: 1.25cm; margin-top: 0.5em; margin-bottom: 0.5em; font-family:Times New Roman, Times, serif; font-size: 12pt; line-height: 150 %;\">" +
                    $"<a href=\"{DocumentUrl}\" target=\"_blank\">{Title}</a>" +
                   $"</p>";
        }

        public static ConferenceProgram[] Parse(string src)
        {
            var result = new List<ConferenceProgram>();

            var pattern = @"<p.*?href=""(.*?)"".*?>(.*?)</a";
            var options = RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.IgnoreCase;
            var matches = Regex.Matches(src, pattern, options);
            foreach (Match match in matches)
            {
                var item = new ConferenceProgram();
                item.DocumentUrl = match.Groups[1].Value;
                item.Title = match.Groups[2].Value;

                result.Add(item);
            }

            return result.ToArray();
        }
    }
}
