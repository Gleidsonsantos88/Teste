$(document).ready(function () {
    atualizaPartialTarefaUsuario();
});

function atualizaPartialTarefaUsuario() {

    $.ajax({
        type: 'GET',
        url: 'tarefa/PartialViewTarefa',
        dataType: 'html',
        async: true,
        success: function (data) {
            $('#modalTarefa').html(data);
        }
    });
}

