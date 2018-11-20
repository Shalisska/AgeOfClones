using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IEntityEditorService
    {
        IDictionary<string, string> GetValidationAttributes(Type entityType, string propertyName);

        //TableEditorModel GetTable(Type entityType, string primaryKeyName, IEnumerable<object> entities);

        //void AddColumn(TableEditorModel table, string propertyName);

        //void AddColumn(TableEditorModel table, string propertyName, ControlType controlType, SelectList selectListItems);
    }
}
