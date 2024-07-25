$(document).ready(function (e) {


    var username = encodeURIComponent(getQueryParam('username'));

    if (username != null) {
        $("#franquias_button").attr("href", "./franquias.html?username=" + username);
        $("#generos_button").attr("href", "./generos.html?username=" + username);
        $("#inicio_button").attr("href", "./index_logado.html?login=" + username);

        $("#login_button").css("display", "none");
        $("#cadastro_button").css("display", "none");
    }


    //Carregar generos
    $.ajax({
        type: 'GET', // Ou 'GET', dependendo da sua API
        url: 'https://localhost:7298/naologado/GetAllGeneros',
        contentType: 'application/json',
        dataType: 'json',
        success: function (data) {
            console.log("Pesquisando Generos...");
            console.log(data);
            console.log("Pesquisa concluída!");
            $("#query_pesquisa").empty();
            data.forEach(data => {
                $("#query_pesquisa").append(`
                     <a href='./pesquisa.html?query=${encodeURIComponent(data.nome)}&username=${encodeURIComponent(username)}' class="btn btn-secondary bg-dark btn-genero text-light rounded" style="margin:7px">${data.nome}</a>`
                );
            });



        },
        error: function (xhr, status, error) {
            console.log("Erro de Carregamento", xhr.responseText); // Exibe detalhes sobre o erro no console
        }
    });

});