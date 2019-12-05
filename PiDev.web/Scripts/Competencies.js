$(document).ready(function () {

    var notification = $("#notification").kendoNotification({
        position: {
            pinned: true,
            top: 30,
            right: 30
        },
        autoHideAfter: 3000,
        stacking: "down",
        templates: [{
            type: "success",
            template: $("#successTemplate").html()
        }]

    }).data("kendoNotification");

    $("#job-filter").kendoDropDownList({
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
            name: "Select a job...",
            id: ""
        },
        change: function (e) {
            var grid = $("#employees-list").data('kendoGrid');
            if ($("#job-filter").data("kendoDropDownList").dataItem().id !== "") {
                grid.showColumn("score");
            } else {

                grid.hideColumn("score");
            }
           grid.dataSource.read();
            grid.refresh();

        }
    });

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
                    dataType: "json",
                    data: function () {

                        var jobId = $("#job-filter").data("kendoDropDownList").dataItem().id;
                        return { jobId: (jobId == "" ? -1: jobId) };
                    }
                }
            },
            pageSize: 20
        },
        dataBound: function () {
            $('#employees-list tr').dblclick(function () {
                var grid = $("#employees-list").data('kendoGrid');
                var data = grid.dataItem(grid.select());
                var jobdropdown = $("#employee-job").data("kendoDropDownList");
                jobdropdown.dataSource.read();
                jobdropdown.refresh();
                jobdropdown.value(data.jobId);
                jobdropdown.trigger("change");
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
            }, {
                field: "jobName",
                title: "Job"
            },
            {
                field: "score",
                title: "Score",
                hidden: true
            },
            {
                field: "jobId",
                hidden: true
            },
            {
                field: "id",
                hidden: true
            }
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
                $("#save").show();
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
                $("#save").hide();
            }

        }
    });
    $("#back").click(function () {
        $("#employee-details").hide();
        $("#competencies-list").empty();
        $("#competencies-list").hide();
        $("#employees-list").show();
        $("#employees-list").data('kendoGrid').dataSource.read();
        $("#employees-list").data('kendoGrid').refresh();
    });

    $("#save").click(function () {
        var jobId = $("#employee-job").data("kendoDropDownList").dataItem().id;
        var userId = $("#employees-list").data('kendoGrid').dataItem($("#employees-list").data('kendoGrid').select()).id;
        $.post("Competency/AssignJob", { empId: userId, jobId: jobId }, function (e) {
            notification.show({
                message: "Assign Successful"
            }, "success");
            $("#back").click();
        });
    });

});

