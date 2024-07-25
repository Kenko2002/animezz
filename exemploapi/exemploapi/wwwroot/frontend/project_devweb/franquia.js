$(document).ready(function (e) {
    var franquiaName = getQueryParam('franquia_nome');
    var franquia_objeto = 0;
    callInformacoes(franquiaName);

    var username =getQueryParam('username');

    if (username != null) {
        console.log(username);
        $("#login-button").css("display", "none");
        $("#cadastro-button").css("display", "none");

        $("#inicio_button").attr("href", 'index_logado.html?login=' + encodeURIComponent(username));
        $("#generos_button").attr("href", "./generos.html?username=" + username);
        $("#franquias_button").attr("href", "./franquias.html?username=" + username);
    }


    function callInformacoes(franquiaName) {
        var url = 'https://localhost:7298/naologado/GetByNameFranquia?franquia_nome=' + encodeURIComponent(franquiaName);
        $.ajax({
            type: 'GET',
            url: url,
            contentType: 'application/json',
            dataType: 'json',
            success: function (data) {
                console.log("Carregando Informações da Franquia...");
                console.log(data);
                franquia_objeto = data;
                $("#franquia_descricao").text(data.sinopse);
                $("#franquia_capa").attr("src", data.animes[0].link_capa);
                $("#franquia_nome").text(data.nome);

                $("#query_generos").empty();
                data.generos.forEach(genero => {
                    $("#query_generos").append(`<a href='./pesquisa.html?query=${encodeURIComponent(genero.nome)}' class="p-2 m-2 bg-dark btn-genero text-light rounded">${genero.nome}</a>`);      
                });


                $("#select_animes").empty();
                data.animes.forEach(anime => {
                    $("#select_animes").append('<option class="anime_selector_option" tipo="anime" nome="' + anime.nome + '">' + anime.nome + '</option>');
                });
                $("#select_animes").append('<option class="anime_selector_option" tipo="filmes"> Filmes </option>');
                $("#query_videos").empty();
                data.animes[0].episodios.forEach(episodio => {
                    if (username != null) {
                        $("#query_videos").append(`
                        <a class="mb-2" onclick="window.location.href='video.html?nome=${episodio.nome}&logado=s&filme=n&username=${encodeURIComponent(username)}'">
                            <div class="inline-block text-center">
                                <img src="${episodio.link_capa}" alt="lancamento" class="w-80 py-2">
                                    <p>${episodio.nome}<br><small>Episodio ${episodio.n_episodio}</small></p>
                            </div>
                        </a>
                    `);
                    } else {
                        $("#query_videos").append(`
                        <a class="mb-2" onclick="window.location.href='video.html?nome=${episodio.nome}&logado=n&filme=n'">
                            <div class="inline-block text-center">
                                <img src="${episodio.link_capa}" alt="lancamento" class="w-80 py-2">
                                    <p>${episodio.nome}<br><small>Episodio ${episodio.n_episodio}</small></p>
                            </div>
                        </a>
                    `);
                    }
                    
                });
                
                



                console.log("Informações de franquia carregadas!");
            },
            error: function (xhr, status, error) {
                console.log("Erro no carregamento da Franquia", xhr.responseText);
            }
        });
    }



    
    $("#select_animes").change(function () {
        var selectedOption = $(this).find('option:selected');
        if (selectedOption.attr("tipo") == "anime") {
            $.ajax({
                type: 'GET',
                url: 'https://localhost:7298/naologado/GetEpisodiosByAnimeName?anime_nome=' + encodeURIComponent($(this).val()),
                contentType: 'application/json',
                dataType: 'json',
                success: function (data) {
                    console.log("Carregando dados do Anime...");
                    console.log(data);
                    console.log("Dados carregados!");
                    $("#query_videos").empty();
                    data.forEach(episodio => {
                        $("#query_videos").append(`
                    <a class="mb-2" onclick="window.location.href='video.html?nome=${episodio.nome}&logado=n&filme=n&username=${encodeURIComponent(username)}'">
                        <div class="inline-block text-center">
                            <img src="${episodio.link_capa}" alt="lancamento" class="w-80 py-2">
                            <p>${episodio.nome}<br><small>Episodio ${episodio.n_episodio}</small></p>
                        </div>
                    </a>
                    `);
                    });
                },
                error: function (xhr, status, error) {
                    console.log("Erro de Carregamento", xhr.responseText); // Exibe detalhes sobre o erro no console
                }
            });
        }
        if (selectedOption.attr("tipo") == "filmes") {
            $("#query_videos").empty();
            franquia_objeto.filmes.forEach(filme => {
                $("#query_videos").append(`
                        <a class="mb-2" onclick="window.location.href='video.html?nome=${filme.nome}&logado=n&filme=s&username=${encodeURIComponent(username)}'">
                            <div class="inline-block text-center">
                                <img src="${filme.link_capa}" alt="lancamento" class="w-80 py-2">
                                    <p>${filme.nome}</p>
                            </div>
                        </a>
                    `);
            });
        }
    });




});

function getQueryParam(param) {
    var urlParams = new URLSearchParams(window.location.search);
    return urlParams.get(param);
}

