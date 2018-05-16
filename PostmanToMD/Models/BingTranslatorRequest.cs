using System;
using System.Collections.Generic;
using System.Text;

namespace PostmanToMD.Models
{
    class BingTranslatorRequest
    {
        public string SourceLanguage { get; set; }

        public string TargetLanguage { get; set; }
        public string Text { get; set; }
    }
}
