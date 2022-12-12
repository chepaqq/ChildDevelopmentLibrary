using ChildDevelopmentLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChildDevelopmentLibrary.Interfaces
{
    public interface IDBWebsite
    {
        public List<Program> Programs { get; set; }
        public List<Child> Children { get; set; }
    }
}
