using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EverhoodModding
{

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class EventCommandInfo : Attribute
    {
        /// <summary>
        /// Metadata atribute for the Command class. 
        /// </summary>
        /// <param name="category">The category to place this command in.</param>
        /// <param name="commandName">The display name of the command.</param>
            public EventCommandInfo(string category, string commandName)
        {
            this.Category = category;
            this.CommandName = commandName;
             
        }

        public string Category { get; set; }
        public string CommandName { get; set; }
        
    }
}
