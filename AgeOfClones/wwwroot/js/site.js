var clonesUtils = {
    dxDataGridExt: function () {
        var init = function (selector, opts) {
            var defaults = {
                editing: {
                    mode: "batch",
                    allowUpdating: true,
                    selectTextOnEditStart: true,
                    startEditAction: "click"
                },

                groupPanel: { visible: true },
                filterRow: { visible: true },
                headerFilter: { visible: true },
                sorting: {
                    mode: "multiple"
                },
                remoteOperations: true,
                scrolling: {
                    mode: "virtual",
                    rowRenderingMode: "virtual"
                },
                paging: {
                    pageSize: 50
                },
                customizeColumns: function (columns) {
                    columns[0].width = 70;
                },
                allowColumnResizing: true,
                columnResizingMode: "widget",
                showRowLines: true,
                rowAlternationEnabled: true,
                showBorders: true,
                columnMinWidth: 50
            };

            $.extend(defaults, opts);

            $(selector).dxDataGrid(defaults);
        }

        return {
            init: init
        };
    }
};
