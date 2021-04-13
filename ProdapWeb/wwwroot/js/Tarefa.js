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
};

function SalvarEdicaoTarefa(id, usuarioId) {


    if ($('#DescricaoTarefaEdicao').val() != '') {

        var data = {

            'Id' : id,
            'Descricao' : $('#DescricaoTarefaEdicao').val(),
            'UsuarioId' : usuarioId,
            'Situacao'  : 1
        };

        $.ajax({
            type: 'POST',
            url: 'tarefa/SalvarEdicaoTarefa',
            data: data,
            async: true,
            success: function (data) {

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
        });

        $("#mensagemDeErro").text("");
    }
    else {

        $("#mensagemDeErro").text("*Informe a descrição da tarefa");
    }  
}


function CancelaEdicao(id, usuarioId) {


    var confirma = confirm("Deseja realmente cancelar a edição da tarefa?");

    if (confirma == true) {

        var data = {

            'Id': id,
            'Descricao': $('#DescricaoTarefaEdicao').val(),
            'UsuarioId': usuarioId,
            'Situacao': 1
        };

        $.ajax({
            type: 'POST',
            url: 'tarefa/CancelaEdicaoTarefa',
            data: data,
            async: true,
            success: function (data) {

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
        });

    }
}

function ConcluirTarefaAFazer(id, usuarioId) {


    var confirma = confirm("Confirma a conclusão da tarefa?");

    if (confirma == true) {

        var data = {

            'Id': id,
            'Descricao': $("#label_" + id).text(),
            'UsuarioId': usuarioId,
            'Situacao': 2
        };

        $.ajax({
            type: 'POST',
            url: 'tarefa/ConcluirTarefaAFazer',
            data: data,
            async: true,
            success: function (data) {

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
        });

    }
}



function RemoverTarefa(id) {


    var confirma = confirm("Confirma a exclusão da tarefa?");

    if (confirma == true) {

        var data = {

            'Id': id
        };

        $.ajax({
            type: 'DELETE',
            url: 'tarefa/RemoverTarefa',
            data: data,
            async: false,
            success: function (data) {
            }
        });

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
}

function CriarTarefa() {
    


    if ($('#DescricaoTarefa').val() != '') {

        var data = {
            'Descricao': $('#DescricaoTarefa').val()
        };

        $.ajax({
            type: 'POST',
            url: 'tarefa/CriarTarefa',
            data: data,
            async: true,
            success: function (data) {

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
        });

        $("#mensagemDeErro").text("");
    }
    else
    {
        $("#mensagemDeErro").text("*Informe a descrição da tarefa");
    }  
} 



function ColocarTarefaEmEdicao(id, usuarioId) {

    var data = {

        'Id': id,
        'Descricao': $("#label_" + id).text(),
        'UsuarioId': usuarioId,
        'Situacao': 3
    };

    $.ajax({
        type: 'POST',
        url: 'tarefa/SalvarEdicaoTarefa',
        data: data,
        async: true,
        success: function (data) {

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
    });
   
}