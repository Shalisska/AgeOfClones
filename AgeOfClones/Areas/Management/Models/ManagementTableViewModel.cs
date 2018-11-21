using Application.Models.TableEditor;

namespace AgeOfClones.Areas.Management.Models
{
    public class ManagementTableViewModel
    {
        public ManagementTableViewModel(
            TableEditorModel table,
            string createActionName,
            string editActionName,
            string deleteActionName)
        {
            Table = table;
            CreateActionName = createActionName;
            EditActionName = editActionName;
            DeleteActionName = deleteActionName;
        }

        public TableEditorModel Table { get; set; }

        public string CreateActionName { get; set; }
        public string EditActionName { get; set; }
        public string DeleteActionName { get; set; }
    }
}
