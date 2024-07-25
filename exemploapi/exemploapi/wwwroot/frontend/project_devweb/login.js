$(document).on('click', '#botao_login', function (e) {
    var user = $('#user').val();
    var senha = $('#senha').val();

    var url = `https://localhost:7298/naologado/Login?login=${encodeURIComponent(user)}&senha=${encodeURIComponent(senha)}`;

    // Faça a requisição AJAX usando GET (se for o caso) ou POST, conforme sua API requer
    $.ajax({
        type: 'POST', // Ou 'GET', dependendo da sua API
        url: url,
        contentType: 'application/json',
        dataType: 'json',
        success: function (data) {
            console.log(data); // Verifique o que está sendo retornado pelo servidor
            
            if (data.hasOwnProperty('user_Id')) {    //verificando se o usuário foi logado.
                var encoded_login = encodeURIComponent(user);
                var encoded_senha = encodeURIComponent(senha);
                window.location.href = 'index_logado.html?login=' + encoded_login;
            } 
        },
        error: function (xhr, status, error) {
            console.log("Erro de Login", xhr.responseText); // Exibe detalhes sobre o erro no console
        }
    });




});