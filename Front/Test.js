$(function () {
    var theToolbar = new toolbar("ToolbarArea");
    theToolbar.addDefault(theToolbar.INSERT, add);
    theToolbar.addDefault(theToolbar.DELETE, add);
    theToolbar.addDefault(theToolbar.UPDATE, add);
    theToolbar.addDefault(theToolbar.SELECT, add);
    theToolbar.addItem("test", "测试", add);

    theToolbar.initial();

    $.ajax({
        url: "/Ajax/Ajax_Navigation.ashx",
        data: "Root=root",
        async: false,
        ifModified: true,
        success: function (data) {
            $("#NavigationArea").html(data);
        }
    });

    $.ajax({
        url: "/Ajax/Ajax_Table.ashx",
        data: "",
        async: false,
        ifModified: true,
        success: function (data) {
            $("#TableArea").html(data);
        }
    });

    $.ajax({
        url: "/Ajax/Ajax_Pager.ashx",
        data: "RecordCount=100&PageIndex=1&PageCount=10",
        async: false,
        ifModified: true,
        success: function (data) {
            $("#PagerArea").html(data);
        }
    });
});

$(document).ready(function () {
});

function add() {
    //alert("add");
}