(function ($) {

    var getCatImage = function () {
        return new Promise(function (resolve, reject) {
            $.get("/getCatImage")
                .done(function (response) {
                    resolve(response);
                })
                .fail(function (error) {
                    reject(error);
                });
        })
    }

    var getDogImage = function () {
        return new Promise(function (resolve, reject) {
            $.get("/getDogImage")
                .done(function (response) {
                    resolve(response);
                })
                .fail(function (error) {
                    reject(error);
                });
        })
    }

    var delay = function (milliseconds) {
        return new Promise(function (resolve, reject) {
            setInterval(function () { resolve(); }, milliseconds);
        })
    }

    $(document).ready(function () {

        getCatImage().then(function (response) {
            $("#imgContainer").attr('src', response.image);
            return delay(3000);
        }).then(function (response) {
            $("#container").css("background-color", "red");
            return getDogImage();
        }).then(function (response) {
            $("#imgContainer").attr('src', response.image);
            return delay(5000);
        }).then(function (response) {
            $("#container").css("background-color", "green");
        })
    });


})(jQuery);