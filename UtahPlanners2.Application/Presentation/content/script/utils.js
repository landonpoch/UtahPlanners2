var deleteMe = {};
var utils = (function () {
    var guid = function () {
        return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'
            .replace(/[xy]/g, function (c) {
                var r = Math.random() * 16 | 0, v = c == 'x' ? r : r & 0x3 | 0x8; return v.toString(16);
            });
    };

    var exampleGet = function() {
        $.ajax({
            url: 'api/lookup',
            type: 'GET',
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                console.log(data);
                deleteMe = data[2];
            }
        });
    };

    var examplePut = function() {
        $.ajax({
            url: 'api/lookup',
            type: 'PUT',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify({
                Id: guid(),
                Type: 'Property',
                Description: 'Apartments'
            })
        });
    };

    var exampleDelete = function (deleteMe) {
        $.ajax({
            url: 'api/lookup',
            type: 'DELETE',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(deleteMe)
        });
    };

    return {
        guid: guid,
        exampleGet: exampleGet,
        examplePut: examplePut,
        exampleDelete: exampleDelete
    };
}());