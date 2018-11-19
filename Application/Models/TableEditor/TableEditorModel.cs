using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.TableEditor
{
    public class TableEditorModel
    {
        public TableEditorModel(
            Type entityType,
            string primaryKeyName,
            IEnumerable<object> entities)
        {
            EntityType = entityType;
            PrimaryKeyName = primaryKeyName;
            Entities = entities;
            Columns = new List<TableEditorColumnModel>();
        }

        public Type EntityType { get; set; }
        public string PrimaryKeyName { get; set; }
        public IEnumerable<object> Entities { get; set; }
        public List<TableEditorColumnModel> Columns { get; }

        public void AddColumn(string propertyName, string name)
        {
            Columns.Add(new TableEditorColumnModel(propertyName, name));
        }

        public void AddColumn(string propertyName, string name, ControlType controlType, IDictionary<string, string> validationAttributes, SelectList selectListItems)
        {
            Columns.Add(new TableEditorColumnModel(propertyName, name, controlType, validationAttributes, selectListItems));
        }

        public IDictionary<string, IEnumerable<TableEditorCellModel>> GetTableRows()
        {
            var rows = new Dictionary<string, IEnumerable<TableEditorCellModel>>();

            foreach (var item in Entities)
            {
                var id = GetCurrentEntityValue(item, PrimaryKeyName).ToString();

                var rowCells = Columns.Select(column => new TableEditorCellModel(
                    id,
                    column.PropertyName,
                    GetCurrentEntityValue(item, column.PropertyName).ToString(),
                    column.IsEditable,
                    column.ControlType,
                    column.ValidationAttributes,
                    column.SelectListItems,
                    GetCurrentEntityValue(item, column.PropertyName)
                    ));

                rows.Add(id.ToString(), rowCells);
            }

            return rows;
        }

        private object GetCurrentEntityValue(object entity, string propertyName)
        {
            return EntityType.GetProperty(propertyName).GetValue(entity, null);
        }
    }

    public class TableEditorColumnModel
    {
        internal TableEditorColumnModel(
            string propertyName,
            string name)
        {
            PropertyName = propertyName;
            Name = name;
            IsEditable = false;
        }

        internal TableEditorColumnModel(
            string propertyName,
            string name,
            ControlType controlType,
            IDictionary<string, string> validationAttributes,
            SelectList selectListItems)
        {
            PropertyName = propertyName;
            Name = name;
            IsEditable = true;
            ControlType = ControlType;
            ValidationAttributes = validationAttributes;
            SelectListItems = selectListItems;
        }

        public string PropertyName { get; set; }
        public string Name { get; set; }
        public bool IsEditable { get; set; }
        public ControlType ControlType { get; set; }
        public IDictionary<string, string> ValidationAttributes { get; set; }
        public SelectList SelectListItems { get; set; }
    }
    public class TableEditorCellModel
    {
        internal TableEditorCellModel(
            string id,
            string propertyName,
            string value,
            bool isEditable,
            ControlType controlType,
            IDictionary<string, string> validationAttributes,
            SelectList selectListItems,
            object selectedItem)
        {
            TagId = $"{propertyName}-{id}";
            PropertyName = propertyName;
            Value = value;
            IsEditable = isEditable;
            ControlType = controlType;
            ValidationAttributes = validationAttributes;
            SelectListItems = selectListItems != null && selectListItems.Count() > 0 ? new SelectList(selectListItems.Items, selectListItems.DataValueField, selectListItems.DataTextField, selectedItem) : null;
        }

        public string TagId { get; set; }
        public string PropertyName { get; set; }
        public string Value { get; set; }

        public bool IsEditable { get; set; }
        public ControlType ControlType { get; set; }

        public IDictionary<string, string> ValidationAttributes { get; set; }
        public SelectList SelectListItems { get; set; }
    }

    public enum ControlType
    {
        Hidden = 1,
        Input = 2,
        Select = 3
    }
}
