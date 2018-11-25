using Application.Models.TableEditor;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface ITableEditorService
    {
        IDictionary<string, string> GetValidationAttributes(Type entityType, string propertyName);

        TableEditorModel GetTable(string tableName, Type entityType, string primaryKeyName, IEnumerable<object> entities, object entity);

        void AddColumn(TableEditorModel table, string propertyName, string name);

        void AddColumn(TableEditorModel table, string propertyName, string name, ControlType controlType, SelectList selectListItems);
    }
}
