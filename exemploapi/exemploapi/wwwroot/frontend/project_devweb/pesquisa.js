$(document).ready(function (e) {
    //SEARCHBAR
    $("#search-button").click(function () {
        var username = getQueryParam("username");
        var login = getQueryParam("login");

        if (username == null && login==null) {
            window.location.href = 'pesquisa.html?query=' + encodeURIComponent($("#search-input").val());
        }
        else {
            if (login != null) {
                window.location.href = 'pesquisa.html?query=' + encodeURIComponent($("#search-input").val()) + "&username=" + encodeURIComponent(login);
            }
            if (username != null) {
                window.location.href = 'pesquisa.html?query=' + encodeURIComponent($("#search-input").val()) + "&username=" + encodeURIComponent(username);
            }
            
        }

    });



    //FIM SEARCHBAR
    



});

function getQueryParam(param) {
    var urlParams = new URLSearchParams(window.location.search);
    return urlParams.get(param);
}