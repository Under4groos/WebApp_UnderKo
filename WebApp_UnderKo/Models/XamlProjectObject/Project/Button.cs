﻿using System.Xml.Serialization;
using WebApp_UnderKo.Models.XamlProjectObject.Project.Base;

namespace WebApp_UnderKo.Models.XamlProjectObject.Project
{
    public class Button : base_XamlData
    {
        [XmlAttribute]
        public string Text { get; set; } = string.Empty;
        public string Command { get; set; } = string.Empty;
    }
}