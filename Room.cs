﻿using System;
using System.Diagnostics.Eventing.Reader;

namespace DungeonExplorer
{
    public class Room
    {
        // Test
        private string description;

        public Room(string description)
        {
            this.description = description;
        }

        public string GetDescription() { return this.description;  }        // Encapsulate room description 
            
    }
} 
