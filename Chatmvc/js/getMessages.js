$(document).ready(function () {
    //Call EmpDetails jsonResult Method  
    $.getJSON("Home/Get",
        function (json) {
            var tr;
            //Append each row to html table  
            for (var i = 0; i < json.length; i++) {
                tr = $('<tr/>');
                tr.append("<td>" + json[i].Id + "</td>");
                tr.append("<td>" + json[i].IdRoom + "</td>");
                tr.append("<td>" + json[i].Date + "</td>");
                tr.append("<td>" + json[i].Text + "</td>");
                $('table').append(tr);
            }
        });
});  