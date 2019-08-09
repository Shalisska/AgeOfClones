using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgeOfClones.Models
{
    public class DEGridTable
    {
        public DEGridTableDataSource DataSource { get; set; }
        public List<DEGridTableColumn> Columns { get; set; }
    }

    public class DEGridTableDataSource
    {
        public string Type { get; set; }
        public string Key { get; set; }
        public Dictionary<string,string> LoadParams { get; set; }
        public string LoadUrl { get; set; }
        public string UpdateUrl { get; set; }
        public string CreateUrl { get; set; }
        public string DeleteUrl { get; set; }
    }

    public class DEGridTableColumn
    {
        public DEGridTableColumn() { }
        public DEGridTableColumn(string dataField)
        {
            IsSimple = true;
            DataField = dataField;
        }

        public bool IsSimple { get; set; }
        public string DataField { get; set; }
        public string Caption { get; set; }

        public DEGridTableLookup Lookup { get; set; }
    }

    public class DEGridTableLookup
    {
        public string ValueExpr { get; set; }
        public string DisplayExpr { get; set; }
        public DEGridTableDataSource DataSource { get; set; }
    }
}
