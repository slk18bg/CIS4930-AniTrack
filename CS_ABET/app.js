var app = angular.module("AnimeTracker", ["ngRoute"]);
app.controller('mainCtrl', function ($scope, $http) {
    $http({
        method: 'GET',
        url: 'api/Genre/Get'
    }).then(function success(response) {
        $scope.genres = response.data;
    }, function failure() {

    });

    $scope.selectGenre = function (genre) {
        $scope.addingGenre = false;
        $scope.editingGenre = false; // added this
        $scope.editingTitle = false; // added this
        $scope.selectedTitle = undefined;
        $scope.selectedGenre = genre;

        $http({
            method: 'GET',
            url: 'api/Title/Get/' + $scope.selectedGenre.Id
        }).then(
            function success(response) {
                $scope.titles = response.data;
            }, function failure() {}
        );

    }

    $scope.selectTitle = function (cl) {
        $scope.addingTitle = false;
        $scope.selectedTitle = cl;
        $scope.editingTitle = false; // added this
    }

    $scope.showNewTitle = function () {
        $scope.cancelEditTitle();
        $scope.addingTitle = true;
        $scope.selectedTitle = new Object();
        
    }

    $scope.showEditTitle = function (cl) {
        $scope.cancelAddTitle();
        $scope.selectedTitle = cl;
        $scope.selectedEditingTitle = angular.copy(cl);
        $scope.editingTitle = true;

    }

    $scope.addTitle = function () {
        $scope.selectedTitle.GenreId = $scope.selectedGenre.Id;

        $http({
            method: 'POST',
            url: 'api/Title/AddOrUpdate',
            data: $scope.selectedTitle
        }).then(function success(response) {
            $scope.titles.push(response.data);
        }, function failure() {

        });

        $scope.selectedTitle = undefined;
        $scope.addingTitle = false;
    }

    $scope.updateTitle = function () {

        $scope.selectedTitle.TitleName = $scope.selectedEditingTitle.TitleName;
        $scope.selectedTitle.Episodes = $scope.selectedEditingTitle.Episodes;
        $scope.selectedTitle.YearReleased = $scope.selectedEditingTitle.YearReleased;
        $scope.selectedTitle.AverageRating = $scope.selectedEditingTitle.AverageRating; // added this

        $http({
            method: 'POST',
            url: 'api/Title/AddOrUpdate',
            data: $scope.selectedEditingTitle
        }).then(function success(response) {

        }, function failure() {

        });

        $scope.selectedTitle = undefined;
        $scope.selectedEditingTitle = undefined;
        $scope.editingTitle = false;
    }


    $scope.cancelAddTitle = function () {
        $scope.selectedTitle = undefined;
        $scope.addingTitle = false;
    }

    $scope.cancelEditTitle = function () {
        $scope.selectedTitle = undefined;
        $scope.selectedEditingTitle = undefined;
        $scope.editingTitle = false;
    }

    $scope.showNewGenre = function () {
        $scope.cancelEditGenre();
        $scope.selectedGenre = undefined;
        $scope.addingGenre = true;
    }

    $scope.showEditGenre = function (genre) {
        $scope.cancelAddGenre();
        $scope.selectedGenre = genre;
        $scope.selectedEditingGenre = angular.copy(genre);
        $scope.editingGenre = true;
     
    }


    $scope.addGenre = function () {

            $http({
                method: 'POST',
                url: 'api/Genre/AddOrUpdate',
                data: $scope.selectedGenre
            }).then(function success(response) {
                $scope.genres.push(response.data);
            }, function failure() {

            });

        $scope.selectedGenre = undefined;
        $scope.addingGenre = false;
    }

    $scope.updateGenre = function () {

        $scope.selectedGenre.Name = $scope.selectedEditingGenre.Name;

        $http({
            method: 'POST',
            url: 'api/Genre/AddOrUpdate',
            data: $scope.selectedEditingGenre
        }).then(function success(response) {

        }, function failure() {

        });

        $scope.selectedGenre = undefined;
        $scope.selectedEditingGenre = undefined;
        $scope.editingGenre = false;
    }
  
    $scope.cancelAddGenre = function () {
        $scope.selectedGenre = undefined;
        $scope.addingGenre = false;
    }

    $scope.cancelEditGenre = function () {
        $scope.selectedGenre = undefined;
        $scope.selectedEditingGenre = undefined;
        $scope.editingGenre = false;
    }

    $scope.removeGenre = function (id) {

        $http({
            method: 'GET',
            url: 'api/Genre/RemoveById/' + id
        }).then(function success() {
            var indexToDelete = -1;
            for (i = 0; i < $scope.genres.length; i++) {
                if ($scope.genres[i].Id === id) {
                    indexToDelete = i;
                    break;
                }
            }
            if (indexToDelete >= 0) {
                $scope.genres.splice(indexToDelete, 1);
            }

            if (id === $scope.selectedGenre.Id) {
                $scope.editingGenre = false; // added
                $scope.selectedGenre = undefined;
            }
        }, function failure() {

        });

       
    }

    $scope.removeTitle = function (id) {

        $http({
            method: 'GET',
            url: 'api/Title/Remove/' + id
        }).then(
            function success() {
                var indexToDelete = -1;
                for (i = 0; i < $scope.titles.length; i++) {
                    if ($scope.titles[i].Id === id) {
                        indexToDelete = i;
                        break;
                    }
                }
                if (indexToDelete >= 0) {
                    $scope.titles.splice(indexToDelete, 1);
                }

                if ($scope.selectedTitle !== undefined && $scope.selectedTitle.Id == id) {
                    $scope.editingTitle = false; // added this
                    $scope.selectedTitle = undefined;
                }
            }, function failure() {

            });

    }



});
