using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Models.TableEditor
{
    public class TableEditorModel
    {
        public TableEditorModel(
            string tableName,
            Type entityType,
            string primaryKeyName,
            IEnumerable<object> entities,
            object currentEntity)
        {
            TableName = tableName;
            EntityType = entityType;
            PrimaryKeyName = primaryKeyName;
            Entities = entities;
            CurrentEntity = currentEntity;
            Columns = new List<TableEditorColumnModel>();
        }

        public string TableName { get; set; }
        public Type EntityType { get; set; }
        public string PrimaryKeyName { get; set; }
        public IEnumerable<object> Entities { get; set; }
        public object CurrentEntity { get; set; }
        public List<TableEditorColumnModel> Columns { get; }

        internal void AddColumn(string propertyName, string name)
        {
            Columns.Add(new TableEditorColumnModel(propertyName, name));
        }

        internal void AddColumn(string propertyName, string name, ControlType controlType, IDictionary<string, string> validationAttributes, SelectList selectList)
        {
            Columns.Add(new TableEditorColumnModel(propertyName, name, controlType, validationAttributes, selectList));
        }

        public IEnumerable<TableEditorRowModel> GetRowsForDisplay()
        {
            var rows = Entities.Select(r => new TableEditorRowModel(
                  GetCurrentEntityValue(r, PrimaryKeyName).ToString(),
                  GetCellsForDisplay(r)));

            return rows;
        }

        public IEnumerable<TableEditorRowModel> GetRows()
        {
            var rows = Entities.Select(r => new TableEditorRowModel(
                  GetCurrentEntityValue(r, PrimaryKeyName).ToString(),
                  GetCells(r)));

            return rows;
        }

        public IEnumerable<TableEditorCellModel> GetCurrentRow()
        {
            var entity = GetCells(CurrentEntity);

            return entity;
        }

        public IEnumerable<TableEditorCellModel> GetNewRow()
        {
            return GetNewRow(null);
        }
        public IEnumerable<TableEditorCellModel> GetNewRow(IDictionary<string, string> parameters)
        {
            var entity = GetCellsForNewRow(parameters);

            return entity;
        }

        private IEnumerable<TableEditorCellModel> GetCellsForDisplay(object entity)
        {
            var fields = Columns.Select(field => new TableEditorCellModel(
                    field.PropertyName,
                    GetCurrentEntityValue(entity, field.PropertyName).ToString(),
                    field.SelectList
                    ));

            return fields;
        }

        private IEnumerable<TableEditorCellModel> GetCells(object entity)
        {
            var fields = Columns.Select(field => new TableEditorCellModel(
                    field.PropertyName,
                    GetCurrentEntityValue(entity, field.PropertyName).ToString(),
                    field.IsEditable,
                    field.ControlType,
                    field.ValidationAttributes,
                    field.SelectList
                    )).ToList();

            return fields;
        }

        private IEnumerable<TableEditorCellModel> GetCellsForNewRow(IDictionary<string, string> parameters)
        {
            var fields = Columns.Select(field => new TableEditorCellModel(
                    field.PropertyName,
                    parameters != null && parameters.ContainsKey(field.PropertyName) ? parameters[field.PropertyName] : null,
                    field.IsEditable,
                    field.ControlType,
                    field.ValidationAttributes,
                    field.SelectList
                    ));

            return fields;
        }

        private object GetCurrentEntityValue(object entity, string propertyName)
        {
            if (propertyName == null)
                return null;
            return EntityType.GetProperty(propertyName).GetValue(entity, null);
        }
    }

    public class TableEditorRowModel
    {
        public TableEditorRowModel(
            string id,
            IEnumerable<TableEditorCellModel> cells)
        {
            Id = id;
            Cells = cells;
        }

        public string Id { get; set; }
        public IEnumerable<TableEditorCellModel> Cells { get; set; }
    }

    public class TableEditorBaseFieldProperties
    {
        internal TableEditorBaseFieldProperties() { }

        internal TableEditorBaseFieldProperties(
            string propertyName,
            ControlType controlType,
            IDictionary<string, string> validationAttributes)
        {
            PropertyName = propertyName;
            ControlType = controlType;
            ValidationAttributes = validationAttributes;
        }

        public string PropertyName { get; set; }
        public ControlType ControlType { get; set; }
        public IDictionary<string, string> ValidationAttributes { get; set; }
    }

    public class TableEditorColumnModel : TableEditorBaseFieldProperties
    {
        internal TableEditorColumnModel(
            string propertyName,
            string name)
        {
            PropertyName = propertyName;
            Name = name ?? PropertyName;
            IsEditable = false;
        }

        internal TableEditorColumnModel(
            string propertyName,
            string name,
            ControlType controlType,
            IDictionary<string, string> validationAttributes,
            SelectList selectList) : base(propertyName, controlType, validationAttributes)
        {
            Name = name ?? PropertyName;
            IsEditable = true;
            SelectList = selectList;
        }

        public string Name { get; set; }
        public bool IsEditable { get; set; }
        public SelectList SelectList { get; set; }
    }

    public class TableEditorCellModel : TableEditorBaseFieldProperties
    {
        internal TableEditorCellModel(
            string propertyName,
            string value,
            SelectList selectList)
        {
            PropertyName = propertyName;
            Value = value;
            SelectList = GetSelectList(selectList, Value);
        }

        internal TableEditorCellModel(
            string propertyName,
            string value,
            bool isEditable,
            ControlType controlType,
            IDictionary<string, string> validationAttributes,
            SelectList selectList) : base(propertyName, controlType, validationAttributes)
        {
            Value = value;
            IsEditable = isEditable;
            SelectList = GetSelectList(selectList, Value);
        }

        public string Value { get; set; }

        public bool IsEditable { get; set; }
        public SelectList SelectList { get; set; }

        private SelectList GetSelectList(SelectList selectList, object selectedItem)
        {
            if (selectList != null && selectList.Count() > 0)
            {
                return selectedItem != null ? new SelectList(selectList.Items, selectList.DataValueField, selectList.DataTextField, selectedItem) : selectList;
            }
            else
            {
                return null;
            }
        }
    }

    public enum ControlType
    {
        Hidden = 1,
        Input = 2,
        Select = 3
    }
}
