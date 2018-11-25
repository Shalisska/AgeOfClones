using Application.Models.TableEditor;
using System.Collections.Generic;

namespace AgeOfClones.Areas.Management.Models
{
    public class ManagementTableViewModel
    {
        public ManagementTableViewModel(
            TableEditorModel table,
            string createActionName,
            string editActionName,
            string deleteActionName,
            IDictionary<string, string> createRouteValues =null,
            IDictionary<string, string> editRouteValues=null,
            IDictionary<string, string> deleteRouteValues =null)
        {
            Table = table;
            CreateActionName = createActionName;
            EditActionName = editActionName;
            DeleteActionName = deleteActionName;

            CreateRouteValues = createRouteValues;
            EditRouteValues = editRouteValues;
            DeleteRouteValues = deleteRouteValues;
        }

        public TableEditorModel Table { get; set; }

        public string CreateActionName { get; set; }
        public string EditActionName { get; set; }
        public string DeleteActionName { get; set; }

        public IDictionary<string, string> CreateRouteValues { get; set; }
        public IDictionary<string, string> EditRouteValues { get; set; }
        public IDictionary<string, string> DeleteRouteValues { get; set; }
    }
}
