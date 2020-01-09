﻿using System;
using System.Linq;
using Windows.UI.Xaml.Controls;

namespace UWPResourcesGallery.Model.Icon
{
    public class IconItem : IFilterable
    {
        public string Code { get; private set; }
        public string Name { get; private set; }

        public string Character { get; private set; }

        public string StringGlyph { get { return "&#x" + Code + ";"; } }

        public bool IsSymbol { get; }

        public IconItem(string code, string description)
        {
            Code = code;
            Name = description;
            Character = char.ConvertFromUtf32(Convert.ToInt32(Code, 16));
            IsSymbol = Enum.IsDefined(typeof(Symbol), description);

        }

        public bool FitsFilter(string[] filter)
        {
            return filter.All(entry => Code.Contains(entry, System.StringComparison.CurrentCultureIgnoreCase)
            || Name.Contains(entry, System.StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
