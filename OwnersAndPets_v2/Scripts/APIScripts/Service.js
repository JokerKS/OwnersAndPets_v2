app.service("APIService", function ($http) {
    var urlBase = window.location.protocol + '/api/';

    this.getOwnersAndPetsCount = function (pageIndex, pageSizeSelected) {
        return $http.get(urlBase + "OwnersAndPets" + "?pageIndex=" + pageIndex + "&pageSize=" + pageSizeSelected)
    }
    this.addOwner = function (ownerName) {
        return $http(
        {
            method: 'post',
            data: '"' + ownerName + '"',
            url: urlBase + 'OwnersAndPets'
        });
    };
    this.removeOwner = function (ownerId) {
        return $http({
            method: "delete",
            url: urlBase + 'OwnersAndPets/' + ownerId
        });
    }

    this.getPets = function (ownerId, pageIndex, pageSizeSelected) {
        return $http.get(urlBase + "Pets?ownerId=" + ownerId + "&pageIndex=" + pageIndex + "&pageSize=" + pageSizeSelected)
    }
    this.addPet = function (ownerId, petName) {
        return $http(
        {
            method: 'post',
            data: '"' + petName + '"',
            url: urlBase + 'Pets?ownerId=' + ownerId
        });
    };
    this.removePet = function (petId) {
        return $http({
            method: "delete",
            url: urlBase + 'Pets/' + petId
        });
    }
});