using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectERP.ViewModel.Interfaces;

namespace ProjectERP.Model.Messages
{
    public class ContentViewMessage
    {
        public IContentView ContentView { get; set; }
    }
}
