app.controller('HomeCtrl', function ($scope, APIService) {
    $scope.maxSize = 3;     // Limit number for pagination display number.  
    $scope.totalCount = 0;  // Total number of items in all pages. initialize as a zero  
    $scope.pageIndex = 1;   // Current page number. First page is 1.-->  

    $scope.pageSizeSelectedOptions = [3,5,7];
    $scope.pageSizeSelected = $scope.pageSizeSelectedOptions[0];

    getOwnersAndPetsCount($scope, APIService);

    $scope.numPages = Math.ceil($scope.totalCount / $scope.pageSizeSelected);

    $scope.addOwner = function () {
        APIService.addOwner($scope.ownerName)
            .then(function (response) {
                alert("Owner added");
                $scope.ownerName = undefined;
                getOwnersAndPetsCount($scope, APIService);
            })
            .catch(function onError(response) {
                $scope.status = 'Not possible to add the owner: ' + response.status;
            });
    };

    $scope.removeOwner = function (id) {
        APIService.removeOwner(id)
            .then(function (response) {
                alert("Owner deleted");
                getOwnersAndPetsCount($scope, APIService);
            })
            .catch(function onError(response) {
                $scope.status = 'Not possible to remove the owner: ' + response.status;
            });
    }

    $scope.pageChanged = function () {
        getOwnersAndPetsCount($scope, APIService);
    };

    $scope.changePageSize = function () {
        $scope.pageIndex = 1;
        getOwnersAndPetsCount($scope, APIService);
    };
});

function getOwnersAndPetsCount($scope, APIService) {
    APIService.getOwnersAndPetsCount($scope.pageIndex, $scope.pageSizeSelected)
        .then(function (response) {
            $scope.owners = response.data.OwnersWithPetsCount;
            $scope.totalCount = response.data.TotalCount;
        })
        .catch(function onError(response) {
            $scope.status = 'Unable to load owners data: ' + response.status;
        });
}


app.controller('OwnerCtrl', function ($scope, APIService) {
    $scope.maxSize = 3;     // Limit number for pagination display number.  
    $scope.totalCount = 0;  // Total number of items in all pages. initialize as a zero  
    $scope.pageIndex = 1;   // Current page number. First page is 1.-->  

    $scope.pageSizeSelectedOptions = [3, 5, 7];
    $scope.pageSizeSelected = $scope.pageSizeSelectedOptions[0];

    $scope.ownerId = document.getElementById('ownerId').value;

    getPets($scope, APIService);

    $scope.numPages = Math.ceil($scope.totalCount / $scope.pageSizeSelected);

    $scope.addPet = function () {
        APIService.addPet($scope.ownerId, $scope.petName)
            .then(function (response) {
                alert("Pet added");
                $scope.petName = undefined;
                getPets($scope, APIService);
            })
            .catch(function onError(response) {
                $scope.status = 'Not possible to add the pet: ' + response.status;
            });
    };


    $scope.removePet = function (id) {
        APIService.removePet(id)
            .then(function (response) {
                alert("Pet deleted");
                getPets($scope, APIService);
            })
            .catch(function onError(response) {
                $scope.status = 'Not possible to remove the pet: ' + response.status;
            });
    }

    $scope.pageChanged = function () {
        getPets($scope, APIService);
    };

    $scope.changePageSize = function () {
        $scope.pageIndex = 1;
        getPets($scope, APIService);
    };
});

function getPets($scope, APIService) {
    APIService.getPets($scope.ownerId, $scope.pageIndex, $scope.pageSizeSelected)
        .then(function (response) {
            $scope.pets = response.data.Pets;
            $scope.ownerName = response.data.OwnerName;
            $scope.totalCount = response.data.TotalCount;
        })
        .catch(function onError(response) {
            $scope.status = 'Unable to load pets data: ' + response.status;
        });
}