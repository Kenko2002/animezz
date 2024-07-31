$(document).ready(function (e) {

    var username = encodeURIComponent(getQueryParam('username'));

    if (username != null) {
        $("#franquias_button").attr("href", "./franquias.html?username=" + username);
        $("#generos_button").attr("href", "./generos.html?username=" + username);
        $("#inicio_button").attr("href", "./index_logado.html?login=" + username);

        $("#login-button").css("display", "none");
        $("#cadastro-button").css("display", "none");
    }
    if (username === null || username === "null") {
        $("#inicio_button").attr("href", "./index.html");
    }


    $("#query_pesquisa").empty();
    //pesquisando franquias
    $.ajax({
        type: 'GET', // Ou 'GET', dependendo da sua API
        url: 'https://localhost:7298/naologado/GetAllFranquias',
        contentType: 'application/json',
        dataType: 'json',
        success: function (data) {
            console.log("Pesquisando...");
            console.log(data);
            console.log("Pesquisa concluída!");

            data.forEach(data => {
                $("#query_pesquisa").append(`

                    <a href="./franquia.html?franquia_nome=${encodeURIComponent(data.nome)}&username=${encodeURIComponent(username)}"  class="my-2">
                        <div class="inline-block text-center">
                            <img style='width:180px;height:250px;' franquia_nome="${data.nome}" class="m-4 img-fluid" src="${data.animes[0].link_capa}" alt="Capa">
                            <p>${data.nome}</p>
                        </div>
                    </a>

                    `);
            });

            




        },
        error: function (xhr, status, error) {
            console.log("Erro de Carregamento", xhr.responseText); // Exibe detalhes sobre o erro no console
        }
    });

    



});

