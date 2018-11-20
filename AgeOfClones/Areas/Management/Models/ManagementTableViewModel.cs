﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgeOfClones.Areas.Management.Models
{
    public class ManagementTableViewModel
    {
        public ManagementTableViewModel(
            EntityEditorModel table,
            string createActionName,
            string editActionName,
            string deleteActionName)
        {
            Table = table;
            CreateActionName = createActionName;
            EditActionName = editActionName;
            DeleteActionName = deleteActionName;
        }

        public EntityEditorModel Table { get; set; }

        public string CreateActionName { get; set; }
        public string EditActionName { get; set; }
        public string DeleteActionName { get; set; }
    }
}