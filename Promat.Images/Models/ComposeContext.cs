using System.Collections.Generic;

namespace Promat.Images.Models {
    public class ComposeContext
    {
        internal CanvasConfiguration Configuration { get; set; }
        internal List<ImageComposeConfiguration> Images { get; set; } = new List<ImageComposeConfiguration>();
    }
}