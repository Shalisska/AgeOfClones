using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Models.TableEditor;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        public TableEditorModel GetTable(Type entityType, string primaryKeyName, IEnumerable<object> entities)
        {
            return new TableEditorModel(entityType, primaryKeyName, entities);
        }

        public IDictionary<string, string> GetValidationAttributes(Type entityType, string propertyName)
        {
            var validationAttributes = new Dictionary<string, string>();

            var propertyInfo = entityType.GetProperty(propertyName);

            var requiredAttribute = (RequiredAttribute)propertyInfo.GetCustomAttributes(typeof(RequiredAttribute), false).FirstOrDefault();
            var requiredErrorMessage = requiredAttribute.ErrorMessage ?? $"Требуется поле {propertyName}.";
            validationAttributes.Add("required", requiredErrorMessage);

            return validationAttributes;
        }
    }
}
