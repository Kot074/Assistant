using System;
using System.Collections.Generic;

#nullable disable

namespace Atom.VectorSiteLibrary.Models
{
    public partial class JosContent
    {
        public uint Id { get; set; }
        public string Title { get; set; }
        public string Alias { get; set; }
        public string TitleAlias { get; set; }
        public string Introtext { get; set; }
        public string Fulltext { get; set; }
        public sbyte State { get; set; }
        public uint Sectionid { get; set; }
        public uint Mask { get; set; }
        public uint Catid { get; set; }
        public DateTime Created { get; set; }
        public uint CreatedBy { get; set; }
        public string CreatedByAlias { get; set; }
        public DateTime Modified { get; set; }
        public uint ModifiedBy { get; set; }
        public uint CheckedOut { get; set; }
        public DateTime CheckedOutTime { get; set; }
        public DateTime PublishUp { get; set; }
        public DateTime PublishDown { get; set; }
        public string Images { get; set; }
        public string Urls { get; set; }
        public string Attribs { get; set; }
        public uint Version { get; set; }
        public uint Parentid { get; set; }
        public int Ordering { get; set; }
        public string Metakey { get; set; }
        public string Metadesc { get; set; }
        public uint Access { get; set; }
        public uint Hits { get; set; }
        public string Metadata { get; set; }
    }
}
