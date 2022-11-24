using ChildDevelopmentLibrary.Interfaces;
using ChildDevelopmentLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChildDevelopmentLibrary
{
    public class DBWebsite: IDBWebsite
    {
        public List<Program> Programs { get; set; } = new List<Program>();
        public List<Child> Children { get; set; } = new List<Child>();
    }
}
