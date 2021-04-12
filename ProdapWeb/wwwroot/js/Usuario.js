
$(document).ready(function () {
    atualizaPartialEntarComUsuarioExistente();
});

function atualizaPartialCadastrarUsuario() {

    $.ajax({
        type: 'GET',
        url: 'usuario/cadastar',
        dataType: 'html',
        async: true,
        success: function (data) {
            $('#modalUsuario').html(data);
        }
    });
}

function atualizaPartialEntarComUsuarioExistente() {

    $.ajax({
        type: 'GET',
        url: 'usuario/Entrar',
        dataType: 'html',
        async: true,
        success: function (data) {
            $('#modalUsuario').html(data);
        }
    });
}

