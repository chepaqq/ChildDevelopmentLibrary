﻿using System;

namespace ChildDevelopmentLibrary
{    
    public class Child
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Period Period { get; set; } = Period.Signed;
    }
}
