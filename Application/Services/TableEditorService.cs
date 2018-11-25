using Application.Interfaces;
using Application.Models.TableEditor;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Application.Services
{
    public class TableEditorService : ITableEditorService
    {
        public void AddColumn(TableEditorModel table, string propertyName, string name)
        {
            table.AddColumn(propertyName, name);
        }

        public void AddColumn(TableEditorModel table, string propertyName, string name, ControlType controlType, SelectList selectListItems)
        {
            var validationAttributes = GetValidationAttributes(table.EntityType, propertyName);

            table.AddColumn(propertyName, name, controlType, validationAttributes, selectListItems);
        }

        public TableEditorModel GetTable(string tableName, Type entityType, string primaryKeyName, IEnumerable<object> entities, object entity)
        {
            return new TableEditorModel(tableName, entityType, primaryKeyName, entities, entity);
        }

        public IDictionary<string, string> GetValidationAttributes(Type entityType, string propertyName)
        {
            var validationAttributes = new Dictionary<string, string>();

            var propertyInfo = entityType.GetProperty(propertyName);

            var requiredAttribute = (RequiredAttribute)propertyInfo.GetCustomAttributes(typeof(RequiredAttribute), false).FirstOrDefault();
            var requiredErrorMessage = requiredAttribute?.ErrorMessage ?? $"Требуется поле {propertyName}.";
            validationAttributes.Add("required", requiredErrorMessage);

            return validationAttributes;
        }
    }
}
