using System;
using System.Collections.Generic;

#nullable disable

namespace EasyHousingSolution_WebAPI.Model
{
    public partial class EhsImage
    {
        public int ImageId { get; set; }
        public int PropertyId { get; set; }
        public byte[] Image { get; set; }

        public virtual EhsProperty Property { get; set; }
    }
}
