using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models.TableEditor;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Application.Interfaces
{
    public interface ITableEditorService
    {
        IDictionary<string, string> GetValidationAttributes(Type entityType, string propertyName);

        TableEditorModel GetTable(Type entityType, string primaryKeyName, IEnumerable<object> entities);

        void AddColumn(TableEditorModel table, string propertyName, string name);

        void AddColumn(TableEditorModel table, string propertyName, string name, ControlType controlType, SelectList selectListItems);
    }
}
