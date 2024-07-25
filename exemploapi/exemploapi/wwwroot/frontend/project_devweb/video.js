$(document).ready(function (e) {

    // Obter o nome do episódio da URL
    var filme = getQueryParam('filme');
    var username = getQueryParam('username');

    if (filme == "s") {
        $("#input_comentario").css("display", "none");
        $("#button_comentario").css("display", "none");
        $("#previous_episode").css("display", "none");
        $("#next_episode").css("display", "none");
        $("#div_comentarios").css("display", "none");
        $("#comment_span").css("display", "none");
    }

    var episodeName = getQueryParam('nome');
    var eh_logado = getQueryParam('logado');

    if (eh_logado == 's') {
        $("#login-button").css("display", "none");
        $("#cadastro-button").css("display", "none");
        $("#inicio_button").attr("href", 'index_logado.html?login=' + encodeURIComponent(username));
        $("#generos_button").attr("href", './generos.html?username=' + encodeURIComponent(username));
        $("#franquias_button").attr("href", './franquias.html?username=' + encodeURIComponent(username));
    }

    var episodeAnimeName = "";
    var num_episode = 0;
    

    /* EM ULTIMO CASO, ABRA O VIDEO EM UM POP UP

    $('#video_source').on('click', function (event) {
        event.preventDefault(); // Previne a ação padrão do vídeo (play/pause)
        var videoSrc = $(this).attr('src');
        window.open(videoSrc, "_blank", "popup=yes,width=600,height=400");
    });*/

    if (filme == "s") {
        callFilme();
    }
    if (filme == "n") {
        callComentarios();
        console.log("Nome do Episódio: " + episodeName);
    }


    //apenas usuários logados podem fazer comentários.
    if (eh_logado == 'n') {
        $("#input_comentario").css("display", "none");
        $("#button_comentario").css("display", "none");
    }
    if (eh_logado == 's') {
        console.log("Criando visualização..."); //Anotando a visualização:
        $.ajax({
            type: 'POST',
            url: 'https://localhost:7298/user/CreateVisualizacao',
            contentType: 'application/json',
            dataType: 'json',
            data: JSON.stringify({
                "nome": episodeName,
                "sinopse": "string",
                "link_src": "string",
                "n_episodio": 0,
                "views": 0,
                "data_insercao": "2024-06-24T05:30:20.016Z",
                "link_capa": "string",
                "anime_nome": "string"
            }),
            success: function (data) {
                console.log(data);
            },
            error: function (xhr, status, error) {
                console.log("Erro na criação de visualização", xhr.responseText);
            }
        });
    }
    
   
    


    $('#next_episode').click(function () {
        $.ajax({
            type: 'GET',
            url: 'https://localhost:7298/naologado/GetNextAnimeEpisode?n_episodio=' + encodeURIComponent(num_episode) + "&anime_nome=" + encodeURIComponent(episodeAnimeName),
            contentType: 'application/json',
            dataType: 'json',
            success: function (data) {
                var encodedNome = encodeURIComponent(data.episodio.nome);
                window.location.href = 'video.html?nome=' + encodedNome + '&filme=n' + '&logado=' + eh_logado;
            },
            error: function (xhr, status, error) {
                console.log("Erro de Carregamento", xhr.responseText); // Exibe detalhes sobre o erro no console
            }
        });
    });

    $('#previous_episode').click(function () {
        $.ajax({
            type: 'GET',
            url: 'https://localhost:7298/naologado/GetPreviousAnimeEpisode?n_episodio=' + encodeURIComponent(num_episode) + "&anime_nome=" + encodeURIComponent(episodeAnimeName),
            contentType: 'application/json',
            dataType: 'json',
            success: function (data) {
                var encodedNome = encodeURIComponent(data.episodio.nome);
                window.location.href = 'video.html?nome=' + encodedNome + '&filme=n' + '&logado=' + eh_logado;
            },
            error: function (xhr, status, error) {
                console.log("Erro de Carregamento", xhr.responseText); // Exibe detalhes sobre o erro no console
            }
        });
    });

    $('#button_comentario').click(function () {
        $.ajax({
            type: 'POST',
            url: 'https://localhost:7298/user/CreateComentario',
            contentType: 'application/json',
            dataType: 'json',
            data: JSON.stringify({
                "episodio_nome": episodeName,
                "texto": $("#input_comentario").val()
            }),
            success: function (data) {
                console.log("Criando comentário...");
                console.log(data);
                console.log("Comentário criado!");
                callComentarios();
            },
            error: function (xhr, status, error) {
                console.log("Erro na criação de visualização", xhr.responseText);
            }
        });
    });


    function getQueryParam(param) {
        var urlParams = new URLSearchParams(window.location.search);
        return urlParams.get(param);
    }

    function callComentarios() {
        $.ajax({
            type: 'GET',
            url: 'https://localhost:7298/naologado/GetByNameEpisodio?episodio_nome=' + encodeURIComponent(episodeName),
            contentType: 'application/json',
            dataType: 'json',
            success: function (data) {
                console.log(data);
                $("#video_source").attr("src", data.link_src);

                $("#episode_name").empty();
                $("#episode_name").append("<p>" + data.nome + "<br><small>" + data.anime.nome + " Ep: " + data.n_episodio + "</small>" + "</p>");

                episodeAnimeName = data.anime.nome;
                num_episode = data.n_episodio;

                $("#div_comentarios").empty();
                data.comentarios.forEach(comentario => {
                    $("#div_comentarios").append(
                        `<div>
                            <img src="${comentario.usuario.link_foto_perfil}" alt="Logo" style="height: 50px; width: 50px; padding: 5px;" class="rounded float-left">
                            <p><strong>${comentario.usuario.login}</strong>  <br> ${comentario.texto}</p>
                        </div>`
                    );
                });



                if (eh_logado == 's') {
                    var dataToSend = {
                        nome: episodeName
                    };

                    $.ajax({
                        type: 'POST',
                        url: 'https://localhost:7298/user/CreateVisualizacao',
                        contentType: 'application/json',
                        dataType: 'json',
                        data: JSON.stringify(dataToSend), // Converte o objeto JavaScript para JSON
                        success: function (data) {
                            console.log(data);
                        },
                        error: function (xhr, status, error) {
                            console.log("Erro de Carregamento", xhr.responseText); // Exibe detalhes sobre o erro no console
                        }
                    });
                }

                




            },
            error: function (xhr, status, error) {
                console.log("Erro de Carregamento", xhr.responseText); // Exibe detalhes sobre o erro no console
                
            }
        });
    }

    function callFilme() {
        $.ajax({
            type: 'GET',
            url: 'https://localhost:7298/naologado/GetByNameFilme?filme_nome=' + encodeURIComponent(episodeName),
            contentType: 'application/json',
            dataType: 'json',
            success: function (data) {
                console.log(data);
                
                $("#video_source").attr("src", data.link_src);

                $("#episode_name").empty();
                $("#episode_name").append("<p>" + data.nome +"</p>");
                
            },
            error: function (xhr, status, error) {
                console.log("Erro de Carregamento", xhr.responseText); // Exibe detalhes sobre o erro no console

            }
        });
    }

});