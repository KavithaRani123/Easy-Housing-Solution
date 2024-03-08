using System;
using System.Collections.Generic;

namespace EasyHousingSolutions_WebUI.Models
{
    public partial class EhsImage
    {
        public int ImageId { get; set; }
        public int PropertyId { get; set; }
        public byte[] Image { get; set; } = null!;

        public virtual EhsProperty Property { get; set; } = null!;
    }
}
