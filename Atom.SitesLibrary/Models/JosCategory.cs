using System;
using System.Collections.Generic;

#nullable disable

namespace Atom.VectorSiteLibrary.Models
{
    public partial class JosCategory
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Image { get; set; }
        public string Section { get; set; }
        public string ImagePosition { get; set; }
        public string Description { get; set; }
        public bool Published { get; set; }
        public uint CheckedOut { get; set; }
        public DateTime CheckedOutTime { get; set; }
        public string Editor { get; set; }
        public int Ordering { get; set; }
        public byte Access { get; set; }
        public int Count { get; set; }
        public string Params { get; set; }
    }
}
