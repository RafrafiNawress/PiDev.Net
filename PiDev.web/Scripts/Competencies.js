$(document).ready(function () {
    $("#employees-list").kendoGrid({
        dataSource: {
            type: "json",
            transport: {
                read: {
                    // The remote service url.
                    url: "Competency/GetEmployees",

                    // The request type.
                    type: "GET",

                    // The data type of the returned result.
                    dataType: "json"
                }
            },
            pageSize: 20
        },
        dataBound: function () {
            $('#employees-list tr').dblclick(function () {
                var grid = $("#employees-list").data('kendoGrid');
                var data = grid.dataItem(grid.select());
                $("#employee-name").text(data.firstName + " " + data.lastName);
                $("#employees-list").hide();
                $("#employee-details").show();
            });
        },
        height: 550,
        groupable: true,
        sortable: true,
        noRecords: true,
        selectable: true,
        filterable: true,
        pageable: {
            refresh: true,
            pageSizes: true,
            buttonCount: 5
        },
        columns: [
            {
            field: "firstName",
            title: "First Name"
        }, {
            field: "lastName",
            title: "Last Name"
            },
            { field: "id", hidden: true }
        ]
    });

    $("#employee-job").kendoDropDownList({
        dataTextField: "name",
        dataValueField: "id",
        dataSource: {
            transport: {
                read: {
                    // The remote service url.
                    url: "Competency/GetJobs",

                    // The request type.
                    type: "GET",

                    // The data type of the returned result.
                    dataType: "json"
                }
            }
        },
        optionLabel: {
            name: "Assign a job...",
            id: ""
        },
        change: function (e) {
            var item = this.dataItem();
            $("#competencies-list").empty();
            if (item.id !== "") {
                $("#competencies-list").kendoGrid({
                    dataSource: {
                        type: "json",
                        transport: {
                            read: {
                                // The remote service url.
                                url: "Competency/GetJobCompetencies",

                                // The request type.
                                type: "GET",

                                // The data type of the returned result.
                                dataType: "json",
                                data: {
                                    id: item.id
                                }
                            }
                        },
                        pageSize: 20
                    },
                    dataBound: function () {

                    },
                    height: 250,
                    groupable: true,
                    sortable: true,
                    noRecords: true,
                    selectable: true,
                    filterable: true,
                    pageable: {
                        refresh: true,
                        pageSizes: true,
                        buttonCount: 5
                    },
                    columns: [
                        {
                            field: "name",
                            title: "Competency Name"
                        }, {
                            field: "level",
                            title: "Mastery"
                        },
                        { field: "id", hidden: true }
                    ]
                });
                $("#competencies-list").show();
            } else {
                $("#competencies-list").hide();
            }

        }
    });
    $("#back").click(function () {
        $("#employee-details").hide();
        $("#competencies-list").empty();
        $("#employees-list").show();
    });

});

