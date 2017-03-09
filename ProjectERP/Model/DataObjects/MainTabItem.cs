﻿using System.Windows.Controls;
using ProjectERP.Enums;

namespace ProjectERP.Model.DataObjects
{
    public class MainTabItem
    {
        public string Header { get; set; }
        public TabName TabName { get; set; }
        public UserControl Content { get; set; }
        public TabType TabType { get; set; }
        public object Extra { get; set; }
    }
}