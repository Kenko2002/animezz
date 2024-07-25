$(document).ready( function (e) {

    callMaisPopulares();
    callAnimesEmLancamento();
    callUltimosEpisodiosLancados();


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
                    $("#query_mais_populares").append(`<a href="./franquia.html?franquia_nome=${encodeURIComponent(franquia.nome)}" class="mb-2"><img franquia_nome="${franquia.nome}" class="img-fluid anime_banner" src="${franquia.animes[0].link_capa}" alt="Capa"></a>`);
                });
                console.log("Animes mais populares carregados!");
            },
            error: function (xhr, status, error) {
                console.log("Erro de Carregamento", xhr.responseText); // Exibe detalhes sobre o erro no console
            }
        });
    }

    function callAnimesEmLancamento() {
        console.log("carregando animes em lançamento");

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

                                    <a href="./franquia.html?franquia_nome=${encodeURIComponent(anime.franquia.nome)}" class="mb-2">
                                        <div class="inline-block text-center w-80">
                                            <img class='img-fluid' style="max-height:80%" franquia_nome="${anime.franquia.nome}" anime_nome="${anime.nome}" src="${anime.link_capa}" alt="lancamento" class="p-2">
                                            <p><small>${anime.nome}</small></p>
                                        </div>
                                    </a>

                    `);
                });
                console.log("Animes em lançamento carregados!");
            },
            error: function (xhr, status, error) {
                console.log("Erro de Carregamento", xhr.responseText); // Exibe detalhes sobre o erro no console
            }
        });

    }

    function callUltimosEpisodiosLancados() {
        console.log("carregando últimos episódios lançados");

        $.ajax({
            type: 'GET', // Ou 'GET', dependendo da sua API
            url: 'https://localhost:7298/naologado/GetEpisodiosUltimosLancamentos',
            contentType: 'application/json',
            dataType: 'json',
            success: function (data) {
                console.log(data);
                $("#query_ultimos_episodios").empty();

                $("#query_ultimos_episodios").append(`
                <script>
                    function goToVideo(nome) {
                                    // Encode the episode name to make it URL-safe
                                    var encodedNome = encodeURIComponent(nome);
                    // Redirect to video.html with the episode name as a query parameter
                    window.location.href = 'video.html?nome=' + encodedNome+"&logado=n&filme=n";
                                }
                </script>
                `);

                data.forEach(episodio => {
                    $("#query_ultimos_episodios").append(`

                                <a class="mb-2" style='width:31%;margin-left:1%'  episodio_nome="${episodio.nome}" onclick="goToVideo('${episodio.nome}')" >
                                    <div class="inline-block text-center" style='width:100%'>
                                        <img class='' style="height:100%;width:100%;object-fit:cover" src="${episodio.link_capa}" alt="lancamento" class="w-80 py-2">
                                        <p>${episodio.nome}<br><small>${episodio.animeNome}</small><br><small>Episodio ${episodio.n_episodio}</small></p>
                                    </div>
                                </a>

                                
                    `);
                    
                });
                console.log("Últimos Episódios carregados!");
            },
            error: function (xhr, status, error) {
                console.log("Erro de Carregamento", xhr.responseText); // Exibe detalhes sobre o erro no console
            }
        });

    }


});

