using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeOfClones.Areas.Management.Models
{
    public class EntityEditorModel
    {
        public EntityEditorModel(
            Type entityType,
            string primaryKeyName,
            IEnumerable<object> entities,
            object currentEntity)
        {
            EntityType = entityType;
            PrimaryKeyName = primaryKeyName;
            Entities = entities;
            CurrentEntity = currentEntity;
            Fields = new List<EntityEditorFieldModel>();
        }

        public Type EntityType { get; set; }
        public string PrimaryKeyName { get; set; }
        public IEnumerable<object> Entities { get; set; }
        public object CurrentEntity { get; set; }
        public List<EntityEditorFieldModel> Fields { get; }

        public void AddColumn(string propertyName)
        {
            Fields.Add(new EntityEditorFieldModel(propertyName));
        }

        public void AddColumn(string propertyName, ControlType controlType, IDictionary<string, string> validationAttributes, SelectList selectList)
        {
            Fields.Add(new EntityEditorFieldModel(propertyName, controlType, validationAttributes, selectList));
        }

        public IDictionary<string, IEnumerable<EntityEditorCurrentFieldModel>> GetEntitiesForDisplay()
        {
            var rows = new Dictionary<string, IEnumerable<EntityEditorCurrentFieldModel>>();

            foreach (var item in Entities)
            {
                var id = GetCurrentEntityValue(item, PrimaryKeyName).ToString();

                var rowCells = GetEntityFieldsForDisplay(item);

                rows.Add(id.ToString(), rowCells);
            }

            return rows;
        }

        public IDictionary<string, IEnumerable<EntityEditorCurrentFieldModel>> GetEntities()
        {
            var rows = new Dictionary<string, IEnumerable<EntityEditorCurrentFieldModel>>();

            foreach (var item in Entities)
            {
                var id = GetCurrentEntityValue(item, PrimaryKeyName).ToString();

                var rowCells = GetEntityFields(item);

                rows.Add(id.ToString(), rowCells);
            }

            return rows;
        }

        public IEnumerable<EntityEditorCurrentFieldModel> GetCurrentEntity()
        {
            var entity = GetEntityFields(CurrentEntity);

            return entity;
        }

        public IEnumerable<EntityEditorCurrentFieldModel> GetNewEntity()
        {
            var entity = GetEntityFieldsForCreate();

            return entity;
        }

        private IEnumerable<EntityEditorCurrentFieldModel> GetEntityFieldsForDisplay(object entity)
        {
            var fields = Fields.Select(field => new EntityEditorCurrentFieldModel(
                    field.PropertyName,
                    GetCurrentEntityValue(entity, field.PropertyName).ToString(),
                    field.SelectList
                    ));

            return fields;
        }

        private IEnumerable<EntityEditorCurrentFieldModel> GetEntityFields(object entity)
        {
            var fields = Fields.Select(field => new EntityEditorCurrentFieldModel(
                    field.PropertyName,
                    GetCurrentEntityValue(entity, field.PropertyName).ToString(),
                    field.IsEditable,
                    field.ControlType,
                    field.ValidationAttributes,
                    field.SelectList
                    )).ToList();

            return fields;
        }

        private IEnumerable<EntityEditorCurrentFieldModel> GetEntityFieldsForCreate()
        {
            var fields = Fields.Select(field => new EntityEditorCurrentFieldModel(
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

    public class EntityEditorFieldModel
    {
        internal EntityEditorFieldModel(
            string propertyName)
        {
            PropertyName = propertyName;
            Name = PropertyName;
            IsEditable = false;
        }

        internal EntityEditorFieldModel(
            string propertyName,
            ControlType controlType,
            IDictionary<string, string> validationAttributes,
            SelectList selectList)
        {
            PropertyName = propertyName;
            Name = PropertyName;
            IsEditable = true;
            ControlType = controlType;
            ValidationAttributes = validationAttributes;
            SelectList = selectList;
        }

        public string PropertyName { get; set; }
        public string Name { get; set; }
        public bool IsEditable { get; set; }
        public ControlType ControlType { get; set; }
        public IDictionary<string, string> ValidationAttributes { get; set; }
        public SelectList SelectList { get; set; }
    }

    public class EntityEditorCurrentFieldModel
    {
        internal EntityEditorCurrentFieldModel(
            string propertyName,
            string value,
            SelectList selectList)
        {
            PropertyName = propertyName;
            Value = value;
            SelectList = GetSelectList(selectList, Value);
        }

        internal EntityEditorCurrentFieldModel(
            string propertyName,
            string value,
            bool isEditable,
            ControlType controlType,
            IDictionary<string, string> validationAttributes,
            SelectList selectList)
        {
            PropertyName = propertyName;
            Value = value;
            IsEditable = isEditable;
            ControlType = controlType;
            ValidationAttributes = validationAttributes;
            SelectList = GetSelectList(selectList, Value);
        }

        public string PropertyName { get; set; }
        public string Value { get; set; }

        public bool IsEditable { get; set; }
        public ControlType ControlType { get; set; }

        public IDictionary<string, string> ValidationAttributes { get; set; }
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
