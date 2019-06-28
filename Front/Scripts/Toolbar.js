function toolbar(elementId) {
    var ElementId = elementId;
    var Buttons = new Array();

    this.INSERT = "INSERT";//增加
    this.DELETE = "DELETE";//删除
    this.UPDATE = "UPDATE";//修改
    this.SELECT = "SELECT";//查询
    this.SAVE = "SAVE";//保存
    this.REFRESH = "REFRESH";//刷新
    this.PREVIEW = "PREVIEW";//预览
    this.PRINT = "PRINT";//打印
    this.EXPORT = "EXPORT";//导出

    this.addDefault = function (id, functionName) {
        switch (id) {
            case this.INSERT:
                this.addItem(id, "添加", functionName,"plus-circle");
                break;
            case this.DELETE:
                this.addItem(id, "删除", functionName,"minus-circle");
                break;
            case this.UPDATE:
                this.addItem(id, "修改", functionName,"edit");
                break;
            case this.SELECT:
                this.addItem(id, "查询", functionName,"search");
                break;
            case this.SAVE:
                this.addItem(id, "保存", functionName<"save");
                break;
            case this.REFRESH:
                this.addItem(id, "刷新", functionName,"refresh");
                break;
            case this.PREVIEW:
                this.addItem(id, "预览", functionName,"eye");
                break;
            case this.PRINT:
                this.addItem(id, "打印", functionName,"print");
                break;
            case this.EXPORT:
                this.addItem(id, "导出", functionName,"file");
                break;
        }
    }

    this.addItem = function (id, text, functionName, icon) {
        Buttons[Buttons.length] = [id, text, functionName, icon];
    }

    this.initial = function () {
        let content = "<div class='btn-group' style='flex-wrap:wrap;-webkit-flex-wrap:wrap;'>";
        for (let index in Buttons) {
            let itemId = ElementId + "_" + Buttons[index][0];
            content += "<button type='button' class='btn btn-outline-primary' id='" + itemId
                + "'><i class='fa fa-" + Buttons[index][3]+"'></i> " + Buttons[index][1] + "</button > ";
        }
        content += "</div>";
        $("#" + ElementId).html(content);
        for (let index in Buttons) {
            let itemId = ElementId + "_" + Buttons[index][0];
            $("#" + itemId).bind("click", Buttons[index][2]);
        }
    }
}