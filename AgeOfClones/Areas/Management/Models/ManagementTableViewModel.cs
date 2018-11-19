using Application.Models.TableEditor;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgeOfClones.Areas.Management.Models
{
    public class ManagementTableViewModel
    {
        public ManagementTableViewModel(
            TableEditorModel table)
        {
            Table = table;
        }

        public TableEditorModel Table { get; set; }
    }
}
