$(document).ready(function (e) {

    var username = encodeURIComponent(getQueryParam('username'));

    if (username != null) {
        $("#franquias_button").attr("href", "./franquias.html?username=" + username);
        $("#generos_button").attr("href", "./generos.html?username=" + username);
        $("#inicio_button").attr("href", "./index_logado.html?login=" + username);

        $("#login_button").css("display", "none");
        $("#cadastro_button").css("display", "none");
    }


    var query = getQueryParam("query");
    $("#pesquisa_visualizacao").append( query );


    $("#query_pesquisa").empty();
    //pesquisando franquias
    $.ajax({
        type: 'GET', // Ou 'GET', dependendo da sua API
        url: 'https://localhost:7298/naologado/GetByNameFranquia?franquia_nome=' + encodeURIComponent(query),
        contentType: 'application/json',
        dataType: 'json',
        success: function (data) {
            console.log("Pesquisando...");
            console.log(data);
            console.log("Pesquisa concluída!");

            if (username != null) {
                $("#query_pesquisa").append(`

                    <a href="./franquia.html?franquia_nome=${encodeURIComponent(data.nome)}&username=${encodeURIComponent(username)}"  class="my-2">
                        <div class="inline-block text-center">
                            <img style='width:180px;height:250px;' franquia_nome="${data.nome}" class="m-4 img-fluid" src="${data.animes[0].link_capa}" alt="Capa">
                            <p>${data.nome}</p>
                        </div>
                    </a>

                    `);
            }
            else {
                $("#query_pesquisa").append(`

                    <a href="./franquia.html?franquia_nome=${encodeURIComponent(data.nome)}"  class="my-2">
                        <div class="inline-block text-center">
                            <img style='width:180px;height:250px;' franquia_nome="${data.nome}" class="m-4 img-fluid" src="${data.animes[0].link_capa}" alt="Capa">
                            <p>${data.nome}</p>
                        </div>
                    </a>

                    `);
            }
            
            



        },
        error: function (xhr, status, error) {
            console.log("Erro de Carregamento", xhr.responseText); // Exibe detalhes sobre o erro no console
        }
    });

    //pesquisando por gênero
    $.ajax({
        type: 'GET', // Ou 'GET', dependendo da sua API
        url: 'https://localhost:7298/naologado/GetByGeneroFranquia?genero_nome=' + encodeURIComponent(query),
        contentType: 'application/json',
        dataType: 'json',
        success: function (data) {
            console.log("Pesquisando por genero...");
            console.log(data);
            console.log("Pesquisa por gênero concluída!");

            data.forEach(data => {

                if (username != null) {
                    $("#query_pesquisa").append(`

                    <a href="./franquia.html?franquia_nome=${encodeURIComponent(data.nome)}&username=${encodeURIComponent(username)}"  class="my-2">
                        <div class="inline-block text-center">
                            <img style='width:180px;height:250px;' franquia_nome="${data.nome}" class="m-4 img-fluid" src="${data.animes[0].link_capa}" alt="Capa">
                            <p>${data.nome}</p>
                        </div>
                    </a>

                    `);
                }
                else {
                    $("#query_pesquisa").append(`

                    <a href="./franquia.html?franquia_nome=${encodeURIComponent(data.nome)}"  class="my-2">
                        <div class="inline-block text-center">
                            <img style='width:180px;height:250px;' franquia_nome="${data.nome}" class="m-4 img-fluid" src="${data.animes[0].link_capa}" alt="Capa">
                            <p>${data.nome}</p>
                        </div>
                    </a>

                    `);
                }

                
            });




        },
        error: function (xhr, status, error) {
            console.log("Erro de Carregamento", xhr.responseText); // Exibe detalhes sobre o erro no console
        }
    });



});

function getQueryParam(param) {
    var urlParams = new URLSearchParams(window.location.search);
    return urlParams.get(param);
}