//criando um programa baseado em angular..
var app = angular.module('appLivro', []);

app.controller('cadastroController', function ($scope, $http) {

    //modelo de dados que será enviado para a API..
    $scope.livro = {
        ISBN: "",
        Autor: "",
        Nome: "",
        Preco: "",
        DtPublicacao: "",
        ImagemCapa: ""
    };

    //função cadastrar
    $scope.cadastrar = function () {
        $scope.mensagem = "Enviando requisição, por favor aguarde.";
        //Post               
        $http.post('http://localhost:63515//api/livro/cadastrar', $scope.livro)
            .then(function (d) { //sucesso..
                $scope.mensagem = d.data; //mensagem do serviço..
                $scope.livro.ISBN = "";
                $scope.livro.Autor = "";
                $scope.livro.Nome = "";
                $scope.livro.Preco = "0";
                $scope.livro.DtPublicacao = "";
                $scope.livro.ImagemCapa = "";
                //limpar os campos..
                $scope.livro = {};
            })
            .catch(function (e) {
                $scope.mensagem = e.data; //mensagem de erro.
            });
    };

});       