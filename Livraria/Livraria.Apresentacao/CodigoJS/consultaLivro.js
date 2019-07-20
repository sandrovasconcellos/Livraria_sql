var app = angular.module('appLivro', [])
app.controller('consultaController', function ($scope, $http) {

    //funão para consultar todos
    $scope.consultar = function () {
        //GET
        $http.get('http://localhost:63515//api/livro/consultartodos')
            .then(function (d) { //sucesso..
                //armazenar em scope os dados retornados pela consulta..
                $scope.livros = d.data;
            })
            .catch(function (e) { //erro..
                $scope.mensagem = e.data; //mensagem de erro..
            });
    }

    //função consultar por ISBN
    $scope.consultarporisbn = function (isbn) {
        //GET 
        $http.get('http://localhost:63515//api/livro/consultarporisbn?isbn=' + isbn)
            .then(function (d) {
                $scope.livro = d.data; //obtend o registro pelo id..
            })
            .catch(function (e) {
                $scope.mensagem = e.data;
            });
    };

    //função para exclusao
    $scope.excluir = function (isbn) {
        //DELETE
        $http.delete('http://localhost:63515//api/livro/excluir?isbn=' + isbn)
            .then(function () {
                $scope.mensagem = "Livro excluido com sucesso.";
                $scope.consultar(); //executando a consulta..
            })
            .catch(function (e) {
                $scope.mensagem = e.data;
            });
    }

    //função para atualizar
    $scope.atualizar = function () {
        //PUT
        $http.put('http://localhost:63515//api/livro/atualizar', $scope.livro)
            .then(function () {
                $scope.mensagem = "Livro atualizado com sucesso.";
                $scope.consultar(); //executando a consulta..
            })
            .catch(function (e) {
                $scope.mensagem = e.data;
            });
    }
});