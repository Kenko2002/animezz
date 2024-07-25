
function getQueryParam(param) {
    var urlParams = new URLSearchParams(window.location.search);
    return urlParams.get(param);
}



$(document).ready(function (e) {
    $("#username").empty().append(getQueryParam('login'));
    var username = encodeURIComponent(getQueryParam('login'));

    if (username != null) {
        $("#franquias_button").attr("href", "./franquias.html?username=" + username);
        $("#generos_button").attr("href", "./generos.html?username=" + username);
        $("#inicio_button").attr("href", "./index_logado.html?login=" + username);
    }


    callMaisPopulares();
    callAnimesEmLancamento();
    callUltimasVisualizacoes();

    function callMaisPopulares() {
        console.log("carregando animes mais populares");

        $.ajax({
            type: 'GET', // Ou 'GET', dependendo da sua API
            url: 'https://localhost:7298/naologado/GetAllFranquiasMaisVistas',
            contentType: 'application/json',
            dataType: 'json',
            success: function (data) {
                //console.log(data);
                $("#query_mais_populares").empty();
                data.forEach(franquia => {
                    $("#query_mais_populares").append(`<a href="./franquia.html?franquia_nome=${encodeURIComponent(franquia.nome)}&username=${username}"  class="mb-2"><img franquia_nome="${franquia.nome}" class="img-fluid anime_banner" src="${franquia.animes[0].link_capa}" alt="Capa"></a>`);
                });
                console.log("Animes mais populares carregados!");
            },
            error: function (xhr, status, error) {
                console.log("Erro de Carregamento", xhr.responseText); // Exibe detalhes sobre o erro no console
            }
        });
    }

    function callAnimesEmLancamento() {
        console.log("carregando animes em lan�amento");

        $.ajax({
            type: 'GET', // Ou 'GET', dependendo da sua API
            url: 'https://localhost:7298/naologado/GetAnimesUltimosLancamentos',
            contentType: 'application/json',
            dataType: 'json',
            success: function (data) {
                //console.log(data);
                $("#query_animes_em_lancamento").empty();
                data.forEach(anime => {
                    $("#query_animes_em_lancamento").append(`

                                    <a href="./franquia.html?franquia_nome=${encodeURIComponent(anime.franquia.nome)}&username=${username}" class="mb-2">
                                        <div class="inline-block text-center w-80">
                                            <img class='img-fluid' style="max-height:80%" anime_nome="${anime.nome}" src="${anime.link_capa}" alt="lancamento" class="p-2">
                                            <p><small>${anime.nome}</small></p>
                                        </div>
                                    </a>

                    `);
                });
                console.log("Animes em lan�amento carregados!");
            },
            error: function (xhr, status, error) {
                console.log("Erro de Carregamento", xhr.responseText); // Exibe detalhes sobre o erro no console
            }
        });

    }




    function callUltimasVisualizacoes() {
        console.log("carregando ultimasVisualizacoes");

        $.ajax({
            type: 'GET', // Ou 'GET', dependendo da sua API
            url: 'https://localhost:7298/user/UltimasVisualizacoes',
            contentType: 'application/json',
            dataType: 'json',
            success: function (data) {
                console.log(data);
                $("#query_continue_assistindo").empty();


                $("#query_continue_assistindo").append(
                    `
                <script>
                    function goToVideo(nome) {
                                    // Encode the episode name to make it URL-safe
                                    var encodedNome = encodeURIComponent(nome);
                    // Redirect to video.html with the episode name as a query parameter
                    window.location.href = 'video.html?nome=' + encodedNome+"&logado=s&filme=n&username=${username}";
                                }
                </script>
                `);

                data.forEach(episodio => {
                    $("#query_continue_assistindo").append(`

                             <a class="mb-2"   episodio_nome="${episodio.nome}" onclick="goToVideo('${episodio.nome}')">
                                    <div class="inline-block text-center episodio">
                                        <img src="${episodio.link_capa}" alt="lancamento" class="w-80 py-2">
                                        <p>${episodio.nome}<br><small>${episodio.animeNome}</small><br><small>Episódio ${episodio.n_episodio}</small></p>
                                    </div>
                             </a>       

                    `);
                });
                console.log("Ultimas visualizacoes carregadas!");
            },
            error: function (xhr, status, error) {
                console.log("Erro de Carregamento", xhr.responseText); // Exibe detalhes sobre o erro no console
            }
        });

    }

    


});

