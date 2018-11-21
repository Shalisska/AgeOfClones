using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Models.TableEditor
{
    public class TableEditorModel
    {
        public TableEditorModel(
            Type entityType,
            string primaryKeyName,
            IEnumerable<object> entities,
            object currentEntity)
        {
            EntityType = entityType;
            PrimaryKeyName = primaryKeyName;
            Entities = entities;
            CurrentEntity = currentEntity;
            Columns = new List<TableEditorColumnModel>();
        }

        public Type EntityType { get; set; }
        public string PrimaryKeyName { get; set; }
        public IEnumerable<object> Entities { get; set; }
        public object CurrentEntity { get; set; }
        public List<TableEditorColumnModel> Columns { get; }

        internal void AddColumn(string propertyName)
        {
            Columns.Add(new TableEditorColumnModel(propertyName));
        }

        internal void AddColumn(string propertyName, ControlType controlType, IDictionary<string, string> validationAttributes, SelectList selectList)
        {
            Columns.Add(new TableEditorColumnModel(propertyName, controlType, validationAttributes, selectList));
        }

        public IDictionary<string, IEnumerable<TableEditorCellModel>> GetRowsForDisplay()
        {
            var rows = new Dictionary<string, IEnumerable<TableEditorCellModel>>();

            foreach (var item in Entities)
            {
                var id = GetCurrentEntityValue(item, PrimaryKeyName).ToString();

                var rowCells = GetCellsForDisplay(item);

                rows.Add(id.ToString(), rowCells);
            }

            return rows;
        }

        public IDictionary<string, IEnumerable<TableEditorCellModel>> GetRows()
        {
            var rows = new Dictionary<string, IEnumerable<TableEditorCellModel>>();

            foreach (var item in Entities)
            {
                var id = GetCurrentEntityValue(item, PrimaryKeyName).ToString();

                var rowCells = GetCells(item);

                rows.Add(id.ToString(), rowCells);
            }

            return rows;
        }

        public IEnumerable<TableEditorCellModel> GetCurrentRow()
        {
            var entity = GetCells(CurrentEntity);

            return entity;
        }

        public IEnumerable<TableEditorCellModel> GetNewRow()
        {
            var entity = GetCellsForNewRow();

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

        private IEnumerable<TableEditorCellModel> GetCellsForNewRow()
        {
            var fields = Columns.Select(field => new TableEditorCellModel(
                    field.PropertyName,
                    null,
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
            string propertyName)
        {
            PropertyName = propertyName;
            Name = PropertyName;
            IsEditable = false;
        }

        internal TableEditorColumnModel(
            string propertyName,
            ControlType controlType,
            IDictionary<string, string> validationAttributes,
            SelectList selectList) : base(propertyName, controlType, validationAttributes)
        {
            Name = PropertyName;
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
