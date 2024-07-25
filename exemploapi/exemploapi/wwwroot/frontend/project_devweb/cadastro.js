$(document).on('click', '#botao_cadastrar', function (e) {
    var user = $('#usuario').val();
    var email = $('#email').val();

    var senha = $('#senha').val();
    var senha_confirmacao = $('#confirmacao').val();

    if (senha != senha_confirmacao) {
        console.log("Senhas diferentes!")
    }
    
    $.ajax({
        type: 'POST',
        url: 'https://localhost:7298/naologado/Registrar',
        contentType: 'application/json', // Define o tipo de conteúdo enviado
        dataType: 'json', // Define o tipo de conteúdo esperado na resposta
        data: JSON.stringify({
            "login": user,
            "senha": senha,
            "link_foto_perfil": "https://img.freepik.com/vetores-premium/avatar-de-homem-barbudo-foto-generica-de-perfil-masculino_53562-20202.jpg"
        }),
        success: function (data) {
            console.log(data);

            if (data.hasOwnProperty('user_Id')) { //verificando se o usuário foi logado e o cadastro realizado com sucesso.
                window.location.reload;
            }
        },
        error: function (e) {
            console.log("Erro de Cadastro", e);
        }
    });



});