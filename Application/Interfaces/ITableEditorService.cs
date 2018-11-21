using Application.Models.TableEditor;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITableEditorService
    {
        IDictionary<string, string> GetValidationAttributes(Type entityType, string propertyName);

        TableEditorModel GetTable(Type entityType, string primaryKeyName, IEnumerable<object> entities, object entity);

        void AddColumn(TableEditorModel table, string propertyName);

        void AddColumn(TableEditorModel table, string propertyName, ControlType controlType, SelectList selectListItems);
    }
}
